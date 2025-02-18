using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inv.Entity;

namespace inv.Contract;
public interface IInventoryManager
{
    void AddProduct(Product product);
    void RemoveProduct(uint productId);
    void UpdateProduct(uint productId, uint newQuantity);
    void ListProduct();
    decimal GetTotalValue();
}
