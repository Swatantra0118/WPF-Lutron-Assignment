using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.Tests
{
    public class DatabaseManagerTests
    {
        private DatabaseManager databaseManager;

        [SetUp]
        public void Setup()
        {
            // Set up a DatabaseManager instance for testing and any other requirements that are required for tests come here
            databaseManager = new DatabaseManager();
        }

        [Test]
        public void AddProductTest()
        {
            // Arrange
            ProductModel product = new ProductModel
            {
                ModelId = 7,
                ModelDisplayString = "TestProduct",
                Description = "TestDescription",
                Category = ProductModel.ProductCategory.ControlStation,
                NumberOfButtons = 4,
                MountType = ProductModel.MountTypeEnum.WallMount,
                Quantity = 10
            };

            // Act
            databaseManager.AddProduct(product);

            // Assert
            ProductModel addedProduct = databaseManager.GetProductById(product.ModelId);
            if (addedProduct == null)
            {
                Assert.Fail("Product was not added successfully.");
            }

        }

        [Test]
        public void UpdateProductTest()
        {
            // Arrange
            int productIdToUpdate = 2; // Assuming there's a product with ID 1 in the database
            //ProductModel originalProduct = databaseManager.GetProductById(productIdToUpdate);

            // Create an updated product model
            ProductModel updatedProduct = new ProductModel
            {
                ModelId = productIdToUpdate,
                ModelDisplayString = "UpdatedTestProduct",
                Description = "UpdatedTestDescription",
                Category = ProductModel.ProductCategory.Enclosure,
                NumberOfButtons = 6,
                MountType = ProductModel.MountTypeEnum.TableTop,
                Quantity = 15
            };

            // Act
            databaseManager.UpdateProduct(updatedProduct);

            // Get the updated product from the database
            ProductModel retrievedUpdatedProduct = databaseManager.GetProductById(productIdToUpdate);

            // Assert
            if (retrievedUpdatedProduct == null)
            {
                Assert.Fail("Product with the specified ID was not found in the database.");
            }

            if (updatedProduct.ModelDisplayString != retrievedUpdatedProduct.ModelDisplayString)
            {
                Assert.Fail("ModelDisplayString was not updated successfully.");
            }

            if (updatedProduct.Description != retrievedUpdatedProduct.Description)
            {
                Assert.Fail("Description was not updated successfully.");
            }

            if (updatedProduct.Category != retrievedUpdatedProduct.Category)
            {
                Assert.Fail("Category was not updated successfully.");
            }

            if (updatedProduct.NumberOfButtons != retrievedUpdatedProduct.NumberOfButtons)
            {
                Assert.Fail("NumberOfButtons was not updated successfully.");
            }

            if (updatedProduct.MountType != retrievedUpdatedProduct.MountType)
            {
                Assert.Fail("MountType was not updated successfully.");
            }

            if (updatedProduct.Quantity != retrievedUpdatedProduct.Quantity)
            {
                Assert.Fail("Quantity was not updated successfully.");
            }
        }

        [Test]
        public void DeleteProductTest()
        {
            // Arrange
            int modelIdToDelete = 1; // Assuming there's a product with ID 1 in the database

            // Act
            databaseManager.DeleteProduct(modelIdToDelete);

            // Assert
            DataTable products = databaseManager.GetProducts();
            bool productDeleted = true;

            foreach (DataRow row in products.Rows)
            {
                if ((int)row["ModelId"] == modelIdToDelete)
                {
                    productDeleted = false;
                    break;
                }
            }

            Assert.That(productDeleted, $"Product with ID {modelIdToDelete} was not deleted successfully.");
        }
    }
}
