using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tetris
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Postavke.Init(System.IO.Path.GetDirectoryName(
                Application.ExecutablePath) + "\\Tetris.xml");
            
            Postavke.Pohrani();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Pocetna());
        }
    }
}
