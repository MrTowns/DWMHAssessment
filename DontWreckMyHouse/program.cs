using Ninject;
using System;
using System.IO;
using DontWreckMyHouse.BLL;
using DontWreckMyHouse.DAL;
namespace DontWreckMyHouse.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NinjectContainer.Configure();
            Controller controller = NinjectContainer.kernel.Get<Controller>();
            controller.Run();
        }

    }
}