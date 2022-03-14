using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductOther : BaseEntity
    {
        public string Title { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Price { get; set; }
        public bool TopSale { get; set; }

    }
}
