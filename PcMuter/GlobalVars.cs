using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcMuter
{
    public static class GlobalVars
    {
        public static Timings Times { get; set; }
        public static List<Timer> Timers { get; set; } = new List<Timer>();
    }
}
