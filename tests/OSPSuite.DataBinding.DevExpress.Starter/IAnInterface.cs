using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors.DXErrorProvider;
using OSPSuite.Utility.Reflection;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress.Starter;

public interface IAnInterface : IValidatable, INotifier, IDXDataErrorInfo
{
   string FirstName { get; set; }
   string LastName { get; set; }
   IAnInterface Child { get; set; }
   string ReadOnlyProp { get; }
   string ValueFromList { get; set; }
   IEnumerable<string> ListOfValues { get; }
   IEnumerable<string> ListOfDisplayValues { get; }
   double Value { get; set; }
   IEnumerable<string> Log { get; set; }
   int IntValue { get; set; }
   double? NullableValue { get; set; }
   bool BoolValue { get; set; }

   Color MyColor { get; set; }
   Color? MyNullableColor { get; set; }

   IEnumerable<IAnInterface> Children { get; }
   double PercentValue { get; set; }

   void AddChild(IAnInterface child);
   void InternalValidate();
}