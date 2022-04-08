using DontWreckMyHouse.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.Interfaces
{
    public interface IHostRepo
    {
        
        public List<Host> FindAllHost();
        public Host FindByEmail(string email);
    }
}
