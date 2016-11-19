using GST_Program.Domain.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GST_Program.Domain.Sql;

namespace GST_Program.Domain.Services {
	public class Database {
		private string connection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		#region Database Creation

		// Drop & Create Database
		public void CreateDatabase() {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["MasterConnection"].ConnectionString)) {
				db.Execute(Scripts.CreateDatabaseSql);
			}
		}

		
		// Create Tables to fill the Database
		public void CreateTables() {
			using (IDbConnection db = new SqlConnection(connection)) {
				db.Execute(Scripts.CreateTablesSql);
			}
		}


		// Fill tables with dummy data
		public void InsertData() {
			using (IDbConnection db = new SqlConnection(connection)) {
				db.Execute(Scripts.InsertDummyDataSql);
			}
		}

		#endregion

		#region Create

		// Create new row in Person
		public void Create(Person p) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "INSERT INTO person VALUES(@Person_ID, @Person_Type, @Person_Name, @Person_Email, @Admin_Status)";
				db.Execute(sqlQuery, p);
			}
		}


		// Create new row in Badge
		public void Create(Badge b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "INSERT INTO BadgeBank VALUES(@Badge_ID, @Badge_Name, @Badge_Summary, @Badge_Category, @Badge_Give_Type, @Date_Activated_Str, @Date_Retired, @Notes, @Image_Address)";
				db.Execute(sqlQuery, b);
			}
		}


		// Create new row in BadgeHistory
		public void Create(BadgeHistory b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "INSERT INTO BadgeHistory VALUES(@Badge_ID, @ID_Giver, @Student_ID, @Time_Stamp, @Comment)";
				db.Execute(sqlQuery, b);
			}
		}

		#endregion

		#region Read Multiple

		// Populate List<Person> with rows in Db
		public List<Person> ReadAllPerson() {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Person>("Select * From Person").ToList();
			}
		}


		// Populate List<Person> with rows in Db based off of Person_Type
		public List<Person> ReadAllPersonByType(string type) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Person>("Select * From Person WHERE Person_Type = @type", new { type }).ToList();
			}
		}


		// Populate List<Badge> with rows in the Db
		public List<Badge> ReadAllBadge() {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Badge>("Select * From BadgeBank").ToList();
			}
		}


		// Populate List<Badge> with rows in the Db
		public List<Badge> ReadAllBadgeByType(string type) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Badge>("Select * From BadgeBank WHERE Badge_Give_Type = @type", new { type }).ToList();
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Giver ID
		public List<BadgeHistory> ReadAllBadgeReceivedByGiver(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sql = @"SELECT BadgeHistory.*, BadgeBank.*, g.*, r.*
								FROM BadgeHistory, BadgeBank, Person AS g, Person AS r
								WHERE BadgeBank.Badge_ID = BadgeHistory.Badge_ID
								AND g.Person_ID = BadgeHistory.Giver_ID
								AND r.Person_ID = BadgeHistory.Student_ID
								AND BadgeHistory.Giver_ID = @id";
				var result = db.Query<BadgeHistory, Badge, Person, Person, BadgeHistory>(sql,
					(bh, badge, giver, receiver) => {
						bh.Badge = badge;
						bh.Giver = giver;
						bh.Receiver = receiver;
						return bh;
					}, new { id = ID },
					splitOn: "Badge_ID,Person_ID,Person_ID").AsList();

				return result;
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Receiver ID
		public List<BadgeHistory> ReadAllBadgeReceivedByReceiver(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sql = @"SELECT BadgeHistory.*, BadgeBank.*, g.*, r.*
								FROM BadgeHistory, BadgeBank, Person AS g, Person AS r
								WHERE BadgeBank.Badge_ID = BadgeHistory.Badge_ID
								AND g.Person_ID = BadgeHistory.Giver_ID
								AND r.Person_ID = BadgeHistory.Student_ID
								AND BadgeHistory.Student_ID = @id";
				var result = db.Query<BadgeHistory, Badge, Person, Person, BadgeHistory>(sql,
					(bh, badge, giver, receiver) => {
						bh.Badge = badge;
						bh.Giver = giver;
						bh.Receiver = receiver;
						return bh;
					}, new { id = ID },
					splitOn: "Badge_ID,Person_ID,Person_ID").AsList();

				return result;
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Badge ID
		public List<BadgeHistory> ReadAllBadgeReceivedByBadge(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sql = @"SELECT BadgeHistory.*, BadgeBank.*, g.*, r.*
								FROM BadgeHistory, BadgeBank, Person AS g, Person AS r
								WHERE BadgeBank.Badge_ID = BadgeHistory.Badge_ID
								AND g.Person_ID = BadgeHistory.Giver_ID
								AND r.Person_ID = BadgeHistory.Student_ID
								AND BadgeHistory.Badge_ID = @id";
				var result = db.Query<BadgeHistory, Badge, Person, Person, BadgeHistory>(sql,
					(bh, badge, giver, receiver) => {
						bh.Badge = badge;
						bh.Giver = giver;
						bh.Receiver = receiver;
						return bh;
					}, new { id = ID },
					splitOn: "Badge_ID,Person_ID,Person_ID").AsList();

				return result;
			}
		}

		#endregion

		#region Read Single

		// Retrieve Person by ID
		public Person ReadSinglePerson(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Person>("SELECT * FROM Person WHERE Person_ID = @ID", new { ID }).SingleOrDefault();
			}
		}


		// Retrieve Person by Name
		public Person ReadSinglePersonByName(string name) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Person>("SELECT * FROM Person WHERE Person_Name LIKE '%'+@name+'%'", new { name }).FirstOrDefault();
			}
		}


		// Retrieve Badge by ID
		public Badge ReadSingleBadge(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Badge>("SELECT * FROM BadgeBank WHERE Badge_ID = @ID", new { ID }).SingleOrDefault();
			}
		}


		// Retrieve Badge by Name
		public Badge ReadSingleBadgeByName(string name) {
			using (IDbConnection db = new SqlConnection(connection)) {
				return db.Query<Badge>("SELECT * FROM BadgeBank WHERE Badge_Name LIKE '%'+@name+'%'", new { name }).FirstOrDefault();
			}
		}


		// Retrieve BadgeReceived by ID
		public BadgeHistory ReadSingleBadgeReceived(string ID) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sql = @"SELECT BadgeHistory.*, BadgeBank.*, g.*, r.*
								FROM BadgeHistory, BadgeBank, Person AS g, Person AS r
								WHERE BadgeBank.Badge_ID = BadgeHistory.Badge_ID
								AND g.Person_ID = BadgeHistory.Giver_ID
								AND r.Person_ID = BadgeHistory.Student_ID
								AND BadgeHistory.Transaction_Num = @id";
				var result = db.Query<BadgeHistory, Badge, Person, Person, BadgeHistory>(sql,
					(bh, badge, giver, receiver) => {
						bh.Badge = badge;
						bh.Giver = giver;
						bh.Receiver = receiver;
						return bh;
					}, new { id = ID },
					splitOn: "Badge_ID,Person_ID,Person_ID").FirstOrDefault();

				return result;
				//return db.Query<BadgeHistory>("Select * From BadgeBank WHERE Transation_Num = @ID", new { ID }).SingleOrDefault();
			}
		}

		#endregion

		#region Update

		// Update row in Person
		public void Update(Person p) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "UPDATE person SET Person_Type = @Person_Type, Person_Name = @Person_Name, Person_Email = @Person_Email, Admin_Status = @Admin_Status WHERE person_ID = @Person_ID";
				db.Execute(sqlQuery, p);
			}
		}


		// Update row in Badge
		public void Update(Badge b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				var sqlQuery = "UPDATE BadgeBank SET Badge_Name = @Badge_Name, Badge_Summary = @Badge_Summary, Badge_Category = @Badge_Category, Badge_Give_Type = @Badge_Give_Type, Date_Activated = @Date_Activated, Date_Retired = @Date_Retired, Notes = @Notes, Image_Address = @Image_Address WHERE Badge_ID = @Badge_ID";
				db.Execute(sqlQuery, b);
			}
		}


		// Update row in BadgeReceived
		public void Update(BadgeHistory b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "UPDATE BadgeReceived SET Transaction_Num = @Transaction_Num, Badge_ID = @Badge_ID, Giver_ID = @Giver_ID, Student_ID = @Student_ID, Time_Stamp = @Time_Stamp, Comment = @Comment WHERE Transaction_Num = @Transaction_Num";
				db.Execute(sqlQuery, b);
			}
		}

		#endregion

		#region Delete

		// Delete row in Person
		public void Delete(Person p) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "DELETE Person WHERE Person_ID = @Person_ID";
				db.Execute(sqlQuery, p);
			}
		}


		// Delete row in Badge
		public void Delete(Badge b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "DELETE BadgeBank WHERE Badge_ID = @Badge_ID";
				db.Execute(sqlQuery, b);
			}
		}


		// Delete row in BadgeRecieved
		public void Delete(BadgeHistory b) {
			using (IDbConnection db = new SqlConnection(connection)) {
				string sqlQuery = "DELETE person WHERE Transaction_Num = @Transaction_Num";
				db.Execute(sqlQuery, b);
			}
		}

		#endregion
	}
}
