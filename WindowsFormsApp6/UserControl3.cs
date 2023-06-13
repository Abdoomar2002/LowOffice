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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
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
    }
}
