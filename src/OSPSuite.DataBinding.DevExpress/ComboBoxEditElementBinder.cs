using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using OSPSuite.Utility.Extensions;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class ComboBoxEditElementBinder<TObjectType, TPropertyType> : ListElementBinder<TObjectType, TPropertyType>
   {
      private readonly ComboBoxEdit _comboBox;

      public ComboBoxEditElementBinder(IPropertyBinderNotifier<TObjectType, TPropertyType> propertyBinder, ComboBoxEdit comboBox) : base(propertyBinder)
      {
         _comboBox = comboBox;
         _comboBox.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
      }

      public override Control Control => _comboBox;

      public override TPropertyType GetValueFromControl()
      {
         var index = _comboBox.SelectedIndex;

         //only possible if TextEditStyle was changed to Default.
         if (index < 0 && _comboBox.Properties.TextEditStyle == TextEditStyles.Standard)
            return _comboBox.Text.DowncastTo<TPropertyType>();

         return ValueFromIndex(_comboBox.SelectedIndex);
      }

      public override void SetValueToControl(TPropertyType value)
      {
         _comboBox.SelectedIndex = IndexFromValue(value);
      }

      protected override void FillWith(IEnumerable<TPropertyType> listOfValues, IEnumerable<string> listOfDisplayValues)
      {
         unhookEvents();
         
         _comboBox.SuspendLayout();

         clearComboBox();

         var valueAndDisplays = listOfValues.Select((value, index) => new {Value = value, Display = listOfDisplayValues.ElementAt(index)});

         valueAndDisplays.Each(x => AddItem(x.Value, x.Display));

         _comboBox.ResumeLayout();

         hookEvents();
      }

      private void clearComboBox()
      {
         _comboBox.SelectedItem = null;
         _comboBox.Properties.Items.Clear();
      }

      private void hookEvents()
      {
         _comboBox.SelectedValueChanged += SelectedValueChanged;
         _comboBox.EditValueChanged += EditValueChanged;
      }

      protected virtual void AddItem(TPropertyType value, string displayValue)
      {
         _comboBox.Properties.Items.Add(displayValue);
      }

      protected void SelectedValueChanged(object sender, EventArgs e)
      {
         ValueInControlChanged();
      }

      protected void EditValueChanged(object sender, EventArgs e)
      {
         ValueInControlChanging();
      }

      private void unhookEvents()
      {
         _comboBox.SelectedValueChanged -= SelectedValueChanged;
         _comboBox.EditValueChanged -= EditValueChanged;
      }
   }
}