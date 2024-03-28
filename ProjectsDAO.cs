using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimViec
{
    internal class ProjectsDAO
    {
        DbConnection conn = new DbConnection();

        public void AddProjects(Projects projects)
        {
            string sql = string.Format("INSERT INTO Projects(Title, Description, MinBudget, MaxBudget, Category) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", projects.Title, projects.Description, projects.MinBudge, projects.MaxBudge, projects.Category);
            conn.Execute(sql);
        }
    }
}
