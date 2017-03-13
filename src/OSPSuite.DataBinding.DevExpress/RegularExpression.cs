namespace OSPSuite.DataBinding.DevExpress
{
   public static class RegularExpression
   {
      // one minus at most (\-?) followed by 0 or more digits (\d)*
      private const string _regExInteger = @"\-?(\d)*";

      // 0 or more digits
      private const string _regExUnsignedInteger = @"(\d)*";

      // one minus at most (\-?) followed by zero or more digits (\d)* then followed by zero or one separator ([\.,])? and finally by more digits
      //match -123.5654 and 123.456 and 123,456 and .0002 and -4.
      private const string _regExDouble = @"\-?(\d)*([\.,])?(\d)*";

      //  one minus at most (\-?) follrwed by zero or more digits (\d)* then followed by zero or one LOCAL separator ([\R.])? and finally by more digits
      private const string _regExDoubleLocalSeparator = @"\-?(\d)*(\R.)?(\d)*";

      //match -123.5654e4546 and 123.456E45646 and 132654E-1.546
      private static readonly string _regExNumericDoubleScientific = $@"{_regExDouble}(e|E){_regExInteger}";

      /// <summary>
      /// Regular expression matching a double or float value. (also works with scientific notation)
      /// </summary>
      public static readonly string Numeric = $"({_regExDouble})|{_regExNumericDoubleScientific}";

      /// <summary>
      /// Regular expression matching a double or float value. Only the local decimal separator is allowed. No scientific notation allowed
      /// </summary>
      public static readonly string NumericLocalSeparator = _regExDoubleLocalSeparator;

      /// <summary>
      /// Regular expression maching an integer value
      /// </summary>
      /// <remarks>
      /// number of type 1e3 are not seen as integer. int.tryparse returns false
      ///</remarks>
      public static readonly string Integer = _regExInteger;

      /// <summary>
      /// Regular expression maching an unsigned integer value
      /// </summary>
      public static readonly string UnsignedInteger = _regExUnsignedInteger;
   }
}