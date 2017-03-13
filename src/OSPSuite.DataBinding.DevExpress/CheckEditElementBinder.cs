using System.Windows.Forms;
using DevExpress.XtraEditors;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class CheckEditElementBinder<TObjectType> : ElementBinder<TObjectType, bool>
   {
      private readonly CheckEdit _checkEdit;

      public CheckEditElementBinder(IPropertyBinderNotifier<TObjectType, bool> propertyBinder, CheckEdit checkEdit) : base(propertyBinder)
      {
         _checkEdit = checkEdit;
         _checkEdit.EditValueChanged += (o, e) => ValueInControlChanging();
         _checkEdit.CheckedChanged += (o, e) => ValueInControlChanged();
      }

      public override bool GetValueFromControl()
      {
         return _checkEdit.Checked;
      }

      public override void SetValueToControl(bool value)
      {
         _checkEdit.Checked = value;
      }

      public override Control Control => _checkEdit;

      public CheckEditElementBinder<TObjectType> WithCaption(string caption)
      {
         _checkEdit.Text = caption;
         return this;
      }
   }
}