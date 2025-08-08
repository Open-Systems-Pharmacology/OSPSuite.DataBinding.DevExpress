using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors.DXErrorProvider;
using OSPSuite.Utility.Reflection;
using OSPSuite.Utility.Validation;
using OSPSuite.Utility.Extensions;

namespace OSPSuite.DataBinding.DevExpress.Starter;

public class AnImplementation : Notifier, IAnInterface
{
   private string _firstName;
   public double? NullableValue { get; set; }
   public bool BoolValue { get; set; }
   public Color MyColor { get; set; }
   public Color? MyNullableColor { get; set; }

   public IEnumerable<IAnInterface> Children
   {
      get { return _children; }
   }

   public double PercentValue { get; set; }

   public void AddChild(IAnInterface child)
   {
      _children.Add(child);
   }

   public void InternalValidate()
   {
      OnChanged();
   }

   public AnImplementation()
   {
      ValueFromList = "value2";
      _children = new List<IAnInterface>();
   }

   #region IAnInterface Members

   public string FirstName
   {
      get { return _firstName; }
      set
      {
         _firstName = value;
         OnPropertyChanged(() => FirstName);
      }
   }

   private double _value;

   public double Value
   {
      get { return _value; }
      set
      {
         _value = value;
         OnPropertyChanged(() => Value);
      }
   }

   public IEnumerable<string> Log { get; set; }

   public int IntValue { get; set; }
   private string _lastName;
   private readonly List<IAnInterface> _children;

   public string LastName
   {
      get { return _lastName; }
      set
      {
         _lastName = value;
         OnPropertyChanged(() => LastName);
      }
   }

   public IAnInterface Child { get; set; }
   public string ReadOnlyProp { get; private set; }
   private string _valueFromList;

   public string ValueFromList
   {
      get { return _valueFromList; }
      set
      {
         _valueFromList = value;
         OnPropertyChanged(() => ValueFromList);
      }
   }

   public IEnumerable<string> ListOfValues
   {
      get { return new List<string> { "value1", "value2", "value3" }; }
   }

   public IEnumerable<string> ListOfDisplayValues
   {
      get { return new List<string> { "DisplayValue1", "DisplayValue2", "DisplayValue3" }; }
   }

   public IBusinessRuleSet Rules
   {
      get { return AllRules.Default; }
   }

   #endregion

   public event EventHandler FirstNameChanged = delegate { };

   public override string ToString()
   {
      return FirstName + LastName;
   }

   #region Nested type: AllRules

   public static class AllRules
   {
      public static IBusinessRule FirstNameNotEmpty
      {
         get
         {
            return CreateRule.For<IAnInterface>()
               .Property(p => p.FirstName)
               .WithRule((p, value) => !value.IsNullOrEmpty())
               .WithError("FirstName is required");
         }
      }

      public static IBusinessRule FirstNameLenghtSmallerThan15
      {
         get
         {
            return CreateRule.For<IAnInterface>()
               .Property(p => p.FirstName)
               .WithRule((p, value) => value.IsNullOrEmpty() || value.Length <= 15)
               .WithError("FirstName length should be smaller than 15");
         }
      }

      public static IBusinessRule ValueSmallerThan100
      {
         get
         {
            return CreateRule.For<IAnInterface>()
               .Property(p => p.Value)
               .WithRule((p, value) => value <= 100)
               .WithError("Value smaller than 100");
         }
      }

      public static IBusinessRuleSet Default
      {
         get { return new BusinessRuleSet(FirstNameNotEmpty, FirstNameLenghtSmallerThan15, ValueSmallerThan100); }
      }
   }

   #endregion

   public void GetPropertyError(string propertyName, ErrorInfo info)
   {
      var error = this.Validate(propertyName);
      if (error.IsEmpty) return;
      info.ErrorText = error.Message;
      info.ErrorType = ErrorType.Critical;
   }

   public void GetError(ErrorInfo info)
   {
      var error = this.Validate();
      if (error.IsEmpty) return;
      info.ErrorText = error.Message;
      info.ErrorType = ErrorType.Critical;
   }
}