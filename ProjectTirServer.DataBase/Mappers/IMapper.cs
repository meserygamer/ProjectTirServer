using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTirServer.DataBase.Mappers
{
    public interface IMapper<F,T>
    {
        public T ToDomain(F entity);

        public F ToEntity(T domainModel);
    }
}
