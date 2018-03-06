using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalClock
{
    public static class HddInfo
    {
       public static double getTotalHdd(DriveInfo[] allDrive)
       {
            double size = 0;
            
            foreach(var d in allDrive)
            {
                if (d.IsReady)
                {
                    size += d.TotalSize;
                }
               
            }
            return (size / 1024 / 1024 / 1024);
       }

        public static double getHddPercen(DriveInfo[] allDrive)
        {
            double size = 0;

            foreach (var d in allDrive)
            {
                if (d.IsReady)
                {
                    size += d.TotalFreeSpace;
                }

            }

            size = (double)((decimal)size / (decimal)getTotalHdd(allDrive)) * 100;

            size = Math.Round(size, 1);

            return (100 - (size / 1024 / 1024 / 1024));
        }
    }
}
