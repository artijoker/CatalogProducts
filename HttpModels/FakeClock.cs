using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpModels
{
    public class FakeClock : IClock
    {
        public DateTime GetClock() => new DateTime(2022, 2, 9);
    }
}
