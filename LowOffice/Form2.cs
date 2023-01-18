using LowOffice.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LowOffice
{
    public partial class Form2 : Form
    {
        Form1 frm;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form1 form)
        {
            InitializeComponent();
            frm = form;
            form.Hide();
            this.Activate();
            form.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("readme.txt");
            string[] str = text.Split("\n");
            string userName = str[0];
            string us = userName.Substring(0, 5);
            string password = str[1];
           // MessageBox.Show(us + " " + us.Length.ToString());
           // MessageBox.Show(password + " " + password.Length.ToString());
            if (textBox1.Text == us && textBox2.Text == password)
            {

                new FirstPage().Show();
                this.Hide();
                //this.Close();
                //Application.Run();
                //ShowDialog(new Form1());
            }
            else
                MessageBox.Show("اسم المستخدم او كلمة المرور خاطئه", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sqliteConnection1_StateChange(object sender, StateChangeEventArgs e)
        {

        }
    }
}
