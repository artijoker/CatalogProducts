using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public class Clock : IClock 
    {
        public DateTime GetClock() => DateTime.Now;
    }
}
