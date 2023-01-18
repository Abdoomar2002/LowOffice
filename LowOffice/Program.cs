using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LowOffice
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            //  System.Timers.Timer timer = new System.Timers.Timer();
           // InitTimer();
           
        }
        public static void fun() 
        {
            MessageBox.Show("hello" + DateTime.Now);
        }
        private static Timer timer1;
        public static void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private static void timer1_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("hello time now is :"+DateTime.Now.ToString());
        }
    }
    
}
