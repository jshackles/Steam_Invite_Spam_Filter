using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamInviteSpamFilter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMain main_form = new frmMain();
            if (Properties.Settings.Default.startMinimized)
            {
                main_form.WindowState = FormWindowState.Minimized;
                main_form.ShowInTaskbar = false;
            }
            Application.Run(main_form);
        }
    }
}
