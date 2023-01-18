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
    public partial class update : UserControl
    {public static bool b1=true,b2=false;
        public int num;
        public static bool flag = true;
        public static int outIndex;
        public update()
        {
            InitializeComponent();
            //MessageBox.Show(flag.ToString());
            if (!flag)
            {
                new update("hh");
              //  MessageBox.Show("hi");
               // button6_Click(null, null);
            }flag = true;
            panel3.SendToBack();
            panel3.Visible = b2;
            panel2.BringToFront();
            panel2.Visible = b1;
        }//Form1 sho;
        update sho;
        public update(string sh)
        {
            InitializeComponent();
            // sho = sh;
           // ActiveControl = this.ActiveControl;
            //this.ActiveControl = ActiveControl;
            flag = false;
            panel2.Visible = b2;
            panel3.Visible = b1;
            panel3.BringToFront();
            this.BringToFront();
            getData.Text = outIndex.ToString();
            button6_Click(null, null);
          //  MessageBox.Show(getData.Text);
            
        }

        private void takeId1_Load(object sender, EventArgs e)
        {


            // panel3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (getData.Text != "" && int.TryParse(getData.Text, out num))
            {
                panel2.Visible = b2;
                panel3.Visible = b1;
                panel3.BringToFront();
                CasesContext context = new CasesContext();
                Cases updCase = new Cases();
                updCase = context.Cases.FromSqlRaw("select * from Cases where Id=" + num).FirstOrDefault();
                if (updCase != null)
                {
                    caseDescision.Text = updCase.caseDecision;
                    Hall.Text = updCase.Hall;
                    date.Text = updCase.date;
                    dateOfLast.Text = updCase.dateOflast;
                    caseNum.Text = updCase.caseNum;
                    circleNum.Text = updCase.circleNum;
                    oppenentName.Text = updCase.oppenentName;
                    attribute.Text = updCase.attribute;
                    lastOne.Text = updCase.Lastone;
                    describtion.Text = updCase.describtion;
                }
                else 
                {
                    button1_Click(null, null);
                    MessageBox.Show("لا يوجد قضية بهذا الرقم");
                }

            }
            else
            {
                MessageBox.Show("ادخل قيمة صحيحة من فضلك");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData.Text = "";
            panel3.SendToBack();
            panel3.Visible = b2;
            panel2.BringToFront();
            panel2.Visible = b1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            string date2 = date.Text;
            string dateOflast2 = dateOfLast.Text;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2


            };
            context.Cases.Add(newcase);
            context.SaveChanges();
            context.SaveChangesAsync();
            MessageBox.Show("تمت اضافة القضية بنجاح");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            string date2 = date.Text;
            string dateOflast2 = dateOfLast.Text;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = num,
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };
            context.Entry(newcase).State = EntityState.Modified;
            context.SaveChanges();
            MessageBox.Show("تم تعديل القضية بنجاح");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            string date2 = date.Text;
            string dateOflast2 = dateOfLast.Text;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = num,
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };
            var answer = MessageBox.Show("هل انت متأكد", "", buttons: MessageBoxButtons.YesNo);
            if (answer == DialogResult.Yes)
            {
                var answer2 = MessageBox.Show("هل تريد مسح القضية كاملة؟", "", buttons: MessageBoxButtons.YesNo);
                if (answer2 == DialogResult.Yes)
                {
                    var cases = context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
                    foreach (var ca in cases)
                    {
                        context.Remove(ca);
                    }
                    context.SaveChanges();
                    MessageBox.Show("تم المسح جميع الجلسات بنجاح");
                    button1_Click(null, null);

                }
                else if (answer2 == DialogResult.No)
                {
                    var answer3 = MessageBox.Show("هل تريد مسح هذه الجلسة فقط", "", buttons: MessageBoxButtons.YesNo);
                    if (answer3 == DialogResult.Yes)
                    {
                        context.Remove(newcase);
                        context.SaveChanges();
                        MessageBox.Show("تم مسح هذه الجلسة فقط بنجاح");
                        button1_Click(null, null);
                    }
                }
                

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            string date2 = date.Text;
            string dateOflast2 = dateOfLast.Text;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = num,
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };

            var cases = context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].Id == newcase.Id)
                    if (item != 0)
                    {
                        num = cases[item - 1].Id;
                        caseDescision.Text = cases[item - 1].caseDecision;
                        Hall.Text = cases[item - 1].Hall;
                        date.Text = cases[item - 1].date;
                        dateOfLast.Text = cases[item - 1].dateOflast;
                        caseNum.Text = cases[item - 1].caseNum;
                        circleNum.Text = cases[item - 1].circleNum;
                        oppenentName.Text = cases[item - 1].oppenentName;
                        attribute.Text = cases[item - 1].attribute;
                        lastOne.Text = cases[item - 1].Lastone;
                        describtion.Text = cases[item - 1].describtion;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد جلسات سابقة");
                        break;
                    }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            string date2 = date.Text;
            string dateOflast2 = dateOfLast.Text;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = num,
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };

            var cases = context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].Id == newcase.Id)
                    if (item != cases.Length - 1)
                    {
                        num = cases[item + 1].Id;
                        caseDescision.Text = cases[item + 1].caseDecision;
                        Hall.Text = cases[item + 1].Hall;
                        date.Text = cases[item + 1].date;
                        dateOfLast.Text = cases[item + 1].dateOflast;
                        caseNum.Text = cases[item + 1].caseNum;
                        circleNum.Text = cases[item + 1].circleNum;
                        oppenentName.Text = cases[item + 1].oppenentName;
                        attribute.Text = cases[item + 1].attribute;
                        lastOne.Text = cases[item + 1].Lastone;
                        describtion.Text = cases[item + 1].describtion;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد جلسات تالية");
                        break;
                    }
            }

        }
        public void getRowOutside() 
        {
            num = outIndex;
            button6_Click(null, null);
        }
    }
    
 }
