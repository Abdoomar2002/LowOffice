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
using PdfiumViewer;
using System.IO;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using ExcelDataReader;

namespace WindowsFormsApp6
{
    public partial class AddCase : UserControl
    {
       public string fileCase;
        public string act="p2";
        private static PrivateFontCollection fontCollection = new PrivateFontCollection();
        DateTimePicker dtp = new DateTimePicker();
        Rectangle rect; 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handle = base.CreateParams;
                handle.ExStyle |= 0x02000000;
                return handle;
            }
        }
        public AddCase()
        {

            InitializeComponent();
            // Load the embedded font file
            /*  fontCollection.AddFontFile(@"Cairo-VariableFont_slnt,wght.ttf");
              foreach(Control c in this.Controls)
              {
                  c.Font =new Font(fontCollection.Families[0],14, FontStyle.Bold);
              }*/
            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
            

        }private void dtp_TextChange(Object sender,EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text.ToString();
        }

        public void guna2Button1_Click(object sender, EventArgs e)
        {
            CasesContext context = new CasesContext();
            context.Database.CreateIfNotExists();


            string caseNum =guna2TextBox7.Text+"/"+Num.Text;
            string Hall = hall.Text;
            string typeOfHall = type.Text;
            string circleNum = circle.Text;
            string oppenentName = oppenent.Text;
            string attribute = attr.Text;
            DateTime date = date1.Value;
            DateTime dateOflast = dateOflast2.Value;
            string describtion = desc.Text;
            string caseDecision = comboBox1.Text;
            string Lastone = Last.Text;
            string nameOf = guna2TextBox3.Text;
            string dept = guna2TextBox2.Text;
            string num = guna2TextBox1.Text;
            string lawyer = guna2TextBox4.Text;
            string opp3 = guna2TextBox6.Text;
            string location = guna2TextBox5.Text;
            Cases fake = new Cases();


            Cases newcase = new Cases
            {
                caseNum = caseNum,
                Hall = Hall,
                typeOfHall = typeOfHall,
                circleNum = circleNum,
                oppenentName = oppenentName,
                attribute = attribute,
                date = date.Date,
                dateOflast = dateOflast.Date,
                describtion = describtion,
                caseDecision = caseDecision,
                Lastone = Lastone,
                depart = dept,
                nameofpers = nameOf,
                serial = num,
                file = fileCase,
                nameoflaw = lawyer,
                oppenent3 = opp3,
                location = location,
                FirstDate = guna2DateTimePicker1.Value.Date,
                price = guna2TextBox8.Text,
                arrival = guna2DateTimePicker2.Value.Date,
                lastPrice=guna2TextBox9.Text,
                


            };
            context.Cases.Add(newcase);
            context.SaveChanges();
            context.SaveChangesAsync();
            MessageBox.Show("تمت اضافة القضية بنجاح");
            guna2Button2_Click(null, null);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            type.SelectedIndex = -1;
            guna2TextBox8.Text = "";
            guna2DateTimePicker1.Value = DateTime.Now;
            Num.Text = "";
            hall.Text = "";
            Last.Text = "";
            desc.Text = "";
            attr.Text = "";
            dateOflast2.Value = DateTime.Today;
            guna2TextBox5.Text = "اسيوط";
            guna2TextBox6.Text = "";
            date1.Value = DateTime.Today;
            guna2DateTimePicker2.Value = DateTime.Today;
            comboBox1.SelectedIndex = 0;
            oppenent.Text = "";
            circle.Text = "";
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox7.Text = "";
            guna2TextBox3.Text = "";
            guna2Button4.Text = "اضافة ملف";
            fileCase = "";
            guna2TextBox4.Text = "محمد عيد معبد";
            guna2TextBox9.Text = "";
           // label1.Text = "لم يتم ارفاق اي ملف";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "متداول")
            {
                Last.Visible = true;
                label11.Visible = true;
                label11.Text = "قرار الجلسة السابقة";
            }
            else if (comboBox1.Text == "حكم")
            {
                Last.Visible = true;
                label11.Text = "قرار القضية ";
                label11.Visible = true;
            }
            else if (comboBox1.Text == "تحت الرفع")
            {
                Last.Visible = true;
                label11.Text = "";
                label11.Visible = true;
            }
            else if (comboBox1.Text == "شطب")
            {
                Last.Visible = true;
                label11.Text = "قرار الجلسة ";
                label11.Visible = true;
            }
        }
        public List<Cases> printCase()
        {
            List<Cases> data = new List<Cases>(1);
            data[0].caseNum = Num.Text;
            data[0].Hall = hall.Text;
            data[0].typeOfHall = type.Text;
            data[0].circleNum = circle.Text;
            data[0].oppenentName = oppenent.Text;
            data[0].attribute = attr.Text;
            data[0].date = date1.Value;
            data[0].dateOflast = dateOflast2.Value;
            data[0].describtion = desc.Text;
            data[0].caseDecision = comboBox1.Text;
            data[0].Lastone = Last.Text;
            data[0].depart = guna2TextBox2.Text;
            

            return data;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            Last.Visible = false;
            label11.Visible = false;
            pdfViewer1.Visible = false;
            guna2Button6.Visible = false;
            date1.Value = DateTime.Now.Date;
            dateOflast2.Value = DateTime.Now.Date;
            guna2DateTimePicker1.Value = DateTime.Now;
            guna2DateTimePicker2.Value = DateTime.Now;

        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Panel1.SendToBack();
            act = "p2";
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            guna2Panel1.BringToFront();
            act = "p1";

        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Index==7)
            {
                
                rect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex,true);
                dtp.Size = new Size(rect.Width, rect.Height);
                dtp.Location = new Point(rect.X, rect.Y);
                dtp.Visible = true;
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Index == 0)
            {
                OpenFileDialog openFile = new OpenFileDialog() {Filter="Print Document File|*.pdf" };
                if(openFile.ShowDialog()==DialogResult.OK)
                {
                    dataGridView1.CurrentCell.Value = openFile.FileName.ToString();
                }
            }
            else 
            {
                dtp.Visible = false;
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            List<Cases> cases=new List<Cases>();
           // MessageBox.Show(dataGridView1.Rows[0].Cells[0].Value.ToString());
            for (int i=0;i< dataGridView1.RowCount-1;i++)
            {
                // MessageBox.Show(i.ToString());

                Cases cases1 = new Cases()
                {
                    file = dataGridView1.Rows[i].Cells[0].Value != null ? dataGridView1.Rows[i].Cells[0].Value.ToString() : "",
                    location = dataGridView1.Rows[i].Cells[1].Value != null ? dataGridView1.Rows[i].Cells[1].Value.ToString() : "",
                    nameoflaw = dataGridView1.Rows[i].Cells[2].Value != null ? dataGridView1.Rows[i].Cells[2].Value.ToString():"",
                    serial = dataGridView1.Rows[i].Cells[3].Value != null ? dataGridView1.Rows[i].Cells[3].Value.ToString() : "",
                    depart = dataGridView1.Rows[i].Cells[4].Value != null ? dataGridView1.Rows[i].Cells[4].Value.ToString() : "",
                    caseDecision = dataGridView1.Rows[i].Cells[5].Value != null ? dataGridView1.Rows[i].Cells[5].Value.ToString() : "",
                    Lastone = dataGridView1.Rows[i].Cells[6].Value != null ? dataGridView1.Rows[i].Cells[6].Value.ToString() : "",
                    date = dataGridView1.Rows[i].Cells[7].ToString() != "" ? DateTime.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString()) : DateTime.Now.Date,
                    describtion = dataGridView1.Rows[i].Cells[8].Value != null ? dataGridView1.Rows[i].Cells[8].Value.ToString() : "",
                    oppenent3 = dataGridView1.Rows[i].Cells[9].Value != null ? dataGridView1.Rows[i].Cells[9].Value.ToString() : "",
                    nameofpers = dataGridView1.Rows[i].Cells[10].Value != null ? dataGridView1.Rows[i].Cells[10].Value.ToString() : "",
                    oppenentName = dataGridView1.Rows[i].Cells[11].Value != null ? dataGridView1.Rows[i].Cells[11].Value.ToString() : "",
                    attribute = dataGridView1.Rows[i].Cells[12].Value != null ? dataGridView1.Rows[i].Cells[12].Value.ToString() : "",
                    circleNum = dataGridView1.Rows[i].Cells[13].Value != null ? dataGridView1.Rows[i].Cells[13].Value.ToString() : "",
                    caseNum = dataGridView1.Rows[i].Cells[14].Value != null ? dataGridView1.Rows[i].Cells[14].Value.ToString() : "",
                    Hall = dataGridView1.Rows[i].Cells[15].Value != null ? dataGridView1.Rows[i].Cells[15].Value.ToString() : "",
                    typeOfHall = dataGridView1.Rows[i].Cells[16].Value != null ? dataGridView1.Rows[i].Cells[16].Value.ToString() : "",
                    dateOflast = DateTime.Now.Date
                };
                if(cases1.date < DateTime.MinValue.AddDays(2))
                {
                    cases1.date = DateTime.Now.Date;
                }
                cases.Add(cases1);
            }
            CasesContext context = new CasesContext();
            foreach (Cases c in cases)
            {
                context.Cases.Add(c);


            }
            context.SaveChanges();
            dataGridView1.Rows.Clear();

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            if (guna2Button4.Text != "عرض المستندات ")
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileCase = openFileDialog1.FileName;
                    if (fileCase.Length > 3)
                        guna2Button4.Text = "عرض المستندات ";
                    else guna2Button4.Text = "أضافة مستندات";
                }
            }
            else label1_Click(null, null);
           
        }
        DataSet result;
        DataTableCollection tableCollection;
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog() { Filter = "Excel WorkBook|*.xlsx|Excel |*.xls",ValidateNames=true };
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                FileStream fs = File.Open(openFile.FileName, FileMode.Open, FileAccess.Read);
                using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs))
                {
                    result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });
                    tableCollection = result.Tables;
                    cbo.Items.Clear();
                    cbo.Items.Add(" ");
                    foreach (DataTable dt in result.Tables)
                    {
                        cbo.Items.Add(dt.TableName);
                    }
                    reader.Close();
                }
            }
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = tableCollection[cbo.SelectedItem.ToString()];
            //guna2DataGridView1.DataSource = dataTable;
             guna2DataGridView1.BringToFront();
            guna2DataGridView1.DataSource = dataTable;
            if(cbo.SelectedIndex==0)
            {
                guna2DataGridView1.SendToBack();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            guna2Button6.Visible = true;
            pdfViewer1.BringToFront();
            pdfViewer1.Visible = true;
            byte[] bytes = File.ReadAllBytes(fileCase);
            var stream = new MemoryStream(bytes);
            PdfiumViewer.PdfDocument document = PdfiumViewer.PdfDocument.Load(stream);
            pdfViewer1.Document = document;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            pdfViewer1.Visible = false;
            guna2Button6.Visible = false;
        }
        public void save()
        {
            switch(act)
            {
                case "p2":
                    guna2Button1_Click(null, null);
                    break;
                case "p1":
                    guna2Button3_Click_1(null, null);
                    break;
                default : 
                    break;
            }

        }
    }
}
