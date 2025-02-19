using inv.Entity;
using inv.Repository;

var prodManager = new InventoryManager();
var product = new Product();
uint id;

bool running = true;
while (running)
{
    Console.WriteLine("===============================================================");
    Console.WriteLine("                    Inventory Management System                ");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Remove Product");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Get list of product");
    Console.WriteLine("5. Get Invetory's products value");
    Console.WriteLine("0. Exit");
    Console.WriteLine("===============================================================");

    int crudOp = int.Parse(Console.ReadLine()!);
    switch (crudOp)
    {
        case 1:
            prodManager.AddProduct(product);
            break;
        case 2:
            prodManager.Print("Enter product id to be deleted: ");
            id = uint.Parse(Console.ReadLine()!);
            prodManager.RemoveProduct(id);
            break;
        case 3:
            try
            {
                prodManager.Print("Enter product id to be updated: ");
                id = uint.Parse(Console.ReadLine()!);
                prodManager.Print("Enter new quantity: ");
                var newQuantity = uint.Parse(Console.ReadLine()!);
                prodManager.UpdateProduct(id, newQuantity);
            }
            catch (OverflowException)
            {
                prodManager.Print("Id or quantity shoud be positive integer.");
            }
            break;
        case 4:
            prodManager.ListProduct();
            break;
        case 5:
            prodManager.Print($"Total inventoru value: Php {string.Format("{0:0.00}", prodManager.GetTotalValue())}");
            break;
        case 0:
            running = false;
            break;
        default:
            Console.WriteLine("Invalid input.");
            break;
    }
}
