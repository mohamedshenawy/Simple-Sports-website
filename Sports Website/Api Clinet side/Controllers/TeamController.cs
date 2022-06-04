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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        IUnitOfWork UnitOfWork;
        IModelRepo<Teams> teamRepo;
        IModelRepo<Tournaments> tournamentRepo;
        public TeamController(IUnitOfWork _unit)
        {
            UnitOfWork = _unit;
            teamRepo = UnitOfWork.GetTeamsRepo();
            tournamentRepo = UnitOfWork.GetTournamentsRepo();


        }

        //read all
        [HttpGet]
        public IActionResult GetbytournamentID(int tournamentID)
        {
            var teams = teamRepo.Read().Where(t => t.TournamentID == tournamentID).ToList();
            if (teams == null)
                return NotFound();


            return Ok(teams);
        }
    }
}
