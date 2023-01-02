using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public UserManagerController(UserManager<IdentityUser> userManager)
        {
            _userManager= userManager;
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
                //var user = _userManager.Users.Where(user => user.Id == userId).First();
                var user = await _userManager.FindByIdAsync(userId);
                return View(user);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserVM model)
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
                if (!result.Succeeded)
                    return BadRequest("update user failed");
                return View("Index",_userManager.Users);
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

    }
}
