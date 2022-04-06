using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DontWreckMyHouse.CORE.DTO;


namespace DontWreckMyHouse.CORE.Interfaces
{
    public interface IReservationRepo
    {
        public List<Reservation> FindByHost(Host host);

        public Reservation Add(Reservation reservation);

        public Reservation Remove(Reservation reservation);

        public Reservation Edit(Reservation reservation);
        
        public Reservation CalcTotal(Reservation reservation);
        
    }
}
