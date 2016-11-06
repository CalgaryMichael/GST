using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GST_Program.Domain;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace GST_Program.Models {
	public class DatabaseModel {

		// ***********************
		// Read Multiple
		// ***********************

		// Populate List<Person> with rows in Db
		public List<Person> ReadAllPerson() {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Person>("Select * From person").ToList();
			}
		}


		// Populate List<Person> with rows in Db based off of Person_Type
		public List<Person> ReadAllPersonByType(string type) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Person>("Select * From person WHERE Person_Type = @type", new { type }).ToList();
			}
		}


		// Populate List<Badge> with rows in the Db
		public List<Badge> ReadAllBadge() {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Badge>("Select * From BadgeBank").ToList();
			}
		}

		// Populate List<Badge> with rows in the Db
		public List<Badge> ReadAllBadgeByType(string type) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Badge>("Select * From BadgeBank WHERE Badge_Give_Type = @type", new { type }).ToList();
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Giver ID
		public List<BadgeReceived> ReadAllBadgeReceivedByGiver(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<BadgeReceived>("Select * From BadgeHistory WHERE ID_Giver = @ID", new { ID }).ToList();
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Receiver ID
		public List<BadgeReceived> ReadAllBadgeReceivedByReceiver(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<BadgeReceived>("Select * From BadgeHistory WHERE Student_ID = @ID", new { ID }).ToList();
			}
		}


		// Populate List<BadgeReceived> with rows in the Db equal to Badge ID
		public List<BadgeReceived> ReadAllBadgeReceivedByBadge(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<BadgeReceived>("Select * From BadgeHistory WHERE Badge_ID = @ID", new { ID }).ToList();
			}
		}


		// ***********************
		// Read Single
		// ***********************

		// Retrieve Person to edit
		public Person ReadSinglePerson(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Person>("Select * From person WHERE person_ID = @Person_ID", new { ID }).SingleOrDefault();
			}
		}


		// Retrieve Badge to edit
		public Badge ReadSingleBadge(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<Badge>("Select * From BadgeBank WHERE Badge_ID = @ID", new { ID }).SingleOrDefault();
			}
		}


		// Retrieve BadgeReceived to edit
		public BadgeReceived ReadSingleBadgeReceived(string ID) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				return db.Query<BadgeReceived>("Select * From BadgeBank WHERE Transation_Num = @ID", new { ID }).SingleOrDefault();
			}
		}


		// ***********************
		// Create Row
		// ***********************

		// Create new row in Person
		public void Create(Person p) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "INSERT INTO person VALUES(@Person_ID, @Person_Type, @Person_Name, @Person_Email, @Admin_Status)";
				db.Execute(sqlQuery, p);
			}
		}


		// Create new row in Badge
		public void Create(Badge b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "INSERT INTO BadgeBank VALUES(@Badge_ID, @Badge_Name, @Badge_Summary, @Badge_Category, @Badge_Give_Type, @Date_Activated, @Date_Retired, @Notes, @Image_Address)";
				db.Execute(sqlQuery, b);
			}
		}


		// Create new row in BadgeReceived
		public void Create(BadgeReceived b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "INSERT INTO BadgeHistory VALUES(@Transaction_Num, @Badge_ID, @ID_Giver, @Student_ID, @Time_Stamp, @Comment)";
				db.Execute(sqlQuery, b);
			}
		}


		// ***********************
		// Update Row
		// ***********************

		// Update row in Person
		public void Update(Person p) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "UPDATE person SET Person_Type = @Person_Type, Person_Name = @Person_Name, Person_Email = @Person_Email, Admin_Status = @Admin_Status WHERE person_ID = @Person_ID";
				db.Execute(sqlQuery, p);
			}
		}


		// Update row in Badge
		public void Update(Badge b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "UPDATE BadgeBank SET Badge_ID = @Badge_ID, Badge_Name = @Badge_Name, Badge_Summary = @Badge_Summary, Badge_Category = @Badge_Category, Badge_Give_Type = @Badge_Give_Type, Date_Activated = @Date_Activated, Date_Retired = @Date_Retired, Notes = @Notes, Image_Address = @Image_Address)";
				db.Execute(sqlQuery, b);
			}
		}


		// Update row in BadgeReceived
		public void Update(BadgeReceived b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "UPDATE BadgeReceived SET Transaction_Num = @Transaction_Num, Badge_ID = @Badge_ID, ID_Giver = @ID_Giver, Student_ID = @Student_ID, Time_Stamp = @Time_Stamp, Comment = @Comment)";
				db.Execute(sqlQuery, b);
			}
		}

		// ***********************
		// Delete Row
		// ***********************

		// Delete row in Person
		public void Delete(Person p) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "DELETE person WHERE person_ID = @Person_ID";
				db.Execute(sqlQuery, p);
			}
		}


		// Delete row in Badge
		public void Delete(Badge b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "DELETE BadgeBank WHERE Badge_ID = @Badge_ID";
				db.Execute(sqlQuery, b);
			}
		}


		// Delete row in BadgeRecieved
		public void Delete(BadgeReceived b) {
			using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
				string sqlQuery = "DELETE person WHERE Transaction_Num = @Transaction_Num";
				db.Execute(sqlQuery, b);
			}
		}
	}
}