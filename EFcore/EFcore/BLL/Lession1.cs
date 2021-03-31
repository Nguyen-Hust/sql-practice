using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.BLL
{
    public class CustomerAndQuantity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Quantity { get; set; }
    }
    public class CategoryAndQuantity
    {
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductAndQuantity
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
    public class Lession1
    {
        private BikeStoreDbContext context;
        public Lession1(BikeStoreDbContext _context) => this.context = _context;
        public void ShowCustomers()
        {
            var table = context.Customers.Join(context.Orders, customer => customer.customer_id, order => order.customer_id,
                    (customer, order) => new {
                        CutomerId = customer.customer_id,
                        FirstName = customer.first_name,
                        LastName = customer.last_name,
                        OrderId = order.order_id
                    })
                    .Join(context.OrderItems, order => order.OrderId, item => item.order_id,
                    (customer, item) => new {
                        CustomerId = customer.CutomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Quantity = item.quantity
                    }).ToArray();
            Dictionary<int, CustomerAndQuantity> result = new Dictionary<int, CustomerAndQuantity>();
            foreach (var item in table)
            {
                if (result.ContainsKey(item.CustomerId))
                {
                    result[item.CustomerId].Quantity += item.Quantity;
                }
                else
                {
                    CustomerAndQuantity customer = new CustomerAndQuantity();
                    customer.FirstName = item.FirstName;
                    customer.LastName = item.LastName;
                    customer.Quantity = item.Quantity;
                    result.Add(item.CustomerId, customer);
                }
            }
            result = result.OrderByDescending(t => t.Value.Quantity).ToDictionary(t => t.Key, t => t.Value);
            Console.WriteLine("CustomerId\tFirstName\tLastName\tQuantity");
            foreach (KeyValuePair<int, CustomerAndQuantity> item in result)
            {
                Console.WriteLine($"{item.Key}\t{item.Value.FirstName}\t{item.Value.LastName}\t{item.Value.Quantity}");
            }
        }
        public void ShowCategory()
        {
            var table = context.Products.Join(context.Categories, product => product.category_id, category => category.category_id,
                    (product, category) => new {
                        CategoryId = category.category_id,
                        CategoryName = category.category_name,
                        ProductId = product.product_id
                    })
                    .Join(context.OrderItems, product => product.ProductId, item => item.product_id,
                    (category, item) => new {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Quantity = item.quantity
                    }).ToArray();
            Dictionary<int, CategoryAndQuantity> result = new Dictionary<int, CategoryAndQuantity>();
            foreach (var item in table)
            {
                if (result.ContainsKey(item.CategoryId))
                {
                    result[item.CategoryId].Quantity += item.Quantity;
                }
                else
                {
                    CategoryAndQuantity customer = new CategoryAndQuantity();
                    customer.CategoryName = item.CategoryName;
                    customer.Quantity = item.Quantity;
                    result.Add(item.CategoryId, customer);
                }
            }
            result = result.OrderByDescending(t => t.Value.Quantity).ToDictionary(t => t.Key, t => t.Value);
            Console.WriteLine("CustomerId\tCategoryName\tQuantity");
            foreach (KeyValuePair<int, CategoryAndQuantity> item in result)
            {
                Console.WriteLine($"{item.Key}\t{item.Value.CategoryName}\t{item.Value.Quantity}");
            }
        }
        public void ShowProduct()
        {
            var table = context.Products.Join(context.OrderItems, product => product.product_id, item => item.product_id,
                    (product, item) => new
                    {
                        ProductId = product.product_id,
                        ProductName = product.product_name,
                        Quantity = item.quantity
                    }).ToArray();
            Dictionary<int, ProductAndQuantity> result = new Dictionary<int, ProductAndQuantity>();
            foreach (var item in table)
            {
                if (result.ContainsKey(item.ProductId))
                {
                    result[item.ProductId].Quantity += item.Quantity; 
                }
                else
                {
                    ProductAndQuantity product = new ProductAndQuantity();
                    product.ProductName = item.ProductName;
                    product.Quantity = item.Quantity;
                    result.Add(item.ProductId, product);
                }
            }
            result = result.OrderByDescending(p => p.Value.Quantity).ToDictionary(t => t.Key, t => t.Value);
            Console.WriteLine("ProductId\tProductName\tQuantity");
            foreach (KeyValuePair<int, ProductAndQuantity> item in result)
            {
                Console.WriteLine($"{item.Key}\t{item.Value.ProductName}\t{item.Value.Quantity}");
            }
        }
        public void ShowProductOfStore()
        {
            var table = context.Stocks.Join(context.Stores, stock => stock.store_id, store => store.store_id,
                    (stock, store) => new {
                        StoreName = store.store_name,
                        ProductId = stock.product_id
                    })
                    .Join(context.Products, stock => stock.ProductId, product => product.product_id,
                    (store, product) => new {
                        StoreName = store.StoreName,
                        ProductName = product.product_name,
                    }).ToArray();
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
            foreach (var item in table)
            {
                if (result.ContainsKey(item.StoreName))
                {
                    if(!result[item.StoreName].Contains(item.ProductName))
                        result[item.StoreName].Add(item.ProductName);
                }
                else
                {
                    List<string> products = new List<string>();
                    products.Add(item.ProductName);
                    result.Add(item.StoreName, products);
                }
            }
            Console.WriteLine("StoreName\tProductName");
            foreach (KeyValuePair<string, List<string>> item in result)
            {
                foreach (string productName in item.Value)
                {
                    Console.WriteLine($"{item.Key}\t{productName}");
                }
            }
        }
    }
}
