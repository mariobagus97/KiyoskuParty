using Intersoft.Crosslight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Core.BindingProviders
{
     public class ValidationBindingProvider : BindingProvider
    {
        public ValidationBindingProvider()
        {
            this.AddBinding("PinNumberText", BindableProperties.TextProperty, "PinNumber", BindingMode.TwoWay);
        }
    }
}
