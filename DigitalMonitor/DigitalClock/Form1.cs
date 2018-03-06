using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Net;
using System.Collections.ObjectModel;
using NativeWifi;
using System.Globalization;
using System.Media;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Collections;
using System.Threading;

namespace DigitalClock
{
    public partial class Form1 : Form
    {
        #region Local Fields
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();

        public PerformanceCounter cpuCounter;
        public PerformanceCounter ramCounter;
        public PerformanceCounter hddCounter;
        PerformanceCounterCategory pcg ;
        List<PerformanceCounter> instanceDown;
        List<PerformanceCounter> instanceUp;
        public WlanClient wlan;
        DriveInfo[] allDrives;
        public Collection<String> connectedSsids;
        public string internalSSID = "No Internet";
        public string SSID;
        public string ActiveNetworkAdapter;
        public bool nointernet = false;
        public bool connection;
        public int freeram;
        public decimal ramusage;
        public decimal cpucount;
        public int signal = 0;
        public int TotalRam = 0;
        public string NAME = "";
        float oldDown;
        float oldUp;
        bool CheckBoxHandeler = true;
        double cpuusage;
        double diskusage;
        public static WebRequest WebReq;
        public static WebResponse Resp;
        SoundPlayer sound;
        public bool netGone = false;
        public DateTime alarmtime;
        bool AlarmNotCancaled = false;

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
        PerformanceCounter DownloadCounter;
        PerformanceCounter UploadCounter;
        #endregion

        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StratSplash));
            t.Start();
            InitializeComponent();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            hddCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            pcg = new PerformanceCounterCategory("Network Interface");
            wlan = new WlanClient();
            allDrives = DriveInfo.GetDrives();
            instanceDown = new List<PerformanceCounter>();
            connectedSsids = new Collection<string>();
            instanceUp = new List<PerformanceCounter>();
            getActiveCounters();

            #region Font Initializing
            namelabel.Font = DigitalFont(14.25F, false, true);
            txtSecond.Font = DigitalFont(27.7F, false, true); ;
            txtHourMin.Font = DigitalFont(48, true, false);
            txtDay.Font = DigitalFont(21.75F, false, true);
            txtDate.Font = DigitalFont(27.75F, true, false);
            txt_cpu_label.Font = DigitalFont(15.75F, true, false);
            cpu_label.Font = DigitalFont(15.75F, true, false);
            ram_label.Font = DigitalFont(15.75F, true, false);
            txt_ram_label.Font = DigitalFont(15.75F, true, false);
            txt_dwn.Font = DigitalFont(15.75F, true, false);
            down_label.Font = DigitalFont(15.75F, true, false);
            upload_label.Font = DigitalFont(15.75F, true, false);
            upload_txt.Font = DigitalFont(15.75F, true, false);
            txt_hdd.Font = DigitalFont(15.75F, true, false);
            hdd_label.Font = DigitalFont(15.75F, true, false);
            internet_label.Font = DigitalFont(11.25F, false, true);
            txt_signal.Font = DigitalFont(11F, true, false);
            txt_hdd_label.Font = DigitalFont(11.25F, true, false);
            txt_hdd_size.Font = DigitalFont(11.25F, true, false);
            txt_hdd_percentage.Font = DigitalFont(11F, true, false);
            netsign_label.Font = DigitalFont(15F, true, false);
            #endregion

            #region Ticker Initialization
            upload_label.BringToFront();
            upload_txt.BringToFront();
            internet_label.BringToFront();

            timer1.Start();
            nametimer.Start();
            hardware_timer2.Interval = 1850;
            hardware_timer2.Start();
            internet_connection_timer.Start();
            mouse_timer.Start();
            updowntimer.Interval = 1000;
            updowntimer.Start();
            servernetworkchecktimer.Interval = 25000;
            servernetworkchecktimer.Start();
            #endregion

            #region Alarm UI Initialize
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "hh:mm:tt";
            dateTimePicker1.ShowUpDown = true;
            ContextMenuStrip = contextMenuStrip4;
            Stream str = Properties.Resources.Alarm01;
            sound = new SoundPlayer(str);
            dateTimePicker1.Hide();
            btnSetAlaram.Hide();
            radioOff.Hide();
            radioOn.Hide();
            radioOnce.Hide();
            radioEveryday.Hide();
            btnStopAlarm.Hide();
            btnAlaramSettings.Hide();
            #endregion

            txt_hdd_size.Text = Math.Round(HddInfo.getTotalHdd(allDrives), 1).ToString() + " GB";
            internet_label.MaximumSize = new Size(160, 16);
            colorProgressBar2.Value = (int)HddInfo.getHddPercen(allDrives);
            txt_hdd_percentage.Text = colorProgressBar2.Value.ToString() + "%";
            netsign_label.Location = new Point(internet_label.Location.X + internet_label.Width, netsign_label.Location.Y);
            MaximumSize = new Size(456, 210);


            t.Abort();

            this.TopMost = true;
            alwaysOnTopToolStripMenuItem3.Checked = true;

            BackColor = (Color)Properties.Settings.Default["backColor"];
            this.Icon = Properties.Resources.DigitalMonitorIcon;
            systraynotifyicon.Icon = Properties.Resources.ballonIcon;

            Opacity = Convert.ToDouble(Properties.Settings.Default["opacity"]);
            label1.BackColor = (Color)Properties.Settings.Default["backColor"];
            bool alwaysTop = (bool)Properties.Settings.Default["alwayonTop"];
            if (alwaysTop)
            {
                this.TopMost = true;
                alwaysOnTopToolStripMenuItem3.Checked = true;
            }

            bool isTransparent = (bool)Properties.Settings.Default["Transparent"];
            if (isTransparent)
            {
                this.TransparencyKey = this.BackColor;
                transparentToolStripMenuItem.Checked = true;
            }

            bool isAlarm = (bool)Properties.Settings.Default["isAlaramOn"];
            bool isAlarmEveryday = (bool)Properties.Settings.Default["everydayAlarm"];
            bool isAlarmPending = (bool)Properties.Settings.Default["isAlarmPending"];

            if (isAlarm && (isAlarmEveryday || isAlarmPending))
            {
                alaramTimer.Start();
            }
        }

        /*  FORM LOAD.................................................*/
        private async void Form1_Load(object sender, EventArgs e)
        {
            //   MyNetworking.getLineSpeed();
            string path = "SabirsDigitalClockYourName.sabir";
            //RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
            //("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //if (registryKey.GetValue("DigitalMonitor") == null)
            //{
            //    registryKey.SetValue("DigitalMonitor", Application.ExecutablePath);
            //}

            //Initializing Active Adapters for getting download upload
            IniNetwork(pcg);

           /*getting User Name */
            var name = Recurse();

            File.WriteAllText(path, name);

            if (name == "" || String.IsNullOrEmpty(name))
            {
                namelabel.Text = NAME;
            }
            else
            {
                namelabel.Text = name;
            }

            //  #if DEBUG
            systraynotifyicon.Visible = true;
            systraynotifyicon.BalloonTipText = "DM has started\nFor monitoring the system.";
            systraynotifyicon.ShowBalloonTip(500);
            //#endif
            TotalRam = (int)(getTotalRam() / 1024);
            ActiveNetworkAdapter = MyNetworking.ActiveNetworkInterface();
            try
            {
                if (await MyNetworking.CheckForInternetConnection())
                {
                    SSID = getSSID();
                    nointernet = false;
                }
                else
                {
                    SSID = "No Internet";
                    nointernet = true;
                }
            }
            catch
            {
                SSID = "No Internet";
                nointernet = true;
            }

        }

        #region WIFI DATA
        /*GETTING INTERNET CONNECTION*/
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connDescription, int ReservedValue);
        //check if a connection to the Internet can be established
        public static bool IsConnectionAvailable()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }
        public string getSSID()
        {
            if (nointernet)
            {
                return internalSSID;
            }

            try
            {
                foreach (WlanClient.WlanInterface wlanInterface in wlan.Interfaces)
                {
                    Wlan.Dot11Ssid ssid = wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                    connectedSsids.Add(new String(Encoding.ASCII.GetChars(ssid.SSID, 0, (int)ssid.SSIDLength)));
                }

                foreach (var item in connectedSsids)
                {
                    internalSSID = item;
                }
            }
            catch
            {
                nointernet = true;
                return internalSSID;
            }

            return internalSSID;
        }
        private int getSignal()
        {
            if (nointernet)
            {
                return 0;
            }
            try
            {
                foreach (WlanClient.WlanInterface wlanIface in wlan.Interfaces)
                {
                    Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                    foreach (Wlan.WlanAvailableNetwork network in networks)
                    {
                        if (network.profileName.Equals(SSID))
                        {
                            signal = Convert.ToInt32(network.wlanSignalQuality.ToString());
                        }
                    }
                }
            }
            catch
            {
                if (!IsConnectionAvailable() || !nointernet)
                {
                    nointernet = true;
                }
                return 0;
            }

            return signal;
        }
        #endregion

        #region Utility Functions
        private void getActiveCounters()
        {
            DownloadCounter = MyNetworking.DownloadCounter("down");
            UploadCounter = MyNetworking.DownloadCounter("up");
        }
        private float GetAvg(ArrayList log)
        {
            float tot = 0;
            foreach (float n in log)
                tot += n;
            float avg = tot / log.Count;
            log.Clear();
            return avg;
        }

        private void updateCounter()
        {
            if (nointernet || !IsConnectionAvailable())
            {
                down_label.Text = "0 KB/s";
                upload_label.Text = "0 KB/s";
                return;
            }
            oldDown = oldUp = 0;
            try
            {
                try
                {
                    oldDown += DownloadCounter.NextValue();
                    oldUp += UploadCounter.NextValue();
                }
                catch
                {
                    try
                    {
                        foreach (var item in instanceDown)
                        {
                            oldDown += item.NextValue();
                        }
                        foreach (var item in instanceUp)
                        {
                            oldUp += item.NextValue();
                        }
                    }
                    catch
                    {
                        down_label.Text = "0 KB/s";
                        upload_label.Text = "0 Kb/s";
                        return;
                    }
                    
                }

                oldDown = (float)Math.Round(oldDown / 1024, 1);
                if (oldDown > 1024)
                {
                    oldDown = (float)Math.Round((oldDown / 1024), 1);
                    down_label.Text = oldDown.ToString() + " MB/s";
                }
                else
                {
                    down_label.Text = oldDown.ToString() + " KB/s";
                }

                oldUp = (float)Math.Round(oldUp / 1024, 1);
                if(oldUp > 1024)
                {
                    oldUp = (float)Math.Round(oldUp / 1024, 1);
                    upload_label.Text = oldUp.ToString() + " MB/s";
                }
                else
                {
                    upload_label.Text = oldUp.ToString() + " KB/s";
                }
            }
            catch
            {
                down_label.Text = "0 KB/s";
                upload_label.Text = "0 KB/s";
                return;
            }
            
        }

        public void IniNetwork(PerformanceCounterCategory pccg)
        {
            foreach (var item in pccg.GetInstanceNames())
            {
                instanceDown.Add(new PerformanceCounter("Network Interface", "Bytes Received/sec", item));
                instanceUp.Add(new PerformanceCounter("Network Interface", "Bytes Sent/sec", item));
            }
        }

        public void StratSplash()
        {
            Application.Run(new SplashForm());
        }

        //FORM MOVING BY MOUSE CURSOR
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }
        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        //FORM MOVING BY MOUSE CURSOR END

        //FONT STYLE EMBEDING
        public Font DigitalFont(float size, bool bold, bool italic)
        {
            byte[] fontData = Properties.Resources.DS_DIGIB;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.DS_DIGIB.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.DS_DIGIB.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);

            if (bold && italic)
            {
                return new Font(fonts.Families[0], size, FontStyle.Bold | FontStyle.Italic);
            }
            else if (!italic && bold)
            {
                return new Font(fonts.Families[0], size, FontStyle.Bold);
            }
            else if (italic && !bold)
            {
                return new Font(fonts.Families[0], size, FontStyle.Italic);
            }
            else
            {
                return new Font(fonts.Families[0], size);
            }
        }

        /*CPU COUNTER GETTING CPU USAGE*/
        private long getTotalRam()
        {
            ComputerInfo v = new ComputerInfo();
            GetPhysicallyInstalledSystemMemory(out long memKb);
            return memKb;
        }
        private double getCpu(string hardware)
        {
            if (hardware.Equals("cpu"))
            {
                cpucount = (decimal)cpuCounter.NextValue();
                cpucount = Math.Round(cpucount, 1);
                return (double)cpucount;
            }
            else if (hardware.Equals("ram"))
            {
                return ramCounter.NextValue();
            }
            else if (hardware.Equals("disk"))
            {
                return Math.Round(hddCounter.NextValue(), 1);
            }
            return -1;
        }
        /*FILE SYSTEM AND USER VALIDATION*/
        private string Recurse()
        {
            string path = "SabirsDigitalClockYourName.sabir";
            string readName = "";
            try
            {
                readName = File.ReadAllText(path);
            }
            catch
            {
                File.WriteAllText(path, "");
            }

            if (!String.IsNullOrWhiteSpace(readName))
            {
                return readName;
            }

            string promptValue = Prompt.ShowDialog("Please enter your name", "123");
            NAME = promptValue;
            if (String.IsNullOrWhiteSpace(promptValue))
            {
                DialogResult dr = MessageBox.Show("You must enter your name before continue.\nDo you want to exit?",
                    "Exit Alert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                if (dr == DialogResult.No)
                {
                    Recurse();
                }
                else
                {
                    this.Close();
                }
            }
            return promptValue;
        }
        #endregion
       


        #region All Other Tickers Clicks and Others Handler
        /*CLOSE BUTTON*/
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*TIME TIMER*/
        private void Timer_1_Method(object sender, EventArgs e)
        {
            txtSecond.Location = new Point(txtHourMin.Location.X + txtHourMin.Width - 15, txtSecond.Location.Y);
            txtDay.Location = new Point(txtHourMin.Location.X + txtHourMin.Width - 15, txtDay.Location.Y);
            txtHourMin.Text = DateTime.Now.ToString("hh:mm") + ":";
            txtSecond.Text = DateTime.Now.ToString("ss tt");
            txtDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            txtDay.Text = DateTime.Now.ToString("dddd");
        }
        /*NAME TIMER*/
        private void name_ticker(object sender, EventArgs e)
        {
            if (IsConnectionAvailable() && !nointernet)
            {
                if (namelabel.ForeColor == Color.LimeGreen)
                {
                    namelabel.ForeColor = Color.Black;
                }
                else
                {
                    namelabel.ForeColor = Color.LimeGreen;
                }
            }
            else
            {
                if (namelabel.ForeColor == Color.OrangeRed)
                {
                    namelabel.ForeColor = Color.Black;
                }
                else
                {
                    namelabel.ForeColor = Color.OrangeRed;
                }
            }

        }

        private void txtHourMin_Click(object sender, EventArgs e)
        {

        }

        private void main_for_hover(object sender, MouseEventArgs e)
        {
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void hardware_timer2_tick(object sender, EventArgs e)
        {
            cpuusage = getCpu("cpu");
            if (cpuusage > 100)
            {
                cpuusage = 98.2;
            }
            cpu_label.Text = cpuusage + "%";

            diskusage = getCpu("disk");
            if (diskusage > 100)
            {
                diskusage = 98.2;
            }
            hdd_label.Text = diskusage.ToString() + "%";

            freeram = (int)getCpu("ram");
            ramusage = freeram / (decimal)TotalRam * 100;
            ramusage = 100 - ramusage * 100 / 100;
            ramusage = Math.Round(ramusage, 1);
            if (ramusage > 100)
            {
                ramusage = 80;
            }
            ram_label.Text = ramusage.ToString() + "%";

            // updateCounter();
#region Text Coloring
            if (ramusage > 50 && ramusage < 80 && ram_label.ForeColor != Color.LightSalmon)
            {
                ram_label.ForeColor = Color.LightSalmon;
            }
            else if (ramusage > 79 && ramusage < 99 && ram_label.ForeColor != Color.OrangeRed)
            {
                ram_label.ForeColor = Color.OrangeRed;
            }
            else if (ramusage > 98 && ram_label.ForeColor != Color.Red)
            {
                ram_label.ForeColor = Color.Red;
            }
            else if (ramusage < 50 && ram_label.ForeColor != Color.Lime)
            {
                ram_label.ForeColor = Color.Lime;
            }

            if (cpuusage > 50 && cpuusage < 80 && cpu_label.ForeColor != Color.LightSalmon)
            {
                cpu_label.ForeColor = Color.LightSalmon;
            }
            else if (cpuusage > 79 && cpuusage < 99 && cpu_label.ForeColor != Color.OrangeRed)
            {
                cpu_label.ForeColor = Color.OrangeRed;
            }
            else if (cpuusage > 98 && cpu_label.ForeColor != Color.Red)
            {
                cpu_label.ForeColor = Color.Red;
            }
            else if (cpuusage < 50 && cpu_label.ForeColor != Color.Lime)
            {
                cpu_label.ForeColor = Color.Lime;
            }

            if (diskusage > 50 && diskusage < 80 && hdd_label.ForeColor != Color.LightSalmon)
            {
                hdd_label.ForeColor = Color.LightSalmon;
            }
            else if (diskusage > 79 && diskusage < 99 && hdd_label.ForeColor != Color.OrangeRed)
            {
                hdd_label.ForeColor = Color.OrangeRed;
            }
            else if (diskusage > 98 && hdd_label.ForeColor != Color.Red)
            {
                hdd_label.ForeColor = Color.Red;
            }
            else if (diskusage < 50 && hdd_label.ForeColor != Color.Lime)
            {
                hdd_label.ForeColor = Color.Lime;
            }
#endregion
        }

        private void updowntimer_Tick(object sender, EventArgs e)
        {
            if (!nointernet)
            {
                updateCounter();
            }
            else
            {
                upload_label.Text = "0 kb/s";
                down_label.Text = "0 kb/s";
            }
        }

        private async void servernetworkchecktimer_Tick(object sender, EventArgs e)
        {
            try
            {
                nointernet = await MyNetworking.CheckForInternetConnection() ? false : true;
            }
            catch
            {
                nointernet = true;
            }
            

            if (!IsConnectionAvailable())
            {
                nointernet = true;
                netGone = true;
            }
            if (nointernet)
            {
                netGone = true;
            }
        }

        private void internet_connection_timer_Tick(object sender, EventArgs e)
        {
            if (!nointernet)
            {
                if (netGone)
                {
                    netGone = false;
                    SSID = getSSID();
                    getActiveCounters();
                }
                netsign_label.Text = "\u263A";
                netsign_label.ForeColor = Color.Lime;

                internet_label.Text = SSID;
                internet_label.ForeColor = Color.Lime;

                colorProgressBar1.Value = getSignal();

                txt_signal.Text = getSignal().ToString() + "%";
                txt_signal.ForeColor = Color.Lime;
                
            }
            else
            {
                netGone = true;
                netsign_label.Text = "-";
                internet_label.Text = "no internet";
                txt_signal.ForeColor = Color.OrangeRed;
                netsign_label.ForeColor = Color.OrangeRed;
                internet_label.ForeColor = Color.OrangeRed;
                colorProgressBar1.Value = 0;
                txt_signal.Text = "0%";
                if (!nointernet)
                {
                    nointernet = true;
                }
            }

        }

        private void txtDay_Click(object sender, EventArgs e)
        {

        }

        private void namelabel_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void sign_timer_tick(object sender, EventArgs e)
        {

        }

        private void blinkface_timer_tick(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtsabir.BringToFront();
            if (e.KeyChar == 'S')
            {
                if (!txtsabir.Visible)
                {
                    this.TransparencyKey = Color.Olive;
                    txtsabir.Visible = true;
                }
                else
                {
                    txtsabir.Visible = false;
                }
            }

        }

        private void mouse_timer_Tick(object sender, EventArgs e)
        {
            var X = this.PointToClient(Cursor.Position).X;
            var Y = this.PointToClient(Cursor.Position).Y;
            if (X < 450 && X > 1 && Y < 215 && Y > 1)
            {
                btnClose.BringToFront();
                btnClose.Show();
            }
            else
            {
                btnClose.Hide();
            }
        }

        private void txtsabir_Click(object sender, EventArgs e)
        {

        }
#endregion

#region RightClickFunctions
        private void alwaysOnTopToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                Properties.Settings.Default["alwayonTop"] = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                this.TopMost = true;
                Properties.Settings.Default["alwayonTop"] = true;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

        }

        private void hideToSysTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            systraynotifyicon.Visible = true;
            systraynotifyicon.BalloonTipText = "DM is hidden in system tray";
            systraynotifyicon.ShowBalloonTip(500);
            this.Visible = false;
        }

        private void systraynotifyicon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.Visible)
            {
                this.Show();
            }
            else
            {
                this.TopMost = true;
                alwaysOnTopToolStripMenuItem3.Checked = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.TransparencyKey != this.BackColor)
            {
                this.TransparencyKey = this.BackColor;
                Properties.Settings.Default["Transparent"] = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                this.TransparencyKey = Color.FromArgb(22, 199, 1);
                Properties.Settings.Default["Transparent"] = false;
                Properties.Settings.Default.Save();
            }
        }
