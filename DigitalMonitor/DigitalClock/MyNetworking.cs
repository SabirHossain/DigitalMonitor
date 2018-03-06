using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalClock
{
    public static class MyNetworking
    {
        public static string ActiveNetworkInterface()
        {
            string TwitIP = "199.59.149.230";
            try
            {
                UdpClient u = new UdpClient(TwitIP, 1);
                IPAddress localAddr = ((IPEndPoint)u.Client.LocalEndPoint).Address;

                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    IPInterfaceProperties ipProps = nic.GetIPProperties();
                    foreach (UnicastIPAddressInformation addrinfo in ipProps.UnicastAddresses)
                    {
                        if (localAddr.Equals(addrinfo.Address))
                        {
                            return nic.Description;
                        }
                    }
                }
            }
            catch
            {
                return "not found";
            }
            return "not found";
        }

        public static async Task<bool> CheckForInternetConnection()
        {
            Uri uri = new Uri("http://clients3.google.com/generate_204");
            try
            {
                 using (var client = new WebClient())
                {
                    using (await Task.Run(() => client.OpenReadTaskAsync(uri)))
                    {
                        return true;
                    }
                }
            }
            catch(WebException ex)
            {
                return false;
            }
            catch (ArgumentNullException ex)
            {
                return false;
            }
            catch
            {
                return false;
            }
        }
       
        public static PerformanceCounter DownloadCounter(string UPorDOWN)
        {
            PerformanceCounterCategory pcg = new PerformanceCounterCategory("Network Interface");
            PerformanceCounter instanceDown = new PerformanceCounter();
            PerformanceCounter instanceUp = new PerformanceCounter();
            ArrayList instancesList2 = new ArrayList();
            try
            {
                foreach (string name in pcg.GetInstanceNames())
                {
                    if (name.Equals(ActiveNetworkInterface()))
                    {
                        instanceDown = new PerformanceCounter("Network Interface", "Bytes Received/sec", name);
                        instanceUp = new PerformanceCounter("Network Interface", "Bytes Sent/sec", name);
                    }
                }
            }
            catch(Exception ex)
            {
                return new PerformanceCounter();
            }
            switch (UPorDOWN)
            {
                case "down":
                    return instanceDown;
                case "up":
                    return instanceUp;
                default:
                    return new PerformanceCounter();
            }
        }
    }
}
