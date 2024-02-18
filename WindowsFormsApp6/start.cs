using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6.db;

namespace WindowsFormsApp6
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }
        public void notifi()
        {
            CasesContext context = new CasesContext();
            DateTime dateX = DateTime.Today, dateY = DateTime.Today.AddDays(2);
            var filteredCases = context.Cases
                     .AsEnumerable()
                     .Where(c => c.date >= dateX && c.date <= dateY)
                     .GroupBy(c => c.caseNum)
                     .Select(g => g.OrderBy(c => c.date).FirstOrDefault())
                     .OrderBy(c => c.date).ToArray();
            notifyIcon1.ShowBalloonTip(1000, " لديك عدد " + filteredCases.Length.ToString() + "من القضايا في اليومين التاليين ", "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);
            DateTime last = DateTime.Today;
            var lastest = context.Cases
                   .AsEnumerable()
                   // .Where(c => c.date <= last)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToList();

            var  lastest2 = lastest.Where(c => (c.caseDecision == "مؤجلة" || c.caseDecision == "متداول"||c.caseDecision=="") && c.date < last).ToArray();
            notifyIcon1.ShowBalloonTip(1000, " لديك عدد " + lastest2.Length.ToString() + "من القضايا اللتي لم يتم ترحيلها ", "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);
            var Saved = context.Cases
                   .AsEnumerable()
                   // .Where(c => c.date <= last)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToList();

            var Saved2 = lastest.Where(c => (c.caseDecision == "حفظ") ).ToArray();
            notifyIcon1.ShowBalloonTip(1000, " لديك عدد " +Saved2.Length.ToString() + "من القضايا المحفوظة ", "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);

            var lastest4 = context.Cases
                  .AsEnumerable()
                  // .Where(c => c.date <= last)
                 
                  .OrderByDescending(c => c.date).ToList();

            var lastest3 = lastest4.Where(c => c.caseDecision == "تحت الرفع" ).ToArray();
            notifyIcon1.ShowBalloonTip(1000, " لديك عدد " + lastest3.Length.ToString() + "من القضايا اللتي لم يتم رفعها ", "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);
            pausesCases();
            System.IO.StreamWriter file = new System.IO.StreamWriter("D:/backup.bat");
           var cases= context.Cases.ToList();
            foreach (var item in cases) {
                file.WriteLine(JsonConvert.SerializeObject(item)); 
            
            
            }
//            file.WriteLine();
            file.Close();
           // MessageBox.Show(context.Cases.ToString().Length.ToString());
            
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Program.ActiveForm is Form1)
            {
                new Form1().Show();
            }else
            {
                new Form2().Show();
            }
        }

        private void start_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifi();
            //  notifyIcon1.ShowBalloonTip(1000, "hi", "yo", ToolTipIcon.Info);
        }
        public void pausesCases()
        {
            var date = DateTime.Now.Date.AddDays(-30);
            CasesContext context = new CasesContext();
            var cases = context.Cases
                   .AsEnumerable()
                   // .Where(c => c.date <= last)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToList();
               cases= cases.Where(c => c.caseDecision == "حكم" && (c.date == date)).ToList();
            foreach (var item in cases)
            {
                notifyIcon1.ShowBalloonTip(1000, "تذكير ب مذكرة عرض/ " + " إيداع إستئناف قضية رقم " + item.caseNum, "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);

            }
        }

        private void start_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();

        }

        private void start_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
