using Microsoft.AspNetCore.Mvc;
using Technics.com.Services;

namespace Technics.com.Controllers
{
    public class LogoutController:Controller
    {
         private readonly ServiceUser servicesUser;

        public LogoutController(ServiceUser servicesUser)
        {
            this.servicesUser = servicesUser;
        }

        public ActionResult Logout()
        {
            servicesUser.DeleteUser();
            return RedirectToAction("List", "Products");
        }
    }
}
