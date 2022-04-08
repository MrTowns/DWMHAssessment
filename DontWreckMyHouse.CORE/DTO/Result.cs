using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.DTO
{
    public class Result<T>
    {
        public bool Success => messages.Count == 0;

        private List<string> messages = new List<string>();
        public List<string> Message => new List<string>(messages);
        public Result<T> Data { get; set; }

        public T Value { get; set; }
        
       
        public void AddMessage(string message)
        {
            messages.Add(message);
        }


    }
}
/*private List<string> messages = new List<string>();
public bool Success => messages.Count == 0;
public List<string> Messages => new List<string>(messages);*/