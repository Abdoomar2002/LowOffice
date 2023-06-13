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
    public partial class notification : UserControl
    {
        public notification()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView1.CurrentRow== null || e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
            string arg = dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString() != " " ? dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString() : "";
            form1.control(arg);
        }
        public List<Cases> CasesList
        {
            get
            {
                return dataGridView1.DataSource as List<Cases>;
            }
        }

        public void notification_Load(object sender, EventArgs e)
        {
            DateTime dateX = DateTime.Today ,dateY = DateTime.Today.AddDays(3);
            CasesContext context = new CasesContext();
            var filteredCases = context.Cases
                   .AsEnumerable()
                   .Where(c => c.date >= dateX && c.date <= dateY)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderBy(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToArray();
            dataGridView1.DataSource = filteredCases.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            DateTime last = DateTime.Today;
            var lastest= context.Cases
                   .AsEnumerable()
                  // .Where(c => c.date <= last)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToList();

            lastest = lastest.Where(c =>(c.caseDecision == "مؤجلة" || c.caseDecision == "")&&c.date<=last).ToList();
            dataGridView2.DataSource = lastest.ToList();
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[8].Visible = false;
            dataGridView2.Columns[12].Visible = false;
            dataGridView2.Columns[11].Visible = false;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow == null || e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
            string arg = dataGridView2.CurrentRow.Cells["caseNum"].Value.ToString() != " " ? dataGridView2.CurrentRow.Cells["caseNum"].Value.ToString() : "";
            form1.control(arg);
        }
    }
}
