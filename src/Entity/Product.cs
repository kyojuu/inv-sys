using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inv.Entity;
public sealed class Product
{
    // here I use uint for ProductId and QuantityInStock instead of int
    // for efficiency and to ensure that all value should be non-negative type
    public uint ProductId { get; set; } = 1;
    public string Name { get; set; }
    public uint QuantityInStock { get; set; }
    public decimal Price { get; set; }
}
