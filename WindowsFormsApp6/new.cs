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
    public partial class filters : UserControl
    {
        public filters()
        {
            InitializeComponent();
        }
        public string str = "";
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {

            
                DateTime dateX, dateY;
                dateX = dateTimePicker1.Value.Date;
                dateY = dateTimePicker2.Value.Date.AddDays(0);
                // MessageBox.Show(dateX.ToString() +"\n"+ dateY.ToString());
                CasesContext context = new CasesContext();
                context.Database.CreateIfNotExists();
            var filteredCases = context.Cases
                                .AsEnumerable()
                                .Where(c=> c.date >= dateX && c.date <= dateY)
                                .GroupBy(c => c.caseNum)
                                .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                                .OrderByDescending(c => c.date).ToList();
            /*      if (checkBox1.Checked == true && checkBox2.Checked == true&&checkBox3.Checked==true&&checkBox4.Checked==true)
                      {

                      dataGridView1.DataSource = filteredCases.Where(c => (c.caseDecision == "مؤجلة" || c.caseDecision == "حكم"||c.caseDecision=="شطب"||c.caseDecision=="تحت الرفع") && c.date >= dateX && c.date <= dateY).ToList();

                  }
                  else if(checkBox1.Checked&&checkBox2.Checked)
                  {
                      dataGridView1.DataSource = filteredCases.Where(c => (c.caseDecision == "حكم"||c.caseDecision=="مؤجلة") && c.date >= dateX && c.date <= dateY).ToList();

                  }
                  else if (checkBox2.Checked&&checkBox3.Checked) 
                  {
                      dataGridView1.DataSource = filteredCases.Where(c => (c.caseDecision == "حكم" || c.caseDecision == "شطب") && c.date >= dateX && c.date <= dateY).ToList();

                  }
                  else if (checkBox1.Checked && checkBox3.Checked)
                  {
                      dataGridView1.DataSource = filteredCases.Where(c => (c.caseDecision == "مؤجلة" || c.caseDecision == "شطب") && c.date >= dateX && c.date <= dateY).ToList();

                  }
                  else if (checkBox1.Checked == true)
                    {

                      dataGridView1.DataSource = filteredCases.Where(c => c.caseDecision == "مؤجلة" && c.date >= dateX && c.date <= dateY).ToList();

                    }
                  else if (checkBox2.Checked == true)
                      {

                          dataGridView1.DataSource = filteredCases.Where(c => c.caseDecision == "حكم" && c.date >= dateX && c.date <= dateY).ToList();

                      }
                  else if (checkBox3.Checked==true) 
                     {
                      dataGridView1.DataSource = filteredCases.Where(c => c.caseDecision == "شطب" && c.date >= dateX && c.date <= dateY).ToList();
                     }
                  else
                      {

                      dataGridView1.DataSource = filteredCases.Where(c => c.date >= dateX && c.date <= dateY).ToList();

                  }*/
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked)
            {
                var filteredList = filteredCases.Where(c =>
                    (checkBox1.Checked && (c.caseDecision == "مؤجلة" || c.caseDecision == "متداول") && c.date >= dateX && c.date <= dateY) ||
                    (checkBox2.Checked && c.caseDecision == "حكم" && c.date >= dateX && c.date <= dateY) ||
                    (checkBox3.Checked && (c.caseDecision == "شطب" || c.caseDecision == "مسدد") && c.date >= dateX && c.date <= dateY)).ToList();
                   // (checkBox4.Checked && c.caseDecision == "تحت الرفع" && c.date >= dateX && c.date <= dateY)).ToList();
                if (checkBox4.Checked) filteredList.AddRange(context.Cases.AsEnumerable().Where(c => c.caseDecision == "تحت الرفع" && c.date >= dateX && c.date <= dateY).ToList());
                dataGridView1.DataSource = filteredList.OrderBy(c => c.date).ToList();
                
              
            }
            else
            {
                 filteredCases.AddRange(context.Cases.AsEnumerable().Where(c => c.caseDecision == "تحت الرفع" && c.date >= dateX && c.date <= dateY).ToList());
                //dataGridView1.DataSource = filteredList.OrderBy(c => c.date).ToList();
                dataGridView1.DataSource = filteredCases.Where(c => c.date >= dateX && c.date <= dateY).OrderBy(c=>c.date).ToList();
                
             
            }


            // MessageBox.Show(filteredCases.ToArray()[0].caseNum);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            setCounter();
         

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            str = "مؤجلة";

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            str = checkBox2.Text;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null || e.RowIndex == -1)
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
                return dataGridView1.DataSource as List<Cases>;
            }
        }

        private void filters_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            str = checkBox3.Text;
        }
        public void setCounter() 
        {
            Form1 form1 = (Form1)this.ParentForm;
            form1.label2.Text = " عدد القضايا " + dataGridView1.RowCount.ToString();
        }
    }
}
