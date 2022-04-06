using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DontWreckMyHouse.BLL;
using DontWreckMyHouse.BLL.Tests.TestDoubles;
using DontWreckMyHouse.CORE.DTO;
using NUnit.Framework;

namespace DontWreckMyHouse.BLL.Tests
{
    public class HostServiceTest
    {
        HostService service = new HostService(new HostRepoDouble());

        [Test]
        public void GetHosts_ShouldReturnAllHosts()
        {
            List<Host> expected = new List<Host>();
            {
                new()
                {
                    HostId = "1",
                    Email = "123foobar@yahoo.coom",
                    Phone = "5555555555"
                    Address = "123 Fake St",
                    City = "Faketown",
                    State = "FL",
                    PostalCode = "12345",
                    StandardRate = "100m",
                    WeekendRate = "150m",

                }
            // Arrange
            // Act
            var actual = service.GetHosts();

            // Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}
