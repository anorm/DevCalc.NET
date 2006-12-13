using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DevCalcNET
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
            if(ApplicationInstanceLimiter.Limit())
            {
                return;
            }
            Application.Run(new FormMain());
        }
    }
}