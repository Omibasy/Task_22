using Api_Task_22.AuthPersonApp;
using Api_Task_22.AuthPersonApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace Api_Task_22.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            _userManager = signInManager.UserManager;
            _signInManager = signInManager;
   
        }


        [HttpPost]
        [Route("EnterLogin")]
        public async Task<object> Login([FromBody] UserLogin _user)
        {

            Microsoft.AspNetCore.Identity.SignInResult loginResult =
                await _signInManager.PasswordSignInAsync(_user.loginProp,
                                                         _user.password,
                                                         true,
                                                         true);

            if (loginResult.Succeeded)
            {
                if (Url.IsLocalUrl(_user.returnUrl))
                {
                    return _user.returnUrl;
                }

                User selectUser = await _userManager.FindByNameAsync(_user.loginProp);

                IList<string> roles = await _userManager.GetRolesAsync(selectUser);

                return roles[0];
            }

            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("EnterRegistration")]
        public async Task<string> Registration([FromBody] UserRegistration _user)
        {
            User user = new User { UserName = _user.LoginProp };

            IdentityResult createResult = await _userManager.CreateAsync(user, _user.Password);

            if (createResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, _user.GetRole());

                await _signInManager.SignInAsync(user, false);

                return _user.GetRole();
            }
            else
            {
                string errorMassage = "";

                foreach (IdentityError identityError in createResult.Errors)
                {
                    errorMassage += "\n" + identityError.Description;
                }

                return errorMassage;
            }
        }

        [HttpGet]
        [Route("Logout")]
        [Authorize(Roles = "admin, user")]
        public async Task<string> Logout()
        {
            await _signInManager.SignOutAsync();

            return "Пользователь вышел из системы";
        }

        [HttpGet]
        [Route("GetUserList")]
        [Authorize(Roles = "admin")]
        public async Task<DataUser[]> Get()
        {
            return await Task.Factory.StartNew(() =>
            {

                return GetListUsers();

            });
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = "admin")]
        public async Task<string> AddUser([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.LoginProp };

                var createResult = await _userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.GetRole());

                    return model.GetRole();
                }
                else
                {
                    string errorMassage = "";

                    foreach (IdentityError identityError in createResult.Errors)
                    {
                        errorMassage += "\n" + identityError.Description;
                    }

                    return errorMassage;
                }
            }

            return "Что то пошло не так";
        }

        [HttpDelete]
        [Route("DeleteUser/{name}")]
        [Authorize(Roles = "admin")]
        public async Task<string> DeleteUser(string name)
        {
            User user = await _userManager.FindByNameAsync(name);

            await _userManager.DeleteAsync(user);

            return $"Пользователь {name} удален";
        }

        private DataUser[] GetListUsers()
        {
            string nameActiveUser = User.Identity.Name;

            User[] users = _userManager.Users.Where(User => User.UserName != nameActiveUser).ToArray();

            DataUser[] dataUsers = new DataUser[users.Length];

            if (dataUsers.Length <= 0)
            {
                DataUser[] dataUsersNull = new DataUser[1];

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

