using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class JobDAO
    {
        DbConnection connection = new DbConnection();

        public void AddJob(Job job)
        {
            string sqlStr = string.Format("INSERT INTO Job(Title, Description, MinBudget, MaxBudget, Category) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", job.Title, job.Description, job.MinBudge, job.MaxBudge, job.Category);
            connection.Execute(sqlStr);
        }
    }
}
