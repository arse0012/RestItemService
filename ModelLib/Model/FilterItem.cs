using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FilterItem
    {
        public double HighQuantity { get; set; }
        public double LowQuantity { get; set; }

        public FilterItem(double highQuantity, double lowQuantity)
        {
            HighQuantity = highQuantity;
            LowQuantity = lowQuantity;
        }

        public FilterItem()
        {
            
        }
    }
}
