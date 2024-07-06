using ProjectTirServer.Core.DomainModel;
using ProjectTirServer.Core.RepositoryInterfaces;
using ProjectTirServer.DataBase.Entities;
using ProjectTirServer.DataBase.Mappers;


namespace ProjectTirServer.DataBase.Repositories
{
    public class SQLiteSessionRepository : ISessionRepository
    {
        public SQLiteSessionRepository(ProjectTirDbContext projectTirDbContext) 
        { 
            _projectTirDbContext = projectTirDbContext;
        }


        private ProjectTirDbContext _projectTirDbContext;


        public Session? GetSessionById(Guid id)
        {
            SessionEntity? sessionEntity = _projectTirDbContext.Sessions.Where(s => s.Id == id).FirstOrDefault();
            return (sessionEntity is null) ? null : new SessionMapper().ToDomain(sessionEntity);
        }
    }
}
