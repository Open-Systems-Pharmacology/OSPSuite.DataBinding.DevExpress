using DevExpress.Utils;
using OSPSuite.Utility.Extensions;
using OSPSuite.Utility.Format;

namespace OSPSuite.DataBinding.DevExpress.Extensions
{
   public static class FormatInfoExtensions
   {
      public static void AddDefaultFormattingFor<TPropertyType>(this FormatInfo formatInfo)
      {
         if (!typeof(TPropertyType).IsNumeric()) return;
         var numericFormatter = new NumericFormatter<TPropertyType>(NumericFormatterOptions.Instance);
         formatInfo.FormatType = FormatType.Custom;
         formatInfo.Format = new DxFormatterProvider<TPropertyType>(numericFormatter);
      }
   }
}