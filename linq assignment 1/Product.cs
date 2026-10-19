using System;
using System.Collections.Generic;
using System.Text;

namespace linq_assignment_1
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public override string ToString() => $"ProductID={ProductID}, ProductName={ProductName}, Category={Category}, UnitPrice={UnitPrice:C2}, UnitsInStock={UnitsInStock}";
    }
}
