using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;

public partial class ProductCustomAttribute
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeTitle { get; set; } = null!;

    public string AttributeValue { get; set; } = null!;

    public virtual CustomAttributeTemplate Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
