using NUnit.Framework;
using DontWreckMyHouse.BLL;
using DontWreckMyHouse.BLL.Tests.TestDoubles;
using DontWreckMyHouse.CORE.DTO;
using System.Collections.Generic;
using System;

namespace BLLTestProject
{
    
    public class ReservationServiceTest
    {

        ReservationService reservationService = new ReservationService(
            new ReservationRepoDouble(),
            new HostRepoDouble(),
            new GuestRepoDouble());


            [Test]
            public void GetHost_ShouldReturnAllHosts()
            {
                List<Reservation> expected = new List<Reservation>()
            {
                // Arrange
                new()
                {
                    Id = 1,
                    StartDate = new DateTime(2018, 1, 1),
                    EndDate = new DateTime(2018, 1, 2),
                    GuestId = "1",
                    Total = 1000.00M

                }
            };

            // Act

            var actual = reservationService.Add();
            Assert.AreEqual(expected, actual.Data);
        }
    }
}