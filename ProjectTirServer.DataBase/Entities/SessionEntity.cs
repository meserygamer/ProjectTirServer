using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTirServer.DataBase.Entities
{
    public class SessionEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; } = null!;
    }
}
