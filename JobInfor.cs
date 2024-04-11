using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class JobInfor
    {
        private String jobTitle;
        private String jobDescription;
        private String category;
        private String price;
        public JobInfor(string jobTitle, string jobDescription, string category, string price)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.category = category;
            this.price = price;

        }

        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string JobDescription { get => jobDescription; set => jobDescription = value; }
        public string Category { get => category; set => category = value; }
        public string Price { get => price; set => price = value; }

    }

}
