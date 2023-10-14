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
            if(e.RowIndex == -1)
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
    }
}
