using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class ProductInventoryInputDto
    {
        public int ProductId { get; set; }

        public int? OrderId { get; set; }

        public int Qty { get; set; }

        public bool IsAppend { get; set; }

        public DateTime ActionAt { get; set; }
    }
    public class ProductInventoryOutputDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int? OrderId { get; set; }

        public int Qty { get; set; }

        public bool IsAppend { get; set; }

        public DateTime ActionAt { get; set; }
    }
}
