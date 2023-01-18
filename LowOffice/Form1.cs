using LowOffice.db;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
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

namespace LowOffice
{
    public partial class Form1 : Form
    {
        update up;
       
        public Form1()
        {
            InitializeComponent();
            this.Show();
        }
        
        public Form1(ShowAll sh)
        {
            
             InitializeComponent();
            
            button2_Click(null, null);
            update1.BringToFront();
            this.Activate();
            
        }
        public static string dt = "1";
        public static edit newEdit = new edit();
       
        public void button1_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          panel4.BringToFront();
            //this.Visible = false;
          
        }

        public void button3_Click(object sender, EventArgs e)
        {
           
            showAll1.BringToFront();
            newdata();         
        }

        private void button6_Click(object sender, EventArgs e)
        { if (comboBox1.Text=="")
            {
                MessageBox.Show("من فضلك ادخل البيانات كامله");
                return;
            }
            /*Id 
    رقم القضية
    اسم المحكمة
    رقم الدايرة
    اسم الخصم
    صفة البنك
    تاريخ الجلسة
    تاريخ الجلسة السابقة
    قرار الجلسة
    الجلسة السابقة
    موضوع الدعوي*/
            string search_key = "";
            if (comboBox1.Text == "Id") search_key = "Id";
            if (comboBox1.Text == "رقم القضية") search_key = "caseNum";
            if (comboBox1.Text == "اسم المحكمة") search_key = "Hall";
            if (comboBox1.Text == "رقم الدايرة") search_key = "circleNum";
            if (comboBox1.Text == "اسم الخصم") search_key = "oppenentName";
            if (comboBox1.Text == "صفة البنك") search_key = "attribute";
            if (comboBox1.Text == "تاريخ الجلسة") search_key = "date";
            if (comboBox1.Text == "تاريخ الجلسة السابقة") search_key = "dateOflast";
            if (comboBox1.Text == "قرار الجلسة") search_key = "caseDecision";
            if (comboBox1.Text == "الجلسة السابقة") search_key = "Lastone";
            if (comboBox1.Text == "موضوع الدعوي") search_key = "describtion";


            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();
            var searchCases = context.Cases.FromSqlRaw("select * from Cases where (" +search_key+"='"+textBox1.Text+"')  order by Id desc");
           if(searchCases==null)
            {
                MessageBox.Show("غير موجود");
            }
           
            userControl31.dataGridView1.DataSource = searchCases.ToList();
            userControl31.BringToFront();
        }
     private void newdata()
        {

            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();
            var allCases = context.Cases.FromSqlRaw("select * from Cases order by Id desc");
            
            showAll1.dataGridView1.DataSource = allCases.ToList();
            var Id= context.Cases.FromSqlRaw("select Id from Cases order by Id desc");
           // showAll1.Column1.DataGridView.DataSource = allCases.ToList();
           // allCases = null;
        }

        public  void button2_Click(object sender, EventArgs e)
        {
            /* edit1.ResetText();


             if (sender != null || e != null)
             {
                 Form2 f = new Form2();
                 f.Show();
                 edit1.BringToFront();
               //  edit1.outcase(new Cases() { Id = 5, Hall = "asd", circleNum = "f", caseDecision = "asd", describtion = "asd" });   
             }
             else
             {
                 MessageBox.Show(dt);
                /* Cases cases = new Cases();
                 cases.Hall = "hsd";
                 edit1.outcase(cases);*/



            // Form2 f = new Form2();
            //f.Show();
            // MessageBox.Show("done");
            //edit1.textBox1.Text = "abc";
            /* 
                 CasesContext context = new CasesContext();
            edit edit = new edit();
         //edit.textBox1.Text = "abc";   
         /*
         var editcase = context.Cases.FromSqlRaw("select * from Cases where Id=" + dt + " order by Id desc").FirstOrDefault();
             edit.textBox1.Text = editcase.circleNum.ToString();
             edit.textBox4.Text = editcase.Hall;
             edit.textBox3.Text = editcase.caseNum;
             edit.textBox8.Text = editcase.attribute;
             edit.textBox5.Text = editcase.oppenentName;
             edit.textBox11.Text = editcase.describtion;
             edit.textBox10.Text = editcase.Lastone;
             edit.comboBox1.Text = editcase.caseDecision;
         //edit1.dateTimePicker2.Text = editcase.date;
         //edit1.dateTimePicker1.Text = editcase.dateOflast;
         edit.outcase(new Cases()
         {
             circleNum = editcase.circleNum,
             Hall = editcase.Hall,
             caseNum = editcase.caseNum,
             attribute = editcase.attribute,
             oppenentName = editcase.oppenentName,
             describtion = editcase.describtion,
             Lastone = editcase.Lastone,
             caseDecision = editcase.caseDecision,
             date = editcase.date,
             dateOflast = editcase.dateOflast
         });
         MessageBox.Show(editcase.circleNum);

         }
             */
           // new update(up);
            update1.BringToFront();

            
            
        }
        public void edit(string text)
        {
            Form2 f = new Form2();
            CasesContext context = new CasesContext();
            var editcase = context.Cases.FromSqlRaw("select * from Cases where Id="+text+" order by Id desc").FirstOrDefault();
            //MessageBox.Show(editcase.ToString());
            dt = text;
            edit e = new edit();
           
        }
        
       

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
          