#endregion

#region Coloring
        private void cadetBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.SlateGray;
            this.label1.BackColor = Color.SlateGray;
            ResetCheckList("Slate Gray");
            Properties.Settings.Default["backColor"] = Color.SlateGray;
            Properties.Settings.Default.Save();
        }

        private void navyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Indigo;
            this.label1.BackColor = Color.Indigo;
            ResetCheckList("Indigo");
            Properties.Settings.Default["backColor"] = Color.Indigo;
            Properties.Settings.Default.Save();
        }

        private void oliveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(20, 60, 85);
            this.label1.BackColor = Color.FromArgb(20, 60, 85);
            ResetCheckList("Coolend");
            Properties.Settings.Default["backColor"] = Color.FromArgb(20, 60, 85);
            Properties.Settings.Default.Save();
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(54, 60, 73);
            this.label1.BackColor = Color.FromArgb(54, 60, 73);
            ResetCheckList("Default");
            Properties.Settings.Default["backColor"] = Color.FromArgb(54, 60, 73);
            Properties.Settings.Default.Save();
        }
        

        private void tealToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(0, 64, 128);
            this.label1.BackColor = Color.FromArgb(0, 64, 128);
            ResetCheckList("Coolstart");
            Properties.Settings.Default["backColor"] = Color.FromArgb(0, 64, 128);
            Properties.Settings.Default.Save();
        }

        private void coolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(80, 60, 85);
            this.label1.BackColor = Color.FromArgb(80, 60, 85);
            ResetCheckList("Cool");
            Properties.Settings.Default["backColor"] = Color.FromArgb(80, 60, 85);
            Properties.Settings.Default.Save();
        }

        public void ResetCheckList(string item)
        {
            for (int i = 0; i < this.backgroundToolStripMenuItem.DropDownItems.Count; i++)
            {
                if (this.backgroundToolStripMenuItem.DropDownItems[i].Text.Equals(item))
                {
                    this.backgroundToolStripMenuItem.DropDownItems[i].Enabled = false;
                }
                else
                {
                    this.backgroundToolStripMenuItem.DropDownItems[i].Enabled = true;
                    var temp = this.backgroundToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem;
                    temp.Checked = false;
                }
            }
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BackgroundColorPicker.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = BackgroundColorPicker.Color;
                this.label1.BackColor = BackgroundColorPicker.Color;
                Properties.Settings.Default["backColor"] = BackgroundColorPicker.Color;
                Properties.Settings.Default.Save();
                for (int i = 0; i < this.backgroundToolStripMenuItem.DropDownItems.Count; i++)
                {
                    if (this.backgroundToolStripMenuItem.DropDownItems[i].Text.Equals("Custom"))
                    {
                        var temp = this.backgroundToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem;
                        temp.Checked = true;
                    }
                    else
                    {
                        this.backgroundToolStripMenuItem.DropDownItems[i].Enabled = true;
                        var temp = this.backgroundToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem;
                        temp.Checked = false;
                    }
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version to access settings!\nThank you.";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }
        
        private void processMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version to access process monitoring!\nThank you.";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }

        private void opacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = this;

            var opacity = Tracker.ShowDialog(Math.Round(this.Opacity, 2),f);
            
            var x = Convert.ToDouble("." + opacity.ToString()).ToString("0.00");
            var y = Convert.ToDouble(x);
            Math.Round(y, 2);
            this.Opacity = y;
            Properties.Settings.Default["opacity"] = (decimal)Math.Round(y, 2);
            Properties.Settings.Default.Save();
        }
#endregion

        private void btnSetAlaram_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Hide();
            btnSetAlaram.Hide();
            radioOff.Hide();
            radioOn.Hide();
            radioOnce.Hide();
            radioEveryday.Hide();
            btnAlaramSettings.Hide();
            Properties.Settings.Default["alarmTime"] =  dateTimePicker1.Value ;
            Properties.Settings.Default.Save();

            if (radioOn.Checked)
            {
                Properties.Settings.Default["isAlaramOn"] = true;
                Properties.Settings.Default.Save();
                Properties.Settings.Default["isAlarmPending"] = true;
                Properties.Settings.Default.Save();
                alaramTimer.Start();
            }
            else
            {
                Properties.Settings.Default["isAlaramOn"] = false;
                Properties.Settings.Default.Save();
            }

            if (radioEveryday.Checked)
            {
                Properties.Settings.Default["everydayAlarm"] = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default["everydayAlarm"] = false;
                Properties.Settings.Default.Save();
            }
            if (radioOff.Checked)
            {
                alaramTimer.Stop();
            }
        }

        private void alaramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Show();
            btnSetAlaram.Show();
            dateTimePicker1.BringToFront();
            btnSetAlaram.BringToFront();

            radioOff.Show();
            radioOn.Show();
            radioOn.BringToFront();
            radioOnce.Show();
            radioOnce.BringToFront();
            radioEveryday.Show();
            btnAlaramSettings.Show();
            DateTime alarmTime = (DateTime)Properties.Settings.Default["alarmTime"];
            dateTimePicker1.Value = alarmTime;

            bool isAlarmOn = (bool)Properties.Settings.Default["isAlaramOn"];
            bool isEveryday = (bool)Properties.Settings.Default["everydayAlarm"];

            if (isAlarmOn)
            {
                radioOn.Checked = true;
            }
            else
            {
                radioOff.Checked = true;
            }

            if (isEveryday)
            {
                radioEveryday.Checked = true;
            }
            else
            {
                radioOnce.Checked = true;
            }
        }

        private void radioOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxHandeler)
            {
                CheckBoxHandeler = false;
                if (radioEveryday.Checked)
                {
                    radioEveryday.Checked = false;
                }
                if (!radioOnce.Checked)
                {
                    radioOnce.Checked = true;
                }
                CheckBoxHandeler = true;
            }
            
        }

        private void radioEveryday_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxHandeler)
            {
                CheckBoxHandeler = false;
                if (radioOnce.Checked)
                {
                    radioOnce.Checked = false;
                }
                if (!radioEveryday.Checked)
                {
                    radioEveryday.Checked = true;
                }
                CheckBoxHandeler = true;

            }
            
        }

        private void radioOn_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxHandeler)
            {
                CheckBoxHandeler = false;
                if (radioOff.Checked)
                {
                    radioOff.Checked = false;
                }
                if (!radioOn.Checked)
                {
                    radioOn.Checked = true;
                }
                CheckBoxHandeler = true;
            }
        }

        private void radioOff_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxHandeler)
            {
                CheckBoxHandeler = false;
                if (radioOn.Checked)
                {
                    radioOn.Checked = false;
                }
                if (!radioOff.Checked)
                {
                    radioOff.Checked = true;
                }
                CheckBoxHandeler = true;
            }
        }

        private async void alaramTimer_Tick(object sender, EventArgs e)
        {
            alarmtime = (DateTime)Properties.Settings.Default["alarmTime"];

            if (alarmtime.Hour == DateTime.Now.Hour && alarmtime.Minute == DateTime.Now.Minute)
            {
                Properties.Settings.Default["isAlarmPending"] = false;
                Properties.Settings.Default.Save();
                alaramTimer.Stop();
                btnStopAlarm.Show();
                alarmTimeTimer.Start();
                Task t = Task.Factory.StartNew(() =>
                {
                    sound.PlayLooping();
                });

                await Task.Delay(TimeSpan.FromSeconds(60));
                if (!AlarmNotCancaled)
                {
                    await Task.Run(() =>
                    {
                        StopAlarm();
                    });
                }
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            AlarmNotCancaled = true;
            await Task.Run(() =>
            {
                StopAlarm();
            });
        }

        public async void StopAlarm()
        {
            this.btnStopAlarm.Invoke((MethodInvoker) delegate
             {
                 btnStopAlarm.Hide();
             });
            this.btnAlaramSettings.Invoke((MethodInvoker)delegate
            {
                btnAlaramSettings.Hide();
            });

            sound.Stop();
            alarmTimeTimer.Stop();
            txtHourMin.Invoke((MethodInvoker)delegate
            {
                txtHourMin.ForeColor = Color.Chartreuse;
            });
                

            bool isAlarmEveryady = (bool)Properties.Settings.Default["everydayAlarm"];
            if (isAlarmEveryady)
            {
                Properties.Settings.Default["isAlaramOn"] = true;
                Properties.Settings.Default.Save();

                await Task.Delay(TimeSpan.FromSeconds(61));
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        alaramTimer.Start();
                    });
                }
                else
                {
                    alaramTimer.Start();
                }
            }
            else
            {
                Properties.Settings.Default["isAlaramOn"] = false;
                Properties.Settings.Default.Save();
            }
        }

        private void alarmTimeTimer_Tick(object sender, EventArgs e)
        {
            if(txtHourMin.ForeColor == Color.Chartreuse)
            {
                txtHourMin.ForeColor = this.BackColor;
            }
            else
            {
                txtHourMin.ForeColor = Color.Chartreuse;
            }
        }

        private void btnAlaramSettings_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version for alarm settings. Ex- Snooze Time, Preferred Day in a week, Schedule alarm etc.\nThank you!";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }

        private void pCOptimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version to optimize your machine!\nThank you.";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Right click on texts for menu and if you want move the form left click in the free space and hold then drag.\nMore on the website help page";
            string caption = "Help";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
            try
            {
                Process.Start("https://sabirdigitalmonitor.azurewebsites.net/Home/Help");
            }
            catch
            {

            }
        }

        private void miniModeNetworkOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version to get mini mode!\nThank you.";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }

        private void miniModeSysOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Please buy full version to get mini mode!\nThank you.";
            string caption = "Buy";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Asterisk);
        }
    }

    #region Prompt Dialog Boxes
    /*PROMPT DIALOG BOX*/
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200, ForeColor = Color.Green };
            TextBox textBox = new TextBox() { Left = 50, Top = 40, Width = 200, ForeColor = Color.DeepSkyBlue, MaxLength = 8 };
            Button confirmation = new Button() { Text = "OK", Left = 100, Width = 100, Height = 30, Top = 80, DialogResult = DialogResult.OK, ForeColor = Color.DeepPink, BackColor = Color.GreenYellow };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.Text = "DMonitor";
            textLabel.Font = DigitalFont(14, false, false);
            textBox.Font = DigitalFont(14, false, false);
            confirmation.Font = DigitalFont(14, true, false);
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        //FONT STYLE EMBEDING
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection fonts = new PrivateFontCollection();
        public static Font DigitalFont(float size, bool bold, bool italic)
        {

            byte[] fontData = Properties.Resources.DS_DIGIB;
            IntPtr fontPtr =Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.DS_DIGIB.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.DS_DIGIB.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);

            if (bold && italic)
            {
                return new Font(fonts.Families[0], size, FontStyle.Bold | FontStyle.Italic);
            }
            else if (!italic && bold)
            {
                return new Font(fonts.Families[0], size, FontStyle.Bold);
            }
            else if (italic && !bold)
            {
                return new Font(fonts.Families[0], size, FontStyle.Italic);
            }
            else
            {
                return new Font(fonts.Families[0], size);
            }
        }
    }

    public static class Tracker
    {
        public static string ShowDialog(double opacityNow, Form form)
        {
            Form prompt = new Form2();
            if (form.TopMost)
            {
                prompt.TopMost = true;
            }
            
           // Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200, ForeColor = Color.Green };
            TrackBar TrackPad = new TrackBar() { Left =10, Top = 30, Width = 230, Height = 70, ForeColor = Color.DeepSkyBlue, Maximum = 98, Minimum = 10 };
            Label label = new Label() {Left = 243, Top = 35, Text = "100%", Width = 200, ForeColor = Color.Green };
            Button confirmation = new Button() { Text = "OK", Left = 40, Width = 100, Height = 25, Top = 80, DialogResult = DialogResult.OK};
            Button btndefault = new Button() { Text = "Default", 
                Left = 180,
                Width = 100,
                Height = 25,
                Top = 80 };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            btndefault.Click += (sender, e) =>
            {
                TrackPad.Value = 90;
                label.Text = TrackPad.Value.ToString() + "%";
                var x = Convert.ToDouble("." + TrackPad.Value.ToString()).ToString("0.00");
                var y = Convert.ToDouble(x);
                form.Opacity = y;
            };

            prompt.Controls.Add(TrackPad);
            prompt.Controls.Add(btndefault);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(label);
            prompt.AcceptButton = confirmation;

            string s = opacityNow.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = s.Split('.');
            int i1 = int.Parse(parts[0]);
            int i2 = int.Parse(parts[1]);

            TrackPad.Value = i2;
            label.Text = TrackPad.Value.ToString() + "%";

            TrackPad.Scroll += (sender, e) =>
            {
                label.Text = TrackPad.Value.ToString() + "%";
                var x = Convert.ToDouble("." + TrackPad.Value.ToString()).ToString("0.00");
                var y = Convert.ToDouble(x);
                form.Opacity = y;
            };
            return prompt.ShowDialog() == DialogResult.OK ? TrackPad.Value.ToString() : i2.ToString();
        }
    }
#endregion
}



