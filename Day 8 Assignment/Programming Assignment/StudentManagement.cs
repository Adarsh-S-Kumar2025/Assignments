using System;
using Microsoft.Data.SqlClient; // Install via: dotnet add package Microsoft.Data.SqlClient
using System.Data;

namespace AdoNetStudentDemo
{
    class Program
    {
        // ✅ Adjust as per your SQL Server setup
        static string connectionString = @"Server=localhost;Database=StudentDB;User Id = sa; Password=12345678Aa;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            Console.WriteLine("=== STUDENT MANAGEMENT USING ADO.NET ===\n");

            CreateStudentTable();
            CreateStoredProcedures();

            InsertStudentInline(1, "John", "10th");
            InsertStudentInline(2, "Emma", "9th");
            InsertStudentInline(3, "David", "8th");

            Console.WriteLine("\n--- Get Student By ID (SP) ---");
            GetStudentById(1);

            Console.WriteLine("\n--- Insert Using Stored Procedure (Output Param) ---");
            InsertStudentUsingSP("Sophia", "11th");

            Console.WriteLine("\n--- Update Student (SP) ---");
            UpdateStudent(2, "Emma Watson", "10th");

            Console.WriteLine("\n--- Delete Student (SP) ---");
            DeleteStudent(3);
        }

        // -------------------------------------------------------------
        // 1️⃣ Create Table
        // -------------------------------------------------------------
        static void CreateStudentTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Student' AND xtype='U')
                CREATE TABLE Student (
                    Id INT PRIMARY KEY,
                    Name NVARCHAR(100),
                    Class NVARCHAR(50)
                )
                ELSE
                DELETE FROM Student;";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Student table ready and cleared.");
            }
        }

        // -------------------------------------------------------------
        // 2️⃣ Create Stored Procedures
        // -------------------------------------------------------------
        static void CreateStoredProcedures()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string createGetSP = @"
CREATE OR ALTER PROCEDURE GetStudentById
    @StudentId INT
AS
BEGIN
    SELECT Id, Name, Class FROM Student WHERE Id = @StudentId;
END";

                string createInsertSP = @"
CREATE OR ALTER PROCEDURE InsertStudent
    @Name NVARCHAR(100),
    @Class NVARCHAR(50),
    @LastInsertedId INT OUTPUT
AS
BEGIN
    DECLARE @NewId INT;
    SELECT @NewId = ISNULL(MAX(Id),0) + 1 FROM Student;
    INSERT INTO Student (Id, Name, Class) VALUES (@NewId, @Name, @Class);
    SET @LastInsertedId = @NewId;
END";

                string createUpdateSP = @"
CREATE OR ALTER PROCEDURE UpdateStudent
    @StudentId INT,
    @StudentName NVARCHAR(100),
    @Class NVARCHAR(50)
AS
BEGIN
    UPDATE Student SET Name = @StudentName, Class = @Class WHERE Id = @StudentId;
END";

                string createDeleteSP = @"
CREATE OR ALTER PROCEDURE DeleteStudent
    @StudentId INT
AS
BEGIN
    DELETE FROM Student WHERE Id = @StudentId;
END";

                con.Open();
                new SqlCommand(createGetSP, con).ExecuteNonQuery();
                new SqlCommand(createInsertSP, con).ExecuteNonQuery();
                new SqlCommand(createUpdateSP, con).ExecuteNonQuery();
                new SqlCommand(createDeleteSP, con).ExecuteNonQuery();

                Console.WriteLine("✅ Stored procedures created successfully.");
            }
        }

        // -------------------------------------------------------------
        // 3️⃣ Parameterized Inline Query - INSERT
        // -------------------------------------------------------------
        static void InsertStudentInline(int id, string name, string className)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Student (Id, Name, Class) VALUES (@Id, @Name, @Class)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Class", className);

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine($"✅ Inserted Student (Inline): {name}");
            }
        }

        // -------------------------------------------------------------
        // 4️⃣ Get Student by Stored Procedure
        // -------------------------------------------------------------
        static void GetStudentById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Class: {reader["Class"]}");
                    }
                }
                else
                {
                    Console.WriteLine($"⚠️ No student found with ID {id}");
                }

                reader.Close();
            }
        }

        // -------------------------------------------------------------
        // 5️⃣ Insert Using Stored Procedure (Output Parameter)
        // -------------------------------------------------------------
        static void InsertStudentUsingSP(string name, string className)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Class", className);

                SqlParameter outParam = new SqlParameter("@LastInsertedId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outParam);

                con.Open();
                cmd.ExecuteNonQuery();

                int newId = (int)outParam.Value;
                Console.WriteLine($"✅ Inserted via SP. New Student ID = {newId}");
            }
        }

        // -------------------------------------------------------------
        // 6️⃣ Update Student using SP
        // -------------------------------------------------------------
        static void UpdateStudent(int id, string name, string className)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", id);
                cmd.Parameters.AddWithValue("@StudentName", name);
                cmd.Parameters.AddWithValue("@Class", className);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0
                    ? $"✅ Student {id} updated successfully."
                    : $"⚠️ No student found with ID {id}.");
            }
        }

        // -------------------------------------------------------------
        // 7️⃣ Delete Student using SP
        // -------------------------------------------------------------
        static void DeleteStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentId", id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0
                    ? $"🗑️ Student {id} deleted successfully."
                    : $"⚠️ No student found with ID {id}.");
            }
        }
    }
}
