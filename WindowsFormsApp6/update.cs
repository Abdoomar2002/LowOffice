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
    public partial class update : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        //   private VScrollBar vScrollBar;
        public static bool b1 = true, b2 = false;
        public string num;
        public int Id;
        public static bool flag = true;
        public static int outIndex;
        public DateTime d;
        string path = "";
        List<string> files = new List<string>();
        public update()
        {
            InitializeComponent();
            panel3.SendToBack();
            panel3.Visible = b2;
            panel2.BringToFront();
            panel2.Visible = b1;
            getData.Focus();
          /*  vScrollBar = new VScrollBar();
            vScrollBar.Dock = DockStyle.Right;
            vScrollBar.Maximum = this.Height - ClientSize.Height;
            vScrollBar.LargeChange = ClientSize.Height;
            vScrollBar.Scroll += new ScrollEventHandler(vScrollBar_Scroll);
            this.Controls.Add(vScrollBar);*/
        }
        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            // Update the position of the content
            this.AutoScrollPosition = new Point(0, e.NewValue);

        }

        private void update_Load(object sender, EventArgs e)
        {
            getData.Focus();
            
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            getData.Text = "";
            panel3.SendToBack();
            panel3.Visible = b2;
            panel2.BringToFront();
            panel2.Visible = b1;
            getData.Focus();

            if (path.Length < 3)
            {
                guna2Button6.Text = "اضافة مستندات";
            }
            else guna2Button6.Text = "عرض مستندات";

        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(Casenumber.Text + "/" + caseNum.Text);
            if (Casenumber.Text + "/" + caseNum.Text == "/" || Casenumber.Text + "/" + caseNum.Text == "")
            {
                MessageBox.Show("لا يوجد جلسات سابقة");
                return;
            }
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();
            var uCase = context.Cases.Where(c => c.caseNum == Casenumber.Text+"/"+ caseNum.Text).ToArray();
            uCase = uCase.OrderBy(c => c.date).ToArray();

            var cases = uCase;  // context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].Id == Id)
                    if (item != 0)
                    {
                        Id = cases[item - 1].Id;
                        caseDescision.Text = cases[item - 1].caseDecision;
                        Hall.Text = cases[item - 1].Hall;
                        typeOfHall.Text = cases[item - 1].typeOfHall;
                        date.Value = cases[item - 1].date;
                        dateOfLast.Value = cases[item - 1].dateOflast;
                        caseNum.Text = cases[item-1].caseNum.Substring(cases[item-1].caseNum.IndexOf("/")+1);
                        Casenumber.Text = cases[item-1].caseNum.IndexOf("/")!=-1? cases[item-1].caseNum.Substring(0, cases[item-1].caseNum.IndexOf("/")):"";
                        circleNum.Text = cases[item - 1].circleNum;
                        oppenentName.Text = cases[item - 1].oppenentName;
                        attribute.Text = cases[item - 1].attribute;
                        lastOne.Text = cases[item - 1].Lastone;
                        describtion.Text = cases[item - 1].describtion;
                        guna2TextBox3.Text = cases[item - 1].nameofpers;
                        guna2TextBox2.Text = cases[item - 1].depart;
                        guna2TextBox1.Text = cases[item - 1].serial;
                        law.Text = cases[item - 1].nameoflaw;
                        files = cases[item - 1].file.Split('$').ToList();
                        path = files[0];
                        guna2TextBox4.Text = cases[item - 1].oppenent3;
                        guna2TextBox5.Text = cases[item - 1].location;
                        price.Text = cases[item - 1].price;
                        guna2DateTimePicker2.Value = cases[item - 1].arrival;
                        firstDate.Value = cases[item - 1].FirstDate;
                        lastprice.Text = cases[item - 1].lastPrice;
                        guna2TextBox10.Text = cases[item - 1].notes;
                        guna2TextBox11.Text = cases[item - 1].saving_number;
                        guna2ComboBox1.Text = cases[item - 1].IsCompleted;
                            break;
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد جلسات سابقة");
                        break;
                    }

                if (path.Length < 3)
                {
                    guna2Button6.Text = "اضافة مستندات";
                }
                else guna2Button6.Text = "عرض مستندات";


            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (Casenumber.Text + "/" + caseNum.Text == "/"||Casenumber.Text + "/" + caseNum.Text == "") 
            {
                MessageBox.Show("لا يوجد جلسات تالية");
                return;
            }
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();
            var uCase = context.Cases.Where(c => c.caseNum ==Casenumber.Text+"/"+ caseNum.Text).OrderBy(c=>c.date).ToArray();
            var cases = uCase; //context.Cases.FromSqlRaw("select * from Cases where (caseNum='" + newcase.caseNum + "') order by Id asc").ToArray();
            for (int item = 0; item < cases.Length; item++)
            {
                if (cases[item].Id == Id)
                    if (item != cases.Length - 1)
                    {
                        Id = cases[item + 1].Id;
                        caseDescision.Text = cases[item + 1].caseDecision;
                        Hall.Text = cases[item + 1].Hall;
                        date.Value = cases[item + 1].date;
                        typeOfHall.Text = cases[item + 1].typeOfHall;
                        dateOfLast.Value = cases[item + 1].dateOflast;
                        caseNum.Text = cases[item+1].caseNum.Substring(cases[item+1].caseNum.IndexOf("/")+1);
                        Casenumber.Text =cases[item+1].caseNum.IndexOf("/") != -1 ? cases[item+1].caseNum.Substring(0, cases[item+1].caseNum.IndexOf("/")):"";
                        circleNum.Text = cases[item + 1].circleNum;
                        oppenentName.Text = cases[item + 1].oppenentName;
                        attribute.Text = cases[item + 1].attribute;
                        lastOne.Text = cases[item + 1].Lastone;
                        describtion.Text = cases[item + 1].describtion;
                        guna2TextBox3.Text = cases[item+1].nameofpers;
                        guna2TextBox2.Text = cases[item+1].depart;
                        guna2TextBox1.Text = cases[item+1].serial;
                        law.Text = cases[item + 1].nameoflaw;
                        files = cases[item + 1].file.Split('$').ToList();
                        path = files[0];
                        guna2TextBox4.Text = cases[item + 1].oppenent3;
                        guna2TextBox5.Text = cases[item + 1].location;
                        price.Text = cases[item + 1].price;
                        firstDate.Value = cases[item + 1].FirstDate;
                        lastprice.Text = cases[item + 1].lastPrice;
                        guna2DateTimePicker2.Value = cases[item + 1].arrival;
                        guna2TextBox10.Text = cases[item + 1].notes;
                        guna2TextBox11.Text = cases[item + 1].saving_number;
                        guna2ComboBox1.Text = cases[item + 1].IsCompleted;


                        break;

                      
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد جلسات تالية");
                        break;
                    }

                if (path.Length < 3)
                {
                    guna2Button6.Text = "اضافة مستندات";
                }
                else guna2Button6.Text = "عرض مستندات";


            }
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            if(caseDescision.Text=="تحت الرفع") 
            {
               var ans= MessageBox.Show("هل تقصد حفظ القضية ؟", "", MessageBoxButtons.YesNo);
                if (ans == DialogResult.Yes) 
                {
                    guna2Button3_Click(null, null);
                    return;

                }
                else 
                {
                    return;
                }
            }
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();


            string caseNum2 =Casenumber.Text+"/"+ caseNum.Text;
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
            string dept = guna2TextBox2.Text;
            string num = guna2TextBox1.Text;
            string name = guna2TextBox3.Text;
            string lawer = law.Text;
            string opp3 = guna2TextBox4.Text;
            string location = guna2TextBox5.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall = type,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = d,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2,
                depart = dept,
                serial = num,
                nameofpers = name,
                file = string.Join("$", files),
                nameoflaw = lawer,
                oppenent3 = opp3,
                location = location,
                price = price.Text,
                FirstDate = firstDate.Value.Date,
                arrival = guna2DateTimePicker2.Value.Date,
                lastPrice = lastprice.Text,
                notes = guna2TextBox10.Text,
                saving_number = guna2TextBox11.Text,
                IsCompleted = guna2ComboBox1.Text
                
                
            };
            context.Cases.Add(newcase);
            context.SaveChanges();
            //context.SaveChangesAsync();
            dateOfLast.Value = d;
            MessageBox.Show("تمت اضافة الجلسة بنجاح");
            d = date.Value;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();


            string caseNum2 =Casenumber.Text+"/"+ caseNum.Text;
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
            string dept = guna2TextBox2.Text;
            string num = guna2TextBox1.Text;
            string name = guna2TextBox3.Text;
            string lawer = law.Text;
            string opp3 = guna2TextBox4.Text;
            string location = guna2TextBox5.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall = type,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2,
                depart = dept,
                serial = num,
                nameofpers = name,
                file = string.Join("$",files),
                nameoflaw = lawer,
                oppenent3 = opp3,
                location = location,
                FirstDate = firstDate.Value.Date,
                price=price.Text,
                arrival=guna2DateTimePicker2.Value.Date,
                lastPrice=lastprice.Text,
                notes=guna2TextBox10.Text,
                saving_number=guna2TextBox11.Text,
                IsCompleted = guna2ComboBox1.Text

            };
            context.Entry(newcase).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            var uCase = context.Cases.Where(c=>c.caseNum== newcase.caseNum).ToArray();
            uCase = uCase.OrderByDescending(c => c.date).ToArray();
            //  MessageBox.Show(uCase[0].date.ToString());
            if (uCase.Length > 1)
            {
                for (int i = 0; i < uCase.Length; i++)
                {
                    if (i + 1 != uCase.Length && uCase[i + 1].Id == newcase.Id)
                    {
                        uCase[i].dateOflast = newcase.date;
                        context.SaveChanges();
                    }
                    if (i - 1 >= 0 && uCase[i - 1].Id == newcase.Id)
                    {
                        uCase[i].date = newcase.dateOflast;
                        context.SaveChanges();

                    }
                }
            }
            /*context.Entry(newcase).State = EntityState.Modified;
            context.SaveChanges();*/

            //context.Entry(pervCase).State = EntityState.Modified;

            MessageBox.Show("تم تعديل الجلسة بنجاح");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();


            string caseNum2 =Casenumber.Text+"/"+ caseNum.Text;
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
            string dept = guna2TextBox2.Text;
            string num = guna2TextBox1.Text;
            string name = guna2TextBox3.Text;
            string lawer = law.Text;
            string opp3 = guna2TextBox4.Text;
            string location = guna2TextBox5.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                Id = Id,
                caseNum = caseNum2,
                Hall = Hall2,
                typeOfHall = type,
                circleNum = circleNum2,
                oppenentName = oppenentName2,
                attribute = attribute2,
                date = date2,
                dateOflast = dateOflast2,
                describtion = describtion2,
                caseDecision = caseDecision2,
                Lastone = Lastone2,
                depart = dept,
                serial = num,
                nameofpers = name,
                file=string.Join("$", files),
                nameoflaw=lawer,
                oppenent3 = opp3,
                location = location,
                price=price.Text,
                FirstDate=firstDate.Value.Date,
                arrival= guna2DateTimePicker2.Value.Date,
                lastPrice=lastprice.Text,
                notes=guna2TextBox10.Text,
                saving_number=guna2TextBox11.Text,
                IsCompleted = guna2ComboBox1.Text

            };
            var answer = MessageBox.Show("هل انت متأكد", "", buttons: MessageBoxButtons.YesNo);
          //  MessageBox.Show(answer.ToString());
            if (answer == DialogResult.Yes)
            {
              //  MessageBox.Show(newcase.caseDecision);
                if (newcase.caseDecision != "تحت الرفع" && newcase.caseDecision != "")
                {
                    var answer2 = MessageBox.Show("هل تريد مسح القضية كاملة؟", "", buttons: MessageBoxButtons.YesNo);

                    if (answer2 == DialogResult.Yes)
                    {
                        var cases = context.Cases.Where(c => c.caseNum == newcase.caseNum).ToArray();
                        foreach (var ca in cases)
                        {
                            //context.Remove(ca);
                            context.Cases.Remove(ca);
                        }
                        context.SaveChanges();
                        MessageBox.Show("تم المسح جميع الجلسات بنجاح");
                        guna2Button4_Click(null, null);

                    }
                    else if (answer2 == DialogResult.No)
                    {
                        var answer3 = MessageBox.Show("هل تريد مسح هذه الجلسة فقط", "", buttons: MessageBoxButtons.YesNo);
                        if (answer3 == DialogResult.Yes)
                        {
                            var removed = context.Cases.Find(newcase.Id);
                            if (removed != null)
                                context.Cases.Remove(removed);
                            context.SaveChanges();
                            MessageBox.Show("تم مسح هذه الجلسة فقط بنجاح");
                            guna2Button4_Click(null, null);
                            path = "";
                        }
                    }
                }
                else if(newcase.caseDecision == "تحت الرفع" || newcase.caseDecision == "")
                {
                    var removed = context.Cases.Find(newcase.Id);
                    if (removed != null)
                        context.Cases.Remove(removed);
                    context.SaveChanges();
                    MessageBox.Show("تم مسح هذه الجلسة فقط بنجاح");
                    guna2Button4_Click(null, null);
                    path = "";
                }

            }
        }

            private void guna2Button5_Click(object sender, EventArgs e)
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
                var uCase = context.Cases.Where(c => c.caseNum == num).ToArray();
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
                    caseNum.Text = updCase.caseNum.Substring(updCase.caseNum.IndexOf("/")+1);
                    Casenumber.Text = updCase.caseNum.IndexOf("/")!=-1? updCase.caseNum.Substring(0, updCase.caseNum.IndexOf("/")):"";
                    circleNum.Text = updCase.circleNum;
                    oppenentName.Text = updCase.oppenentName;
                    attribute.Text = updCase.attribute;
                    lastOne.Text = updCase.Lastone;
                    describtion.Text = updCase.describtion;
                    guna2TextBox3.Text = updCase.nameofpers;
                    guna2TextBox2.Text = updCase.depart;
                    guna2TextBox1.Text = updCase.serial;
                    guna2TextBox4.Text = updCase.oppenent3;
                    guna2TextBox5.Text = updCase.location;
                    files =updCase.file.Length<3? updCase.file.Split('$').ToList():new List<string>();
                    path = files.Count > 0 ? files[0] :"";
                    law.Text = updCase.nameoflaw;
                    price.Text = updCase.price;
                    firstDate.Value = updCase.FirstDate;
                    guna2DateTimePicker2.Value = updCase.arrival;
                    lastprice.Text = updCase.lastPrice;
                    guna2TextBox10.Text = updCase.notes;
                    guna2TextBox11.Text = updCase.saving_number;
                    guna2ComboBox1.Text = updCase.IsCompleted;

                    if (path.Length < 3)
                    {
                        guna2Button6.Text = "اضافة مستندات";
                    }
                    else guna2Button6.Text = "عرض مستندات";

                }
                else
                {
                    guna2Button4_Click(null, null);
                    MessageBox.Show("لا يوجد قضية بهذا الرقم");
                }

            }
            else
            {
                MessageBox.Show("ادخل قيمة صحيحة من فضلك");
            }

        }
        public List<Cases> printCase()
        {
            List<Cases> data;
            CasesContext context = new CasesContext();
            data = context.Cases.Where(c=>c.caseNum==num).ToList();
            data = data.OrderByDescending(c => c.date).ToList();

            return data;
        }

        private void getData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button5_Click(null, null);
            }
        }

        private void dateOfLast_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (path.Length ==0)
            {
                var rt = MessageBox.Show("هل تريد اضافة مستند", "لا يوجد مستند لهذه القضية", MessageBoxButtons.YesNo);
                if (rt == DialogResult.Yes)
                {
                    pdfViewer1.Hide();
                        //pdfViewer1.Document=null;
                    guna2Panel1.BringToFront();
                }
                else
                    return;


            }
            else
            {
                if (File.Exists(path))
                {
                    guna2Panel1.BringToFront();
                    byte[] bytes = File.ReadAllBytes(path);
                    var stream = new MemoryStream(bytes);
                    PdfiumViewer.PdfDocument document = PdfiumViewer.PdfDocument.Load(stream);
                    pdfViewer1.Document = document;
                    pdfViewer1.Show();
                }
                else
                {
                    var rt = MessageBox.Show("هل تريد اضافة مستند", "لا يوجد مستند لهذه القضية", MessageBoxButtons.YesNo);
                    if (rt == DialogResult.Yes)
                        guna2Panel1.BringToFront();
                    else
                        return;
                }
            }
           
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                fileShow();
            }
        }
        public void  fileShow()
        {
            byte[] bytes = File.ReadAllBytes(path);
            var stream = new MemoryStream(bytes);
            PdfiumViewer.PdfDocument document = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer1.Document = document;
            pdfViewer1.Show();
        }
        private void back_Click(object sender, EventArgs e)
        {
            guna2Panel1.SendToBack();

            if (path.Length < 3)
            {
                guna2Button6.Text = "اضافة مستندات";
            }
            else guna2Button6.Text = "عرض مستندات";

        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel24_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel25_Click(object sender, EventArgs e)
        {

        }
        public void getId(int number)
        {
            //num = number == -1 ? -1 : number;
            panel2.Visible = b2;
            panel3.Visible = b1;
            panel3.BringToFront();
            CasesContext context = new CasesContext();
            Cases updCase = new Cases();
            // date.MinDate = DateTime.Now;
            var uCase = context.Cases.Where(c => c.Id == number).ToArray();
            uCase = uCase.OrderByDescending(c => c.date).ToArray();

            if (uCase.Length != 0)
                updCase = uCase[0];
            if (updCase.Id != 0)
            {
                // MessageBox.Show(updCase.caseNum.IndexOf("/").ToString());
                Id = updCase.Id;
                d = updCase.date;
                caseDescision.Text = updCase.caseDecision;
                typeOfHall.Text = updCase.typeOfHall;
                Hall.Text = updCase.Hall;
                date.Value = updCase.date;
                dateOfLast.Value = updCase.dateOflast;
                num = updCase.caseNum;
                caseNum.Text = updCase.caseNum.Substring(updCase.caseNum.IndexOf("/") + 1);
                Casenumber.Text = updCase.caseNum.IndexOf("/") != -1 ? updCase.caseNum.Substring(0, updCase.caseNum.IndexOf("/")) : "";
                circleNum.Text = updCase.circleNum;
                oppenentName.Text = updCase.oppenentName;
                attribute.Text = updCase.attribute;
                lastOne.Text = updCase.Lastone;
                describtion.Text = updCase.describtion;
                guna2TextBox3.Text = updCase.nameofpers;
                guna2TextBox2.Text = updCase.depart;
                guna2TextBox1.Text = updCase.serial;
                files =updCase.file!=""? updCase.file.Split('$').ToList():new List<string>();
                path = files.Count > 0 ? files[0] : ""; law.Text = updCase.nameoflaw;
                guna2TextBox4.Text = updCase.oppenent3;
                guna2TextBox5.Text = updCase.location;
                price.Text = updCase.price;
                firstDate.Value = updCase.FirstDate;
                guna2DateTimePicker2.Value = updCase.arrival;
                lastprice.Text = updCase.lastPrice;
                guna2TextBox10.Text = updCase.notes;
                guna2TextBox11.Text = updCase.saving_number;
                guna2ComboBox1.Text = updCase.IsCompleted;


                if (path.Length < 3)
                {
                    guna2Button6.Text = "اضافة مستندات";
                }
                else guna2Button6.Text = "عرض مستندات";


            }
            else
            {
                guna2Button4_Click(null, null);
                MessageBox.Show("لا يوجد قضية بهذا الرقم");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (files.IndexOf(path) > 0)
            {
                path = files[files.IndexOf(path) - 1];
                fileShow();
            }
            else
            {
                MessageBox.Show("لا يوجد ملفات اخري ");
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (files.Count - 1 > files.IndexOf(path))
            {
                path = files[files.IndexOf(path) + 1];
                fileShow();
            }
            else
            {
                MessageBox.Show("لا يوجد ملفات اخري ");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                files.Add(openFileDialog1.FileName);
                path = openFileDialog1.FileName;
                fileShow();

            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            var ans = MessageBox.Show("هل تريد مسح الملف", "", MessageBoxButtons.YesNo);
            if (ans == DialogResult.Yes)
            {

                if (files.Count == 1)
                {
                    files.Remove(path);
                    guna2Panel1.SendToBack();
                    path = "";

                    if (path.Length < 3)
                    {
                        guna2Button6.Text = "اضافة مستندات";
                    }
                    else guna2Button6.Text = "عرض مستندات";


                }
                else if (files.IndexOf(path) != 0)
                {
                    var temp = path;
                    path = files[files.IndexOf(path) - 1];
                    files.Remove(temp);
                    fileShow();
                }
                else
                {
                    var temp = path;
                    path = files[files.IndexOf(path) + 1];
                    files.Remove(temp);
                    fileShow();
                }
            }
        }

        public void getRowOutside(string number)
        {
            num = number == "" ? "" : number;
            panel2.Visible = b2;
            panel3.Visible = b1;
            panel3.BringToFront();
            CasesContext context = new CasesContext();
            Cases updCase = new Cases();
            // date.MinDate = DateTime.Now;
            var uCase = context.Cases.Where(c=>c.caseNum==num).ToArray();
            uCase = uCase.OrderByDescending(c => c.date).ToArray();
            
            if (uCase.Length != 0)
                updCase = uCase[0];
            if (updCase.Id != 0)
            {
               // MessageBox.Show(updCase.caseNum.IndexOf("/").ToString());
                Id = updCase.Id;
                d = updCase.date;
                caseDescision.Text = updCase.caseDecision;
                typeOfHall.Text = updCase.typeOfHall;
                Hall.Text = updCase.Hall;
                date.Value = updCase.date;
                dateOfLast.Value = updCase.dateOflast;
                caseNum.Text = updCase.caseNum.Substring(updCase.caseNum.IndexOf("/")+1);
                Casenumber.Text =updCase.caseNum.IndexOf("/")!=-1? updCase.caseNum.Substring(0, updCase.caseNum.IndexOf("/")):"";
                circleNum.Text = updCase.circleNum;
                oppenentName.Text = updCase.oppenentName;
                attribute.Text = updCase.attribute;
                lastOne.Text = updCase.Lastone;
                describtion.Text = updCase.describtion;
                guna2TextBox3.Text = updCase.nameofpers;
                guna2TextBox2.Text = updCase.depart;
                guna2TextBox1.Text = updCase.serial;
                files =updCase.file!=""? updCase.file.Split('$').ToList():new List<string>();
                path =files.Count>0? files[0]:"";
                law.Text = updCase.nameoflaw;
                guna2TextBox4.Text = updCase.oppenent3;
                guna2TextBox5.Text = updCase.location;
                price.Text = updCase.price;
                firstDate.Value = updCase.FirstDate;
                guna2DateTimePicker2.Value = updCase.arrival;
                lastprice.Text = updCase.lastPrice;
                guna2TextBox10.Text = updCase.notes;
                guna2TextBox11.Text = updCase.saving_number;
                guna2ComboBox1.Text = updCase.IsCompleted;


                if (path.Length < 3)
                {
                    guna2Button6.Text = "اضافة مستندات";
                }
                else guna2Button6.Text = "عرض مستندات";

            }
            else
            {
                guna2Button4_Click(null, null);
                MessageBox.Show("لا يوجد قضية بهذا الرقم");
            }
        }
    }
}
