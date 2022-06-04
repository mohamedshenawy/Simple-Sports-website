using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Sports_Website.Controllers
{
    public class TeamController : Controller
    {

        IUnitOfWork unitOfWork;
        IModelRepo<Teams> teamsRepo;
        IModelRepo<Tournaments> tournamentRepo;
        public TeamController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            teamsRepo = unitOfWork.GetTeamsRepo();
            tournamentRepo = unitOfWork.GetTournamentsRepo();
        }
        public IActionResult Index()
        {
            List<Teams> teams = teamsRepo.Read().ToList();
            List<Tournaments> tournaments = tournamentRepo.Read().ToList();
            if(tournaments.Count < 1)
                return RedirectToAction("Create", "Home");

            
            return View(teams);
        }
        [HttpGet]

        public IActionResult Create()
        {
            List<Tournaments> tournaments = tournamentRepo.Read().ToList();
            List<SelectListItem> tournamentsVB = new List<SelectListItem>();
            foreach(var tournament in tournaments)
            {
                var t = new SelectListItem
                {
                    Text = tournament.Name,
                    Value = tournament.ID.ToString()
                };
                tournamentsVB.Add(t);
            }
            ViewData["tournaments"] = tournamentsVB;

            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamVM team)
        {
            if (!ModelState.IsValid)
                return View(team);



            //get directory
            string PhotosPath = Directory.GetCurrentDirectory();
            //save photo 
            var photoName = FileHepler.SaveFile(team.LogoFile, PhotosPath);
            
            var DBteam = team.ToTeam();

            DBteam.LogoUrl = photoName;
            

            teamsRepo.Create(DBteam);
            unitOfWork.Save();
           

            return RedirectToAction("Index");
        }



        public IActionResult Edit(int teamID)
        {
            
            var team = teamsRepo.GetByID(teamID);


            if (team == null)
                return RedirectToAction("Index");

            var teamVM = team.ToTeamVM();
            List<Tournaments> tournaments = tournamentRepo.Read().ToList();
            List<SelectListItem> tournamentsVB = new List<SelectListItem>();
            foreach (var tournament in tournaments)
            {
                var t = new SelectListItem
                {
                    Text = tournament.Name,
                    Value = tournament.ID.ToString()
                };
                tournamentsVB.Add(t);
            }
            ViewData["tournaments"] = tournamentsVB;

            return View(teamVM);
        }
        [HttpPost]
        public IActionResult Edit(TeamVM team)
        {
            if (!ModelState.IsValid)
                return View(team);

            if (team.LogoFile != null)
            {
                string PhotosPath = Directory.GetCurrentDirectory();
                var photoName = FileHepler.SaveFile(team.LogoFile, PhotosPath);
                var DBteam = team.ToTeam();

                DBteam.LogoUrl = photoName;
                teamsRepo.Update(DBteam);
                unitOfWork.Save();
            }
            else
            {
                var t = teamsRepo.Read().Where(t => t.ID == team.ID).FirstOrDefault();
                var DBteam = team.ToTeam();

                DBteam.LogoUrl = t.LogoUrl;
                
                teamsRepo.Update(DBteam);
                unitOfWork.Save();
            }
            


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int teamID)
        {
            try
            {
            teamsRepo.Delete(teamID);
                unitOfWork.Save();

            }
            catch
            {
                return RedirectToAction("Error" , "Home");
            }
            return RedirectToAction("Index");
        }






    }
}
