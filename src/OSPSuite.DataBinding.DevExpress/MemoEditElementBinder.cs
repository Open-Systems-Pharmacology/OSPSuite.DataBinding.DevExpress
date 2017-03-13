using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class MemoEditElementBinder<TObjectType> : ElementBinder<TObjectType, IEnumerable<string>>
   {
      private readonly MemoEdit _memoEdit;

      public MemoEditElementBinder(IPropertyBinderNotifier<TObjectType, IEnumerable<string>> propertyBinder, MemoEdit memoEdit) : base(propertyBinder)
      {
         _memoEdit = memoEdit;
         _memoEdit.EditValueChanged += (o, e) => ValueInControlChanging();
         _memoEdit.Validating += (o, e) => ValueInControlChanged();
      }

      public override IEnumerable<string> GetValueFromControl()
      {
         return _memoEdit.Lines;
      }

      public override void SetValueToControl(IEnumerable<string> value)
      {
         _memoEdit.Lines = value.ToArray();
      }

      public override Control Control => _memoEdit;
   }
}