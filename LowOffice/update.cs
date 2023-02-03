using LowOffice.db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LowOffice
{
    public partial class update : UserControl
    {public static bool b1=true,b2=false;
        public string num;
        public int Id;
        public static bool flag = true;
        public static int outIndex;
        public DateTime d;
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
            getData.Focus();
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
            getData.Focus();
            getData.Text = outIndex.ToString();
            
            button6_Click(null, null);
          //  MessageBox.Show(getData.Text);
            
        }

        private void takeId1_Load(object sender, EventArgs e)
        {

            getData.Focus();
            // panel3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (getData.Text != "")
            {
                num = getData.Text;
                panel2.Visible = b2;
                panel3.Visible = b1;
                panel3.BringToFront();
                CasesContext context = new CasesContext();
                Cases updCase = new Cases();
               // date.MinDate = DateTime.Now;
                var uCase = context.Cases.FromSqlRaw("select * from Cases where caseNum=" + num).ToArray();
              uCase=uCase.OrderByDescending(c => c.date).ToArray();
               
                if(uCase.Length!=0)
                updCase = uCase[0];
                if (updCase.Id != 0)
                {
                    Id = updCase.Id;
                    d = updCase.date;
                    caseDescision.Text = updCase.caseDecision;
                    typeOfHall.Text = updCase.typeOfHall;
                    Hall.Text = updCase.Hall;
                    date.Value = updCase.date;
                    dateOfLast.Value = updCase.dateOflast;
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
            getData.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();
            

            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string type = typeOfHall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            DateTime date2 = date.Value;
            DateTime dateOflast2 = dateOfLast.Value;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall=type,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = d,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2


            };
            context.Cases.Add(newcase);
            context.SaveChanges();
            context.SaveChangesAsync();
            dateOfLast.Value = d;
            MessageBox.Show("تمت اضافة القضية بنجاح");

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string type = typeOfHall.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            DateTime date2 = date.Value;
            DateTime dateOflast2 = dateOfLast.Value;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall=type,
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
            var uCase = context.Cases.FromSqlRaw("select * from Cases where caseNum=" + newcase.caseNum).ToArray();
            uCase = uCase.OrderByDescending(c => c.date).ToArray();
          //  MessageBox.Show(uCase[0].date.ToString());
            if(uCase.Length>1)
            {
                for(int i=0;i<uCase.Length;i++)
                {
                    if(i+1!=uCase.Length&&uCase[i+1].Id==newcase.Id)
                    {
                        uCase[i].dateOflast = newcase.date;
                        context.SaveChanges();
                    }
                     if (i - 1 >= 0&&uCase[i - 1].Id == newcase.Id)
                     {
                        uCase[i].date = newcase.dateOflast;
                        context.SaveChanges();
                         
                     }
                }
            }
            /*context.Entry(newcase).State = EntityState.Modified;
            context.SaveChanges();*/

            //context.Entry(pervCase).State = EntityState.Modified;
           
            MessageBox.Show("تم تعديل القضية بنجاح");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.EnsureCreated();


            string caseNum2 = caseNum.Text;
            string Hall2 = Hall.Text;
            string circleNum2 = circleNum.Text;
            string type = typeOfHall.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            DateTime date2 = date.Value;
            DateTime dateOflast2 = dateOfLast.Value;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall=type,
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
            string type = typeOfHall.Text;
            string circleNum2 = circleNum.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            DateTime date2 = date.Value;
            DateTime dateOflast2 = dateOfLast.Value;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                typeOfHall=type,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };
            var uCase = context.Cases.FromSqlRaw("select * from Cases where caseNum=" + newcase.caseNum).ToArray();
            uCase = uCase.OrderBy(c => c.date).ToArray();

            var cases = uCase;  // context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].date == newcase.date)
                    if (item != 0)
                    {
                        Id = cases[item - 1].Id;
                        caseDescision.Text = cases[item - 1].caseDecision;
                        Hall.Text = cases[item - 1].Hall;
                        typeOfHall.Text = cases[item - 1].typeOfHall;
                        date.Value = cases[item - 1].date;
                        dateOfLast.Value = cases[item - 1].dateOflast;
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
            string type = typeOfHall.Text;
            string oppenentName2 = oppenentName.Text;
            string attribute2 = attribute.Text;
            DateTime date2 = date.Value;
            DateTime dateOflast2 = dateOfLast.Value;
            string describtion2 = describtion.Text;
            string caseDecision2 = caseDescision.Text;
            string Lastone2 = lastOne.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall=type,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2
            };
            var uCase = context.Cases.FromSqlRaw("select * from Cases where caseNum=" + newcase.caseNum).ToArray();
            uCase = uCase.OrderBy(c => c.date).ToArray();

            var cases = uCase; //context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].date == newcase.date)
                    if (item != cases.Length - 1)
                    {
                        Id = cases[item + 1].Id;
                        caseDescision.Text = cases[item + 1].caseDecision;
                        Hall.Text = cases[item + 1].Hall;
                        date.Value = cases[item + 1].date;
                        typeOfHall.Text = cases[item + 1].typeOfHall;
                        dateOfLast.Value = cases[item + 1].dateOflast;
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

        private void date_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void getData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button6_Click(null, null);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        public void getRowOutside(string number) 
        {
            num = number==""?"":number;
            panel2.Visible = b2;
            panel3.Visible = b1;
            panel3.BringToFront();
            CasesContext context = new CasesContext();
            Cases updCase = new Cases();
            // date.MinDate = DateTime.Now;
            var uCase = context.Cases.FromSqlRaw("select * from Cases where caseNum='" + num+"'").ToArray();
            uCase = uCase.OrderByDescending(c => c.date).ToArray();

            if (uCase.Length != 0)
                updCase = uCase[0];
            if (updCase.Id != 0)
            {
                Id = updCase.Id;
                d = updCase.date;
                caseDescision.Text = updCase.caseDecision;
                typeOfHall.Text = updCase.typeOfHall;
                Hall.Text = updCase.Hall;
                date.Value = updCase.date;
                dateOfLast.Value = updCase.dateOflast;
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
       public List<Cases> printCase() 
        { 
            List<Cases> data;
            CasesContext context = new CasesContext();
            data = context.Cases.FromSqlRaw("select * from Cases where caseNum='" + num + "'").ToList();
            data = data.OrderByDescending(c => c.date).ToList();

            return data;
        }
    }
    
 }
