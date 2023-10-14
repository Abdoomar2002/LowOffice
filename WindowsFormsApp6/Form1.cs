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
using System.Linq;
using OfficeOpenXml;
using System.IO;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public string activeUser= "notifi";

        public Form1()
        {
            this.InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            /* Cases newcase = new Cases { attribute = "1234" ,date=DateTime.Now,dateOflast=DateTime.Now};
             CasesContext context = new CasesContext();
             // CasesContext context = new CasesContext();
            if( context.Database.Exists())
             {
                 //   context.Cases.Add(newcase);
             }
             else
             {
                 context.Database.Create();
             }
             context.Cases.Add(newcase);
             context.SaveChanges();
             var cases = context.Cases.ToArray();
            // MessageBox.Show(cases[0].attribute);
            */
      
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CasesContext context = new CasesContext();
           // var cases = context.Cases.ToList();
            //guna2DataGridView1.DataSource = cases;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
        //add
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            userControl11.BringToFront();
            activeUser = "add";
            label2.Text = "";
        }
        //get All
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            userControl21.BringToFront();
            activeUser = "all";
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();
            var allCases = context.Cases
                       .AsEnumerable()
                       .GroupBy(c => c.caseNum)
                       .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault()).OrderByDescending(c => c.date).ToList();
            allCases.AddRange(context.Cases.AsEnumerable().Where(c => c.caseDecision == "تحت الرفع").ToList());

            userControl21.dataGridView1.DataSource = allCases.OrderByDescending(c=>c.date).ToList();
            userControl21.dataGridView1.Columns[0].Visible = false;
            userControl21.dataGridView1.Columns[3].Visible = false;
            userControl21.dataGridView1.Columns[6].Visible = false;
            userControl21.dataGridView1.Columns[8].Visible = false;
            userControl21.dataGridView1.Columns[12].Visible = false;
            userControl21.dataGridView1.Columns[13].Visible = false;
            userControl21.dataGridView1.Columns[17].Visible = false;
            userControl21.dataGridView1.Columns[18].Visible = false;
            userControl21.dataGridView1.Columns[22].Visible = false;
            // var Id = context.Cases.FromSqlRaw("select Id from Cases order by Id desc");
            // showAll1.Column1.DataGridView.DataSource = allCases.ToList();
            // allCases = null;
            label2.Text = " عدد القضايا " + allCases.Count.ToString();
        }
        //enter key for search
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                search();
            }
        }
        public void search()
        {
            activeUser = "search";

            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();
            if (comboBox1.Text == "")
            {
                var searchTerm = textBox1.Text != "" ? textBox1.Text : "";
                var searchCases3 = context.Cases
                            .Where(c => c.caseNum.Contains(searchTerm) ||
                            c.describtion.Contains(searchTerm) ||
                            c.Hall.Contains(searchTerm) ||
                            c.attribute.Contains(searchTerm) ||
                            c.typeOfHall.Contains(searchTerm) ||
                            c.circleNum.Contains(searchTerm) ||
                            c.caseDecision.Contains(searchTerm) ||
                            c.Lastone.Contains(searchTerm) ||
                            c.depart.Contains(searchTerm) ||
                            c.typeOfHall.Contains(searchTerm) ||
                            c.serial.Contains(searchTerm) ||
                            c.nameofpers.Contains(searchTerm) ||
                            c.nameoflaw.Contains(searchTerm) ||
                            c.oppenentName.Contains(searchTerm) ||
                            c.oppenent3.Contains(searchTerm) ||
                            c.location.Contains(searchTerm) ||
                            c.price.Contains(searchTerm))
                           .ToList();

                if (!searchCases3.Any())
                {
                    MessageBox.Show("غير موجود");
                    return;
                }
                else
                {
                    var part1 = searchCases3.AsEnumerable().Where(c=>c.caseDecision!="تحت الرفع")
                            .GroupBy(c => c.caseNum)
                            .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault()).ToList();
                    var part2 = searchCases3.AsEnumerable()
                            .Where(c=>c.caseDecision=="تحت الرفع").ToList();
                    searchCases3 = part1;
                   searchCases3.AddRange(part2);
                    userControl31.dataGridView1.DataSource = searchCases3.OrderByDescending(c => c.date).ToList();
                    userControl31.dataGridView1.Columns[0].Visible = false;
                    userControl31.dataGridView1.Columns[3].Visible = false;
                    userControl31.dataGridView1.Columns[6].Visible = false;
                    userControl31.dataGridView1.Columns[8].Visible = false;
                    userControl31.dataGridView1.Columns[12].Visible = false;
                    userControl31.dataGridView1.Columns[13].Visible = false;
                    userControl31.dataGridView1.Columns[17].Visible = false;
                    userControl31.dataGridView1.Columns[18].Visible = false;
                    userControl31.dataGridView1.Columns[22].Visible = false;

                    userControl31.BringToFront();
                    label2.Text = " عدد القضايا " + searchCases3.Count.ToString();

                    return;
                }
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
            if (comboBox1.Text == "اسم المحكمة") search_key = "Hall";
            if (comboBox1.Text == "رقم القضية") search_key = "caseNum";
            if (comboBox1.Text == "رقم الدائرة") search_key = "circleNum";
            if (comboBox1.Text == "اسم الخصم") search_key = "oppenentName";
            if (comboBox1.Text == "صفة البنك") search_key = "attribute";
            if (comboBox1.Text == "تاريخ الجلسة التالية") search_key = "date";
            if (comboBox1.Text == "تاريخ الجلسة السابقة") search_key = "dateOflast";
            if (comboBox1.Text == "قرار الجلسة") search_key = "caseDecision";
            if (comboBox1.Text == "قرار الجلسة السابقة") search_key = "Lastone";
            if (comboBox1.Text == "موضوع الدعوي") search_key = "describtion";
            if (comboBox1.Text == "الفرع") search_key = "dept";
            if (comboBox1.Text == "الرقم التعريفي للعميل") search_key = "num";
            if (comboBox1.Text == "اسم الخصم2") search_key = "name";
            if (comboBox1.Text == "اسم الخصم3") search_key = "name2";
            if (comboBox1.Text == "اسم المأمورية") search_key = "loc";
            if (comboBox1.Text == "المبلغ") search_key = "price";




            //   var searchCases = context.Cases.FromSqlRaw("select * from Cases where (" + search_key + "='" + textBox1.Text + "') group by caseNum  order by date asc ");

            //        var searchCases = context.Cases
            //.Where(c => c[search_key] == textBox1.Text)
            //.GroupBy(c => c.caseNum)
            //.Select(g => g.OrderByDescending(c => c.date).FirstOrDefault());

            var searchCases=context.Cases.ToList();

            //  IEnumerable<Cases> searchCases;
            string key = textBox1.Text;
            switch (search_key)
            {
                case "caseNum":
                    searchCases = context.Cases
                        .Where(c => c.caseNum.Contains(key)).ToList();

                    break;
                case "Hall":
                    searchCases = context.Cases
                        .Where(c => c.Hall.Contains(textBox1.Text)).ToList();

                    break;
                case "circleNum":
                    searchCases = context.Cases
                        .Where(c => c.circleNum.Contains(key)).ToList();
                    break;
                case "oppenentName":
                    searchCases = context.Cases
                        .Where(c => c.oppenentName.Contains(key)).ToList();
                    break;
                case "attribute":
                    searchCases = context.Cases
                        .Where(c => c.attribute.Contains(key)).ToList();
                    break;
                case "law":
                    searchCases = context.Cases
                        .Where(c => c.nameoflaw.Contains(key)).ToList();
                    break;
                case "price":
                    searchCases = context.Cases
                        .Where(c => c.price.Contains(key)).ToList();
                    break;
                case "date":
                    DateTime dateTime;
                    searchCases = context.Cases
                        .Where(c => DateTime.TryParse(key, out dateTime) && c.date == dateTime).ToList();
                    break;
                case "dateOflast":
                    DateTime dateTime2;
                    searchCases = context.Cases
                        .Where(c => DateTime.TryParse(key, out dateTime2) && c.dateOflast == dateTime2).ToList();
                    break;
                case "describtion":
                    searchCases = context.Cases
                        .Where(c => c.describtion.Contains(key)).ToList();
                    break;
                case "caseDecision":
                    searchCases = context.Cases
                        .Where(c => c.caseDecision.Contains(key)).ToList();
                    break;
                case "Lastone":
                    searchCases = context.Cases
                        .Where( c => c.Lastone.Contains(key)).ToList();
                    break;
                case "name":
                    searchCases = context.Cases
                        .Where(c => c.nameofpers.Contains(key)).ToList();
                    break;
                case "name2":
                    searchCases = context.Cases
                        .Where(c => c.oppenent3.Contains(key)).ToList();
                    break;
                case "loc":
                    searchCases = context.Cases
                        .Where(c => c.location.Contains(key)).ToList();
                    break;
                case "num":
                    searchCases = context.Cases
                        .Where(c => c.serial.Contains(key)).ToList();
                    break;
                case "dept":
                    searchCases = context.Cases
                        .Where(c => c.depart.Contains(key)).ToList();
                    break;
                default:
                    searchCases = context.Cases
                        .Where(c => c.Id == -1).ToList();
                    break;
            }
            // searchCases = searchCases.Count()==0?searchCases :searchCases.ToArray();





            //var searchCases = context.Cases.FromSqlRaw($"Select * from Cases where {search_key} =' {textBox1.Text}' ").OrderBy(c => c.date).AsEnumerable().GroupBy(c => c.caseNum);

            if (!searchCases.Any())
            {
                MessageBox.Show("غير موجود");
            }
            else
            {
                var part1 = searchCases.AsEnumerable().Where(c => c.caseDecision != "تحت الرفع")
                            .GroupBy(c => c.caseNum)
                            .Select(g => g.OrderByDescending(c => c.date).FirstOrDefault()).ToList();
                var part2 = searchCases.AsEnumerable()
                        .Where(c => c.caseDecision == "تحت الرفع").ToList();
                searchCases = part1;
                searchCases.AddRange(part2);
                userControl31.dataGridView1.DataSource = searchCases.OrderByDescending(c => c.date).ToList();
                userControl31.dataGridView1.Columns[0].Visible = false;
                userControl31.dataGridView1.Columns[3].Visible = false;
                userControl31.dataGridView1.Columns[6].Visible = false;
                userControl31.dataGridView1.Columns[8].Visible = false;
                userControl31.dataGridView1.Columns[13].Visible = false;
                userControl31.dataGridView1.Columns[12].Visible = false;
                userControl31.dataGridView1.Columns[17].Visible = false;
                userControl31.dataGridView1.Columns[18].Visible = false;
                userControl31.dataGridView1.Columns[22].Visible = false;
                label2.Text = " عدد القضايا " + searchCases.Count.ToString();

                userControl31.BringToFront();
            }
        }

        //update 
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            update1.BringToFront();
            activeUser = "update";
            label2.Text = "";

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            filters1.BringToFront();
            filters1.guna2Button1_Click(null,null);
            filters1.setCounter();
            activeUser = "data";
          

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            activeUser = "notifi";
            notification1.BringToFront();
            notification1.notification_Load(null, null);
            notification1.setCounter();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            var c = context.Cases
                        .AsEnumerable()
                        .GroupBy(b => b.caseNum)
                        .Select(g => g.OrderByDescending(b => b.date).FirstOrDefault()).OrderBy(b => b.date).ToList();

            // workbook.SaveAs(saveFile.FileName);
            Print(c);

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            List<Cases> printCases;
            //  MessageBox.Show(activeUser);
            switch (activeUser)
            {
                case "add":
                    printCases = userControl11.printCase();
                    Print(printCases);
                    break;
                case "all":
                    printCases = userControl21.CasesList;
                    Print(printCases);
                    break;
                case "search":
                    printCases = userControl31.CasesList;
                    Print(printCases);
                    break;
                case "update":
                    //cases = GetCasesForUpdate();
                    printCases = update1.printCase();
                    Print(printCases);
                    break;
                case "data":
                    printCases = filters1.CasesList;
                    Print(printCases);
                    break;
                case "notifi":
                    printCases = notification1.CasesList;
                    Print(printCases);
                    break;
                default:
                    break;
            }
        } 
    private void Print(List<Cases> data)
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
                        // Set header row
                        string[] headers = {
                            "نوع المحكمة",
                            "محكمة",
                            "رقم القضية",
                            "تاريخ ورود الملف",
                            "تاريخ إقامة الدعوى",
                            "رقم الدائره",
                            "صفة البنك",
                            "اسم الخصم",
                            "موضوع الدعوي",
                            "المبلغ المطالب به",
                            "تاريخ الجلسة",
                            "القرار",
                            "المبلغ المقضي به",
                            "اسم الفرع",
                            "الرقم التعريفي للعميل",
                            "اسم المحامي",
                         "اسم المأمورية"
                            // Add more headers here...
                        };

                        for (int i = 0; i < headers.Length; i++)
                        {
                            xcel.Cells[1, headers.Length - i].Value = headers[i];
                        }

                        // Fill data rows
                        for (int i = 0; i < data.Count; i++)
                        {
                            Cases cases = data[i];
                            xcel.Cells[i + 2, 17].Value = cases.typeOfHall;
                            xcel.Cells[i + 2, 16].Value = cases.Hall;
                            xcel.Cells[i + 2, 15].Value = cases.caseNum;
                            xcel.Cells[i + 2, 14].Value = cases.arrival.ToLongDateString();
                            xcel.Cells[i + 2, 13].Value = cases.FirstDate.ToLongDateString();
                            xcel.Cells[i + 2, 12].Value = cases.circleNum;
                            xcel.Cells[i + 2, 11].Value = cases.attribute;
                            xcel.Cells[i + 2, 10].Value = cases.oppenentName;      
                            xcel.Cells[i + 2, 9].Value = cases.describtion;
                            xcel.Cells[i + 2, 8].Value = cases.price;
                            xcel.Cells[i + 2, 7].Value = cases.date.ToLongDateString();
                            xcel.Cells[i + 2, 6].Value = cases.Lastone;
                            xcel.Cells[i + 2, 5].Value = cases.lastPrice;
                            xcel.Cells[i + 2, 4].Value = cases.depart;
                            xcel.Cells[i + 2, 3].Value = cases.serial;
                            xcel.Cells[i + 2, 2].Value = cases.nameoflaw;
                            xcel.Cells[i + 2, 1].Value = cases.location;

                            // Add more cell values for additional properties
                            // Make sure to adjust the column index accordingly

                            // Example: xcel.Cells[i + 2, 19].Value = cases.MyOtherProperty;

                            // Continue to add more cells for other properties
                        }

                        pack.Save();
                    }
                }
            }
        }


        private void guna2Button8_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("هل تريد حفظ البيانات", "خروج", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {
                switch (activeUser)
                {
                    case "add":
                        userControl11.save();
                        break;
                    case "update":
                        //cases = GetCasesForUpdate();
                        update1.guna2Button1_Click(null, null);
                        break;
                    default:
                        break;
                }
            }
            else
            {

            }
            this.Hide();
        }

        private void guna2Button1_Enter(object sender, EventArgs e)
        {

            Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)sender;
            button.FillColor = Color.White;
            button.ForeColor = Color.Black;
        }

        private void guna2Button1_Leave(object sender, EventArgs e)
        {

            Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)sender;
            button.FillColor = Color.Transparent;
            button.ForeColor = Color.White;
        }
        public void control(string num)
        {
            update1.getRowOutside(num);
            update1.BringToFront();
            //showAll1.SendToBack();
            activeUser = "update";
            //  return update1;*/
        }
        public void undertest(int num)
        {
            update1.getId(num);
            update1.BringToFront();
            //showAll1.SendToBack();
            activeUser = "update";
            label2.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new CasesContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE Cases");
               // context.Database.Delete();
                context.SaveChanges();
            }
        }

        private void notification1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!Program.flag)
            Application.ExitThread();
            else
            {
                Program.ActiveForm.Hide();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
          
            var x=  MessageBox.Show("هل تريد حفظ البيانات", "خروج", MessageBoxButtons.YesNoCancel);
            if(x==DialogResult.Yes)
            {
                switch (activeUser)
                {
                    case "add":
                        userControl11.guna2Button1_Click(null,null);
                        break;
                    case "update":
                        //cases = GetCasesForUpdate();
                        update1.guna2Button1_Click(null,null);
                        break;
                    default:
                        break;
                }
                if (Program.flag == true)
                    //this.Hide();
                    Program.ActiveForm.Hide();
                else
                {
                    Application.ExitThread();
                }
            }
            else if(x==DialogResult.No)
            {
                if (Program.flag == true)
                    //this.Hide();
                    Program.ActiveForm.Hide();
                else
                {
                    Application.ExitThread();
                }
            }
            
        }
    }
}
