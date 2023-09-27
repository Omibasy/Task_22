using Api_Task_22.Model;
using Api_Task_22.Model.Data;
using Api_Task_22.Model.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Task_22.Controllers
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
        [Route("GetRange")]
        public async Task<IEnumerable<IPersone>> Get()
        {
            return await Task.Factory.StartNew(() => phoneBook.GetPersonalities().ToList());     
        }

        [HttpGet]
        [Route("GetInfo/{id}")]
        public async Task<BoxPerson> Info(int id)
        {

            BoxPerson person = new BoxPerson()
            {
                Data = await phoneBook.GetPersonalData(id),
                HepfImg = GetPathPhoto(id)
            };

            return person;   
        }


        [HttpPost]
        [Authorize(Roles = "admin, user")]
        [Route("AddPerson")]
        public async Task<string> AddPerson([FromBody]PackagePerson package)
        {
           return  await  phoneBook.AddingNewData(package, _appEnvironment);
        }





        private string GetPathPhoto(int id)
        {
            string pathFolder = _appEnvironment.WebRootPath + "\\Photo";

            string[] path = Directory.GetFiles(pathFolder);

            string[] str = FaindPhoto(path, id);

            if (str == null)
            {
                return $"/Photo/photoDefault.jpg";
            }
            else
            {
                return $"/" + str[str.Length - 2] + "/" + str[str.Length - 1];
            }
        }

        private string[] FaindPhoto(string[] path, int id)
        {
            string strId = id.ToString();
            int valueId = 0;

            for (int i = 0; i < path.Length; i++)
            {
                string[] value =  path[i].Split('_');

                valueId = value.Length - 1;

                value =  value[valueId].Split('.');

                if (value[0] == strId)
                {
                    return path[i].Split('\\');
                }
            }
            return null;
        }
    }
}
