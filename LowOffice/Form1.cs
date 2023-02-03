using LowOffice.db;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections;
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
        public string activeUser;

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
            activeUser = "add";


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
            activeUser = "all";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            activeUser = "search";

            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();
            if (comboBox1.Text == "")
            {
                var searchTerm = textBox1.Text!=""?textBox1.Text:"";
                var  searchCases3 = context.Cases
                            .Where(c => c.caseNum.Contains(searchTerm) ||
                            c.describtion.Contains(searchTerm)||
                            c.Hall.Contains(searchTerm)||
                            c.attribute.Contains(searchTerm) ||
                            c.typeOfHall.Contains(searchTerm) ||
                            c.circleNum.Contains(searchTerm) ||
                            c.caseDecision.Contains(searchTerm) ||
                            c.Lastone.Contains(searchTerm) )
                            .AsEnumerable()
                            .GroupBy(c => c.caseNum)
                            .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());

                userControl31.dataGridView1.DataSource = searchCases3.OrderBy(c => c.date).ToList();
                userControl31.dataGridView1.Columns[0].Visible = false;
                userControl31.BringToFront();
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
            if (comboBox1.Text == "نوع المحكمة") search_key = "typeOfHall";
            if (comboBox1.Text == "رقم القضية") search_key = "caseNum";
            if (comboBox1.Text == "اسم المحكمة") search_key = "Hall";
            if (comboBox1.Text == "رقم الدايرة") search_key = "circleNum";
            if (comboBox1.Text == "اسم الخصم") search_key = "oppenentName";
            if (comboBox1.Text == "صفة البنك") search_key = "attribute";
            if (comboBox1.Text == "تاريخ الجلسة التالية") search_key = "date";
            if (comboBox1.Text == "تاريخ الجلسة السابقة") search_key = "dateOflast";
            if (comboBox1.Text == "قرار الجلسة") search_key = "caseDecision";
            if (comboBox1.Text == "قرار الجلسة السابقة") search_key = "Lastone";
            if (comboBox1.Text == "موضوع الدعوي") search_key = "describtion";


            
            //   var searchCases = context.Cases.FromSqlRaw("select * from Cases where (" + search_key + "='" + textBox1.Text + "') group by caseNum  order by date asc ");

            //        var searchCases = context.Cases
            //.Where(c => c[search_key] == textBox1.Text)
            //.GroupBy(c => c.caseNum)
            //.Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());

            IEnumerable<Cases> searchCases;
          //  IEnumerable<Cases> searchCases;
            switch (search_key)
            {
                case "caseNum":
                    searchCases = context.Cases
                        .Where(c => c.caseNum == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "Hall":
                    searchCases = context.Cases
                        .Where(c => c.Hall == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "circleNum":
                    searchCases = context.Cases
                        .Where(c => c.circleNum == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "oppenentName":
                    searchCases = context.Cases
                        .Where(c => c.oppenentName == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "attribute":
                    searchCases = context.Cases
                        .Where(c => c.attribute == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "date":
                    searchCases = context.Cases
                        .Where(c => c.date.ToString() == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "dateOflast":
                    searchCases = context.Cases
                        .Where(c => c.dateOflast.ToString() == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "describtion":
                    searchCases = context.Cases
                        .Where(c => c.describtion == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "caseDecision":
                    searchCases = context.Cases
                        .Where(c => c.caseDecision == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                case "Lastone":
                    searchCases = context.Cases
                        .Where(c => c.Lastone == textBox1.Text)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
                default:
                    searchCases = context.Cases
                        .Where(c => c.Id == -1)
                        .AsEnumerable()
                        .GroupBy(c => c.caseNum)
                        .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());
                    break;
            }






            //var searchCases = context.Cases.FromSqlRaw($"Select * from Cases where {search_key} =' {textBox1.Text}' ").OrderBy(c => c.date).AsEnumerable().GroupBy(c => c.caseNum);

            if (searchCases == null)
            {
                MessageBox.Show("غير موجود");
            }

              userControl31.dataGridView1.DataSource = searchCases.OrderBy(c=>c.date).ToList();
            userControl31.dataGridView1.Columns[0].Visible = false;
            userControl31.BringToFront();
        }
        private void newdata()
        {

            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();
            var allCases = context.Cases
                       .AsEnumerable()
                       .GroupBy(c => c.caseNum)
                       .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault()).OrderBy(c => c.date);

              showAll1.dataGridView1.DataSource = allCases.ToList();
            var Id = context.Cases.FromSqlRaw("select Id from Cases order by Id desc");
            // showAll1.Column1.DataGridView.DataSource = allCases.ToList();
            // allCases = null;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            update1.BringToFront();
            activeUser = "update";
        }
        public void edit(string text)
        {
            Form2 f = new Form2();
            CasesContext context = new CasesContext();
            var editcase = context.Cases.FromSqlRaw("select * from Cases where Id=" + text + " order by Id desc").FirstOrDefault();
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
            mg.CopyFromScreen(this.Location.X + 15, this.Location.Y + 106 + 40, 290, 200, this.Size);
            // this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        Bitmap bmp;
        private void button7_Click(object sender, EventArgs e)
        {
            List<Cases> printCases;
            MessageBox.Show(activeUser);
            switch (activeUser)
            {
                case "add":
                    
                    break;
                case "all":
                    printCases = showAll1.CasesList;
                    print(printCases);
                    break;
                case "search":
                    printCases = userControl31.CasesList;
                    print(printCases);
                    break;
                case "update":
                    //cases = GetCasesForUpdate();
                   printCases= update1.printCase();
                    print(printCases);
                    break;
                case "data":
                    printCases=filters1.CasesList;
                    print(printCases);
                    break;
                case "notifi":
                    //cases = GetNotificationCases();
                    break;
                default:
                    break;
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

            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {


                    var fileInfo = new FileInfo(saveFile.FileName);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pack = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet xcel = pack.Workbook.Worksheets.Add("Cases");
                        CasesContext context = new CasesContext();
                        var c = context.Cases
                       .AsEnumerable()
                       .GroupBy(c => c.caseNum)
                       .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault()).OrderBy(c => c.date).ToArray();

                        // workbook.SaveAs(saveFile.FileName);

                        xcel.Cells[1, 1].Value = "نوع المحكمة";
                        xcel.Cells[1, 2].Value = "اسم المحكمة";
                        xcel.Cells[1, 3].Value = "رقم القضية";
                        xcel.Cells[1, 4].Value = "رقم الدائره";
                        xcel.Cells[1, 5].Value = "اسم الخصم";
                        xcel.Cells[1, 6].Value = "صفة البنك";
                        xcel.Cells[1, 7].Value = "تاريخ الجلسة التالية";
                        xcel.Cells[1, 8].Value = "تاريخ الجلسة السابقة";
                        xcel.Cells[1, 9].Value = "موضوع الدعوي";
                        xcel.Cells[1, 10].Value = "قرار الجلسة السابقة";
                        xcel.Cells[1, 11].Value = "قرار الجلسة";


                        for (int i = 1; i <= c.Length; i++)
                        {
                            xcel.Cells[i + 1, 1].Value = c[i - 1].typeOfHall;
                            xcel.Cells[i + 1, 2].Value = c[i - 1].Hall;
                            xcel.Cells[i + 1, 3].Value = c[i - 1].caseNum;
                            xcel.Cells[i + 1, 4].Value = c[i - 1].circleNum;
                            xcel.Cells[i + 1, 5].Value = c[i - 1].oppenentName;
                            xcel.Cells[i + 1, 6].Value = c[i - 1].attribute;
                            xcel.Cells[i + 1, 7].Value = c[i - 1].date.ToString();
                            xcel.Cells[i + 1, 8].Value = c[i - 1].dateOflast.ToString();
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
            activeUser = "notifi";

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6_Click(null, null);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            filters1.BringToFront();
            activeUser = "data";

        }

        private void showAll1_Load(object sender, EventArgs e)
        {

        }
        public void control(string num) 
        {
            update1.getRowOutside(num);
            update1.BringToFront();
            showAll1.SendToBack();
            activeUser = "update";
          //  return update1;
        }
       
        public void print(List<Cases>data)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {


                    var fileInfo = new FileInfo(saveFile.FileName);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pack = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet xcel = pack.Workbook.Worksheets.Add("Cases");
                        CasesContext context = new CasesContext();
                       
                        // workbook.SaveAs(saveFile.FileName);

                        xcel.Cells[1, 1].Value = "نوع المحكمة";
                        xcel.Cells[1, 2].Value = "اسم المحكمة";
                        xcel.Cells[1, 3].Value = "رقم القضية";
                        xcel.Cells[1, 4].Value = "رقم الدائره";
                        xcel.Cells[1, 5].Value = "اسم الخصم";
                        xcel.Cells[1, 6].Value = "صفة البنك";
                        xcel.Cells[1, 7].Value = "تاريخ الجلسة التالية";
                        xcel.Cells[1, 8].Value = "تاريخ الجلسة السابقة";
                        xcel.Cells[1, 9].Value = "موضوع الدعوي";
                        xcel.Cells[1, 10].Value = "قرار الجلسة السابقة";
                        xcel.Cells[1, 11].Value = "قرار الجلسة";

                        int i = 1;
                        foreach (var cases in data)
                        {
                            
                            xcel.Cells[i + 1, 1].Value = cases.typeOfHall;
                            xcel.Cells[i + 1, 2].Value = cases.Hall;
                            xcel.Cells[i + 1, 3].Value = cases.caseNum;
                            xcel.Cells[i + 1, 4].Value = cases.circleNum;
                            xcel.Cells[i + 1, 5].Value = cases.oppenentName;
                            xcel.Cells[i + 1, 6].Value = cases.attribute;
                            xcel.Cells[i + 1, 7].Value = cases.date.ToString();
                            xcel.Cells[i + 1, 8].Value = cases.dateOflast.ToString();
                            xcel.Cells[i + 1, 9].Value = cases.describtion;
                            xcel.Cells[i + 1, 10].Value = cases.Lastone;
                            xcel.Cells[i + 1, 11].Value = cases.caseDecision;
                            i++;
                        }
                        pack.Save();
                    }
                }
            };
            MessageBox.Show("تم الحفظ بنجاح");
        }
    }
}
