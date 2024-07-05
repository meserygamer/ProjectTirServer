using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTirServer.DataBase.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Login { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string UserSurname { get; set; } = null!;

        public string UserPatronymic { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string UserPhone { get; set; } = null!;

        public DateOnly UserBirtdayDate { get; set; }

        public List<SessionEntity> OpenSessions { get; set; } = null!;
    }
}
