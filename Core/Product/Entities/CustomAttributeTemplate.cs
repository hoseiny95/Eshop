using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;

public partial class CustomAttributeTemplate
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductCustomAttribute> ProductCustomAttributes { get; set; } = new List<ProductCustomAttribute>();
}
