using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevopsWPF.Models;

namespace DevopsWPF
{
    class ClubRepository : SqlLiteBaseRepository
    {
        public ClubRepository()
        {
            if (!DatabaseExists())
            {
                CreateDatabase();
            }
        }
        public int InsertClub(Club club)
        {
            string sql = "INSERT INTO Club (Name) Values (@Name);";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, club);
            }
        }

        public int DeleteClub(string name)
        {
            string sql = "DELETE FROM Club WHERE Name = name;";

            using (var connection = DbConnectionFactory())
            {
                connection.Open();
                return connection.Execute(sql, new { Name = name });
            }
        }

        public IEnumerable<Club> GetClubs()
        {
            string sql = "SELECT * FROM Club;";

            using (var connection = DbConnectionFactory())
            {
                return connection.Query<Club>(sql);
            }
        }
    }
}
