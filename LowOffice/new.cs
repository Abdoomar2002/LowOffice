using LowOffice.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LowOffice
{
    public partial class filters : UserControl
    {
        public filters()
        {
            InitializeComponent();
        }
        public string str="";
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            str = radioButton2.Text;
            //MessageBox.Show(str);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            str = "مؤجلة";
            //MessageBox.Show(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateX, dateY;
            dateX = dateTimePicker1.Value;
            dateY = dateTimePicker2.Value;
           // MessageBox.Show(dateX.ToString() +"\n"+ dateY.ToString());
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();

            //  var allCases = context.Cases.FromSqlRaw("SELECT *  FROM Cases ORDER BY date ASC");
            var filteredCases = context.Cases
                        .AsEnumerable()
                        .Where(c => c.caseDecision == str && c.date >= dateX && c.date <= dateY)
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderBy(c => c.date).FirstOrDefault())
                        .OrderBy(c => c.date);
            // MessageBox.Show(str + "\n" + filteredCases[0].typeOfHall);
            //var  filteredCases2 = filteredCases.ToList();
           
            dataGridView1.DataSource = filteredCases.ToList();
            dataGridView1.Columns[0].Visible = false;
           // MessageBox.Show(filteredCases.ToArray()[0].caseNum);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form1 form1 = (Form1)this.ParentForm;
            form1.control(dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString());
        }
        public List<Cases> CasesList
        {
            get
            {
                return dataGridView1.DataSource as List<Cases>;
            }
        }
    }
}
