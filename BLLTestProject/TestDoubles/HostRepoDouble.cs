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
        private readonly Result<List<Host>> hosts = new Result<List<Host>>();
        List<Host> listHost = new List<Host>()
        {
            new()
            {

                    HostId = "1",
                    HostName = "John",
                    Email = "123foobar@yahoo.coom",
                    Phone = "5555555555",
                    Address = "123 Fake St",
                    City = "Faketown",
                    State = "FL",
                    PostalCode = "12345",
                    StandardRate = 100.00M,
                    WeekendRate = 150.00M,
                   
            }
        };
        public Result<List<Host>> GetAll()
        {
            return new Result<List<Host>>();
        }

        public Result<Host> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}

       