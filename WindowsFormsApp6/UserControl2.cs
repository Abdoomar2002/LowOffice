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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();

            //  var allCases = context.Cases.FromSqlRaw("SELECT *  FROM Cases ORDER BY date ASC");
            var allCases = context.Cases
                        .AsEnumerable()
                        .Where(c=>c.caseDecision!=""||c.caseDecision!="/")
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderBy(c => c.date).FirstOrDefault()).OrderByDescending(c => c.date).ToList();
            allCases.AddRange(context.Cases.AsEnumerable().Where(c => c.caseDecision == "تحت الرفع").ToList());
            
            dataGridView1.DataSource = allCases.OrderBy(c => c.date).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[22].Visible = false;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
          
                Form1 form1 = (Form1)this.ParentForm;
                int arg = dataGridView1.CurrentRow.Cells["Id"].Value.ToString() != (-1).ToString() ? Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value) : -1;
                form1.undertest(arg);
          
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
