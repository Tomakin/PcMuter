using PcMuter;
using System.Threading.Tasks;

HttpClientHelper clientHelper = new HttpClientHelper();
await clientHelper.GetTimes();
SetSalahTimers();

SetDailySalahTimer();

Console.WriteLine("Uygulama çalışıyor. Çıkış yapmak için bir tuşa basın.");
Console.ReadKey();

static void SetTimer(string time)
{
    DateTime now = DateTime.Now;
    DateOnly dateOnly = new DateOnly(now.Year, now.Month, now.Day);
    var times = time.Split(':');
    var timeOnly = new TimeOnly(int.Parse(times[0]), int.Parse(times[1]));
    DateTime scheduledTime = new DateTime(dateOnly, timeOnly).AddMinutes(-3); // apiden çekilen zamandan 3 dakika önceye ayarla

    if (scheduledTime > now)
    {
        TimerCallback timerCallback = new TimerCallback(TimerTick);
        //Timer timer = new Timer(timerCallback, null, (int)(scheduledTime - now).TotalMilliseconds, Timeout.Infinite);
        Timer timer = new Timer(timerCallback, null, 2000, Timeout.Infinite);
        GlobalVars.Timers.Add(timer);
    }
}


static void TimerTick(object state)
{
    // Ses düzeyini sıfıra indir
    AudioControl.Mute();

    // Belirli bir süre sonra sesi geri yükle
    Thread.Sleep(1 * 5 * 1000); // dakika
    AudioControl.Unmute();
}

static void SetDailySalahTimer()
{
    DateTime now = DateTime.Now;
    DateTime scheduledTime = new DateTime(now.Year, now.Month, now.Day, 4, 0, 0);

    if (now > scheduledTime)
    {
        scheduledTime = scheduledTime.AddDays(1);
    }


    TimerCallback timerCallback = new TimerCallback(state => Task.Factory.StartNew(() => GetSalahTimes(state)));

    Timer timer = new Timer(timerCallback, null, (scheduledTime - DateTime.Now).Milliseconds, (int)(TimeSpan.FromDays(1).TotalMilliseconds));

    GlobalVars.Timers.Add(timer);
}


static async Task GetSalahTimes(object state)
{
    HttpClientHelper clientHelper = new HttpClientHelper();
    await clientHelper.GetTimes();
    SetSalahTimers();
}

static void SetSalahTimers()
{
    GlobalVars.Timers.Clear();
    SetTimer(GlobalVars.Times.Sunrise);
    //SetTimer(GlobalVars.Times.Dhuhr);
    //SetTimer(GlobalVars.Times.Asr);
    //SetTimer(GlobalVars.Times.Maghrib);
    //SetTimer(GlobalVars.Times.Isha);
}