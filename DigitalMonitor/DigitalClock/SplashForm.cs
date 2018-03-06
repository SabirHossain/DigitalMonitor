using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalClock
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            label1.Font = DigitalFont(38,false,false);
            this.Icon = Properties.Resources.ballonIcon;
        }
        //FONT STYLE EMBEDING
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
          IntPtr pdv, [In] ref uint pcFonts);
        private static PrivateFontCollection fonts = new PrivateFontCollection();
        public static Font DigitalFont(float size, bool bold, bool italic)
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
    }
}
