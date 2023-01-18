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
    public partial class edit : UserControl
    {
        public string number = "7";
        public int count = 0;
        Cases cases = new Cases();
        public void set() 
        {
            edit.textBox1.Text = "";
            edit.textBox3.Clear();
            edit.textBox4.Text.Remove(0);
        }

        public edit()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void edit_Load(object sender, EventArgs e)
        {


        }
        public void editcase(string text)
        {

            //this.Update();
            
           number = text.ToString();
            button7_Click(null, null);
            this.count++;
            MessageBox.Show("انا اتندهت بردو");
            button7_Click(null, null);



        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = "Id";
            int c=5;
            CasesContext context = new CasesContext();
            Int32.TryParse(number, out c);
            cases.Id = 5;
            cases = context.Cases.Where(x => x.Id ==cases.Id).FirstOrDefault();
            var editcase = context.Cases.FromSqlRaw("select * from Cases where (" + id + "='" + number + "')order by Id desc").FirstOrDefault();
            //textBox1.Text = editcase.circleNum;
            this.Update();
            this.UpdateBounds();
            this.UpdateDefaultButton();
            this.UpdateZOrder();
            this.Refresh();
            this.Show();
            
            
            textBox1.Text = "abc";
           // textBox1.Text = "abcde";
            //this.textBox1.Text = "abcefg";
            // MessageBox.Show(editcase.circleNum);
            if (number != "0"&&count==1&&editcase!=null)
            {
                
                MessageBox.Show(editcase.date);
                 
                textBox1.Text = cases.circleNum;
                textBox4.Text = cases.Hall;
                textBox3.Text = editcase.caseNum;
                textBox8.Text = editcase.attribute;
                textBox5.Text = editcase.oppenentName;
                textBox11.Text = editcase.describtion;
                textBox10.Text = editcase.Lastone;
                comboBox1.Text = editcase.caseDecision;
                dateTimePicker2.Text = editcase.date;
                dateTimePicker1.Text = editcase.dateOflast;
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "abc";
            textBox3.Text = "cde";
            edit.textBox1.Text = "ddd";
        }
        public static void outcase(Cases c)
        {
            textBox1.Text = c.Hall;
            textBox3.Text = c.describtion;
            textBox10.Text = c.circleNum;
            textBox11.Text = c.Id.ToString();
            edit.textBox3.Text = c.Hall;
            
        }
    }
}
