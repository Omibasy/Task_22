using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using Task_22.AuthPersonApp;
using Task_22.AuthPersonApp.Repository;
using Task_22.Model;

namespace Task_22.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
       
    

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
           
        }

        public IActionResult AddUser()
        {
            return View();
        }

        public  IActionResult ViewUsers()
        {

            ViewBag.DataUsers = GetListUsers();

            return View();
        }

        [HttpPost]
        public IActionResult AddNewUser(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.LoginProp };

                var createResult =  _userManager.CreateAsync(user, model.Password).Result;


                if (createResult.Succeeded)
                {

                    _userManager.AddToRoleAsync(user, model.GetRole()).Wait();

                    return Redirect("~/");
                }
                else
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);

        }



        [HttpDelete]
        public IActionResult DeleteUser(params string[] names)
        {
      

            try
            {
                User user = null;

                string str = "Delete Users";

                for (int i = 0; i < names.Length; i++)
                {
                    user = _userManager.FindByNameAsync(names[i]).Result;

                    if (user != null)
                    {
                        _userManager.DeleteAsync(user).Wait();

                        str += $"\n\t{user.UserName}";
                    }
                }


                return Ok(str);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            } 
        }

        private DataUser[] GetListUsers()
        {
            string nameActiveUser = User.Identity.Name;

            User[] users = _userManager.Users.Where(User => User.UserName != nameActiveUser).ToArray();

            DataUser[] dataUsers = new DataUser[users.Length];

            if (dataUsers.Length <= 0)
            {
                DataUser[] dataUsersNull =  new DataUser[1];

                dataUsersNull[0] = new DataUser("Нет данных", "Нет данных");

                return dataUsersNull;
            }

            for (int i = 0; i < dataUsers.Length; i++)
            {
                var rolesList = _userManager.GetRolesAsync(users[i]).Result;

                string role = "";

                if (rolesList.Count >= 1)
                {
                    role = rolesList[0];
                }
                else
                {
                    role = "Нет роли";
                }

                dataUsers[i] = new DataUser(users[i].UserName, role);
            }
        
            return dataUsers;
        }


    }
}
