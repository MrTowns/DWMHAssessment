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
        public List<Reservation> FindByHost(string hostid);

        public Reservation AddReservation(Reservation reservation);

        public bool Remove(Reservation reservation);

        public bool Edit(Reservation reservation);
        
       
        
    }
}
