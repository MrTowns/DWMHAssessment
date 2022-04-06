using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.DTO
{
    public class Reservation
    {
        //id,start_date,end_date,guest_id,total
        public string HostId { get; set; }
        
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string GuestId { get; set; }

        public decimal Total { get; set; }

        public decimal GetTotal { get; set; }

        






        
       /* {
            decimal weekendPrice = 0M;
            decimal weekdayPrice = 0M;
            for (var day = StartDate.Date; day <= EndDate.Date; day = day.AddDays(1))
            {
                if (day.DayOfWeek == DayOfWeek.Sunday || day.DayOfWeek == DayOfWeek.Saturday)
            {
                weekendPrice = weekendPrice + Host.WeekendRate;
            }
                else
                {
                weekdayPrice = weekdayPrice + Host.RegRate;
                }
            }
            decimal cost = weekdayPrice + weekendPrice;
            return cost;*/
        
    }
}
