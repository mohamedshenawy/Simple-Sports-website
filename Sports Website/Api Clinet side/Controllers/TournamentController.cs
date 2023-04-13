using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Clinet_side.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {

        IUnitOfWork UnitOfWork;
        IModelRepo<Tournaments> tournamentRepo;
        IModelRepo<Teams> teamRepo;
        public TournamentController(IUnitOfWork _unit)
        {
            UnitOfWork = _unit;
            tournamentRepo = UnitOfWork.GetTournamentsRepo();
            teamRepo = UnitOfWork.GetTeamsRepo();
           
        }


        //read all
        [HttpGet]
        public IActionResult Get()
        {
            var tournaments = tournamentRepo.Read().ToList();
            return Ok(tournaments);
        }

        //read tourment by id
        [HttpGet]
        public IActionResult GetByID(int tournamentID)
        {
            var tournament = tournamentRepo.GetByID(tournamentID);
            if (tournament == null)
                return NotFound();


            return Ok(tournament);
        }


        [HttpGet]
        public IActionResult GetByName(string tournamentName)
        {
            var tournaments = tournamentRepo.Read().Where(t => t.Name.Contains(tournamentName)).ToList();
            if (tournaments == null)
                return NotFound();


            return Ok(tournaments);
        }


    }
}
