using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class CategoryOutputDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public bool? HasProducts { get; set; }
        public List<ProductOutputDto> Products { get; set; }

    }
}
