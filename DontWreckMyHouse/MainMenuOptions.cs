using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.UI
{
    public enum MainMenuOption
    {
        Exit,
        ViewReservationsForHost,
        MakeReservation,
        EditReservation,
        CancelReservation,
        Generate,
    }

    public static class MainMenuOptionExtensions
    {
        public static string ToLabel(this MainMenuOption option) => option switch
        {
            MainMenuOption.Exit => "Exit",
            MainMenuOption.ViewReservationsForHost => "View reservation for host",
            MainMenuOption.MakeReservation => "Make reservation",
            MainMenuOption.EditReservation => "Edit reservation",
            MainMenuOption.CancelReservation => "cancel reservation",
        };

        public static bool IsHidden(this MainMenuOption option) => option switch
        {
            MainMenuOption.Generate => true,
            _ => false
        };
    }
}
