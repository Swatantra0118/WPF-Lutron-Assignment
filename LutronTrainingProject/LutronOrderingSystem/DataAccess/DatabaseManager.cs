using LutronOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.DataAccess
{
    public class DatabaseManager
    {
        private string connectionString = "Server=IN-FB6XTN3;Database=LutronOrderingSystemDatabase;Trusted_Connection=True;TrustServerCertificate=True";
        public DataTable GetProducts()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void AddProduct(ProductModel product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Products (ModelDisplayString, Description, Category, NumberOfButtons, MountType, Quantity)
                                VALUES (@ModelDisplayString, @Description, @Category, @NumberOfButtons, @MountType, @Quantity)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ModelDisplayString", product.ModelDisplayString);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Category", product.Category.ToString());
                    command.Parameters.AddWithValue("@NumberOfButtons", product.NumberOfButtons);
                    command.Parameters.AddWithValue("@MountType", product.MountType.ToString());
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(ProductModel product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Products 
                            SET ModelDisplayString = @ModelDisplayString, 
                                Description = @Description, 
                                Category = @Category, 
                                NumberOfButtons = @NumberOfButtons, 
                                MountType = @MountType, 
                                Quantity = @Quantity 
                            WHERE ModelId = @ModelId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelId", product.ModelId);
                        command.Parameters.AddWithValue("@ModelDisplayString", product.ModelDisplayString);
                        command.Parameters.AddWithValue("@Description", product.Description);
                        command.Parameters.AddWithValue("@Category", product.Category.ToString());
                        command.Parameters.AddWithValue("@NumberOfButtons", product.NumberOfButtons);
                        command.Parameters.AddWithValue("@MountType", product.MountType.ToString());
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception($"Product with ModelId {product.ModelId} does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                throw; // Rethrow the exception to propagate it up the call stack
            }
        }

        public void DeleteProduct(int modelId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Products WHERE ModelId = @ModelId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelId", modelId);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"{rowsAffected} row(s) deleted.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting product: {ex.Message}");
                throw; // Rethrow the exception to propagate it up the call stack
            }
        }

        public ProductModel GetProductById(int modelId)
        {
            ProductModel product = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Products WHERE ModelId = @ModelId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelId", modelId);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            product = new ProductModel
                            {
                                ModelId = (int)reader["ModelId"],
                                ModelDisplayString = reader["ModelDisplayString"].ToString(),
                                Description = reader["Description"].ToString(),
                                Category = (ProductModel.ProductCategory)Enum.Parse(typeof(ProductModel.ProductCategory), reader["Category"].ToString()),
                                NumberOfButtons = (int)reader["NumberOfButtons"],
                                MountType = (ProductModel.MountTypeEnum)Enum.Parse(typeof(ProductModel.MountTypeEnum), reader["MountType"].ToString()),
                                Quantity = (int)reader["Quantity"]
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving product: {ex.Message}");
                throw; // Rethrow the exception to propagate it up the call stack
            }
            return product;
        }
    }
}
