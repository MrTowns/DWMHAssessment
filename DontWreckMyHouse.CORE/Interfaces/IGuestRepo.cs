using DontWreckMyHouse.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.Interfaces
{
    public interface IGuestRepo
    {
       
        public Guest FindByEmail(string email);

        public List<Guest> FindAllGuest();
    }
}
