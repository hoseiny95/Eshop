using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Qty { get; set; }

    public int ProductPriceId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
