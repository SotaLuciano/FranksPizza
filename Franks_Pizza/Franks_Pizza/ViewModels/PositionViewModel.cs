using Franks_Pizza.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Franks_Pizza.Models
{
    public class PositionViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int OnePrice { get; set; }
        public int Price { get { return OnePrice * Count; } }
        public string Url { get; set; }
        public string Composition { get; set; }

        public PositionViewModel() { }

        public PositionViewModel(Position position)
        {
            Name = position.Name;
            Description = position.Description;
            OnePrice = position.OnePrice;
            Count = position.Count;
            Url = position.Url;
            Composition = position.Composition;
        }

    }
}
