using DontWreckMyHouse.BLL;
using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using SustainableForaging.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.UI
{
    public class Controller
    {
        private readonly ReservationService _reservationService;
        private readonly HostService _hostService;
        private GuestService _guestService;
        private readonly View view;
        
        
        public Controller(ReservationService reservationService, HostService hostService, GuestService guestService, View view)
        {
            _reservationService = reservationService;
            _hostService = hostService;
            _guestService = guestService;
            this.view = view;
        }
        

        public void Run()
        {
            view.DisplayHeader("Main Menu");
            try
            {
                RunAppLoop();
            }
            catch (RepositoryException ex)
            {
                view.DisplayException(ex);
            }
            view.DisplayHeader("Goodbye.");
        }

        private void RunAppLoop()
        {
            MainMenuOption option;
            bool running = true;
            while (running)
            {


                option = view.SelectMainMenuOption();
                switch (option)
                {
                    case MainMenuOption.Exit:
                        Exit();
                        break;
                    case MainMenuOption.ViewReservationsForHost:
                        ViewHost();
                        break;
                    case MainMenuOption.MakeReservation:
                        MakeReservation();
                        break;
                    case MainMenuOption.EditReservation:
                        EditReservation();
                        break;
                    case MainMenuOption.CancelReservation:
                        CancelReservation();
                        break;
                    
             
                    
                }
            }
        }

        

        private void CancelReservation()
        {
            throw new NotImplementedException();
        }

        private void EditReservation()
        {
            throw new NotImplementedException();
        }

        private void MakeReservation()
        {
            Host host = GetHost();
            if (host == null)
            {
                return;
            }
            Guest guest = GetGuest();
            if (guest == null)
            {
                return;
            }
            Reservation reservation = view.CreateReservation(host, guest);
            Result<Reservation> result = _reservationService.Add(reservation);
            if (!result.Success)
            {
                view.DisplayReservation(false, result.Message);
            }
            else
            {
                string successMessage = $"Reservation made for {guest.FirstName} {guest.LastName}";
                view.DisplayReservation(true, successMessage);
            }
        }

        private Host GetHost()
        {
            throw new NotImplementedException();
        }

        private Guest GetGuest()
        {
            throw new NotImplementedException();
        }

        private void ViewHost()
        {
            throw new NotImplementedException();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
    
}
