using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL
{
    public class HostService 
    {


        private readonly IHostRepo _hostRepo;

        public HostService(IHostRepo hostRepo)
        {
            _hostRepo = hostRepo;
        }


        public Result<List<Host>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
