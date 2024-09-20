using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Repos;
using Sports_Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Sports_Website.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IUnitOfWork unitOfWork;
        IModelRepo<Tournaments> tournamentsRepo;


        public HomeController(ILogger<HomeController> logger)
        {
            
        }

        public IActionResult Index()
        {
            try
            {
                
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        
    }
}
