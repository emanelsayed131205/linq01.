using LINQ.DataSources;

namespace linq_assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Get all products from the "Seafood" category. Print each product's name and price.

            var result = Source.ProductList
                .Where(p => p.Category == "Seafood");

            Console.WriteLine("------all products from seafood cateogry------");
            foreach (var product in result)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice}");
            }

            #endregion

            #region Get a list of only the product names from ProductList. Print each name.

            var result2 = Source.ProductList
                .Select(p => p.ProductName);

            Console.WriteLine("------all products name ------");
            foreach (var name in result2)
            {
                Console.WriteLine(name);
            }

            #endregion

            #region Sort all products by UnitPrice (ascending). Print each product's name and price.

            var result3 = Source.ProductList
                .OrderBy(p => p.UnitPrice);

            Console.WriteLine("-------Sort all products by UnitPrice-------");
            foreach (var product in result3)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice}");
            }

            #endregion

            #region Get all products where UnitPrice is between 10 and 30

            var result4 = Source.ProductList
                .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            Console.WriteLine("------all prosucts between 10 and 30------");
            foreach (var product in result4)
            {
                Console.WriteLine($"Name: {product.ProductName}, Price: {product.UnitPrice}");
            }

            #endregion

            #region Get all products that are in stock (UnitsInStock > 0) and belong to the "Condiments" category.
            var result5 = Source.ProductList
                .Where(P => P.UnitsInStock > 0 && P.Category == "Condiments");

            Console.WriteLine("------all products in stock (UnitsInStock > 0) and belong to the Condiments category-------");
            foreach (var product in result5)
            {
                Console.WriteLine($"Name: {product.ProductName},UnitInstock:{product.UnitsInStock}");
            }

            #endregion

            #region Create a new anonymous type with three properties:

            var result6 = Source.ProductList
                .Select(p => new {
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                });

            Console.WriteLine("------crating an anonymous-------");
            foreach (var item in result6)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Status: {item.StockStatus}");
            }
            #endregion

            #region Print each product's name along with its position (1-based) in the list. Expected format: 1.Chai, 2.Chang, etc.

            var result7 = Source.ProductList
                .Select((p, index) => $"{index + 1}. {p.ProductName}");

            foreach (var item in result7)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Sort ProductList by Category ascending, then within each category, sort by UnitPrice descending.

            var result8 = Source.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var product in result8)
            {
                Console.WriteLine($"Category: {product.Category}, Name: {product.ProductName}, Price: {product.UnitPrice}");
            }
            #endregion

            #region Get all products from the "Beverages" category, sorted by UnitsInStock descending. Print name and stock.

            var result9 = Source.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var product in result9)
            {
                Console.WriteLine($"Name: {product.ProductName}, Stock: {product.UnitsInStock}");
            }
            #endregion

            #region Using QUERY SYNTAX with a compound from clause, list all orders placed in 1997 or later showing CustomerID and OrderDate. 
            //by ai helping 
            var result10 = from c in Source.CustomerList
                           from o in c.Orders
                           where o.OrderDate.Year >= 1997
                           select new { c.CustomerID, o.OrderDate };

            foreach (var order in result10)
            {
                Console.WriteLine($"CustomerID: {order.CustomerID}, OrderDate: {order.OrderDate}");
            }
            #endregion

            #region Show position number alongside ProductName
            var result11 = Source.ProductList
                .Select((P, i) => new { Position = i + 1, P.ProductName });
            Console.WriteLine("----position num and product name");
            foreach (var item in result11)
            {
                Console.WriteLine($"{item.Position}.{item.ProductName}");
            }
            #endregion

            #region Sort first by-word length and then by a case -insensitive sort of the words in an array.
            //can not do that question 
            #endregion

            #region Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            //some ai help
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BIUeBeRrY", "ClOvEr", "cHeRry" };

            var result13 = Arr
                .Where(w => w.Length > 1 && char.ToLower(w[1]) == 'i')
                .Reverse();

            foreach (var item in result13)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
    
}
