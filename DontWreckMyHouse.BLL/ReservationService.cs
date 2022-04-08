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


        public List<Reservation> FindAllReservation(string hostId) //Find all Info within Hostfile
        {
            Dictionary<string, Host> hostMap = _hostRepo.FindAllHost()
                    .ToDictionary(i => i.Id);
            Dictionary<int, Guest> guestMap = _guestRepo.FindAllGuest()
                    .ToDictionary(i => i.Id);

            List<Reservation> result = _reservationRepo.FindByHost(hostId);
            foreach (var reservation in result)
            {
                reservation.Host = hostMap[reservation.Host.Id];
                reservation.Guest = guestMap[reservation.Guest.Id];
            }
            return result;
        }

        
        

        
        public List<Host> FindByHostLastName(string prefix)
        {
            return _hostRepo.FindAllHost()
                .Where(h => h.LastName.StartsWith(prefix))
                .ToList();
        }
        public Result<Reservation> MakeReservation(Reservation reservation)
        {
            Result<Reservation> result = Validate(reservation);
            if (!result.Success)
            {
                return result;
            }
            reservation.Total = reservation.GetTotal();
            result.Value = reservation;
            return result;
        }

        public Result<Reservation> Remove(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> Edit(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Result<Reservation> AddReservation(Reservation reservation)
        {
            Result<Reservation> result = new();
            result.Value = _reservationRepo.AddReservation(reservation);
            return result;
        }
        private Result<Reservation> Validate(Reservation reservation)
        {
            Result<Reservation> result = ValidateNulls(reservation);
            if (!result.Success)
            {
                return result;
            }

            ValidateFields(reservation, result);
            if (!result.Success)
            {
                return result;
            }

            ValidateChildrenExist(reservation, result);
            if (!result.Success)
            {
                return result;
            }

            List<Reservation> reservations = _reservationRepo.FindByHost(reservation.Host.Id);
            var currentReservation = reservations.FirstOrDefault(
                x => (x.StartDate <= reservation.StartDate && x.EndDate >= reservation.StartDate)
                || (x.StartDate <= reservation.EndDate && x.EndDate >= reservation.EndDate));

            if (currentReservation != null)
            {
                result.AddMessage($"Reservation dates overlap with reservation {currentReservation.Id}, {currentReservation.StartDate} - {currentReservation.EndDate}");
                return result;
            }

            return result;
        }

        private Result<Reservation> ValidateNulls(Reservation reservation)
        {
            Result<Reservation> result = new Result<Reservation>();
            if (reservation == null)
            {
                result.AddMessage("Reservation is null.");
                return result;
            }
            if (reservation.Host == null)
            {
                result.AddMessage("Host is null.");
                return result;
            }
            if (reservation.Guest == null)
            {
                result.AddMessage("Guest is null.");
                return result;
            }
            return result;
        }
        private void ValidateFields(Reservation reservation, Result<Reservation> result)
        {
            if (reservation.StartDate < DateOnly.FromDateTime(DateTime.Now))
            {
                result.AddMessage("Date cannot be in the past.");
            }
            if (reservation.EndDate < reservation.StartDate)
            {
                result.AddMessage("End date cannot be before start date.");
            }
        }

        private void ValidateChildrenExist(Reservation reservation, Result<Reservation> result)
        {
            if (reservation.Host.Id == null
                    || _hostRepo.FindByEmail(reservation.Host.Email) == null)
            {
                result.AddMessage("Host does not exist.");
            }

            if (reservation.Host.Id == null
                    || _guestRepo.FindByEmail(reservation.Guest.Email) == null)
            {
                result.AddMessage("Guest does not exist.");
            }
        }
    }


}
