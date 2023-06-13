using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp6.db;

namespace WindowsFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox2.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string filePath = @"systemObservation.bat";

            if (File.Exists(filePath))
            {
                string text = File.ReadAllText("systemObservation.bat");
                string[] str = text.Split('\n');
               
                //string us = userName.Substring(0, 5);
                string password = str[0];
                // MessageBox.Show(us + " " + us.Length.ToString());
                // MessageBox.Show(password + " " + password.Length.ToString());
                if (textBox2.Text == password)
                {

                    Program.form1.Show();
                    this.Hide();
                    Program.ActiveForm = Program.form1;
                    //this.Close();
                    //Application.Run();
                    //ShowDialog(new Form1());
                    //using (var context = new CasesContext())
                    //{
                    //    //context.Database.ExecuteSqlCommand("TRUNCATE TABLE Cases");
                    //    context.Database.Delete();
                    //    context.SaveChanges();
                    //}
                }
                else
                    MessageBox.Show("اسم المستخدم او كلمة المرور خاطئه", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new CasesContext())
                {
                    context.Database.ExecuteSqlCommand("TRUNCATE TABLE Cases");
                    context.Database.Delete();
                    context.SaveChanges();
                }
                string content = "Admin";
                File.WriteAllText(filePath, content);

                string text = File.ReadAllText("systemObservation.bat");
                string[] str = text.Split(' ');
               
               // string us = userName.Substring(0, 5);
                string password = str[0];
                // MessageBox.Show(us + " " + us.Length.ToString());
                // MessageBox.Show(password + " " + password.Length.ToString());
                if ( textBox2.Text == password)
                {
                    Program.form1.Show();
                    this.Hide();
                    Program.ActiveForm = Program.form1;
                    //this.Close();
                    //Application.Run();
                    //ShowDialog(new Form1());
                }
                else
                    MessageBox.Show("اسم المستخدم او كلمة المرور خاطئه", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           /* using (var context = new CasesContext())
            {
                 context.Database.ExecuteSqlCommand("TRUNCATE TABLE Cases");
                context.Database.Delete();
                context.SaveChanges();
            }*/

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(null, null);
            }
        
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        public void label5_Click(object sender, EventArgs e)
        {
            // Create a new form to prompt for input
            Form prompt = new Form();
            prompt.Width = 200;
            prompt.Height = 200;
            prompt.Text = "Input";
            prompt.BackColor = Color.White;
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.AutoSize = false;
            prompt.FormBorderStyle =FormBorderStyle.None ;
            prompt.StartPosition = FormStartPosition.CenterParent;
            // Create a label and text box to display the prompt and receive input
            Label textLabel = new Label() { Left = 65, Top = 20, Text = "Your Pin",RightToLeft=RightToLeft.Yes,TextAlign=ContentAlignment.TopRight};
            textLabel.Font = new Font("Segoe UI",8);
            Guna.UI2.WinForms.Guna2TextBox textBox = new Guna.UI2.WinForms.Guna2TextBox() { Left = 20, Top = 60, Width = 150};
          
            Guna.UI2.WinForms.Guna2Button confirmButton = new Guna.UI2.WinForms.Guna2Button() { Text = "OK", Left = 55, Width = 90, Top = 120, BorderThickness = 3, BorderRadius = 5 };

            // Set the confirm button to close the form when clicked
            confirmButton.Click += (sende, er) => { prompt.Close(); };
            confirmButton.FillColor = Color.Black;
            textBox.KeyDown += (se, erd) => { if (erd.KeyCode == Keys.Enter) prompt.Close(); };


            // Add the controls to the form
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmButton);

            // Display the form as a dialog box and wait for the user to input text
            prompt.ShowDialog();

            // Get the input from the text box
            string input = textBox.Text;

            // Do something with the input, such as displaying it in a message box
           if(input=="2604")
            {DialogResult dialogResult= MessageBox.Show("هل تريد تغيير كلمة السر"+"\n"+ "او ارجاعها الي الافتراضية","تغيير كلمة السر", MessageBoxButtons.YesNo);
               if(dialogResult==DialogResult.Yes)
                {
                    Form prompt2 = new Form();
                    prompt2.Width = 200;
                    prompt2.Height = 300;
                    prompt2.Text = "Input";
                    prompt2.BackColor = Color.White;
                    prompt2.MaximizeBox = false;
                    prompt2.MinimizeBox = false;
                    prompt2.AutoSize = false;
                    prompt2.FormBorderStyle = FormBorderStyle.None;
                    prompt2.StartPosition = FormStartPosition.CenterParent;
                    // Create a label and text box to display the prompt and receive input
                    Label textLabel2 = new Label() { Left = 60, Top = 10, Text = "ادخل كلمة السر الجديده", RightToLeft = RightToLeft.Yes, TextAlign = ContentAlignment.TopRight, AutoSize = true };
                    textLabel2.Font = new Font("Segoe UI", 8);
                    Label textLabel4 = new Label() { Left = 50, Top = 170, Text = "عرض كلمة المرور", RightToLeft = RightToLeft.Yes, TextAlign = ContentAlignment.TopRight, AutoSize = true };
                    textLabel4.Font = new Font("Segoe UI", 8);
                    Guna.UI2.WinForms.Guna2TextBox textBox2 = new Guna.UI2.WinForms.Guna2TextBox() { Left = 20, Top = textLabel2.Bottom + 10, Width = 150, PasswordChar = '*',ForeColor=Color.Black };
                    Label textLabel3 = new Label() { Left = 75, Top = textBox2.Bottom + 10, Text = "اعد ادخال كلمة السر", RightToLeft = RightToLeft.Yes, TextAlign = ContentAlignment.TopRight, AutoSize = true };
                    textLabel3.Font = new Font("Segoe UI", 8);
                    Guna.UI2.WinForms.Guna2TextBox textBox3 = new Guna.UI2.WinForms.Guna2TextBox() { Left = 20, Top = textLabel3.Bottom + 10, Width = 150 , PasswordChar = '*',ForeColor=Color.Black};
                    Guna.UI2.WinForms.Guna2Button showButton1 = new Guna.UI2.WinForms.Guna2Button() { Text = "Show", Left = 120, Top = textLabel2.Bottom + 10, Width = 50, Height = 20,FillColor=Color.Transparent };
                    Guna.UI2.WinForms.Guna2Button showButton2 = new Guna.UI2.WinForms.Guna2Button() { Text = "Show", Left = 120, Top = textLabel3.Bottom + 10, Width = 50, Height = 20 ,FillColor=Color.Transparent };

                    Guna.UI2.WinForms.Guna2Button confirmButton2 = new Guna.UI2.WinForms.Guna2Button() { Text = "حفظ", Left =105, Width = 90, Top = textBox3.Bottom + 40, BorderThickness = 3, BorderRadius = 5, };
                    Guna.UI2.WinForms.Guna2Button confirmButton3 = new Guna.UI2.WinForms.Guna2Button() { Text = "افتراضي", Left = 5, Width = 90, Top = textBox3.Bottom + 40,BorderThickness=3,BorderColor=Color.Black,BorderRadius=5,ForeColor=Color.Black };
                    Guna.UI2.WinForms.Guna2Button confirmButton4 = new Guna.UI2.WinForms.Guna2Button() { Text = "الغاء", Left = 55, Width = 90, Top = textBox3.Bottom + 90,  BorderRadius = 5,BorderColor=Color.White };
                    confirmButton3.FillColor = Color.White;
                    confirmButton2.FillColor = Color.Black;
                    Guna.UI2.WinForms.Guna2ToggleSwitch showPasswordToggleSwitch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
                    showPasswordToggleSwitch.Checked = false;
                    showPasswordToggleSwitch.Left = 140;
                    showPasswordToggleSwitch.Top = 170;
                    showPasswordToggleSwitch.CheckedState.FillColor = Color.Black;
                    showPasswordToggleSwitch.UncheckedState.FillColor = Color.DimGray;

                    showPasswordToggleSwitch.Width = 35;
                    showPasswordToggleSwitch.Height = 20;

                    // Add an event handler to the toggle switch to show/hide the password characters
                    showPasswordToggleSwitch.CheckedChanged += (sender5, e5) =>
                    {
                        textBox2.UseSystemPasswordChar = !showPasswordToggleSwitch.Checked;
                        textBox2.PasswordChar = '\0';
                        textBox3.UseSystemPasswordChar = !showPasswordToggleSwitch.Checked;
                        textBox3.PasswordChar = '\0';
                        if(showPasswordToggleSwitch.Checked==true)
                        {
                            textLabel4.Text = "اخفاء كلمة المرور";
                        }
                        else {
                            textLabel4.Text = "عرض كلمة المرور";
                             }
                    };
                    // Set the confirm button to close the form when clicked
                    confirmButton2.Click += (sende, er) => { if (checkText(textBox2.Text, textBox3.Text)) { makePass(textBox3.Text); prompt2.Close(); } else { MessageBox.Show("كلمتان السر غير متطابقتان", "error",MessageBoxButtons.OK, icon: MessageBoxIcon.Error);  }  };
                    confirmButton3.Click += (sende, er) => {  makePass("Admin"); prompt2.Close(); };
                    confirmButton4.Click += (sende, er) => { prompt2.Close(); };
                    
                    textBox3.KeyDown += (se, erd) => { if (erd.KeyCode == Keys.Enter) prompt2.Close(); };
                    showButton1.Click += (sen, ei) => {
                        if (textBox2.PasswordChar == '*')
                        {
                            textBox2.PasswordChar = '\0'; // Show the actual characters
                            showButton1.Text = "Hide";
                        }
                        else
                        {
                            textBox2.PasswordChar = '*'; // Show the password character
                            showButton1.Text = "Show";
                        }
                    };
                    showButton2.Click += (senderr, er) => {
                        if (textBox3.PasswordChar == '*')
                        {
                            textBox3.PasswordChar = '\0'; // Show the actual characters
                            showButton2.Text = "Hide";
                        }
                        else
                        {
                            textBox3.PasswordChar = '*'; // Show the password character
                            showButton2.Text = "Show";
                        }
                    };
                    // Add the controls to the form
                    prompt2.Controls.Add(textBox2);
                    prompt2.Controls.Add(textBox3);
                    prompt2.Controls.Add(textLabel2);
                    prompt2.Controls.Add(textLabel3);
                    prompt2.Controls.Add(textLabel4);
                    prompt.Controls.Add(showButton1);
                    prompt.Controls.Add(showButton2);
                    prompt2.Controls.Add(showPasswordToggleSwitch);
                    prompt2.Controls.Add(confirmButton2);
                    prompt2.Controls.Add(confirmButton3);
                    prompt2.Controls.Add(confirmButton4);

                    // Display the form as a dialog box and wait for the user to input text
                    prompt2.ShowDialog();

                }
            }

        }
        public bool checkText(string tex1,string tex2)
        {
            if (tex1 == tex2)
                return true;
            else return false;
        }
        public void makePass(string pass)
        {
            string filePath = @"systemObservation.bat";
            //pass = "Admin\n" + pass;
            File.WriteAllText(filePath, pass);
            MessageBox.Show("تم تغيير كلمة السر");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.flag == true)
                //this.Hide();
            Program.ActiveForm.Hide();
            else 
            {
                this.Hide();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}
