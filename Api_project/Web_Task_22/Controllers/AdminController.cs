using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Task_22.Model;
using Web_Task_22.Model.AuthPersonApp.AuthRepository;
using Web_Task_22.Model.Data;
using Web_Task_22.Model.Data.Source;

namespace Web_Task_22.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        [HttpDelete]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            return await Task<IActionResult>.Factory.StartNew(() => 
            {
                try
                {                    
                    return Ok(PhoneBoockDataAPI.SendDelete(id)); 
                }
                catch (Exception)
                {
                    return NotFound();
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteView()
        {
            return await Task.Factory.StartNew(() =>
            {
                return View();
            });
        }

        [HttpGet]
        public async Task<IActionResult> DataChangesView(int id)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    BoxPerson boxPerson = PhoneBoockDataAPI.GetPersonsInfo(id);

                    boxPerson.Data.PhoneNumber = boxPerson.Data.PhoneNumber.Replace("8", string.Empty);
                    boxPerson.Data.PhoneNumber = boxPerson.Data.PhoneNumber.Replace("-", string.Empty);

                    ViewBag.Data = (boxPerson);

                    return View();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            });
        }

        [HttpPut]
        public async Task<IActionResult> DataChangesView(Person person, PersonalData personalData)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    PackagePerson package = new PackagePerson()
                    {
                        person = person,
                        personalData = personalData

                    };

                    return Ok(PhoneBoockDataAPI.SendPut(package));
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> ChangePhotoView(int id)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                BoxPerson box = PhoneBoockDataAPI.GetPersonsInfo(id);

                ViewBag.Data = (id, box.HepfImg);

                return View();
            });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePhoto(int id, IFormFile file)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                try
            {

                Person _person = new Person()
                { 
                    ID = id              
                };

                PackagePerson package = new PackagePerson()
                {
                    person = _person,
                    DataPhoto = GetFile(file)
                };

                PhoneBoockDataAPI.SendPhoto(package);



                return Redirect($"~/Home/Info?id={id}");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            });

        }

        public async Task<IActionResult> ViewUsers()
        {
            return await Task.Factory.StartNew(() =>
            {
                ViewBag.DataUsers = PhoneBoockDataAPI.GetUsers();

                return View();
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(params string[] names)
        {
            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    string str = string.Empty;

                    if (names != null)
                    {
                        foreach (string name in names)
                        {
                            str += PhoneBoockDataAPI.DeleteUser(name) + "\n";
                        }
                    }
                    else
                    {
                        str = "Данных нет";
                    }

                    return Ok(str);
                }
                catch (Exception ex)
                {

                    return NotFound(ex);
                }
            });
        }

        public async Task<IActionResult> AddUser()
        {
            return await Task.Factory.StartNew(() =>
            {
                return View();
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(UserRegistration model)
        {

            return await Task<IActionResult>.Factory.StartNew(() =>
            {
                try
                {
                    PhoneBoockDataAPI.AddUser(model);

                    return Redirect("~/Admin/ViewUsers");

                }
                catch (Exception ex)
                {

                    return NotFound(ex);
                }

            });

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
    }
}
