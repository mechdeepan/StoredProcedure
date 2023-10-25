using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Data;
using StoredProcedure.Models;
using System.Drawing;

namespace StoredProcedure.Services
{
    public class ProductService
    {
        private readonly APPDbContext _context;

        public ProductService(APPDbContext context)
        {
            _context = context;
        }

        public void AddProduct(string name, decimal price)
        {
            _context.Database.ExecuteSqlRaw("AddProduct @Name, @Price",
                new SqlParameter("Name", name),
                new SqlParameter("Price", price));
        }

        public void UpdateProduct(int productId, string name, decimal price)
        {
            _context.Database.ExecuteSqlRaw("UpdateProduct @ProductId, @Name, @Price",
                new SqlParameter("ProductId", productId),
                new SqlParameter("Name", name),
                new SqlParameter("Price", price));
        }

        public void DeleteProduct(int productId)
        {
            _context.Database.ExecuteSqlRaw("DeleteProduct @ProductId",
                new SqlParameter("ProductId", productId));
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.FromSqlRaw("EXEC GetAllProducts").ToList();
        }

        public Product GetProductById(int productId)
        {
            SqlParameter param = new SqlParameter("@ProductId", productId);

            // Execute the stored procedure and return the result.
            return _context.Products.FromSqlRaw("EXEC GetProductById @ProductId", param).AsEnumerable().FirstOrDefault();
        }
  






    }
}