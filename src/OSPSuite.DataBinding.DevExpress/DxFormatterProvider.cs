using System;
using OSPSuite.Utility.Extensions;
using OSPSuite.Utility.Format;

namespace OSPSuite.DataBinding.DevExpress
{
   public class DxFormatterProvider<TPropertyType> : IFormatProvider, ICustomFormatter
   {
      private readonly IFormatter<TPropertyType> _formatter;

      public DxFormatterProvider(IFormatter<TPropertyType> formatter)
      {
         _formatter = formatter;
      }

      public object GetFormat(Type formatType)
      {
         return this;
      }

      /// <summary>
      /// Formats the given value (arg) according to the formatter
      /// </summary>
      public string Format(string format, object arg, IFormatProvider formatProvider)
      {
         return _formatter.Format(arg.ConvertedTo<TPropertyType>());
      }
   }

}