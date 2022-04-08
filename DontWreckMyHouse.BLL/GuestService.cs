using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL
{
    public class GuestService
    {
        private readonly IGuestRepo _guestRepo;

        public GuestService(IGuestRepo guestRepo)
        {
            _guestRepo = guestRepo;
        }
        
        public List<Guest> FindByGuestLastName(string prefix)
        {
            return _guestRepo.FindAllGuest()
                .Where(h => h.LastName.StartsWith(prefix))
                .ToList();
        }
    }
}
