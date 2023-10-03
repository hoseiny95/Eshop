using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int StatusId { get; set; }

    public DateTime OrderAt { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual OrderStatus Status { get; set; } = null!;
}
