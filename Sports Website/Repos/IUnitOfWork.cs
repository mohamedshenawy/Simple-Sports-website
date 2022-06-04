using Models;

namespace Repos
{
    public interface IUnitOfWork
    {
        IModelRepo<Teams> GetTeamsRepo();
        IModelRepo<Tournaments> GetTournamentsRepo();
        void Save();

    }
}
