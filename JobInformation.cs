using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class JobInformation
    { 
        private String jobTitle;
        private String jobDescription;
        private String category;
        private String minBudge;
        private String maxBudge;
        private String payType;

        public JobInformation(string jobTitle, string jobDescription, string category, string minBudge, string maxBudge, string payType)
        {
            this.jobTitle = jobTitle;
            this.jobDescription = jobDescription;
            this.category = category;
            this.minBudge = minBudge;
            this.maxBudge = maxBudge;
            this.payType = payType;
        }

        public string JobTitle { get => jobTitle; set => jobTitle = value; }
        public string JobDescription { get => jobDescription; set => jobDescription = value; }
        public string Category { get => category; set => category = value; }
        public string MinBudge { get => minBudge; set => minBudge = value; }
        public string MaxBudge { get => maxBudge; set => maxBudge = value; }
        public string PayType { get => payType; set => payType = value; }
    }
}