            //printDocument1.DefaultPageSettings.Landscape = true;
            // e.Graphics.DrawImageUnscaled(bmp, 0,0);
            Graphics g = this.CreateGraphics();
            bmp = new Bitmap(this.Size.Width, this.Size.Height);

            Graphics mg = Graphics.FromImage(bmp);
            mg.CopyFromScreen(this.Location.X+15, this.Location.Y + 106+40, 290, 200, this.Size);
           // this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        private void button7_Click(object sender, EventArgs e)
        {
            /* int screenLeft = SystemInformation.VirtualScreen.Left;
             int screenTop = SystemInformation.VirtualScreen.Top;
             int screenWidth = SystemInformation.VirtualScreen.Width;
             int screenHeight = SystemInformation.VirtualScreen.Height;
             Graphics g = this.CreateGraphics();
             using (bmp = new Bitmap(this.panel4.Width, this.panel4.Height))
             {
                 // Draw the screenshot into our bitmap.
                 using (Graphics mg = Graphics.FromImage(bmp))
                 {

                     
                 }
             }*/
           // Graphics mg = Graphics.FromImage(bmp);
            //mg.CopyFromScreen(this.Width, this.Height + 106, 0, 0, bmp.Size);
           // printPreviewDialog1.ShowDialog();
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;

            DialogResult dialogResult = printDialog.ShowDialog();
            if(dialogResult==DialogResult.OK)
            {
                printDocument1.DocumentName = "newCases";
                printDocument1.Print();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit();
        }
        public void nothingToDo()
        {
            userControl31.BringToFront();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Excel Workbook|*.xlxs" })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {


                    var fileInfo = new FileInfo(saveFile.FileName);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pack = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet xcel = pack.Workbook.Worksheets.Add("Cases");
                        CasesContext context = new CasesContext();
                        var c = context.Cases.FromSqlRaw("select * from Cases").ToArray();
                        // workbook.SaveAs(saveFile.FileName);

                        xcel.Cells[1, 1].Value = "Id";
                        xcel.Cells[1, 2].Value = "رقم الدايره";
                        xcel.Cells[1, 3].Value = "اسم المحكمة";
                        xcel.Cells[1, 4].Value = "اسم الخصم";
                        xcel.Cells[1, 5].Value = "رقم القضية";
                        xcel.Cells[1, 6].Value = "صفة البنك";
                        xcel.Cells[1, 7].Value = "تاريخ الجلسة";
                        xcel.Cells[1, 8].Value = "تاريخ الجلسة السابقة";
                        xcel.Cells[1, 9].Value = "موضوع الدعوي";
                        xcel.Cells[1, 10].Value = "الجلسة السابقة";
                        xcel.Cells[1, 11].Value = "قرار الجلسة";


                        for (int i = 1; i <= c.Length; i++)
                        {
                            xcel.Cells[i + 1, 1].Value = c[i - 1].Id;
                            xcel.Cells[i + 1, 2].Value = c[i - 1].circleNum;
                            xcel.Cells[i + 1, 3].Value = c[i - 1].Hall;
                            xcel.Cells[i + 1, 4].Value = c[i - 1].oppenentName;
                            xcel.Cells[i + 1, 5].Value = c[i - 1].caseNum;
                            xcel.Cells[i + 1, 6].Value = c[i - 1].attribute;
                            xcel.Cells[i + 1, 7].Value = c[i - 1].date;
                            xcel.Cells[i + 1, 8].Value = c[i - 1].dateOflast;
                            xcel.Cells[i + 1, 9].Value = c[i - 1].describtion;
                            xcel.Cells[i + 1, 10].Value = c[i - 1].Lastone;
                            xcel.Cells[i + 1, 11].Value = c[i - 1].caseDecision;

                        }
                        pack.Save();
                    }
                }
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("يتم العمل عليها");
        }
    } 
}
