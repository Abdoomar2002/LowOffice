using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6.db
{
    public class Cases
    {//0 false
     public int Id { get; set; }
        [DisplayName("اسم المامورية")]

     //1 true
        public string location { get; set; }
        [DisplayName("اسم المحامي")]
        //2 true
        public string nameoflaw { get; set; }
        [DisplayName("ملفات")]
        //3 false
        public string file { get; set; }
        [DisplayName(" الرقم التعريفي للعميل")]
        //4 true
        public string serial { get; set; }
        [DisplayName("الفرع")]
      //5 true
        public string depart { get; set; }
        [DisplayName("قرار الجلسة")]
       //6 false
        public string caseDecision { get; set; }
        [DisplayName("القرار")]
        //7 true
        public string Lastone { get; set; }
        [DisplayName("تاريخ الحلسة السابقة")]
        //8 false
        public DateTime dateOflast { get; set; }
        [DisplayName("تاريخ الجلسة")]
        //9 true
        public DateTime date { get; set; }
        [DisplayName("المبلغ المطالب به")]
       //10 true
        public string price { get; set; }
        [DisplayName("موضوع الدعوي")]
        //11 true
        public string describtion { get; set; }
        [DisplayName("اسم الخصم 3")]
       //12 false
        public string oppenent3 { get; set; }
        [DisplayName("اسم الخصم2")]
       //13 false
        public string nameofpers { get; set; }
        [DisplayName("اسم الخصم")]
       //14 true
        public string oppenentName { get; set; }
        [DisplayName("صفة البنك")]
       //15 true
        public string attribute { get; set; }
        [DisplayName("رقم الدائرة")]
       //16 true
        public string circleNum { get; set; }
        //17 true
        [DisplayName("تاريخ إقامة الدعوى")]
      //18 true
        public DateTime FirstDate { get; set; }
        [DisplayName("تاريخ ورود الملف")]
        public DateTime arrival { get; set; }
        [DisplayName("رقم القضية")]
       //19 true
        public string caseNum { get; set; }
        [DisplayName("محكمة")]
      //20 true
        public string Hall { get; set; }
        [DisplayName("نوع المحكمة")]
       //21 true
        public string typeOfHall { get; set; }
        [DisplayName("المبلغ المقضي به")]
        public string lastPrice { get; set; }
      //  0 3 6 8 12 13
    }
}
