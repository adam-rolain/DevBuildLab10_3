﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Lab10_2CoffeeShop.Models
{
    public class DAL
    {
        // Database connection field
        public static MySqlConnection DB = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");

        // Read all products from product table
        public static List<Product> GetAllProducts()
        {
            return DB.GetAll<Product>().ToList();
        }

        // Read products by category
        public static List<Product> GetProductsByCategory(string category)
        {
            return DB.Query<Product>("SELECT * FROM product WHERE category = @mycat", new { mycat = category }).ToList();
        }

        // Read individual product
        public static Product GetProduct(int id)
        {
            return DB.Get<Product>(id);
        }

    }
}