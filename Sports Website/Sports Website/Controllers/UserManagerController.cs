using AutoMapper;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Security.Claims;

namespace Sports_Website.Controllers
{
    [Authorize(Roles= "super admin")]
    public class UserManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public UserManagerController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager , IMapper mapper)
        {
            _userManager= userManager;
            _roleManager = roleManager;
            _mapper= mapper;

        }
        //read
        public async Task<IActionResult> Index()
        
        {
            try
            {
                List<IdentityUser> users = await _userManager.Users.ToListAsync();
                return View(users);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //insert
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser(SignUpVM model)
        {
            try
            {
                // data annotation validation 
                if (!ModelState.IsValid)
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
                return Ok(Url.Action("Index", "UserManager"));
            }
            catch
            {
                return BadRequest();
            }

        }
        //update
        [HttpGet]
        public async Task<IActionResult> Update(string userId)
        {
            try
            {
                ViewBag.Roles = _roleManager.Roles.ToList();
                var user = await _userManager.FindByIdAsync(userId);
                var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                ViewBag.userRole = userRole;
                return View(user);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = await _userManager.FindByIdAsync(model.Id);
                user.UserName = model.Name;
                user.NormalizedUserName = model.Name.ToUpper();
                user.Email = model.Email;
                user.NormalizedEmail = model.Email.ToUpper();
                var result = await _userManager.UpdateAsync(user);
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                await _userManager.AddToRoleAsync(user, role.Name);
                if (!result.Succeeded)
                    return BadRequest("update user failed");
                return Content("/UserManager/Index");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //delete
        [HttpDelete]
        public async Task<IActionResult> Delete(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                    return BadRequest("falid delete");

                return Ok("deleted");
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public async Task<IActionResult> RestPassword(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, code, "P@ssw0rd@123");
                if (!result.Succeeded)
                    return BadRequest("Error");

                return Ok("done");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //[HttpGet("signin-google")]
        //public IActionResult SignInWithGoogle()
        //{
        //    var properties = new AuthenticationProperties { RedirectUri = "/signin-google-callback" };
        //    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        //}
        //[HttpGet("signin-google-callback")]
        //public async Task<IActionResult> SignInWithGoogleCallback()
        //{
        //    var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        //    // TODO: Handle the authentication result
        //    return View();
        //}

        //[HttpGet("signin-facebook")]
        public IActionResult SignInWithFacebook()
        {
            var properties = new AuthenticationProperties { RedirectUri = "/UserManager/SignInWithFacebookCallback" };
            return Challenge(properties, FacebookDefaults.AuthenticationScheme);
        }

        //[HttpGet("signin-facebook-callback")]
        public async Task<IActionResult> SignInWithFacebookCallback()
        {
            var result = await HttpContext.AuthenticateAsync(FacebookDefaults.AuthenticationScheme);
            // TODO: Handle the authentication result
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            var facebookId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser == null)
            {
                // User does not exist, create a new user
                var newUser = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    //FacebookId = facebookId // Optionally, store the Facebook ID in your user model
                                            // Set other properties as needed
                };

                // Create the new user in the database
                var createResult = await _userManager.CreateAsync(newUser);
                if (createResult.Succeeded)
                {
                    // User creation successful
                    // Perform any additional actions or redirect the user to the desired page
                }
                else
                {
                    // User creation failed
                    // Handle the error and display appropriate feedback to the user
                }
            }
            else
            {
                // User already exists, perform any additional actions or redirect the user to the desired page
            }


            return View();
        }

    }
}
