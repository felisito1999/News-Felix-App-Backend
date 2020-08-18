using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsCategoryDelete { get; set; }
    }
}
