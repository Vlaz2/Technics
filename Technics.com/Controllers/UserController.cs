using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Technics.com.Attributes;
using Technics.com.Models;
using Technics.com.Options;
using Technics.com.Repository.Interfaces;
using Technics.com.Services;

namespace Technics.com.Controllers
{
    public class UserController : Controller
    {
        private readonly IAllUser userRep;
        private readonly ApplicationOption appOptions;
        private CryptoService cryptoService;
        private readonly ServiceUser serviceUser;
        private readonly EmailService emailService;

        public UserController(IAllUser userRep, ApplicationOption appOptions, ServiceUser serviceUser, EmailService emailService)
        {
            this.userRep = userRep;
            this.appOptions = appOptions;
            this.serviceUser = serviceUser;
            this.emailService = emailService;
        }

        public IActionResult ForgotPassword(string message)
        {
            ViewBag.message = message;
            return View();
        }

        public async Task<IActionResult> ForgotPassword(User userToUpdate)
        {
            var _user = userRep.GetUserByEmail(userToUpdate.Email);

            if (_user == null && _user.ConfirmEmail == false)
                return RedirectToAction("ForgotPassword", new { message = $"Пользователь с почтовым адресом {userToUpdate.Email} не зарегистрирован" });

            cryptoService = new CryptoService(appOptions);
            _user.Token = Guid.NewGuid().ToString();
            await userRep.UpdateUserAsync(_user);
            emailService.Send(_user.Email, _user.Token, "User/AllowResetPassword", "Для сброса пароля перейдите по ссылке", "Сброс пароя");
            ViewBag.message = "Письмо отправлено,проверьте вашу почту";
            return View("ForgotPasswordConfirmation");
        }

        public IActionResult AllowResetPassword(string code)
        {
            var _user = userRep.GetUserByToken(code);

            if (_user == null)
                return BadRequest();

            serviceUser.SetTemporaryToken(_user.Token);
            return View();
        }

        [AuthorizedAttribute()]
        public IActionResult UserInformation()
        {
            var _user = serviceUser.GetUser();
            return View(userRep.GetUserByEmail(_user.Email));
        }

        [AuthorizedAttribute()]
        public async Task<IActionResult> UpdateUserInformation(User user)
        {
            var _user = serviceUser.GetUser();
            var userToUpdate = userRep.GetUserByEmail(_user.Email);
            userToUpdate.LastName = user.LastName;
            userToUpdate.Name = user.Name;
            userToUpdate.Phone = user.Phone;
            serviceUser.SetUser(userToUpdate);
            await userRep.UpdateUserAsync(userToUpdate);
            return RedirectToAction("UserInformation");
        }

        public async Task<IActionResult> ResetPassword(string password)
        {
            var token = serviceUser.GetTemporaryToken();
            var userToUpdate = userRep.GetUserByToken(token);

            if (token == null || userToUpdate == null)
                return BadRequest();

            cryptoService = new CryptoService(appOptions);
            userToUpdate.Password = cryptoService.Encrypt(password);
            userToUpdate.Token = null;
            await userRep.UpdateUserAsync(userToUpdate);
            serviceUser.DeleteTemporaryToken();
            ViewBag.message = "Ваш пароль заменено успешно";
            return View("ForgotPasswordConfirmation");
        }
    }
}