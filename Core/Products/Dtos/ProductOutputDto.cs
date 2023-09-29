using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductOutputDto
    {
        public int? CategoryId { get; set; }

        public string? Title { get; set; }

        public int CalculatedQty { get; set; }
    }
}
