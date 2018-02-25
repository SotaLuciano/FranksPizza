using System;
using System.Collections.Generic;
using System.Text;

namespace Franks_Pizza.Models
{
    public class Position
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int OnePrice { get; set; }
        public int Price { get { return OnePrice * Count; } }
        public string Url { get; set; }
        public string Composition { get; set; }
    }
}
