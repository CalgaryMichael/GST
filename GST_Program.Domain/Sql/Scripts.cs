using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GST_Program.Domain.Sql
{
    public static class Scripts
    {
        static Scripts()
        {
            SqlRoot = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent?.FullName + "/GST_Program.Domain/Sql";

            ScriptDictionary = Directory.GetFiles(SqlRoot, "*.sql").ToDictionary(Path.GetFileNameWithoutExtension, File.ReadAllText, StringComparer.OrdinalIgnoreCase);

            CreateDatabaseSql = ScriptDictionary["CreateDatabase"];
            CreateTablesSql = ScriptDictionary["CreateTables"];
            InsertDummyDataSql = ScriptDictionary["InsertDummyData"];
        }

        public static string SqlRoot { get; }

        public static string CreateDatabaseSql { get; }
        public static string CreateTablesSql { get; }
        public static string InsertDummyDataSql { get; }

        public static Dictionary<string, string> ScriptDictionary { get; }
    }
}
