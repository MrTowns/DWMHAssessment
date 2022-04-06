using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.DAL
{
    public class HostRepo : IHostRepo 
    {
        private const string HEADER = "id,last_name,email,phone,address,city,state,postal_code,standard_rate,weekend_rate";
        private readonly string filePath;

        public HostRepo(string filePath)
        {
            this.filePath = filePath;
        }

        public Result<Host> GetAll(int id)
        {
            throw new NotImplementedException();
        }
    }
}
