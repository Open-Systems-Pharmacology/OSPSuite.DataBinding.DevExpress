using System.Collections.Generic;
using System.Drawing;
using DevExpress.XtraEditors;

namespace OSPSuite.DataBinding.DevExpress
{
   public static class ScreenToElementBinderExtensions
   {
      public static TextEditElementBinder<TObject, TProperty> To<TObject, TProperty>(this IScreenToElementBinder<TObject, TProperty> screenToElementBinder, TextEdit textbox)
      {
         var element = new TextEditElementBinder<TObject, TProperty>(screenToElementBinder.PropertyBinder, textbox);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static MemoEditElementBinder<TObject> To<TObject>(this IScreenToElementBinder<TObject, IEnumerable<string>> screenToElementBinder, MemoEdit memoEdit)
      {
         var element = new MemoEditElementBinder<TObject>(screenToElementBinder.PropertyBinder, memoEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static LabelControlBinder<TObject, TProperty> To<TObject, TProperty>(this IScreenToElementBinder<TObject, TProperty> screenToElementBinder, LabelControl label)
      {
         var element = new LabelControlBinder<TObject, TProperty>(screenToElementBinder.PropertyBinder, label);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static CheckEditElementBinder<TObject> To<TObject>(this IScreenToElementBinder<TObject, bool> screenToElementBinder, CheckEdit checkEdit)
      {
         var element = new CheckEditElementBinder<TObject>(screenToElementBinder.PropertyBinder, checkEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static ComboBoxEditElementBinder<TObject, TProperty> To<TObject, TProperty>(this IScreenToElementBinder<TObject, TProperty> screenToElementBinder,
                                                                                                         ComboBoxEdit comboBoxEdit)
      {
         var element = new ComboBoxEditElementBinder<TObject, TProperty>(screenToElementBinder.PropertyBinder, comboBoxEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }


      public static MRUEditElementBinder<TObject> To<TObject>(this IScreenToElementBinder<TObject, string> screenToElementBinder,
                                                                                                         MRUEdit mruEdit)
      {
         var element = new MRUEditElementBinder<TObject>(screenToElementBinder.PropertyBinder, mruEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static ListBoxControlElementBinder<TObject, TProperty> To<TObject, TProperty>(this IScreenToElementBinder<TObject, TProperty> screenToElementBinder,
                                                                                                           ListBoxControl listBoxControl)
      {
         var element = new ListBoxControlElementBinder<TObject, TProperty>(screenToElementBinder.PropertyBinder, listBoxControl);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static ColorEditElementBinder<TObject> To<TObject>(this IScreenToElementBinder<TObject, Color> screenToElementBinder, ColorEdit colorEdit)
      {
         var element = new ColorEditElementBinder<TObject>(screenToElementBinder.PropertyBinder, colorEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }

      public static ImageComboBoxEditElementBinder<TObject, TProperty> To<TObject, TProperty>(this IScreenToElementBinder<TObject, TProperty> screenToElementBinder,
                                                                                                              ImageComboBoxEdit imageComboBoxEdit)
      {
         var element = new ImageComboBoxEditElementBinder<TObject, TProperty>(screenToElementBinder.PropertyBinder, imageComboBoxEdit);
         screenToElementBinder.ScreenBinder.AddElement(element);
         return element;
      }
   }
}