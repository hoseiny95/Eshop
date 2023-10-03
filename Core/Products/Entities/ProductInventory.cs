using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class ProductInventory
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? OrderId { get; set; }

    public int Qty { get; set; }

    public bool IsAppend { get; set; }

    public DateTime ActionAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}
