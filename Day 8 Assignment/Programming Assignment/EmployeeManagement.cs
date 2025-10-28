using System;
using System.Data;
using Microsoft.Data.SqlClient; 

namespace AdoNetFullDemo
{
    class EmployeeManagement
    {
        static string connectionString = @"Server=localhost;Database=EmployeeDB;User Id = sa; Password=12345678Aa;TrustServerCertificate=true";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== ADO.NET Full Demo ===\n");

                CreateEmployeeTable();
                InsertEmployee(1, "John", 50000);
                InsertEmployee(2, "Emma", 60000);
                InsertEmployee(3, "David", 55000);

                Console.WriteLine("\n1️⃣ Employees using SqlDataReader:");
                DisplayEmployeesWithReader();

                UpdateEmployee(2, "Emma Watson", 75000);
                DeleteEmployee(1);

                Console.WriteLine("\n2️⃣ Employees after Update/Delete:");
                DisplayEmployeesWithReader();

                Console.WriteLine("\n3️⃣ Total Employee Count using ExecuteScalar:");
                DisplayEmployeeCount();

                Console.WriteLine("\n4️⃣ Display using Disconnected Mode (DataAdapter + DataSet):");
                DisplayEmployeesDisconnected();

                Console.WriteLine("\n5️⃣ Modify DataSet and Update Database:");
                ModifyAndUpdateUsingDataSet();

                Console.WriteLine("\n✅ All tasks completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }

        // --------------------------------------------------
        // 1) Create Employee Table
        // --------------------------------------------------
        static void CreateEmployeeTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employee' AND xtype='U')
                                 CREATE TABLE Employee (
                                     Id INT PRIMARY KEY,
                                     Name NVARCHAR(100),
                                     Salary DECIMAL(10,2)
                                 )";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("✅ Employee table ready.");
            }
        }

        // --------------------------------------------------
        // 2) Insert Employee
        // --------------------------------------------------
        static void InsertEmployee(int id, string name, decimal salary)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
IF NOT EXISTS (SELECT 1 FROM Employee WHERE Id = @Id)
    INSERT INTO Employee (Id, Name, Salary) VALUES (@Id, @Name, @Salary);
ELSE
    SELECT -1; -- no-op when duplicate
";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? $"✅ Inserted Employee: {name}" : $"⚠️ Employee with ID {id} already exists. Skipping insert.");
            }
        }

        // --------------------------------------------------
        // 3) Update Employee
        // --------------------------------------------------
        static void UpdateEmployee(int id, string name, decimal salary)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employee SET Name=@Name, Salary=@Salary WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Salary", salary);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? $"✅ Updated Employee ID {id}" : $"⚠️ Employee {id} not found.");
            }
        }

        // --------------------------------------------------
        // 4) Delete Employee
        // --------------------------------------------------
        static void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employee WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? $"🗑️ Deleted Employee ID {id}" : $"⚠️ Employee {id} not found.");
            }
        }

        // --------------------------------------------------
        // 5) Display Employees using SqlDataReader
        // --------------------------------------------------
        static void DisplayEmployeesWithReader()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Salary FROM Employee";
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nID\tName\t\tSalary");
                Console.WriteLine("--------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Id"]}\t{reader["Name"],-15}\t{reader["Salary"]}");
                }
                reader.Close();
            }
        }

        // --------------------------------------------------
        // 6) Display Employee Count using ExecuteScalar
        // --------------------------------------------------
        static void DisplayEmployeeCount()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Employee";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                Console.WriteLine($"👥 Total Employees: {count}");
            }
        }

        // --------------------------------------------------
        // 7) Disconnected Mode - Display using DataSet
        // --------------------------------------------------
        static void DisplayEmployeesDisconnected()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");

                Console.WriteLine("\nID\tName\t\tSalary");
                Console.WriteLine("--------------------------------");
                foreach (DataRow row in ds.Tables["Employee"].Rows)
                {
                    Console.WriteLine($"{row["Id"]}\t{row["Name"],-15}\t{row["Salary"]}");
                }
            }
        }

        // --------------------------------------------------
        // 8) Modify DataSet and Update Database using da.Update()
        // --------------------------------------------------
        static void ModifyAndUpdateUsingDataSet()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employee", con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                DataSet ds = new DataSet();
                da.Fill(ds, "Employee");

                if (ds.Tables["Employee"].Rows.Count > 0)
                {
                    ds.Tables["Employee"].Rows[0]["Salary"] = 99999;
                    Console.WriteLine("💾 Modified first employee's salary in DataSet.");
                }

                DataRow newRow = ds.Tables["Employee"].NewRow();
                newRow["Id"] = 10;
                newRow["Name"] = "NewGuy";
                newRow["Salary"] = 42000;
                ds.Tables["Employee"].Rows.Add(newRow);
                int rowsUpdated = da.Update(ds, "Employee");
                Console.WriteLine($"✅ Database updated successfully ({rowsUpdated} changes).");
                Console.WriteLine("\n🔁 Final Employee List:");
                DisplayEmployeesDisconnected();
            }
        }
    }
}
