using ProjectTirServer.Core.DomainModel;

namespace ProjectTirServer.Core.RepositoryInterfaces
{
    public interface ISessionRepository
    {
        public Session? GetSessionById(Guid id);
    }
}
