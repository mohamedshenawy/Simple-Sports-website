using Microsoft.AspNetCore.Http;
using Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class TournametVM
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile LogoFile { get; set; }
        public string vedioUrl { get; set; }
    }

    public static class TournamentConverter
    {
        public static Tournaments ToTournament(this TournametVM tournament)
        {
            return new Tournaments
            {
                ID = tournament.ID,
                Name = tournament.Name,
                Description = tournament.Description,
                //LogoUrl = tournament.LogoUrl,
                vedioUrl = tournament.vedioUrl
            };
        }


        public static TournametVM ToTournamentVM(this Tournaments tournament)
        {
            return new TournametVM
            {
                ID = tournament.ID,
                Name = tournament.Name,
                Description = tournament.Description,
                vedioUrl = tournament.vedioUrl
            };
        }
    }
}
