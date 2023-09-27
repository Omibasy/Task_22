using Api_Task_22.Model.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api_Task_22.Model.Data;

namespace Api_Task_22.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
      
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IPhoneBook phoneBook;

    
        public AdminController(IWebHostEnvironment appEnvironment, IPhoneBook book)
        {
            _appEnvironment = appEnvironment;

            phoneBook = book;
        }

        [HttpPut]
        [Route("DataChanges")]
        public async Task<string> DataChanges([FromBody] PackagePerson packagea)
        {
               return await phoneBook.DataChanges(packagea);
        }


        [HttpDelete]
        [Route("DataDelete/{id}")]
        public async Task<string> DeleteRecord(int id)
        {
            return await phoneBook.DeleteAnEntry(id, _appEnvironment);
        }


        [HttpPost]
        [Route("ChangePhoto")]
        public async Task<string> EditPhoto([FromBody] PackagePerson packagea)
        {
            return await phoneBook.EditPhoto(packagea.person.ID, 
                                             packagea.DataPhoto,
                                             _appEnvironment);
        }




    }
}
