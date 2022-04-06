using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.UI
{
    public class Controller
    {
        public void Run()
        {
            var model = new Model();
            var view = new View();
            var controller = new Controller(model, view);
            view.Controller = controller;
            view.Run();



        }
    }
}
