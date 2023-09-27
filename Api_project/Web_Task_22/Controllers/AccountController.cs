using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_Task_22.Model;
using Web_Task_22.Model.AuthPersonApp;
using Web_Task_22.Model.AuthPersonApp.AuthRepository;


namespace Web_Task_22.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Login(string _returnUrl)
        {

            return await Task.Factory.StartNew(() => 
            {
                return View(new UserLogin()
                {
                    ReturnUrl = _returnUrl,
                });
            });
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLogin model)
        {
            string role = PhoneBoockDataAPI.SendLogIn(model);

            if (role == "admin" || role == "user")
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.LoginProp ),
                    new Claim(ClaimTypes.Role, role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");

            }
            else
            {
              
                  return View(model);
                
            }         
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserRegistration());

        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            try
            {
               string message = PhoneBoockDataAPI.SendRegistration(model);

                if (message.Length >= 7) 
                {
                    return RedirectToAction("Index", "Home");
                }

                if (model.GetRole() == "admin" || model.GetRole() == "user")
                {

                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.LoginProp ),
                    new Claim(ClaimTypes.Role, model.GetRole())
                };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Home");

                }
                else
                {

                    return View(model);

                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            

           
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");

        }
    }
}
