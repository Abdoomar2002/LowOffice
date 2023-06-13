using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace WindowsFormsApp6
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static Form2 form2 = new Form2();
        public static Form1 form1 = new Form1();
        public static Form ActiveForm=form2;
        static readonly string MutexName = "MyApplicationMutex";
        [STAThread]
        static void Main(string[]args)
        {
            Process p = Process.GetCurrentProcess();
            Process[] pr = Process.GetProcessesByName(p.ProcessName);
            if(pr.Length>2)
            {
                pr[1].Kill();
            }
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            
            if (args.Length > 0 && args[0] == "/fun")
            {
                fun();
                flag = true;
            }
            else
            {
                 Application.Run(ActiveForm);
                ActiveForm = form1;
               
            }
        }


        public static void fun()
        {
            //Application.Run(form);
            Thread backgroundThread = new Thread(NotificationThread);
            backgroundThread.Start();
            // Application.Run(new start());
            //  Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(form);
            ActiveForm = form;
        }
        static void NotificationThread()
        {

            noti();
            while (true)
            {
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                if ((hour == 8) || hour == 20 )
                {
                    // MessageBox.Show("Hello! It's 8 AM or 8 PM.");
                    noti();
                    //sleeptime = 60 * 60 * 1000 * 12;
                }
                Thread.Sleep(360000); // sleep for 1 minute
            }
        }
        public static void noti()
        {
            form.notifi();
            //MessageBox.Show("hello");
        }
        public static bool flag = false;
        public static start form = new start();
    }
}
