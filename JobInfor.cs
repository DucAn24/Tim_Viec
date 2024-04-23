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
        private String imageJob;
        public JobInfor(string jobTitle, string jobDescription, string category, string price, string imageJob)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.category = category;
            this.price = price;
            this.imageJob = imageJob;
        }

        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string JobDescription { get => jobDescription; set => jobDescription = value; }
        public string Category { get => category; set => category = value; }
        public string Price { get => price; set => price = value; }

        public string ImageJob { get => imageJob; set => imageJob = value; }

    }

}
