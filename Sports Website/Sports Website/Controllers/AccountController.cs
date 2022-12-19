using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                //var user = new IdentityUser { UserName= model.UserName };
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if(!result.Succeeded)
                {
                    return BadRequest("invalid email or password");
                }

                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message); 
            }
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SinUpPost(SignUpVM model)
        {
            try
            {
                // data annotation validation 
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                //sign up with identity 
                IdentityUser newUser = new IdentityUser();
                newUser = _mapper.Map<IdentityUser>(model);
                var result = await _userManager.CreateAsync(newUser, model.Password);

                if (!result.Succeeded)
                {
                    var errors = new List<string>();
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }
                    return BadRequest(errors);
                }
                return Ok(Url.Action("Index" , "Home"));
            }
            catch
            {
                return BadRequest();
            }

        }



    }
}
