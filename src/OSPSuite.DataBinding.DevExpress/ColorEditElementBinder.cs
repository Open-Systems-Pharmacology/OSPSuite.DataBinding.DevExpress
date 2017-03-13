using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public class ColorEditElementBinder<TypeToBindTo> : ElementBinder<TypeToBindTo, Color>
   {
      private readonly ColorEdit _colorEdit;

      public ColorEditElementBinder(IPropertyBinderNotifier<TypeToBindTo, Color> propertyBinder, ColorEdit colorEdit)
         : base(propertyBinder)
      {
         _colorEdit = colorEdit;
         _colorEdit.ColorChanged += (o, e) => ValueInControlChanged();
      }

      public override Color GetValueFromControl()
      {
         return _colorEdit.Color;
      }

      public override void SetValueToControl(Color value)
      {
         _colorEdit.Color = value;
      }

      public override Control Control => _colorEdit;
   }
}