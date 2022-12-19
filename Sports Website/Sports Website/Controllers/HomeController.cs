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


        public HomeController(ILogger<HomeController> logger , IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
            tournamentsRepo = unitOfWork.GetTournamentsRepo();
        }

        public IActionResult Index()
        {
            try
            {
                var tournaments = tournamentsRepo.Read().ToList();
                return View(tournaments);

            }
            catch
            {
                //Sports_Website.Models.ErrorViewModel er = new ErrorViewModel();
                
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TournametVM tournamentVm)
        {
            if (!ModelState.IsValid)
                return View(tournamentVm);

            //get directory
            string PhotosPath = Directory.GetCurrentDirectory();
            //save photo 
            var photoName = FileHepler.SaveFile(tournamentVm.LogoFile, PhotosPath);


            var DBtournament = tournamentVm.ToTournament();

            DBtournament.LogoUrl = photoName;

            tournamentsRepo.Create(DBtournament);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int tournamentID)
        {
            var tournament = tournamentsRepo.GetByID(tournamentID);

            if (tournament == null)
                return RedirectToAction("Error");


            var tournamentVm = tournament.ToTournamentVM();


            return View(tournamentVm);
        }

        [HttpPost]
        public IActionResult Edit(TournametVM tournamentVm)
        {

            if (!ModelState.IsValid)
                return View(tournamentVm);
            if(tournamentVm.LogoFile != null)
            {
            string PhotosPath = Directory.GetCurrentDirectory();
            var photoName = FileHepler.SaveFile(tournamentVm.LogoFile, PhotosPath);
            var DBtournament = tournamentVm.ToTournament();
            DBtournament.LogoUrl = photoName;

            tournamentsRepo.Update(DBtournament);
            unitOfWork.Save();
            }
            else
            {
                var t = tournamentsRepo.Read().Where(t => t.ID == tournamentVm.ID).FirstOrDefault();
                var DBtournament = tournamentVm.ToTournament();

                t.Name = DBtournament.Name;
                t.Description = DBtournament.Description;
                t.vedioUrl = DBtournament.vedioUrl;
                



                tournamentsRepo.Update(t);
                unitOfWork.Save();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int tournamentID)
        {
            try
            {
                tournamentsRepo.Delete(tournamentID);
                unitOfWork.Save();
            }
            catch
            {
                return RedirectToAction("Error");
            }
            return RedirectToAction("Index");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
