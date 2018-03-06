using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public static class Utility
    {
        public static async void StopMusic(SoundPlayer sound, int second, bool alarmStoped)
        {
            if (!alarmStoped)
            {
                await Task.Delay(TimeSpan.FromSeconds(second));
                sound.Stop();
            }
            else
            {
                return;
            }
        }
    }
}
