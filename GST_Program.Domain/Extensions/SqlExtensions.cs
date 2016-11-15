using System.Collections.Generic;
using System.Data;
using Dapper;

namespace GST_Program.Domain.Extensions
{
    public static class SqlExtensions
    {
        public static IEnumerable<T> Select<T>(this IDbConnection db, string sql = null, object param = null)
        {
            return db.Query<T>($"SELECT * FROM [{typeof(T).Name}] {sql}", param);
        }

        public static T SelectSingleOrDefault<T>(this IDbConnection db, string sql = null, object param = null)
        {
            return db.QuerySingleOrDefault<T>($"SELECT * FROM [{typeof(T).Name}] {sql}", param);
        }
    }
}