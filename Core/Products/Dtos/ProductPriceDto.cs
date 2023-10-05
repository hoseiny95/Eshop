using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class ProductPriceInputDto
    {
        public int? ProductId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? Price { get; set; }
    }

    public class ProductPriceOutputDto
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public int? Price { get; set; }
    }

    //public record PDto(int id, int price);
}
