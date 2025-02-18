using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using inv.Contract;
using inv.Entity;

namespace inv.Repository;
public sealed class InventoryManager : IInventoryManager
{
    // here I use a mockup like dependency injection for table products
    // then implement a repository pattern to decouple data processing
    private List<Product> _products = new List<Product>();
    private uint _id = 1;

    public void AddProduct(Product product)
    {
        // here id automatically increment to a positive integer
        // then create a new instance of product to be added on the list
        _id = product.ProductId++;
        Print("Product Name: ");
        var productName = Console.ReadLine()!;
        Print("Quantity: ");
        var quantity = uint.Parse(Console.ReadLine()!);
        Print("Price: ");
        var price = decimal.Parse(Console.ReadLine()!);
        
        // if the price is not negative or less than zero proceed, otherwise not 
        if (price > 0)
        {
            product = new Product()
            {
                ProductId = _id,
                Name = productName,
                QuantityInStock = quantity,
                Price = price,
            };
            _products.Add(product);
            Print("Added product.");
        }
        else
        {
            Print("Product should be positive integer.");
        }
    }

    // here I use lambda method to find the id then remove its all of properties content
    public void RemoveProduct(uint productId)
    {
        _products.RemoveAll(x => x.ProductId.Equals(productId));
        Print($"Deleted product: {productId}");
    }

    // same with RemoveProduct to find id 
    // then once find a newly inputed quantity will be assign
    public void UpdateProduct(uint productId, uint newQuantity)
    {
        var product = _products.Find(x => x.ProductId.Equals(productId));
        product!.QuantityInStock = newQuantity;
        Print("Updated product.");
        
    }

    // here to query all of the contents of products list
    public void ListProduct()
    {
        foreach (var product in _products)
        {
            Print($"Product id: {product.ProductId}, \tProduct Name: {product.Name}, \tAvailable in stocks: {product.QuantityInStock}, \tPrice: {product.Price}");
            Print("===============================================================");
        }
    }

    // here using lambda method to add all of the value of price multiply by number of quantity
    public decimal GetTotalValue()
    {
        return _products.Sum(x => x.Price * x.QuantityInStock);
    }

    public void Print(object value)
    {
        Console.WriteLine(value);
    }
}
