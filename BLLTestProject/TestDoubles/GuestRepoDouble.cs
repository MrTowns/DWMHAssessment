using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL.Tests.TestDoubles
{
    public class GuestRepoDouble : IGuestRepo
    {
        public List<Guest> FindAllGuest()
        {
            throw new NotImplementedException();
        }

        public Guest FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public class HostRepoDouble 
        {
            private readonly Result<List<Guest>> hosts = new Result<List<Guest>>();
            List<Guest> listGuest = new List<Guest>()
        {
            new()
            {
               // guest_id,first_name,last_name,email,phone,state

                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "123foobar@yahoo.coom",
                    Phone = "5555555555",
                    State = "FL",
                   

            }
        };
            public Result<List<Host>> GetAll()
            {
                return new Result<List<Host>>();
            }

            
        }
    }
}
