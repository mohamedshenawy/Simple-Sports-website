using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class TeamVM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string WebsiteUrl { get; set; }
        public IFormFile LogoFile { get; set; }
        public DateTime FoundationDate { get; set; }
        [Required]
        public int tournamentID { get; set; }
    }

    public static class TeamConverter
    {
        public static Teams ToTeam(this TeamVM team)
        {
            return new Teams
            {
                ID = team.ID,
                Name = team.Name,
                Description = team.Description,
                WebsiteUrl = team.WebsiteUrl,
                LogoUrl = team.LogoFile.FileName,
                FoundationDate = team.FoundationDate,
                TournamentID = team.tournamentID
            };
        }

        public static TeamVM ToTeamVM(this Teams team)
        {
            return new TeamVM
            {
                ID = team.ID,
                Name = team.Name,
                Description = team.Description,
                WebsiteUrl = team.WebsiteUrl,
                FoundationDate = team.FoundationDate
            };
        }
    }
}
