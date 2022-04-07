using DontWreckMyHouse.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.UI
{
    public class View
    {
       


        private readonly ConsoleIO io;

        public View(ConsoleIO io)
        {
            this.io = io;
        }

        public MainMenuOption SelectMainMenuOption()
        {
            DisplayHeader("Main Menu");
            int min = int.MaxValue;
            int max = int.MinValue;
            MainMenuOption[] options = Enum.GetValues<MainMenuOption>();
            for (int i = 0; i < options.Length; i++)
            {
                MainMenuOption option = options[i];
                if (!option.IsHidden())
                {
                    io.PrintLine($"{i}. {option.ToLabel()}");
                }
                min = Math.Min(min, i);
                max = Math.Max(max, i);
            }

            string message = $"Select [{min}-{max - 1}]: ";
            return options[io.ReadInt(message, min, max)];
        }

        


        public void DisplayReservation(bool success, string message)
        {
            DisplayStatus(success, new List<string>() { message });
        }

        public Reservation CreateReservation(Host host, Guest guest)
        {
            Reservation reservation = new Reservation();
            reservation.Host = host;
            reservation.Guest = guest;
            reservation.StartDate = io.ReadDate("Reservation start date [MM/dd/yyyy]: ");
            reservation.EndDate = io.ReadDate("Reservation end date [MM/dd/yyyy]: ");
            //reservation.TotalPrice = standardrate/weekendrate

            return reservation;
        }
        public DateTime GetStartDate()
        {
            DisplayHeader("Choose a reservation start date: ");
            return io.ReadDate("Select a date [MM/dd/yyyy]: ");
        }
        public DateTime GetEndDate()
        {
            DisplayHeader("Choose a reservation end date: ");
            return io.ReadDate("Select a date [MM/dd/yyyy]: ");
        }







        public void EnterToContinue()
        {
            io.ReadString("Press [Enter] to continue.");
        }

        // display only
        public void DisplayHeader(string message)
        {
            io.PrintLine("");
            io.PrintLine(message);
            io.PrintLine(new string('=', message.Length));
        }

        public void DisplayException(Exception ex)
        {
            DisplayHeader("A critical error occurred:");
            io.PrintLine(ex.Message);
        }

        public void DisplayStatus(bool success, string message)
        {
            DisplayStatus(success, new List<string>() { message });
        }

        public void DisplayStatus(bool success, List<string> messages)
        {
            DisplayHeader(success ? "Success" : "Error");
            foreach (string message in messages)
            {
                io.PrintLine(message);
            }
        }

       
    }

}
