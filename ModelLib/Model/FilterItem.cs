using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.Model
{
    public class FilterItem
    {
        private double _highQuantity;
        private double _lowQuantity;

        public FilterItem()
        {
        }

        public FilterItem(double highQuantity, double lowQuantity)
        {
            _highQuantity = highQuantity;
            _lowQuantity = lowQuantity;
        }
        public double HighQuantity
        {
            get => _highQuantity;
            set => _highQuantity = value;
        }
        public double LowQuantity
        {
            get => _lowQuantity;
            set => _lowQuantity = value;
        }

        public override string ToString()
        {
            return $"{nameof(HighQuantity)}: {HighQuantity}, {nameof(LowQuantity)}: {LowQuantity}";
        }
    }
}
