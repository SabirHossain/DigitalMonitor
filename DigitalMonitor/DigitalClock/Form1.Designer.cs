namespace DigitalClock
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtHourMin = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.namelabel = new System.Windows.Forms.Label();
            this.nametimer = new System.Windows.Forms.Timer(this.components);
            this.cpu_label = new System.Windows.Forms.Label();
            this.ram_label = new System.Windows.Forms.Label();
            this.hardware_timer2 = new System.Windows.Forms.Timer(this.components);
            this.txt_cpu_label = new System.Windows.Forms.Label();
            this.txt_ram_label = new System.Windows.Forms.Label();
            this.txt_dwn = new System.Windows.Forms.Label();
            this.down_label = new System.Windows.Forms.Label();
            this.upload_txt = new System.Windows.Forms.Label();
            this.upload_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_hdd = new System.Windows.Forms.Label();
            this.hdd_label = new System.Windows.Forms.Label();
            this.internet_label = new System.Windows.Forms.Label();
            this.internet_connection_timer = new System.Windows.Forms.Timer(this.components);
            this.netsign_label = new System.Windows.Forms.Label();
            this.colorProgressBar1 = new ColorProgressBar.ColorProgressBar();
            this.txt_signal = new System.Windows.Forms.Label();
            this.txt_hdd_label = new System.Windows.Forms.Label();
            this.colorProgressBar2 = new ColorProgressBar.ColorProgressBar();
            this.txt_hdd_size = new System.Windows.Forms.Label();
            this.txt_hdd_percentage = new System.Windows.Forms.Label();
            this.sign_timer = new System.Windows.Forms.Timer(this.components);
            this.txtsabir = new System.Windows.Forms.Label();
            this.mouse_timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alaramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToSysTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oliveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tealToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadetBlueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processMonitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pCOptimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniModeNetworkOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniModeSysOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.systraynotifyicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundColorPicker = new System.Windows.Forms.ColorDialog();
            this.updowntimer = new System.Windows.Forms.Timer(this.components);
            this.servernetworkchecktimer = new System.Windows.Forms.Timer(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnSetAlaram = new System.Windows.Forms.Button();
            this.radioOnce = new System.Windows.Forms.CheckBox();
            this.radioEveryday = new System.Windows.Forms.CheckBox();
            this.radioOn = new System.Windows.Forms.CheckBox();
            this.radioOff = new System.Windows.Forms.CheckBox();
            this.alaramTimer = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStopAlarm = new System.Windows.Forms.Button();
            this.alarmTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.btnAlaramSettings = new System.Windows.Forms.Button();
            this.contextMenuStrip4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHourMin
            // 
            resources.ApplyResources(this.txtHourMin, "txtHourMin");
            this.txtHourMin.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtHourMin.Name = "txtHourMin";
            this.txtHourMin.Click += new System.EventHandler(this.txtHourMin_Click);
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txtDate.Name = "txtDate";
            // 
            // txtDay
            // 
            resources.ApplyResources(this.txtDay, "txtDay");
            this.txtDay.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.txtDay.Name = "txtDay";
            this.txtDay.Click += new System.EventHandler(this.txtDay_Click);
            // 
            // txtSecond
            // 
            resources.ApplyResources(this.txtSecond, "txtSecond");
            this.txtSecond.ForeColor = System.Drawing.Color.Chartreuse;
            this.txtSecond.Name = "txtSecond";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer_1_Method);
            // 
            // namelabel
            // 
            resources.ApplyResources(this.namelabel, "namelabel");
            this.namelabel.ForeColor = System.Drawing.Color.LimeGreen;
            this.namelabel.Name = "namelabel";
            this.namelabel.Click += new System.EventHandler(this.namelabel_Click);
            // 
            // nametimer
            // 
            this.nametimer.Interval = 380;
            this.nametimer.Tick += new System.EventHandler(this.name_ticker);
            // 
            // cpu_label
            // 
            resources.ApplyResources(this.cpu_label, "cpu_label");
            this.cpu_label.ForeColor = System.Drawing.Color.Lime;
            this.cpu_label.Name = "cpu_label";
            // 
            // ram_label
            // 
            resources.ApplyResources(this.ram_label, "ram_label");
            this.ram_label.ForeColor = System.Drawing.Color.Lime;
            this.ram_label.Name = "ram_label";
            // 
            // hardware_timer2
            // 
            this.hardware_timer2.Interval = 1000;
            this.hardware_timer2.Tick += new System.EventHandler(this.hardware_timer2_tick);
            // 
            // txt_cpu_label
            // 
            resources.ApplyResources(this.txt_cpu_label, "txt_cpu_label");
            this.txt_cpu_label.ForeColor = System.Drawing.Color.Lime;
            this.txt_cpu_label.Name = "txt_cpu_label";
            // 
            // txt_ram_label
            // 
            resources.ApplyResources(this.txt_ram_label, "txt_ram_label");
            this.txt_ram_label.ForeColor = System.Drawing.Color.Lime;
            this.txt_ram_label.Name = "txt_ram_label";
            // 
            // txt_dwn
            // 
            resources.ApplyResources(this.txt_dwn, "txt_dwn");
            this.txt_dwn.ForeColor = System.Drawing.Color.Lime;
            this.txt_dwn.Name = "txt_dwn";
            // 
            // down_label
            // 
            resources.ApplyResources(this.down_label, "down_label");
            this.down_label.ForeColor = System.Drawing.Color.Lime;
            this.down_label.Name = "down_label";
            // 
            // upload_txt
            // 
            resources.ApplyResources(this.upload_txt, "upload_txt");
            this.upload_txt.ForeColor = System.Drawing.Color.Lime;
            this.upload_txt.Name = "upload_txt";
            // 
            // upload_label
            // 
            resources.ApplyResources(this.upload_label, "upload_label");
            this.upload_label.ForeColor = System.Drawing.Color.Lime;
            this.upload_label.Name = "upload_label";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txt_hdd
            // 
            resources.ApplyResources(this.txt_hdd, "txt_hdd");
            this.txt_hdd.ForeColor = System.Drawing.Color.Lime;
            this.txt_hdd.Name = "txt_hdd";
            // 
            // hdd_label
            // 
            resources.ApplyResources(this.hdd_label, "hdd_label");
            this.hdd_label.ForeColor = System.Drawing.Color.Lime;
            this.hdd_label.Name = "hdd_label";
            // 
            // internet_label
            // 
            this.internet_label.AllowDrop = true;
            resources.ApplyResources(this.internet_label, "internet_label");
            this.internet_label.ForeColor = System.Drawing.Color.Lime;
            this.internet_label.Name = "internet_label";
            // 
            // internet_connection_timer
            // 
            this.internet_connection_timer.Interval = 1000;
            this.internet_connection_timer.Tick += new System.EventHandler(this.internet_connection_timer_Tick);
            // 
            // netsign_label
            // 
            resources.ApplyResources(this.netsign_label, "netsign_label");
            this.netsign_label.ForeColor = System.Drawing.Color.LimeGreen;
            this.netsign_label.Name = "netsign_label";
            // 
            // colorProgressBar1
            // 
            this.colorProgressBar1.BackColor = System.Drawing.Color.Black;
            this.colorProgressBar1.BarColor = System.Drawing.Color.LimeGreen;
            this.colorProgressBar1.BorderColor = System.Drawing.Color.Lime;
            this.colorProgressBar1.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.colorProgressBar1.ForeColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.colorProgressBar1, "colorProgressBar1");
            this.colorProgressBar1.Maximum = 100;
            this.colorProgressBar1.Minimum = 0;
            this.colorProgressBar1.Name = "colorProgressBar1";
            this.colorProgressBar1.Step = 10;
            this.colorProgressBar1.Value = 0;
            // 
            // txt_signal
            // 
            resources.ApplyResources(this.txt_signal, "txt_signal");
            this.txt_signal.ForeColor = System.Drawing.Color.Lime;
            this.txt_signal.Name = "txt_signal";
            // 
            // txt_hdd_label
            // 
            this.txt_hdd_label.AllowDrop = true;
            resources.ApplyResources(this.txt_hdd_label, "txt_hdd_label");
            this.txt_hdd_label.ForeColor = System.Drawing.Color.Lime;
            this.txt_hdd_label.Name = "txt_hdd_label";
            // 
            // colorProgressBar2
            // 
            this.colorProgressBar2.BackColor = System.Drawing.Color.Black;
            this.colorProgressBar2.BarColor = System.Drawing.Color.LimeGreen;
            this.colorProgressBar2.BorderColor = System.Drawing.Color.Lime;
            this.colorProgressBar2.FillStyle = ColorProgressBar.ColorProgressBar.FillStyles.Solid;
            this.colorProgressBar2.ForeColor = System.Drawing.Color.Lime;
            resources.ApplyResources(this.colorProgressBar2, "colorProgressBar2");
            this.colorProgressBar2.Maximum = 100;
            this.colorProgressBar2.Minimum = 0;
            this.colorProgressBar2.Name = "colorProgressBar2";
            this.colorProgressBar2.Step = 10;
            this.colorProgressBar2.Value = 0;
            // 
            // txt_hdd_size
            // 
            this.txt_hdd_size.AllowDrop = true;
            resources.ApplyResources(this.txt_hdd_size, "txt_hdd_size");
            this.txt_hdd_size.ForeColor = System.Drawing.Color.Lime;
            this.txt_hdd_size.Name = "txt_hdd_size";
            this.txt_hdd_size.Click += new System.EventHandler(this.label7_Click);
            // 
            // txt_hdd_percentage
            // 
            resources.ApplyResources(this.txt_hdd_percentage, "txt_hdd_percentage");
            this.txt_hdd_percentage.ForeColor = System.Drawing.Color.Lime;
            this.txt_hdd_percentage.Name = "txt_hdd_percentage";
            // 
            // sign_timer
            // 
            this.sign_timer.Tick += new System.EventHandler(this.sign_timer_tick);
            // 
            // txtsabir
            // 
            this.txtsabir.BackColor = System.Drawing.Color.Olive;
            resources.ApplyResources(this.txtsabir, "txtsabir");
            this.txtsabir.ForeColor = System.Drawing.SystemColors.Highlight;
            this.txtsabir.Name = "txtsabir";
            this.txtsabir.Click += new System.EventHandler(this.txtsabir_Click);
            // 
            // mouse_timer
            // 
            this.mouse_timer.Tick += new System.EventHandler(this.mouse_timer_Tick);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alaramToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem3,
            this.hideToSysTrayToolStripMenuItem,
            this.transparentToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.processMonitoringToolStripMenuItem,
            this.pCOptimizeToolStripMenuItem,
            this.miniModeNetworkOnlyToolStripMenuItem,
            this.miniModeSysOnlyToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            resources.ApplyResources(this.contextMenuStrip4, "contextMenuStrip4");
            // 
            // alaramToolStripMenuItem
            // 
            this.alaramToolStripMenuItem.Name = "alaramToolStripMenuItem";
            resources.ApplyResources(this.alaramToolStripMenuItem, "alaramToolStripMenuItem");
            this.alaramToolStripMenuItem.Click += new System.EventHandler(this.alaramToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem3
            // 
            this.alwaysOnTopToolStripMenuItem3.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem3.Name = "alwaysOnTopToolStripMenuItem3";
            resources.ApplyResources(this.alwaysOnTopToolStripMenuItem3, "alwaysOnTopToolStripMenuItem3");
            this.alwaysOnTopToolStripMenuItem3.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem3_Click);
            // 
            // hideToSysTrayToolStripMenuItem
            // 
            this.hideToSysTrayToolStripMenuItem.Name = "hideToSysTrayToolStripMenuItem";
            resources.ApplyResources(this.hideToSysTrayToolStripMenuItem, "hideToSysTrayToolStripMenuItem");
            this.hideToSysTrayToolStripMenuItem.Click += new System.EventHandler(this.hideToSysTrayToolStripMenuItem_Click);
            // 
            // transparentToolStripMenuItem
            // 
            this.transparentToolStripMenuItem.CheckOnClick = true;
            this.transparentToolStripMenuItem.Name = "transparentToolStripMenuItem";
            resources.ApplyResources(this.transparentToolStripMenuItem, "transparentToolStripMenuItem");
            this.transparentToolStripMenuItem.Click += new System.EventHandler(this.transparentToolStripMenuItem_Click);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            resources.ApplyResources(this.opacityToolStripMenuItem, "opacityToolStripMenuItem");
            this.opacityToolStripMenuItem.Click += new System.EventHandler(this.opacityToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.oliveToolStripMenuItem,
            this.tealToolStripMenuItem,
            this.cadetBlueToolStripMenuItem,
            this.navyToolStripMenuItem,
            this.coolToolStripMenuItem,
            this.customToolStripMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            resources.ApplyResources(this.backgroundToolStripMenuItem, "backgroundToolStripMenuItem");
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Checked = true;
            this.defaultToolStripMenuItem.CheckOnClick = true;
            this.defaultToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.defaultToolStripMenuItem, "defaultToolStripMenuItem");
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // oliveToolStripMenuItem
            // 
            this.oliveToolStripMenuItem.CheckOnClick = true;
            this.oliveToolStripMenuItem.Name = "oliveToolStripMenuItem";
            resources.ApplyResources(this.oliveToolStripMenuItem, "oliveToolStripMenuItem");
            this.oliveToolStripMenuItem.Click += new System.EventHandler(this.oliveToolStripMenuItem_Click);
            // 
            // tealToolStripMenuItem
            // 
            this.tealToolStripMenuItem.CheckOnClick = true;
            this.tealToolStripMenuItem.Name = "tealToolStripMenuItem";
            resources.ApplyResources(this.tealToolStripMenuItem, "tealToolStripMenuItem");
            this.tealToolStripMenuItem.Click += new System.EventHandler(this.tealToolStripMenuItem_Click);
            // 
            // cadetBlueToolStripMenuItem
            // 
            this.cadetBlueToolStripMenuItem.CheckOnClick = true;
            this.cadetBlueToolStripMenuItem.Name = "cadetBlueToolStripMenuItem";
            resources.ApplyResources(this.cadetBlueToolStripMenuItem, "cadetBlueToolStripMenuItem");
            this.cadetBlueToolStripMenuItem.Click += new System.EventHandler(this.cadetBlueToolStripMenuItem_Click);
            // 
            // navyToolStripMenuItem
            // 
            this.navyToolStripMenuItem.CheckOnClick = true;
            this.navyToolStripMenuItem.Name = "navyToolStripMenuItem";
            resources.ApplyResources(this.navyToolStripMenuItem, "navyToolStripMenuItem");
            this.navyToolStripMenuItem.Click += new System.EventHandler(this.navyToolStripMenuItem_Click);
            // 
            // coolToolStripMenuItem
            // 
            this.coolToolStripMenuItem.CheckOnClick = true;
            this.coolToolStripMenuItem.Name = "coolToolStripMenuItem";
            resources.ApplyResources(this.coolToolStripMenuItem, "coolToolStripMenuItem");
            this.coolToolStripMenuItem.Click += new System.EventHandler(this.coolToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            resources.ApplyResources(this.customToolStripMenuItem, "customToolStripMenuItem");
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::DigitalClock.Properties.Resources.if_our_process_2_45123;
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // processMonitoringToolStripMenuItem
            // 
            this.processMonitoringToolStripMenuItem.Image = global::DigitalClock.Properties.Resources.if_utilities_system_monitor_118829;
            resources.ApplyResources(this.processMonitoringToolStripMenuItem, "processMonitoringToolStripMenuItem");
            this.processMonitoringToolStripMenuItem.Name = "processMonitoringToolStripMenuItem";
            this.processMonitoringToolStripMenuItem.Click += new System.EventHandler(this.processMonitoringToolStripMenuItem_Click);
            // 
            // pCOptimizeToolStripMenuItem
            // 
            this.pCOptimizeToolStripMenuItem.Image = global::DigitalClock.Properties.Resources.Apps_utilities_system_monitor_icon;
            this.pCOptimizeToolStripMenuItem.Name = "pCOptimizeToolStripMenuItem";
            resources.ApplyResources(this.pCOptimizeToolStripMenuItem, "pCOptimizeToolStripMenuItem");
            this.pCOptimizeToolStripMenuItem.Click += new System.EventHandler(this.pCOptimizeToolStripMenuItem_Click);
            // 
            // miniModeNetworkOnlyToolStripMenuItem
            // 
            this.miniModeNetworkOnlyToolStripMenuItem.Name = "miniModeNetworkOnlyToolStripMenuItem";
            resources.ApplyResources(this.miniModeNetworkOnlyToolStripMenuItem, "miniModeNetworkOnlyToolStripMenuItem");
            this.miniModeNetworkOnlyToolStripMenuItem.Click += new System.EventHandler(this.miniModeNetworkOnlyToolStripMenuItem_Click);
            // 
            // miniModeSysOnlyToolStripMenuItem
            // 
            this.miniModeSysOnlyToolStripMenuItem.Name = "miniModeSysOnlyToolStripMenuItem";
            resources.ApplyResources(this.miniModeSysOnlyToolStripMenuItem, "miniModeSysOnlyToolStripMenuItem");
            this.miniModeSysOnlyToolStripMenuItem.Click += new System.EventHandler(this.miniModeSysOnlyToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = global::DigitalClock.Properties.Resources.Help_icon_72a7cf_svg;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Image = global::DigitalClock.Properties.Resources.if_process_stop_118794;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // systraynotifyicon
            // 
            resources.ApplyResources(this.systraynotifyicon, "systraynotifyicon");
            this.systraynotifyicon.ContextMenuStrip = this.contextMenuStrip1;
            this.systraynotifyicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systraynotifyicon_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::DigitalClock.Properties.Resources.if_process_stop_118794;
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // updowntimer
            // 
            this.updowntimer.Interval = 920;
            this.updowntimer.Tick += new System.EventHandler(this.updowntimer_Tick);
            // 
            // servernetworkchecktimer
            // 
            this.servernetworkchecktimer.Interval = 60000;
            this.servernetworkchecktimer.Tick += new System.EventHandler(this.servernetworkchecktimer_Tick);
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // btnSetAlaram
            // 
            this.btnSetAlaram.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.btnSetAlaram, "btnSetAlaram");
            this.btnSetAlaram.ForeColor = System.Drawing.Color.White;
            this.btnSetAlaram.Name = "btnSetAlaram";
            this.btnSetAlaram.UseVisualStyleBackColor = false;
            this.btnSetAlaram.Click += new System.EventHandler(this.btnSetAlaram_Click);
            // 
            // radioOnce
            // 
            resources.ApplyResources(this.radioOnce, "radioOnce");
            this.radioOnce.ForeColor = System.Drawing.Color.LimeGreen;
            this.radioOnce.Name = "radioOnce";
            this.radioOnce.UseVisualStyleBackColor = true;
            this.radioOnce.CheckedChanged += new System.EventHandler(this.radioOnce_CheckedChanged);
            // 
            // radioEveryday
            // 
            resources.ApplyResources(this.radioEveryday, "radioEveryday");
            this.radioEveryday.ForeColor = System.Drawing.Color.OrangeRed;
            this.radioEveryday.Name = "radioEveryday";
            this.radioEveryday.UseVisualStyleBackColor = true;
            this.radioEveryday.CheckedChanged += new System.EventHandler(this.radioEveryday_CheckedChanged);
            // 
            // radioOn
            // 
            resources.ApplyResources(this.radioOn, "radioOn");
            this.radioOn.ForeColor = System.Drawing.Color.LimeGreen;
            this.radioOn.Name = "radioOn";
            this.radioOn.UseVisualStyleBackColor = true;
            this.radioOn.CheckedChanged += new System.EventHandler(this.radioOn_CheckedChanged);
            // 
            // radioOff
            // 
            resources.ApplyResources(this.radioOff, "radioOff");
            this.radioOff.ForeColor = System.Drawing.Color.OrangeRed;
            this.radioOff.Name = "radioOff";
            this.radioOff.UseVisualStyleBackColor = true;
            this.radioOff.CheckedChanged += new System.EventHandler(this.radioOff_CheckedChanged);
            // 
            // alaramTimer
            // 
            this.alaramTimer.Interval = 1000;
            this.alaramTimer.Tick += new System.EventHandler(this.alaramTimer_Tick);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStopAlarm
            // 
            this.btnStopAlarm.BackColor = System.Drawing.Color.YellowGreen;
            resources.ApplyResources(this.btnStopAlarm, "btnStopAlarm");
            this.btnStopAlarm.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btnStopAlarm.Name = "btnStopAlarm";
            this.btnStopAlarm.UseVisualStyleBackColor = false;
            this.btnStopAlarm.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // alarmTimeTimer
            // 
            this.alarmTimeTimer.Interval = 500;
            this.alarmTimeTimer.Tick += new System.EventHandler(this.alarmTimeTimer_Tick);
            // 
            // btnAlaramSettings
            // 
            this.btnAlaramSettings.BackColor = System.Drawing.Color.LimeGreen;
            resources.ApplyResources(this.btnAlaramSettings, "btnAlaramSettings");
            this.btnAlaramSettings.ForeColor = System.Drawing.Color.White;
            this.btnAlaramSettings.Name = "btnAlaramSettings";
            this.btnAlaramSettings.UseVisualStyleBackColor = false;
            this.btnAlaramSettings.Click += new System.EventHandler(this.btnAlaramSettings_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(60)))), ((int)(((byte)(73)))));
            this.ContextMenuStrip = this.contextMenuStrip4;
            this.Controls.Add(this.btnAlaramSettings);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnStopAlarm);
            this.Controls.Add(this.radioOff);
            this.Controls.Add(this.radioOn);
            this.Controls.Add(this.radioEveryday);
            this.Controls.Add(this.radioOnce);
            this.Controls.Add(this.btnSetAlaram);
            this.Controls.Add(this.txtsabir);
            this.Controls.Add(this.txt_hdd_percentage);
            this.Controls.Add(this.txt_hdd_size);
            this.Controls.Add(this.colorProgressBar2);
            this.Controls.Add(this.txt_hdd_label);
            this.Controls.Add(this.txt_signal);
            this.Controls.Add(this.colorProgressBar1);
            this.Controls.Add(this.netsign_label);
            this.Controls.Add(this.internet_label);
            this.Controls.Add(this.hdd_label);
            this.Controls.Add(this.txt_hdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upload_label);
            this.Controls.Add(this.upload_txt);
            this.Controls.Add(this.down_label);
            this.Controls.Add(this.txt_dwn);
            this.Controls.Add(this.txt_ram_label);
            this.Controls.Add(this.txt_cpu_label);
            this.Controls.Add(this.ram_label);
            this.Controls.Add(this.cpu_label);
            this.Controls.Add(this.namelabel);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSecond);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtHourMin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_for_hover);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtHourMin;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtDay;
        private System.Windows.Forms.Label txtSecond;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.Timer nametimer;
        private System.Windows.Forms.Label cpu_label;
        private System.Windows.Forms.Label ram_label;
        private System.Windows.Forms.Timer hardware_timer2;
        private System.Windows.Forms.Label txt_cpu_label;
        private System.Windows.Forms.Label txt_ram_label;
        private System.Windows.Forms.Label txt_dwn;
        private System.Windows.Forms.Label down_label;
        private System.Windows.Forms.Label upload_txt;
        private System.Windows.Forms.Label upload_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_hdd;
        private System.Windows.Forms.Label hdd_label;
        private System.Windows.Forms.Label internet_label;
        private System.Windows.Forms.Timer internet_connection_timer;
        private System.Windows.Forms.Label netsign_label;
        private ColorProgressBar.ColorProgressBar colorProgressBar1;
        private System.Windows.Forms.Label txt_signal;
        private System.Windows.Forms.Label txt_hdd_label;
        private ColorProgressBar.ColorProgressBar colorProgressBar2;
        private System.Windows.Forms.Label txt_hdd_size;
        private System.Windows.Forms.Label txt_hdd_percentage;
        private System.Windows.Forms.Timer sign_timer;
        private System.Windows.Forms.Label txtsabir;
        private System.Windows.Forms.Timer mouse_timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem3;
        private System.Windows.Forms.NotifyIcon systraynotifyicon;
        private System.Windows.Forms.ToolStripMenuItem hideToSysTrayToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oliveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tealToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadetBlueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coolToolStripMenuItem;
        private System.Windows.Forms.ColorDialog BackgroundColorPicker;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processMonitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.Timer updowntimer;
        private System.Windows.Forms.Timer servernetworkchecktimer;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnSetAlaram;
        private System.Windows.Forms.ToolStripMenuItem alaramToolStripMenuItem;
        private System.Windows.Forms.CheckBox radioOnce;
        private System.Windows.Forms.CheckBox radioEveryday;
        private System.Windows.Forms.CheckBox radioOn;
        private System.Windows.Forms.CheckBox radioOff;
        private System.Windows.Forms.Timer alaramTimer;
        private System.Windows.Forms.Button btnStopAlarm;
        private System.Windows.Forms.Timer alarmTimeTimer;
        private System.Windows.Forms.Button btnAlaramSettings;
        private System.Windows.Forms.ToolStripMenuItem pCOptimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniModeNetworkOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniModeSysOnlyToolStripMenuItem;
    }
}

