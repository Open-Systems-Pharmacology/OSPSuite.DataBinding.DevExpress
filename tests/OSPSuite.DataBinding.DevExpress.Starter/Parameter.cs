using System.Collections.Generic;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public class Parameter
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public IList<double> ListOfDouble { get; set; }
    }
}