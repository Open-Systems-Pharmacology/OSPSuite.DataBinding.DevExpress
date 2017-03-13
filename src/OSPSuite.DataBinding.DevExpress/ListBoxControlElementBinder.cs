using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OSPSuite.Utility.Extensions;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class ListBoxControlElementBinder<TObjectType, TPropertyType> : ListElementBinder<TObjectType, TPropertyType>
   {
      private ListBoxControl _listBoxControl;

      public ListBoxControlElementBinder(IPropertyBinderNotifier<TObjectType, TPropertyType> propertyBinder, ListBoxControl listBoxControl) : base(propertyBinder)
      {
         _listBoxControl = listBoxControl;
      }

      public override Control Control => _listBoxControl;

      public override TPropertyType GetValueFromControl()
      {
         return ValueFromIndex(_listBoxControl.SelectedIndex);
      }

      public override void SetValueToControl(TPropertyType value)
      {
         _listBoxControl.SelectedIndex = IndexFromValue(value);
      }

      protected override void FillWith(IEnumerable<TPropertyType> listOfValues, IEnumerable<string> listOfDisplayValues)
      {
         _listBoxControl.SelectedValueChanged -= SelectedValueChanged;
         _listBoxControl.SelectedItem = null;

         _listBoxControl.SuspendLayout();
         _listBoxControl.Items.Clear();
         listOfDisplayValues.Each(AddItem);
         _listBoxControl.ResumeLayout();
         _listBoxControl.SelectedValueChanged += SelectedValueChanged;
      }

      protected virtual void AddItem(string displayValue)
      {
         _listBoxControl.Items.Add(displayValue);
      }

      protected void SelectedValueChanged(object sender, EventArgs e)
      {
         //Editor is readonly=> throw both event at once
         ValueInControlChanging();
         ValueInControlChanged();
      }

      protected override void Cleanup()
      {
         try
         {
            if (_listBoxControl == null) return;
            _listBoxControl.SelectedValueChanged -= SelectedValueChanged;
            _listBoxControl = null;
         }
         finally
         {
            base.Cleanup();
         }
      }
   }
}