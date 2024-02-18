using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp6.db;

namespace WindowsFormsApp6
{
    public partial class notification : UserControl
    {
        static int active = 3;
        public notification()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (dataGridView1.CurrentRow== null || e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
            int arg = dataGridView1.CurrentRow.Cells["Id"].Value.ToString() != (-1).ToString() ? Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value) : -1;
            form1.undertest(arg);
        }
        public List<Cases> CasesList
        {
            get
            {
                if (active == 3)
                    return dataGridView3.DataSource as List<Cases>;
                else if (active == 2)
                    return dataGridView2.DataSource as List<Cases>;
                else if (active == 1) return dataGridView1.DataSource as List<Cases>;
                else return dataGridView4.DataSource as List<Cases>;

            }
        }

        public void notification_Load(object sender, EventArgs e)
        {
            DateTime dateX = DateTime.Today ,dateY = DateTime.Today.AddDays(3);
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();
            var filteredCases = context.Cases
                   .AsEnumerable()
                   .Where(c =>c.caseDecision!="تحت الرفع"&& c.date >= dateX && c.date <= dateY)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderBy(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToArray();
            dataGridView1.DataSource = filteredCases.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            DateTime last = DateTime.Today;
            var lastest= context.Cases
                   .AsEnumerable()
                  // .Where(c => c.date <= last)
                   .GroupBy(c => c.caseNum)
                   .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                   .OrderByDescending(c => c.date).ToList();
            var underTest = lastest;
            lastest = lastest.Where(c =>(c.caseDecision == "مؤجلة" || c.caseDecision == ""|| c.caseDecision == "متداول") && c.caseDecision!="تحت الرفع"&&c.date<=last).ToList();
            dataGridView3.DataSource = lastest.ToList();
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[14].Visible = false;
            dataGridView3.Columns[15].Visible = false;
            dataGridView3.Columns[19].Visible = false;
            dataGridView3.Columns[20].Visible = false;
            dataGridView3.Columns[24].Visible = false;
            underTest = context.Cases.AsEnumerable().Where(c => c.caseDecision == "تحت الرفع").OrderByDescending(c => c.date).ToList();
            dataGridView2.DataSource = underTest.ToList();
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[8].Visible = false;
            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[14].Visible = false;
            dataGridView2.Columns[15].Visible = false;
            dataGridView2.Columns[19].Visible = false;
            dataGridView2.Columns[20].Visible = false;
            dataGridView2.Columns[24].Visible = false;
            var savedCases = context.Cases.AsEnumerable().Where(c => c.caseDecision == "حفظ").OrderByDescending(c => c.date).ToList();
            dataGridView4.DataSource = savedCases.ToList();
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.Columns[1].Visible = false;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[5].Visible = false;
            dataGridView4.Columns[8].Visible = false;
            dataGridView4.Columns[10].Visible = false;
            dataGridView4.Columns[14].Visible = false;
            dataGridView4.Columns[15].Visible = false;
            dataGridView4.Columns[19].Visible = false;
            dataGridView4.Columns[20].Visible = false;
            dataGridView4.Columns[24].Visible = false;
            setCounter();

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentRow == null || e.RowIndex == -1)
            {
                return;
            }
          //  MessageBox.Show(dataGridView2.CurrentRow.Cells["date"].Value.ToString());
            Form1 form1 = (Form1)this.ParentForm;
            int arg = dataGridView2.CurrentRow.Cells["Id"].Value.ToString() != (-1).ToString() ? Convert.ToInt32(dataGridView2.CurrentRow.Cells["Id"].Value) : -1;
            form1.undertest(arg);
            //  form1.control(arg);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
            active = 1;
            setCounter();
            // MessageBox.Show(active.ToString());

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            active = 2;
            setCounter();
            //  MessageBox.Show(active.ToString());

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
            active = 3;
            setCounter();
            //  MessageBox.Show(active.ToString());
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentRow == null || e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
            int arg = dataGridView3.CurrentRow.Cells["Id"].Value.ToString() != (-1).ToString() ? Convert.ToInt32(dataGridView3.CurrentRow.Cells["Id"].Value) : -1;
            form1.undertest(arg);
        }
        public void setCounter() 
        {
            Form1 form1 = (Form1)this.ParentForm;
            if(active==3)
            form1.label2.Text = " عدد القضايا " + dataGridView3.RowCount.ToString(); 
            if (active == 2)
                form1.label2.Text = " عدد القضايا " + dataGridView2.RowCount.ToString(); 
            if (active == 1)
                form1.label2.Text = " عدد القضايا " + dataGridView1.RowCount.ToString();
            if(active==4)form1.label2.Text= " عدد القضايا " + dataGridView4.RowCount.ToString();

        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.CurrentRow == null || e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
            int arg = dataGridView4.CurrentRow.Cells["Id"].Value.ToString() != (-1).ToString() ? Convert.ToInt32(dataGridView4.CurrentRow.Cells["Id"].Value) : -1;
            form1.undertest(arg);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel8.BringToFront();
            active = 4;
            setCounter();
        }
    }
}
