using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.DTO
{
    public class Host
    {
        public string HostId { get; set; }

        public string HostName { get; set; }

        public string Email { get; set;  }

        public string Phone { get; set;  }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public decimal StandardRate { get; set; }

        public decimal WeekendRate { get; set; }
        
        
    }
}
