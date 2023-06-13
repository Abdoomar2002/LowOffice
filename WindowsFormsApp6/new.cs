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
                                .GroupBy(c => c.caseNum)
                                .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault())
                                .OrderByDescending(c => c.date).ToList();
            if (checkBox1.Checked == true && checkBox2.Checked == true&&checkBox3.Checked==true)
                {
                   
                dataGridView1.DataSource = filteredCases.Where(c => (c.caseDecision == "مؤجلة" || c.caseDecision == "حكم"||c.caseDecision=="شطب") && c.date >= dateX && c.date <= dateY).ToList();
              
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
               
            }

            // MessageBox.Show(filteredCases.ToArray()[0].caseNum);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[11].Visible = false;

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
            if (dataGridView1.CurrentRow==null || e.RowIndex==-1)
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

        private void filters_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            str = checkBox3.Text;
        }
    }
}
