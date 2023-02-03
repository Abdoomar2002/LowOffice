using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
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
using System.Windows.Forms;

//using System.Timers;
namespace LowOffice
{
    public partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().button1_Click(sender, e);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().button2_Click(sender, e);
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().button3_Click(sender, e);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Form1().nothingToDo();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            using (SaveFileDialog saveFile = new SaveFileDialog() { Filter = "Excel Workbook|*.xlxs" }) 
            {
                if(saveFile.ShowDialog()==DialogResult.OK)
                {


                    var fileInfo = new FileInfo(saveFile.FileName);
                    ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                    using (var pack=new ExcelPackage(fileInfo))
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
                            xcel.Cells[i+1, 1].Value = c[i-1].Id;
                            xcel.Cells[i+1, 2].Value = c[i-1].circleNum;
                            xcel.Cells[i+1, 3].Value = c[i-1].Hall;
                            xcel.Cells[i+1, 4].Value = c[i-1].oppenentName;
                            xcel.Cells[i+1, 5].Value = c[i-1].caseNum;
                            xcel.Cells[i+1, 6].Value = c[i-1].attribute;
                            xcel.Cells[i+1, 7].Value = c[i-1].date;
                            xcel.Cells[i+1, 8].Value = c[i-1].dateOflast;
                            xcel.Cells[i+1, 9].Value = c[i-1].describtion;
                            xcel.Cells[i+1, 10].Value = c[i-1].Lastone;
                            xcel.Cells[i+1, 11].Value = c[i-1].caseDecision;

                        }pack.Save();
                    }
                }
            } ;
           /* try
            {
                XLWorkbook xL = new XLWorkbook();
                Microsoft.Office.Interop.Excel.Application xcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.ApplicationClass workbook = new Microsoft.Office.Interop.Excel.ApplicationClass();
                CasesContext context = new CasesContext();
                var c = context.Cases.FromSqlRaw("select * from Cases").ToArray();
                var ca= File.OpenWrite("cases.xlxs" );
                //Microsoft.Office.Interop.Excel.
                xcel.Application.Workbooks.Add(Type.Missing);
                xcel.Cells[1, 0] = "Id";
                xcel.Cells[1, 1] = "رقم الدايره";
                xcel.Cells[1, 2] = "اسم المحكمة";
                xcel.Cells[1, 3] = "اسم الخصم";
                xcel.Cells[1, 4] = "رقم القضية";
                xcel.Cells[1, 5] = "صفة البنك";
                xcel.Cells[1, 6] = "تاريخ الجلسة";
                xcel.Cells[1, 7] = "تاريخ الجلسة السابقة";
                xcel.Cells[1, 8] = "موضوع الدعوي";
                xcel.Cells[1, 9] = "الجلسة السابقة";
                xcel.Cells[1, 10] = "قرار الجلسة";


                for (int i = 0; i < c.Length; i++)
                {
                    xcel.Cells[i, 0] = c[i].Id;
                    xcel.Cells[i, 1] = c[i].circleNum;
                    xcel.Cells[i, 2] = c[i].Hall;
                    xcel.Cells[i, 3] = c[i].oppenentName;
                    xcel.Cells[i, 4] = c[i].caseNum;
                    xcel.Cells[i, 5] = c[i].attribute;
                    xcel.Cells[i, 6] = c[i].date;
                    xcel.Cells[i, 7] = c[i].dateOflast;
                    xcel.Cells[i, 8] = c[i].describtion;
                    xcel.Cells[i, 9] = c[i].Lastone;
                    xcel.Cells[i, 10] = c[i].caseDecision;

                }
                xcel.Columns.AutoFit();
                xcel.Visible = true;
            }catch(Exception excep)
            {
                MessageBox.Show(excep.Message);
            }*/
        }

        private void FirstPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
           // var t = new Timer();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CasesContext cases = new CasesContext();
            cases.Cases.RemoveRange(cases.Cases);
            //cases.Database.ex
            cases.SaveChanges();
            MessageBox.Show("delete date");
        }
    }
}
