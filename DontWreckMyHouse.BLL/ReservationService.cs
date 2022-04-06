using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using DontWreckMyHouse.DAL;
namespace DontWreckMyHouse.BLL
{
    public class ReservationService 
    {
        private readonly IReservationRepo _reservationRepo;
        private readonly IHostRepo _hostRepo;
        private IGuestRepo _guestRepo;
        public ReservationService(IReservationRepo reservationRepo, IHostRepo hostRepo, IGuestRepo guestRepo)
        {
            _reservationRepo = reservationRepo;
            _hostRepo = hostRepo;
            _guestRepo = guestRepo;
        }
       


        
        public Result<List<Reservation>> FindByHost(Host host)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> Add(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> Remove(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> Edit(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> Add()
        {
            throw new NotImplementedException();
        }
    }
}