using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.IO;

namespace WinFormsApp1
{
    public class DatabaseHelper
    {
        // เปลี่ยนชื่อไฟล์เป็น V2 จะได้ได้ตารางใหม่ที่มีช่อง Quantity
        private string dbFile = "MyShopV2.db";
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = $"Data Source={dbFile}";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                // เพิ่มช่อง Quantity INTEGER
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Products (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Brand TEXT,
                        Price REAL,
                        Category TEXT,
                        Quantity INTEGER DEFAULT 0 
                    )";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // เพิ่มสินค้า พร้อมจำนวนเริ่มต้น
        public void AddProduct(Product p)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Products (Name, Brand, Price, Category, Quantity) VALUES (@Name, @Brand, @Price, @Category, @Qty)";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", p.Name ?? "");
                    cmd.Parameters.AddWithValue("@Brand", p.Brand ?? "");
                    cmd.Parameters.AddWithValue("@Price", p.Price);
                    cmd.Parameters.AddWithValue("@Category", p.Category ?? "");
                    cmd.Parameters.AddWithValue("@Qty", p.Quantity); // เพิ่มตรงนี้
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            var list = new List<Product>();
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Product();
                            p.Id = Convert.ToInt32(reader["Id"]);
                            p.Name = reader["Name"].ToString();
                            p.Brand = reader["Brand"].ToString();
                            p.Price = Convert.ToDecimal(reader["Price"]);
                            p.Category = reader["Category"].ToString();
                            p.Quantity = Convert.ToInt32(reader["Quantity"]); // อ่านค่าจำนวน
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }

        // ฟังก์ชันใหม่! เอาไว้ "อัปเดตสต็อก" (ใช้ทั้งตอนขาย และตอนเติมของ)
        public void UpdateStock(int productId, int newQuantity)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Products SET Quantity = @Qty WHERE Id = @Id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Qty", newQuantity);
                    cmd.Parameters.AddWithValue("@Id", productId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Products WHERE Id = @Id";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Product> SearchProducts(string keyword)
        {
            var list = new List<Product>();
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products WHERE Name LIKE @kw OR Brand LIKE @kw";
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var p = new Product();
                            p.Id = Convert.ToInt32(reader["Id"]);
                            p.Name = reader["Name"].ToString();
                            p.Brand = reader["Brand"].ToString();
                            p.Price = Convert.ToDecimal(reader["Price"]);
                            p.Category = reader["Category"].ToString();
                            p.Quantity = Convert.ToInt32(reader["Quantity"]);
                            list.Add(p);
                        }
                    }
                }
            }
            return list;
        }
    }
}