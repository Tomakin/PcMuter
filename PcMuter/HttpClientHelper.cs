using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PcMuter
{
    public class HttpClientHelper
    {
        HttpClient client;
        string address = "Sakarya,Adapazari,Turkey";
        public HttpClientHelper()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://api.aladhan.com/v1/timingsByAddress/"),
            };
        }

        public async Task GetTimes()
        {
            //var responseMessage = await client.GetAsync($"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}?address={address}&method=13");
            //var resultString = await responseMessage.Content.ReadAsStringAsync();
            //var result = JsonSerializer.Deserialize<SalahTimes>(resultString);
            //GlobalVars.Times = result.data.timings;
            FakeIT();
        }

        public async Task FakeIT()
        {
            string time = "18:00";
            GlobalVars.Times = new Timings()
            {
                Asr = time,
                Dhuhr = time,
                Isha = time,
                Maghrib = time,
                Sunrise = time
            };
        }
    }
}
