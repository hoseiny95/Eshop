using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class OrderOutputDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int StatusId { get; set; }

        public DateTime OrderAt { get; set; }
    }
}
