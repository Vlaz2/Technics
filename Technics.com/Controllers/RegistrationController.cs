using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Technics.com.Attributes;
using Technics.com.Models;
using Technics.com.Options;
using Technics.com.Repository.Interfaces;
using Technics.com.Services;

namespace Technics.com.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IAllUser userRep;
        private readonly ApplicationOption appOptions;
        private CryptoService cryptoService;
        private readonly ServiceUser servicesUser;
        private readonly EmailService emailService;

        public RegistrationController(IAllUser userRep, ApplicationOption appOptions, ServiceUser servicesUser, EmailService emailService)
        {
            this.userRep = userRep;
            this.appOptions = appOptions;
            this.servicesUser = servicesUser;
            this.emailService = emailService;
        }

        public ViewResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public async Task<IActionResult> Index(User user)
        {
            user.Role = Roles.Customer;
            Match matchPhone = Regex.Match(user.Phone, @"(^\+38[0-9]{10}$|^[0-9]{10}$|^38[0-9]{10}$)");
            Match matchName = Regex.Match(user.Name, @"\S{3,20}$");
            Match matchLastName = Regex.Match(user.LastName, @"\S{3,20}$");
            Match matchEmail = Regex.Match(user.Email, @".@gmail\.com$|.@mail\.ru$");
            Match matchPassword = Regex.Match(user.Password, @"([0-9a-zA-Z]{6,})");

            if (matchPhone.Success && matchName.Success && matchEmail.Success && matchPassword.Success && matchLastName.Success)
            {

                if (userRep.GetUserByEmail(user.Email) == null)
                {
                    cryptoService = new CryptoService(appOptions);
                    user.Password = cryptoService.Encrypt(user.Password);
                    user.Token = Guid.NewGuid().ToString();
                    await userRep.AddUserAsync(user);
                    emailService.Send(user.Email, user.Token, "Registration/ConfirmEmail", "Для подтверждения перейдите по ссылке", "Подтверждениe почтового адреса");
                    return RedirectToAction("VariousInf", new { inf = "Вы успешно зарегистрированы,пожалуйста подтвердите почтовый адрес" });
                }
                else
                    ViewBag.Message = "Вы уже зарегистрированы";

            }
            else
                ViewBag.Message = "Не правильный ввод данных!";

            return View(user);
        }

        public async Task<IActionResult> ConfirmEmail(string token)
        {
            var _user = userRep.GetUserByToken(token);

            if (_user == null)
                return BadRequest();

            _user.Token = null;
            _user.ConfirmEmail = true;
            await userRep.UpdateUserAsync(_user);
            return RedirectToAction("Index", "Login");
        }

        [AuthorizedAttribute(Roles.Admin)]
        public ViewResult AdminRegistration()
        {
            return View();
        }

        [AuthorizedAttribute(Roles.Admin)]
        public async Task<IActionResult> AdminRegistration(User adminToRegistration)
        {
            adminToRegistration.Role = Roles.Admin;
            Match mathPhone = Regex.Match(adminToRegistration.Phone, @"(^\+38[0-9]{10}$|^[0-9]{10}$|^38[0-9]{10}$)");
            Match mathName = Regex.Match(adminToRegistration.Name, @"\S{3,20}$");
            Match matchEmail = Regex.Match(adminToRegistration.Email, @".@gmail\.com$|.@mail\.ru$");
            Match matchPassword = Regex.Match(adminToRegistration.Password, @"([0-9a-zA-Z]{6,})");
            Match mathLastName = Regex.Match(adminToRegistration.LastName, @"\S{3,20}$");

            if (mathPhone.Success && mathName.Success && matchEmail.Success && matchPassword.Success && mathLastName.Success)
            {
                if (userRep.GetUserByEmail(adminToRegistration.Email) == null)
                {
                    cryptoService = new CryptoService(appOptions);
                    adminToRegistration.Password = cryptoService.Encrypt(adminToRegistration.Password);
                    await userRep.AddUserAsync(adminToRegistration);
                    return RedirectToAction("VariousInf", new { inf = "Администратор успешно зарегистрирован" });
                }
                else
                    ViewBag.Message = "Этот администратор уже зарегистрирован";
            }
            else
                ViewBag.Message = "Не правильный ввод данных!";

            return View();
        }

        public IActionResult VariousInf(string inf)
        {
            ViewBag.Message = inf;
            return View();
        }
    }
}