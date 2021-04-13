using System.Collections.Generic;
using System.Data;
using CsharpMorningChallenge1.Models;
using Dapper;

namespace CsharpMorningChallenge1.Repositories
{
    public class ProductsRepository
    {
        public readonly IDbConnection _db;

        public ProductsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Product> Get()               //GET
        {
            string sql = "SELECT * FROM productss;";
            return _db.Query<Product>(sql);
        }

        internal Product Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM productss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Product>(sql, new { Id });
        }

        internal Product Create(Product newProduct)             //POST
        {
            string sql = @"
      INSERT INTO productss
      (name, description, price)
      VALUES
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newProduct);
            newProduct.id = id;
            return newProduct;
        }

        internal Product Edit(Product productsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE products
      SET
          name = @Name,
          description = @Description,
          price = @Price
          WHERE id = @Id;
          SELECT * FROM products WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Product>(sql, productsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM productss WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}