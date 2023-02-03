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
    public partial class Add1 : UserControl
    {
        public Add1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            textBox10.Visible = false;
            label11.Visible = false;
            dateTimePicker2.MinDate = DateTime.Now;
            dateTimePicker1.MinDate = DateTime.Now;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum = textBox3.Text;
            string Hall = hall.Text;
            string typeOfHall = type.Text;
            string circleNum = textBox1.Text;
            string oppenentName = textBox5.Text;
            string attribute = textBox8.Text;
            DateTime date = dateTimePicker2.Value;
            DateTime dateOflast = dateTimePicker1.Value;
            string describtion = textBox11.Text;
            string caseDecision = comboBox1.Text;
            string Lastone = textBox10.Text;
            Cases fake = new Cases();
            

            Cases newcase = new Cases
            {
                caseNum = caseNum,
                Hall = Hall,
                typeOfHall=typeOfHall,
                circleNum = circleNum,
                oppenentName = oppenentName,
                attribute = attribute,
                date = date,
                dateOflast = dateOflast,
                describtion = describtion,
                caseDecision = caseDecision,
                Lastone = Lastone


            };
            context.Cases.Add(newcase);
            context.SaveChanges();
            context.SaveChangesAsync();
            MessageBox.Show("تمت اضافة القضية بنجاح");

            button2_Click(sender, e);
            
    }

        private void button2_Click(object sender, EventArgs e)
        {
            type.Text = "";
             textBox3.Text="";
             hall.Text = "";
             textBox1.Text = "";
             textBox5.Text = "";
             textBox8.Text = "";
             dateTimePicker2.Text = "";
             dateTimePicker1.Text = "";
             textBox11.Text = "";
             comboBox1.Text = "";
             textBox10.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text== "مؤجلة ")
            {
                textBox10.Visible = true;
                label11.Visible = true;
                label11.Text = "قرار الجلسة السابقة";
            }else if(comboBox1.Text=="محكوم")
            {
                textBox10.Visible = true;
                label11.Text = "قرار القضية الكامله";
                label11.Visible = true;

            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
