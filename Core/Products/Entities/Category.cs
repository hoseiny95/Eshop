using System;
using System.Collections.Generic;

namespace App.Domain.Core.Products.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public bool? HasProducts { get; set; }

    public virtual ICollection<CustomAttributeTemplate> CustomAttributeTemplates { get; set; } = new List<CustomAttributeTemplate>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
