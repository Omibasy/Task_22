using Microsoft.AspNetCore.Mvc;
using Task_22.Model.Data;
using Task_22.Model.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Web;
using static System.Net.WebRequestMethods;


namespace Task_22.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IPhoneBook phoneBook;

        public HomeController(IWebHostEnvironment appEnvironment, IPhoneBook book)
        {
            _appEnvironment = appEnvironment;

            phoneBook = book;

        }


        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Person = phoneBook.GetPersonalities();

            return View();
        }

        [HttpGet]    
        public async Task<IActionResult> Info(int id)
        {

            ViewBag.Data = (await phoneBook.GetPersonalities(id),
                            await phoneBook.GetPersonalData(id),
                            GetPathPhoto(id));

            return View();
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteView()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "user, admin")]
       
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public IActionResult UploadingNewData(Person person,
                                            PersonalData personalData, IFormFile file)
        {
            try
            {
                phoneBook.AddingNewData(person, personalData, file, _appEnvironment);

                return Redirect("~/");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public IActionResult DeleteRecord(int id)
        {
            try
            {
                return Ok(phoneBook.DeleteAnEntry(id, _appEnvironment));
            }
            catch (Exception)
            {
                return NotFound();

            }
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DataChangesView(int id)
        {
            try
            {
                PersonalData personalData = await phoneBook.GetPersonalData(id);

                personalData.PhoneNumber = personalData.PhoneNumber.Replace("8", string.Empty);
                personalData.PhoneNumber = personalData.PhoneNumber.Replace("-", string.Empty);

                ViewBag.Data = (await phoneBook.GetPersonalities(id), personalData);

                return View();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult ChangePhotoView(int id)
        {

            ViewBag.Data = (id, GetPathPhoto(id));


            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult ChangePhoto(int id, IFormFile file)
        {

            try
            {
                phoneBook.EditPhoto(id, file, _appEnvironment);

       

                return Redirect($"~/Home/Info?id={id}");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }


        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public IActionResult DataChangesView(Person person, PersonalData personalData)
        {
            try
            {
                var result = phoneBook.DataChanges(person, personalData);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private string GetPathPhoto(int id)
        {
            string pathFolder = _appEnvironment.WebRootPath + "\\card";

            string[] path = Directory.GetFiles(pathFolder);

            string[] str = FaindPhoto(path, id);
            if (str == null)
            {

                return "https://localhost:7248/card/photoDefault.jpg";
            }
            else
            {

                return "https://localhost:7248/" + str[str.Length - 2] + "/" + str[str.Length - 1];
            }
        }

        private string[] FaindPhoto(string[] path, int id)
        {
            string strId = id.ToString();
            int valueId = 0;

            for (int i = 0; i < path.Length; i++)
            {
                string[] value = path[i].Split('_');

                valueId = value.Length - 1;

                value = value[valueId].Split('.');

                if (value[0] == strId)
                {
                    return path[i].Split('\\');
                }
            }
            return null;
        }
    }
}

