using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Assignment53
{
    public class Customer
    {
        public int CustomerID { get; set; } // Unique identifier for a customer
        public string FirstName { get; set; } // First name of the customer
        public string LastName { get; set; } // Last name of the customer
        public string Country { get; set; } // Country where the customer is located
    }


    // This is the Order class, representing an order placed by a customer.
    public class Order
    {
        public int OrderID { get; set; } // Unique identifier for an order
        public int CustomerID { get; set; } // Identifier for the customer who placed the order
        public DateTime OrderDate { get; set; } // Date on which the order was placed
        public DateTime? ShippedDate { get; set; } // Date on which the order was shipped, nullable
    }


    // This is the Product class, representing a product that may be ordered.
    public class Product
    {
        public int ProductID { get; set; } // Unique identifier for a product
        public string ProductName { get; set; } // Name of the product
        public decimal UnitPrice { get; set; } // Price of a single unit of the product
    }


    // This is the OrderDetail class, representing a line item in an order.
    public class OrderDetail
    {
        public int OrderDetailID { get; set; } // Unique identifier for an order detail
        public int OrderID { get; set; } // Identifier for the order to which the detail belongs
        public int ProductID { get; set; } // Identifier for the product in the order detail
        public int Quantity { get; set; } // Number of units of the product ordered
        public decimal Discount { get; set; } // Discount applied to the product in the order detail
    }
    internal class Program
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerID = 1, FirstName = "John", LastName = "Doe", Country = "USA" },
            new Customer { CustomerID = 2, FirstName = "Jane", LastName = "Doe", Country = "USA" },
            new Customer { CustomerID = 3, FirstName = "Alice", LastName = "Smith", Country = "Canada" },
            new Customer { CustomerID = 4, FirstName = "Bob", LastName = "Smith", Country = "Canada" },
            new Customer { CustomerID = 5, FirstName = "Charlie", LastName = "Brown", Country = "USA" }
        };

            // Create some sample products
            List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", UnitPrice = 18.00M },
            new Product { ProductID = 2, ProductName = "Chang", UnitPrice = 19.00M },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", UnitPrice = 10.00M },
            new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", UnitPrice = 22.00M },
            new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", UnitPrice = 21.35M },
            new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", UnitPrice = 25.00M },
            new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", UnitPrice = 30.00M },
            new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", UnitPrice = 40.00M },
            new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", UnitPrice = 97.00M },
            new Product { ProductID = 10, ProductName = "Ikura", UnitPrice = 31.00M },
            new Product { ProductID = 11, ProductName = "Queso Cabrales", UnitPrice = 21.00M },
            new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", UnitPrice = 38.00M },
            new Product { ProductID = 13, ProductName = "Konbu", UnitPrice = 6.00M },
            new Product { ProductID = 14, ProductName = "Tofu", UnitPrice = 23.25M },
            new Product { ProductID = 15, ProductName = "Genen Shouyu", UnitPrice = 15.50M }
        };

            // define a list of orders
            List<Order> orders = new List<Order>
            {
                new Order { OrderID = 1, CustomerID = 1, OrderDate = new DateTime(2022, 1, 1), ShippedDate = new DateTime(2022, 1, 10) },
                new Order { OrderID = 2, CustomerID = 1, OrderDate = new DateTime(2022, 2, 1), ShippedDate = new DateTime(2022, 2, 10) },
                new Order { OrderID = 3, CustomerID = 2, OrderDate = new DateTime(2022, 3, 1), ShippedDate = new DateTime(2022, 3, 10) },
                new Order { OrderID = 4, CustomerID = 3, OrderDate = new DateTime(2022, 4, 1), ShippedDate = new DateTime(2022, 4, 10) },
                new Order { OrderID = 5, CustomerID = 4, OrderDate = new DateTime(2022, 5, 1), ShippedDate = new DateTime(2022, 5, 10) },
                new Order { OrderID = 6, CustomerID = 5, OrderDate = new DateTime(2022, 6, 1), ShippedDate = new DateTime(2022, 6, 10) },
                new Order { OrderID = 7, CustomerID = 1, OrderDate = new DateTime(2022, 7, 1), ShippedDate = new DateTime(2022, 7, 10) },
                new Order { OrderID = 8, CustomerID = 2, OrderDate = new DateTime(2022, 8, 1), ShippedDate = new DateTime(2022, 8, 10) },
                new Order { OrderID = 9, CustomerID = 3, OrderDate = new DateTime(2022, 9, 1), ShippedDate = new DateTime(2022, 9, 10) },
                new Order { OrderID = 10, CustomerID = 4, OrderDate = new DateTime(2022, 10, 1), ShippedDate = new DateTime(2022, 10, 10) }
                };

            // define a list of order details
            List<OrderDetail> orderDetails = new List<OrderDetail>()
            {
                new OrderDetail() { OrderDetailID = 1, OrderID = 1, ProductID = 1, Quantity = 5, Discount = 0.1m },
                new OrderDetail() { OrderDetailID = 2, OrderID = 1, ProductID = 2, Quantity = 3, Discount = 0m },
                new OrderDetail() { OrderDetailID = 3, OrderID = 2, ProductID = 3, Quantity = 2, Discount = 0.05m },
                new OrderDetail() { OrderDetailID = 4, OrderID = 2, ProductID = 4, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 5, OrderID = 3, ProductID = 5, Quantity = 4, Discount = 0m },
                new OrderDetail() { OrderDetailID = 6, OrderID = 4, ProductID = 6, Quantity = 2, Discount = 0m },
                new OrderDetail() { OrderDetailID = 7, OrderID = 4, ProductID = 7, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 8, OrderID = 5, ProductID = 8, Quantity = 3, Discount = 0m },
                new OrderDetail() { OrderDetailID = 9, OrderID = 5, ProductID = 9, Quantity = 2, Discount = 0m },
                new OrderDetail() { OrderDetailID = 10, OrderID = 5, ProductID = 10, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 11, OrderID = 6, ProductID = 1, Quantity = 4, Discount = 0m },
                new OrderDetail() { OrderDetailID = 12, OrderID = 7, ProductID = 2, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 13, OrderID = 7, ProductID = 3, Quantity = 2, Discount = 0m },
                new OrderDetail() { OrderDetailID = 14, OrderID = 7, ProductID = 4, Quantity = 3, Discount = 0.1m },
                new OrderDetail() { OrderDetailID = 15, OrderID = 8, ProductID = 5, Quantity = 7, Discount = 0m },
                new OrderDetail() { OrderDetailID = 16, OrderID = 8, ProductID = 6, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 17, OrderID = 9, ProductID = 7, Quantity = 2, Discount = 0m },
                new OrderDetail() { OrderDetailID = 18, OrderID = 10, ProductID = 8, Quantity = 3, Discount = 0m },
                new OrderDetail() { OrderDetailID = 19, OrderID = 10, ProductID = 9, Quantity = 1, Discount = 0m },
                new OrderDetail() { OrderDetailID = 20, OrderID = 10, ProductID = 10, Quantity = 4, Discount = 0m }
            };

            Console.WriteLine("Query 1: All customers in alphabetical order by last name");
            List<Customer> list1 = customers.OrderBy(x => x.LastName).ToList();
            foreach(Customer customer in list1)
            {
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }
            Console.WriteLine();
            Console.WriteLine("Query 2: All products in order of unit price, from highest to lowest");
            List<Product> list2 = products.OrderByDescending(x => x.UnitPrice).ToList();
            foreach(Product product in list2)
            {
                Console.WriteLine($"{product.ProductName}: Rs. {product.UnitPrice:F2}"); 
            }
            Console.WriteLine();
            Console.WriteLine("Query 3: All orders shipped in October 2021");
            List<Order> list3 = orders.Where(x => x.ShippedDate.HasValue && x.ShippedDate.Value.Year == 2021 && x.ShippedDate.Value.Month == 10).ToList();
            foreach(Order order in list3)
            {
                Console.WriteLine($"{order.OrderID}, shipped in October 2021");
            }
            Console.WriteLine();
            Console.WriteLine("Query 4: All orders shipped to customers in the USA");
            List<Order> list4 = orders.Where(x => customers.SingleOrDefault(customer => customer.CustomerID == x.CustomerID && customer.Country == "USA") != null).ToList();
            foreach(Order order in list4)
                Console.WriteLine($"Order {order.OrderID}, shipped to USA");
            Console.WriteLine();
            Console.WriteLine("Query 5: All products that were ordered at least once, along with the total quantity ordered and the total revenue generated by each product");
            List<Product> list5 = products.Where(product => orderDetails.FirstOrDefault(orderDetail => orderDetail.ProductID == product.ProductID) != null).ToList();
            var list6 = list5.Select(product =>
            {
                int totalQuantity = orderDetails.Where(orderDetail => orderDetail.ProductID == product.ProductID).ToList().Sum(x => x.Quantity);
                return new
                {
                    ProductName = product.ProductName,
                    TotalQuantity = totalQuantity,
                    TotalRevenue = totalQuantity * product.UnitPrice
                };
            }).ToList();
            foreach(var product in list6)
            {
                Console.WriteLine($"Product: {product.ProductName}");
                Console.WriteLine($"Total Quantity Ordered: {product.TotalQuantity}");
                Console.WriteLine($"Total Revenue Generated: Rs. {product.TotalRevenue:F2}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Query 6: The top 5 customers by the total amount of money they have spent, along with the number of orders they have placed and the average order amount");
            Dictionary<int, decimal> productPrice = new Dictionary<int, decimal>();
            foreach (Product product in products)
            {
                productPrice.Add(product.ProductID, product.UnitPrice);
            }
            var list7 = customers.Select(customer =>
            {
                HashSet<int> orderIds = new HashSet<int>();
                foreach(Order order in orders)
                {
                    if (order.CustomerID == customer.CustomerID)
                    {
                        orderIds.Add(order.OrderID);
                    }
                }
                decimal totalSpend = 0;
                foreach(OrderDetail orderDetail in orderDetails)
                {
                    if(orderIds.Contains(orderDetail.OrderID))
                    {
                        totalSpend += orderDetail.Quantity * productPrice[orderDetail.ProductID] * (1 - orderDetail.Discount);
                    }
                }
                return new
                {
                    CustomerName = customer.FirstName + " " + customer.LastName,
                    TotalSpend = totalSpend,
                    NumberOfOrders = orderIds.Count,
                    AverageSpendPerOrder = totalSpend / orderIds.Count
                };
            }).ToList();
            list7 = list7.OrderByDescending(x => x.TotalSpend).ToList();
            for (int i = 0; i < 5; ++i)
            {
                var custInfo = list7[i];
                Console.WriteLine($"{custInfo.CustomerName}: Total Amount Spent: Rs. {custInfo.TotalSpend:F2}, Number of Orders: {custInfo.NumberOfOrders}, Average Order Amount: Rs. {custInfo.AverageSpendPerOrder:F2}");
            }
            Console.WriteLine();
            Dictionary<int, int> productSoldCount = new Dictionary<int, int>();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                if(productSoldCount.ContainsKey(orderDetail.ProductID))
                {
                    productSoldCount[orderDetail.ProductID] += orderDetail.Quantity;
                }
                else
                {
                    productSoldCount[orderDetail.ProductID] = orderDetail.Quantity;
                }
            }
            int maxSoldCount = 0, maxSoldProductId = 0;
            foreach (KeyValuePair<int, int> pair in productSoldCount)
            {
                if (pair.Value > maxSoldCount)
                {
                    maxSoldCount = pair.Value; 
                    maxSoldProductId = pair.Key;
                }
            }
            Product mostSoldProduct = products.Single(product => product.ProductID == maxSoldProductId);
            Console.WriteLine("Query 7: The most popular product by the number of times it has been ordered");
            Console.WriteLine($"The most popular product is {mostSoldProduct.ProductName}, which has been ordered {maxSoldCount} times.");
        }

    }
}
