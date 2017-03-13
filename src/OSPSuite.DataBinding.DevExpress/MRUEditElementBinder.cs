using DevExpress.XtraEditors;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class MRUEditElementBinder<TObjectType> : TextEditElementBinder<TObjectType, string>
   {
      private readonly MRUEdit _mruEdit;

      public MRUEditElementBinder(IPropertyBinderNotifier<TObjectType, string> propertyBinder, MRUEdit mruEdit)
         : base(propertyBinder, mruEdit)
      {
         _mruEdit = mruEdit;
      }
   }
}