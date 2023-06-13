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
    public partial class UserControl2 : UserControl
    {

        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();

            //  var allCases = context.Cases.FromSqlRaw("SELECT *  FROM Cases ORDER BY date ASC");
            var allCases = context.Cases
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderBy(c => c.date).FirstOrDefault()).OrderByDescending(c => c.date);

            dataGridView1.DataSource = allCases.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            Form1 form1 = (Form1)this.ParentForm;
         //   MessageBox.Show(dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString().Length.ToString());
            string arg = dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString() != " " ? dataGridView1.CurrentRow.Cells["caseNum"].Value.ToString() : "";
            form1.control(arg);
        }
        // public List<Cases> CasesList;
        public List<Cases> CasesList
        {
            get{
                return dataGridView1.DataSource as List<Cases>;
            }
            set
            {

            }
        }
    }
}
