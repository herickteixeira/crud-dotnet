﻿using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUi.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate authenticate)
        {
            _authentication = authenticate;
        }

        public string ReturnUrl { get; private set; }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "A senha deve ser mais forte.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "A senha deve ser mais forte.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }
    }
}