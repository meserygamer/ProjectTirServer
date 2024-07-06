using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTirServer.Core.DomainModel
{
    public class Session
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
