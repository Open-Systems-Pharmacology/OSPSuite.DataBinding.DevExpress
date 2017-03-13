using DevExpress.XtraEditors;
using OSPSuite.DataBinding.Controls;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
    public class LabelControlBinder<TObjectType, TPropertyType> : LabelBinderBase<TObjectType, TPropertyType, LabelControl>
    {
        public LabelControlBinder(IPropertyBinderNotifier<TObjectType, TPropertyType> propertyBinder, LabelControl label) : base(propertyBinder, label)
        {
        }
    }
}