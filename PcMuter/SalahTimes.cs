using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcMuter
{
    public class SalahTimes
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public Timings timings { get; set; }
    }
    public class Timings
    {
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Maghrib { get; set; }
        public string Isha { get; set; }
    }
}
