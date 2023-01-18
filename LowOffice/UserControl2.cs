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
       

        private void UserControl2_Load(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();

            var allCases = context.Cases.FromSqlRaw("SELECT *  FROM Cases ORDER BY Id DESC");
            
            dataGridView1.DataSource = allCases.ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            update.outIndex =int.Parse(dataGridView1.CurrentRow.Cells["Id"].Value.ToString());
            //    up.getData.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            Form f = Form1.ActiveForm;
            new  Form1(this);
            //ft.Show();
            //ft =Form1.ActiveForm;
           //ft.Activate();
            
            update.flag=false;
             
            new update("ss").BringToFront();
            

        }
    }
}
