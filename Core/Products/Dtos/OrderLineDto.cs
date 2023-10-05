using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class OrderLineInputDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public int ProductPriceId { get; set; }
    }


    public class OrderLineOutputDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public int ProductPriceId { get; set; }
    }

}
