using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Task_22.Model;
using Web_Task_22.Model.Data;
using Web_Task_22.Model.Data.Source;

namespace Web_Task_22.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }

        [HttpGet]
        public  async Task<IActionResult> Index()
        {
            return await Task.Factory.StartNew(() => 
            {

                var value = PhoneBoockDataAPI.GetPersons();

                if (value == null)
                {
                    List<Person>  people = new List<Person>();

                    people.Add(new Person()
                    {
                        ID = 0,
                        Name = "Нет данных",
                        Surname = "Нет данных",
                        Patomic = "Нет данных"
                    });

                    value = people;
                }
                else
                {
                    ViewBag.Person = value;
                }

                ViewBag.Person = value;

                return View();
            });

        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                if (id == 0)
                {

                    BoxPerson boxPerson = new BoxPerson()
                    {
                        Data = new PersonalData
                        {
                            ID = 0,
                            Address = "Нет данных",
                            Description = "Нет данных",
                            PhoneNumber = "Нет данных",
                            PersonID = new Person()
                            {
                                ID = 0,
                                Name = "Нет данных",
                                Surname = "Нет данных",
                                Patomic = "Нет данных"
                            }
                        }
                    };

                    ViewBag.Data = boxPerson;
                }
                else
                {
                    ViewBag.Data = PhoneBoockDataAPI.GetPersonsInfo(id);
                }
        
                return View();
                

            });
        }


        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> Add()
        {
            return await Task.Factory.StartNew(() =>
            {
      
                return View();
            });
        }

        [HttpPost]
        [Authorize(Roles = "user, admin")]
        public IActionResult UploadingNewData(Person _person,
                                    PersonalData _personalData, IFormFile file)
        {
            try
            {
                _personalData.PhoneNumber = EditingPhoneNumber(_personalData.PhoneNumber);

                PackagePerson personPackage = new PackagePerson()
                {
                    personalData = _personalData,
                    person = _person,
                    DataPhoto = GetFile(file)
                };

                PhoneBoockDataAPI.SendBox(personPackage);


                return Redirect("~/");
            }
            catch (Exception)
            {

                return NotFound();
            }
         
        }

        private byte[] GetFile(IFormFile photo) 
        {
                
            byte[] bytes;
            using (var file = photo.OpenReadStream())
            {
                bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
            }

            return bytes;
        }

        private string EditingPhoneNumber(string phoneNumder )
        {

            phoneNumder = phoneNumder.Replace("(", string.Empty)
                                     .Replace(")", string.Empty)
                                     .Replace(" ", "-");
            phoneNumder = "8" + phoneNumder.Remove(0, 2);

            return phoneNumder;
        }
    }
}
