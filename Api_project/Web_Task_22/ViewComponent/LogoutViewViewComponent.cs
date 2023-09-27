using Microsoft.AspNetCore.Mvc;

namespace Web_Task_22.Component
{
    public class LogoutViewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
