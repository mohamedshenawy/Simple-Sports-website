using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Sports_Website.Controllers
{
    [Authorize(Roles ="super admin,admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertRole(RoleVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var role = new IdentityRole { Name = model.Name };
                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                    return BadRequest(result.Errors.ToString());

                return View("Index");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
