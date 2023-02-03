using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LowOffice.db
{
    public class Cases
    {
        public int Id { get; set; }
        [DisplayName("نوع المحكمة")]
       public string typeOfHall { get; set; }
        [DisplayName("اسم المحكمة")]
        public string Hall { get; set; }
        [DisplayName("رقم القضية")]
        public string caseNum { get; set; }
        [DisplayName("رقم الدائرة")]
        public string circleNum { get; set; }
        [DisplayName("اسم الخصم")]

        public string oppenentName { get; set; }
        [DisplayName("صفة البنك")]

        public string attribute { get; set; }
        [DisplayName("تاريخ الجلسةالتالية")]

        public DateTime date { get; set; }
        [DisplayName("تاريخ الحلسة السابقة")]

        public DateTime dateOflast { get; set; }
        [DisplayName("موضوع الدعوي")]

        public string describtion { get; set; }
        [DisplayName("قرار الجلسة")]

        public string caseDecision { get; set; }
        [DisplayName("قرار الجلسة سابقة")]
        public string Lastone { get; set; }



    }
}
