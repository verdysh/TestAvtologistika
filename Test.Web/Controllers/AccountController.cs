using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Test.Services.Articles;
using Test.Services.Users;
using Test.Services.Users.Dto;
using Test.Web.Models;

namespace Test.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IQc1testService _apiService;

        public AccountController(IUserService userService, IQc1testService apiService)
        {
            _userService = userService;
            _apiService = apiService;
        }

        public async Task<ActionResult> Index()
        {
            return View("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Login(Mapper.Map<UserDto>(model));
                if (user != null)
                {
                    await _apiService.LoadArticles();
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Пользователя с таким email и паролем нет");
            }

            return View(model);
        }

        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public ActionResult Registration()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.RegisterUser(Mapper.Map<UserDto>(model));
                if (user != null)
                {
                    await _apiService.LoadArticles();
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Пользователь с таким email уже зарегистрирован");
            }

            return View(model);
        }
    }
}