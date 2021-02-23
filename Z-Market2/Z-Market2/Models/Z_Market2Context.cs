using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class Z_Market2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Z_Market2Context() : base("name=Z_Market2Context")
        {
        }

        public System.Data.Entity.DbSet<Z_Market2.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Subcategory> Subcategories { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<Z_Market2.Models.SupplierProduct> SupplierProducts { get; set; }
        //public System.Data.Entity.DbSet<Z_Market2.Models.SupplierProduct> SupplierProducts { get; set; }
    }
}
