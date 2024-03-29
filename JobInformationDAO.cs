using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class JobInformationDAO
    {
        DbConnection connection = new DbConnection();

        public void AddJob(JobInformation job)
        {
            string sqlStr = string.Format("INSERT INTO JobInformation(JobTitle, JobDescription, Category, MinPrice, MaxPrice, PayType) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", job.JobTitle, job.JobDescription, job.Category, job.MinBudge, job.MaxBudge, job.PayType);
            connection.Execute(sqlStr);
        }
    }
}
