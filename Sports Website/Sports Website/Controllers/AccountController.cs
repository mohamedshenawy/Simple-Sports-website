using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Security.Authentication;
using System.Threading.Tasks;
using ViewModels;

namespace Sports_Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IMapper _mapper;
        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Login()
        
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            string returnUrl = HttpContext.Request.Query["returnUrl"];
            if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                ViewBag.returnUrl = returnUrl; 
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if(!result.Succeeded)
                {
                    return BadRequest("invalid email or password");
                }
                //return url
                if (!String.IsNullOrEmpty(model.returnUrl) && Url.IsLocalUrl(model.returnUrl))
                {
                    return Redirect(model.returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        //[HttpGet]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> SinUpPost(SignUpVM model)
        //{
        //    try
        //    {
        //        // data annotation validation 
        //        if(!ModelState.IsValid)
        //            return BadRequest(ModelState);

        //        //sign up with identity 
        //        IdentityUser newUser = new IdentityUser();
        //        newUser = _mapper.Map<IdentityUser>(model);
        //        var result = await _userManager.CreateAsync(newUser, model.Password);

        //        if (!result.Succeeded)
        //        {
        //            var errors = new List<string>();
        //            foreach (var error in result.Errors)
        //            {
        //                errors.Add(error.Description);
        //            }
        //            return BadRequest(errors);
        //        }
        //        return Ok(Url.Action("Index" , "Home"));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }

        //}

        
        public async Task<IActionResult> LogOut()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login");
                }
                return Unauthorized("not authorized");
               
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
