using LowOffice.db;
using Microsoft.EntityFrameworkCore;
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
    public partial class ShowAll : UserControl
    {
        public ShowAll()
        {
            InitializeComponent();
            
        }
        // update up;
        public event EventHandler ButtonClicked;


        public void UserControl2_Load(object sender, EventArgs e)
        {
            
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();

            //  var allCases = context.Cases.FromSqlRaw("SELECT *  FROM Cases ORDER BY date ASC");
            var allCases = context.Cases
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderBy(c => c.date).FirstOrDefault()).OrderBy(c=>c.date);

            dataGridView1.DataSource = allCases.ToList();
            dataGridView1.Columns[0].Visible = false;

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
