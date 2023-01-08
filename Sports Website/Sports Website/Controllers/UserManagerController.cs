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
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserManagerController(UserManager<IdentityUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _userManager= userManager;
            _roleManager = roleManager;

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
