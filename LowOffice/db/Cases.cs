using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LowOffice.db
{
    public class Cases
    {
        public int Id { get; set; }
        [DisplayName("رقم القضية")]

        public string caseNum { get; set; }
        [DisplayName("اسم المحكمة")]

        public string Hall { get; set; }
        [DisplayName("رقم الدايرة")]

        public string circleNum { get; set; }
        [DisplayName("اسم الخصم")]

        public string oppenentName { get; set; }
        [DisplayName("صفة البنك")]

        public string attribute { get; set; }
        [DisplayName("تاريخ الجلسة")]

        public string date { get; set; }
        [DisplayName("تاريخ الحلسة السابقة")]

        public string dateOflast { get; set; }
        [DisplayName("موضوع الدعوي")]

        public string describtion { get; set; }
        [DisplayName("قرار الجلسة")]

        public string caseDecision { get; set; }
        [DisplayName("الجلسة سابقة")]
        public string Lastone { get; set; }



    }
}
