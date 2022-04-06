using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL.Tests.TestDoubles
{
    public class HostRepoDouble : IHostRepo
    {
        public static readonly Host host = new("123", "Hudson", "123foobar@yahoo.com", "");
        private readonly Results<list<Host>> host = new Result<list<Host>>
        
        
        public List<Host> GetAllHosts()
        {





        }
    }
}
