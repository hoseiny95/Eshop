using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Dtos
{
    public class CustomAttributeTemplateInputDto
    {
        public int CategoryId { get; set; }

        public string AttributeTitle { get; set; } = null!;
    }
    public class CustomAttributeTemplateOutputDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string AttributeTitle { get; set; } = null!;
    }
}
