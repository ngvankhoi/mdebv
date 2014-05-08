using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MEDISOFT2011.DESKTOP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string _userid = ""; 
            string _ngaylv = ""; 
            string _ngaysl = "";
            try
            {
                _userid = args[0];
            }
            catch
            {
            }
            try
            {
                _ngaylv = args[1];
            }
            catch
            {
            }
            try
            {
                _ngaysl = args[2];
            }
            catch
            {
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MMain(_userid,_ngaylv,_ngaysl));
            
        }
    }
}