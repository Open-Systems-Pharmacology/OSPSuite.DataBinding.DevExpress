using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using OSPSuite.Utility.Extensions;
using OSPSuite.DataBinding.Controls;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class TextEditElementBinder<TObjectType, TPropertyType> : TextBoxBinderBase<TObjectType, TPropertyType, TextEdit>
   {
      public TextEditElementBinder(IPropertyBinderNotifier<TObjectType, TPropertyType> propertyBinder, TextEdit textEdit) : base(propertyBinder, textEdit)
      {
         _textBox.EditValueChanged += (o, e) => ValueInControlChanging();
         _textBox.Validating += (o, e) => ValueInControlChanged();
         _textBox.Properties.ConfigureWith(typeof (TPropertyType));
         _textBox.CustomDisplayText += customDisplayText;
      }

      public override void SetValueToControl(TPropertyType value)
      {
         if (!typeof(TPropertyType).IsValueType && Equals(value, default(TPropertyType)))
         {
            _textBox.Text = string.Empty;
            return;
         }
         _textBox.EditValue = value;
      }

      private void customDisplayText(object sender, CustomDisplayTextEventArgs e)
      {
         if (e.Value == null) return;
         try
         {
            e.DisplayText = Formatter.Format(e.Value.ConvertedTo<TPropertyType>());
         }
         //it's ok to catch formatting exception here. Message will be displayed in the errorProvider
         catch (FormatException)
         {
            e.DisplayText = string.Empty;
         }
      }
   }
}