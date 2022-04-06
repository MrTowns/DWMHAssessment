using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DontWreckMyHouse.CORE.DTO
{
    public class Result<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }
        public Result<T> Data { get; set; }

        

        
    }
}
/*private List<string> messages = new List<string>();
public bool Success => messages.Count == 0;
public List<string> Messages => new List<string>(messages);*/