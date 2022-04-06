using DontWreckMyHouse.BLL.Tests.TestDoubles;
using DontWreckMyHouse.CORE.DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.BLL.Tests
{
    public class GuestServiceTest
    {
        public class HostServiceTest
        {
            GuestService service = new GuestService(new GuestRepoDouble());

            [Test]
            public void GetHost_ShouldReturnAllHosts()
            {
                List<Guest> expected = new List<Guest>()
            {
                // Arrange
                new()
            {
               // guest_id,first_name,last_name,email,phone,state

                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "123foobar@yahoo.coom",
                    Phone = "5555555555",
                    State = "FL",


            }
            };

                // Act
                var actual = service.GetAll();

                // Assert
                Assert.AreEqual(expected, actual.Data);
            }
        }
    }
}
