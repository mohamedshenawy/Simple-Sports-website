using Data_Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        DbContext context;
        IModelRepo<Teams> TeamsRepo;
        IModelRepo<Tournaments> TournamenetsRepo;
        public UnitOfWork(Context _context  , IModelRepo<Teams> _teams , IModelRepo<Tournaments> _tournaments)
        {
            context = _context;
            TeamsRepo = _teams;
            TournamenetsRepo = _tournaments;

        }
        public IModelRepo<Teams> GetTeamsRepo()
        {
            return TeamsRepo;
        }

        public IModelRepo<Tournaments> GetTournamentsRepo()
        {
            return TournamenetsRepo;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
