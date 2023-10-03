using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? Title { get; set; }

    public int CalculatedQty { get; set; }
    public bool IsRemoved { get; set; } = false;

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual ICollection<ProductCustomAttribute> ProductCustomAttributes { get; set; } = new List<ProductCustomAttribute>();

    public virtual ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

    public virtual ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
}
