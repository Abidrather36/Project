using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CreativeWebApp.RRModel
{

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string UserName { get; set; } = null!;
    }
}

