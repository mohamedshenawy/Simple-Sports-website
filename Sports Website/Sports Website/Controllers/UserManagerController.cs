using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        //delete

    }
}
