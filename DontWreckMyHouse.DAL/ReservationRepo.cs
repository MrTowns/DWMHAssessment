using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.DAL
{
    public class ReservationRepo : IReservationRepo
    {
        private const string HEADER = "id,start_date,end_date,guest_id,total";
        private readonly string directory;

        public ReservationRepo(string directory)
        {
            this.directory = directory;
        }

        public Reservation Add(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation Edit(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> FindByHost(Host host)
        {
            throw new NotImplementedException();
        }

        public Reservation Remove(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
