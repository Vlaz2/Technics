using Microsoft.AspNetCore.Mvc;
using Technics.com.Models;
using Technics.com.Options;
using Technics.com.Repository.Interfaces;
using Technics.com.Services;

namespace Technics.com.Controllers
{
    public class LoginController:Controller
    {
        private readonly IAllUser userRep;
        private readonly ServiceUser servicesUser;
        private readonly ApplicationOption applicationOption;

        public LoginController(IAllUser userRep , ServiceUser servicesUser,ApplicationOption applicationOption)
        {
            this.userRep = userRep;
            this.servicesUser = servicesUser;
            this.applicationOption = applicationOption;
        }

        public ViewResult Index()
        {
            return View(new User());
        }

        public ActionResult Index(User user)
        {
            var _user = userRep.GetUserByEmail(user.Email);

            CryptoService cryptoService = new CryptoService(applicationOption);
            user.Password = cryptoService.Encrypt(user.Password);

            if (_user != null)
            {
                if (_user.Role == Roles.Admin && _user.Password == user.Password)
                {
                    servicesUser.SetUser(_user);
                    return RedirectToAction("List", "Products");
                }

                if (_user.Password == user.Password)
                {
                    if (_user.ConfirmEmail == true)
                    {
                        servicesUser.SetUser(_user);
                        return RedirectToAction("List", "Products");
                    }
                    else
                        ViewBag.Message = "Подтвердите ваш почтовый адрес";
                }
                else
                    ViewBag.Message = "Неправильный логин или пароль";
            }
            else
                ViewBag.Message = "Пользователь не найден";

            return View(user);
        }
    }
}
