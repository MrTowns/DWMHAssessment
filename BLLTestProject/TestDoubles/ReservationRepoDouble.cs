﻿using DontWreckMyHouse.CORE.DTO;
using DontWreckMyHouse.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL.Tests.TestDoubles
{
    public class ReservationRepoDouble : IReservationRepo
    {
        private readonly List<Reservation> _reservation = new List<Reservation>();
        Reservation reservation = new Reservation()
        {
            Id = 1,
            StartDate = new DateTime(2018, 1, 1),
            EndDate = new DateTime(2018, 1, 2),
            GuestId = "1",
            Total = 1000.00M
        };

        public Reservation Add(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation CalcTotal(Reservation reservation)
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
