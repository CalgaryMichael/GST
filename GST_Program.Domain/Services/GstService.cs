using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GST_Program.Domain.Extensions;
using GST_Program.Domain.Models;
using GST_Program.Domain.Sql;

namespace GST_Program.Domain.Services
{
    public class GstService
    {
        private readonly string _connectionString;

        public GstService(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        #region Database Creation

        public string CreateDatabase(string connectionString)
        {
            // This method uses ADO.NET to recreate the database
            using (var db = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(Scripts.CreateDatabaseSql, db);

                try
                {
                    db.Open();
                    command.ExecuteNonQuery();
                    return "Database is Created Successfully";
                }
                catch (System.Exception e)
                {
                    return e.ToString();
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
        }

        public string CreateTables()
        {
            // This method uses ADO.NET to recreate the tables
            using (var db = CreateConnection())
            {
                var command = new SqlCommand(Scripts.CreateTablesSql, db);

                try
                {
                    db.Open();
                    command.ExecuteNonQuery();
                    return "Tables is Created Successfully";
                }
                catch (System.Exception e)
                {
                    return e.ToString();
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
        }

        public string InsertDummyData()
        {
            // This method uses ADO.NET to insert dummy data
            using (var db = CreateConnection())
            {
                var command = new SqlCommand(Scripts.InsertDummyDataSql, db);

                try
                {
                    db.Open();
                    command.ExecuteNonQuery();
                    return "Data Inserted Successfully";
                }
                catch (System.Exception e)
                {
                    return e.ToString();
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
        }

        #endregion

        #region Read Multiple

        // Populate List<Person> with rows in Db
        public List<Person> ReadAllPerson()
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<Person>().ToList();
            }
        }


        // Populate List<Person> with rows in Db based off of PersonType
        public List<Person> ReadAllPersonByType(string type)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<Person>("WHERE [PersonType] = @type", new {type}).ToList();
            }
        }


        // Populate List<Badge> with rows in the Db
        public List<Badge> ReadAllBadge()
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<Badge>().ToList();
            }
        }

        // Populate List<Badge> with rows in the Db
        public List<Badge> ReadAllBadgeByType(string type)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<Badge>("WHERE [BadgeGiveType] = @type", new {type}).ToList();
            }
        }


        // Populate List<BadgeHistory> with rows in the Db equal to Giver ID
        public List<BadgeHistory> ReadAllBadgeReceivedByGiver(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<BadgeHistory>("WHERE [GiverId] = @id", new {id}).ToList();
            }
        }


        // Populate List<BadgeHistory> with rows in the Db equal to Receiver ID
        public List<BadgeHistory> ReadAllBadgeReceivedByReceiver(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<BadgeHistory>("WHERE [StudentId] = @id", new {id}).ToList();
            }
        }


        // Populate List<BadgeHistory> with rows in the Db equal to Badge ID
        public List<BadgeHistory> ReadAllBadgeReceivedByBadge(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.Select<BadgeHistory>("WHERE [BadgeId] = @id", new {id}).ToList();
            }
        }

        #endregion

        #region Select Single

        // Retrieve Person to edit
        public Person ReadSinglePerson(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.SelectSingleOrDefault<Person>("WHERE [PersonId] = @id", new {id});
            }
        }


        // Retrieve Badge to edit
        public Badge ReadSingleBadge(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.SelectSingleOrDefault<Badge>("WHERE [BadgeId] = @id", new {id});
            }
        }


        // Retrieve BadgeHistory to edit
        public BadgeHistory ReadSingleBadgeReceived(string id)
        {
            using (IDbConnection db = CreateConnection())
            {
                return db.SelectSingleOrDefault<BadgeHistory>("WHERE TransationNum = @id", new {id});
            }
        }

        #endregion

        #region Insert

        // Create new row in Person
        public void Create(Person p)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("INSERT INTO [Person] VALUES(@PersonId, @PersonType, @PersonName, @PersonEmail, @AdminStatus)", p);
            }
        }


        // Create new row in Badge
        public void Create(Badge b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("INSERT INTO [BadgeBank] VALUES(@BadgeId, @BadgeName, @BadgeSummary, @BadgeCategory, @BadgeGiveType, @DateActivatedStr, @DateRetired, @Notes, @ImageAddress)", b);
            }
        }


        // Create new row in BadgeHistory
        public void Create(BadgeHistory b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("INSERT INTO [BadgeHistory] VALUES(@BadgeId, @GiverId, @StudentId, @TimeStamp, @Comment)", b);
            }
        }

        #endregion

        #region Update

        // Update row in Person
        public void Update(Person p)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("UPDATE [Person] SET [PersonType] = @PersonType, [PersonName] = @PersonName, [PersonEmail] = @PersonEmail, [AdminStatus] = @AdminStatus WHERE [personID] = @PersonID", p);
            }
        }


        // Update row in Badge
        public void Update(Badge b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("UPDATE [BadgeBank] SET [BadgeName] = @BadgeName, [BadgeSummary] = @BadgeSummary, [BadgeCategory] = @BadgeCategory, [BadgeGiveType] = @BadgeGiveType, [DateActivated] = @DateActivated, [DateRetired] = @DateRetired, [Notes] = @Notes, [Imageaddress] = @ImageAddress WHERE [BadgeId] = @BadgeId", b);
            }
        }


        // Update row in BadgeHistory
        public void Update(BadgeHistory b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("UPDATE [BadgeHistory] SET [TransactionNum] = @TransactionNum, [BadgeId] = @BadgeId, [GiverId] = @GiverId, [StudentId] = @StudentId, [TimeStamp] = @TimeStamp, [Comment] = @Comment WHERE [TransactionNum] = @TransactionNum", b);
            }
        }

        #endregion

        #region Delete Row

        // Delete row in Person
        public void Delete(Person p)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("DELETE person WHERE personID = @PersonID", p);
            }
        }


        // Delete row in Badge
        public void Delete(Badge b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("DELETE BadgeBank WHERE BadgeId = @BadgeId", b);
            }
        }


        // Delete row in BadgeRecieved
        public void Delete(BadgeHistory b)
        {
            using (IDbConnection db = CreateConnection())
            {
                db.Execute("DELETE person WHERE TransactionNum = @TransactionNum", b);
            }
        }

        #endregion
    }
}