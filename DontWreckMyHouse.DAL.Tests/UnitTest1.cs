using NUnit.Framework;
using System.IO;

namespace DontWreckMyHouse.DAL.Tests
{
    public class Tests
    {
        string path = Directory.GetCurrentDirectory() + "\\test.csv";

        [SetUp]
        public void Setup()
        {
            string HEADER = "id,start_date,end_date,guest_id,total";
           


        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}