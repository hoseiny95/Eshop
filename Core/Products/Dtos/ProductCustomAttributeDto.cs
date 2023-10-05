using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class ProductCustomAttributeInputDto
    {
        public int ProductId { get; set; }

        public int AttributeId { get; set; }

        public string AttributeTitle { get; set; } = null!;

        public string AttributeValue { get; set; } = null!;
    }


    public class ProductCustomAttributeOutputDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int AttributeId { get; set; }

        public string AttributeTitle { get; set; } = null!;

        public string AttributeValue { get; set; } = null!;
    }
}
