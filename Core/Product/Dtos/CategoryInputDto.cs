using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class CategoryInputDto
    {
        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public bool? HasProducts { get; set; }
    }
}
