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

            var  lastest2 = lastest.Where(c => (c.caseDecision == "مؤجلة" || c.caseDecision == "") && c.date < last).ToArray();
            notifyIcon1.ShowBalloonTip(1000, " لديك عدد " + lastest2.Length.ToString() + "من القضايا اللتي لم يتم ترحيلها ", "للمزيد من المعلومات اضغط هنا", ToolTipIcon.Info);


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
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifi();
            //  notifyIcon1.ShowBalloonTip(1000, "hi", "yo", ToolTipIcon.Info);
        }
    }
}
