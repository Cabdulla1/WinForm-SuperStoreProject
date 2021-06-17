using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStoreProject
{
    class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public  int TopCategory { get; set; }
        public int SubCategory { get; set; }
        public int Stock { get; set; }
        public  decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int NumberOfSales { get; set; }
        public decimal TotalPrice { get; set; }
        

    }
}
