using LowOffice.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LowOffice
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
