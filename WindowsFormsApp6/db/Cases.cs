using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6.db
{
    public class Cases
    {
        public int Id { get; set; }
        [DisplayName("اسم المامورية")]
        public string location { get; set; }
        [DisplayName("اسم المحامي")]
        public string nameoflaw { get; set; }
        [DisplayName("ملفات")]
        public string file { get; set; }
        [DisplayName(" الرقم التعريفي للعميل")]
        public string serial { get; set; }
        [DisplayName("الفرع")]
        public string depart { get; set; }
        [DisplayName("قرار الجلسة")]
        public string caseDecision { get; set; }
        [DisplayName("القرار")]

        public string Lastone { get; set; }
        [DisplayName("تاريخ الحلسة السابقة")]

        public DateTime dateOflast { get; set; }
        [DisplayName("تاريخ الجلسة")]

        public DateTime date { get; set; }
        [DisplayName("موضوع الدعوي")]

        public string describtion { get; set; }
        [DisplayName("اسم الخصم 3")]
        public string oppenent3 { get; set; }
        [DisplayName("اسم الخصم2")]
        public string nameofpers { get; set; }
        [DisplayName("اسم الخصم")]
        public string oppenentName { get; set; }
        [DisplayName("صفة البنك")]
        public string attribute { get; set; }
        [DisplayName("رقم الدائرة")]
        public string circleNum { get; set; }
        [DisplayName("رقم القضية")]
        public string caseNum { get; set; }
        [DisplayName("اسم المحكمة")]
        public string Hall { get; set; }
        [DisplayName("نوع المحكمة")]
        public string typeOfHall { get; set; }
        
    }
}
