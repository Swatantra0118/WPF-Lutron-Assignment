using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.DataAccess
{
    public class DatabaseInitializer
    {
        private string connectionString = "Server=IN-FB6XTN3;Trusted_Connection=True;TrustServerCertificate=True";

        private bool DatabaseExists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM sys.databases WHERE name = 'LutronOrderingSystemDatabase'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int databaseCount = (int)command.ExecuteScalar();
                    return databaseCount > 0;
                }
            }
        }

        public void CreateDatabaseAndTables()
        {
            // Database creation and table creation logic...

            if(!DatabaseExists()) 
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Create database
                    string createDatabaseQuery = "CREATE DATABASE LutronOrderingSystemDatabase;";
                    using (SqlCommand command = new SqlCommand(createDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Use the database
                    string useDatabaseQuery = "USE LutronOrderingSystemDatabase;";
                    using (SqlCommand command = new SqlCommand(useDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create Products table
                    string createProductsTableQuery = @"
                        CREATE TABLE Products (
                            ModelId INT PRIMARY KEY IDENTITY,
                            ModelDisplayString NVARCHAR(100) NOT NULL,
                            Description NVARCHAR(255),
                            Category NVARCHAR(50),
                            NumberOfButtons INT,
                            MountType NVARCHAR(50),
                            Quantity INT
                        )";
                    using (SqlCommand command = new SqlCommand(createProductsTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                SeedInitialValues();
            }
        }

        public void SeedInitialValues()
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Use the database
                    string useDatabaseQuery = "USE LutronOrderingSystemDatabase;";
                    using (SqlCommand command = new SqlCommand(useDatabaseQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Seed initial values for Products table
                    string seedProductsQuery = @"
                    INSERT INTO Products (ModelDisplayString, Description, Category, NumberOfButtons, MountType, Quantity)
                    VALUES 
                    ('Model1', 'Description1', 'ControlStation', 4, NULL, 10),
                    ('Model2', 'Description2', 'ControlStation', 6, NULL, 15),
                    ('Model3', 'Description3', 'ControlStation', 8, NULL, 20),
                    ('Enclosure1', 'Description1', 'Enclosure', NULL, 'WallMount', 10),
                    ('Enclosure2', 'Description2', 'Enclosure', NULL, 'TableTop', 15),
                    ('Enclosure3', 'Description3', 'Enclosure', NULL, 'PanelMount', 20)";
                    using (SqlCommand command = new SqlCommand(seedProductsQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
        }
    }
}
