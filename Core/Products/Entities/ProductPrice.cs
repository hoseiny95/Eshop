using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class ProductPrice
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? Price { get; set; }

    public virtual Product? Product { get; set; }
}
