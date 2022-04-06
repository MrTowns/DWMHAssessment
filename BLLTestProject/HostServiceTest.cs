using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DontWreckMyHouse.BLL;
using DontWreckMyHouse.BLL.Tests.TestDoubles;
using DontWreckMyHouse.CORE.DTO;
using NUnit.Framework;
using DontWreckMyHouse.DAL;
namespace DontWreckMyHouse.BLL.Tests
{
    public class HostServiceTest 
    {
        HostService service = new HostService(new HostRepoDouble());

        [Test]
        public void GetHost_ShouldReturnAllHosts()
        {
            List<Host> expected = new List<Host>()
            {
                // Arrange
                new()
                {
                    HostId = "1",
                    HostName = "John",
                    Email = "123foobar@yahoo.com",
                    Phone = "5555555555",
                    Address = "123 Fake St",
                    City = "Faketown",
                    State = "FL",
                    PostalCode = "12345",
                    StandardRate = 100.00M,
                    WeekendRate = 150.00M,

                }
            };
            
            // Act
            var actual = service.GetAll();

            // Assert
            Assert.AreEqual(expected, actual.Data);
        }
    }
}
