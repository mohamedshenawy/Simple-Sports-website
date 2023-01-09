using AutoMapper;
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

    }
}
