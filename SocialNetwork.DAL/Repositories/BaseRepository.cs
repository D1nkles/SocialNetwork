﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SocialNetwork.DAL.Repositories
{
    public class BaseRepository
    {
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DB/social_network_db.db; Version = 3");
        }

        protected T QueryFirstOrDefault<T>(string sql, object parameters = null) 
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }
    }
}
