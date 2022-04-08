using DontWreckMyHouse.BLL;
using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using DontWreckMyHouse.CORE.Exceptions;
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

        private void Exit()
        {
            Environment.Exit(0);
        }


        private void ViewHost()
        {
            var host = GetHost();
            List<Reservation> reservations = _reservationService.FindAllReservation(host.Id);
            view.DisplayReservationsByHost(reservations);
            view.EnterToContinue();
        }
        private void MakeReservation()
        {
            view.DisplayHeader(MainMenuOption.MakeReservation.ToLabel());
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
            List<Reservation> reservations = _reservationService.FindAllReservation(host.Id);
            view.DisplayHeader($"Displaying all reservations for {host.LastName} - {host.Email}");
            view.DisplayReservations(reservations);
            Reservation reservation = view.MakeReservation(host, guest);
            Result<Reservation> result = _reservationService.MakeReservation(reservation);
            if (!result.Success)
            {
                view.DisplayStatus(false, result.Message);
            }
            else
            {
                if (view.DisplayTotalPrompt(result))
                {
                    Result<Reservation> resultToAdd = _reservationService.AddReservation(reservation);
                    string successMessage = $"Reservation {resultToAdd.Value.Id} created.";
                    view.DisplayStatus(true, successMessage);
                }
                else
                {
                    return;
                }

            }
        }
        private void CancelReservation()
        {
            view.DisplayHeader(MainMenuOption.CancelReservation.ToLabel());
            Host host = GetHost();
            List<Reservation> reservations = _reservationService.FindAllReservation(host.Id);
            if (!view.DisplayReservationsByHost(reservations))
            {
                return;
            }
            Guest guest = GetGuest();
            if (guest == null)
            {
                return;
            }
            view.DisplayHeader($"Displaying all reservations for {host.LastName} - {host.Email}");
            if (view.DisplayFutureReservations(reservations))
            {
                Reservation reservation = view.DeleteReservation(host, guest);
                bool result = _reservationService.Remove(reservation);
                if (!result)
                {
                    string failMessage = $"Reservation could not be found";
                    view.DisplayStatus(false, failMessage);
                }
                else
                {
                    string successMessage = $"Reservation {reservation.Id} cancelled.";
                    view.DisplayStatus(true, successMessage);
                }
            }
            else
            {
                return;
            }
        }


        private void EditReservation()
        {
            view.DisplayHeader(MainMenuOption.EditReservation.ToLabel());
            Host host = GetHost();
            List<Reservation> reservations = _reservationService.FindAllReservation(host.Id);
            if (!view.DisplayReservationsByHost(reservations))
            {
                return;
            }
            Guest guest = GetGuest();
            if (guest == null)
            {
                return;
            }
            view.DisplayHeader($"Displaying all reservations for {host.LastName} - {host.Email}");
            if (view.DisplayFutureReservations(reservations))
            {
                Reservation reservationIdFromUser = view.GetReservationId();
                Result<Reservation> reservationId = _reservationService.GetReservationID(reservations, reservationIdFromUser.Id);
                if (!reservationId.Success)
                {
                    view.DisplayStatus(false, reservationId.Message);
                    return;
                }
                Reservation reservation = view.EditReservation(host, guest, reservationId.Value);
                Result<Reservation> result = _reservationService.CheckB4Update(reservation);
                if (!result.Success)
                {
                    view.DisplayStatus(false, result.Message);
                }
                else
                {
                    if (view.DisplayTotalPrompt(result))
                    {
                        bool output = _reservationService.Edit(reservation);
                        if (!output)
                        {
                            string failMessage = $"Reservation could not be found";
                            view.DisplayStatus(false, failMessage);
                        }
                        else
                        {
                            string successMessage = $"Reservation {reservation.Id} Updated.";
                            view.DisplayStatus(true, successMessage);
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }

        }

        private Host GetHost()
        {
            string LastNamePrefix = view.GetLastNamePrefix("Host");
            List<Host> allHost = _hostService.FindByHostLastName(LastNamePrefix);
            return view.ChooseHosts(allHost);
        }

        private Guest GetGuest()
        {
            string LastNamePrefix = view.GetLastNamePrefix("Guest");
            List<Guest> allGuest = _guestService.FindByGuestLastName(LastNamePrefix);
            return view.ChooseGuests(allGuest);
        }

        


    }
    
}
