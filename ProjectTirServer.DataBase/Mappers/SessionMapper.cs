using ProjectTirServer.Core.DomainModel;
using ProjectTirServer.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTirServer.DataBase.Mappers
{
    public class SessionMapper : IMapper<SessionEntity, Session>
    {
        public Session ToDomain(SessionEntity entity)
            => new Session 
            {
                Id = entity.Id,
                UserId = entity.UserId,
                StartDate = entity.StartDate
            };

        public SessionEntity ToEntity(Session domainModel)
            => new SessionEntity
            {
                Id = domainModel.Id,
                UserId = domainModel.UserId,
                StartDate = domainModel.StartDate
            };
    }
}
