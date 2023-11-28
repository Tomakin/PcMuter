using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcMuter
{
    public static class AudioControl
    {
        //private static float originalVolume;

        public static void Mute()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);


            // Ses düzeyini sıfıra indir
            device.AudioEndpointVolume.Mute = true;
        }

        public static void Unmute()
        {
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);

            // Orijinal ses düzeyini geri yükle
            device.AudioEndpointVolume.Mute = false;
        }
    }
}
