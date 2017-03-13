using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress
{
   public class CellProperties<TObjectType>
   {
      private readonly IColumn<TObjectType> _column;

      public CellProperties(IColumn<TObjectType> column, TObjectType sourceObject)
      {
         _column = column;
         Source = sourceObject;
      }

      public bool HasInvalidHandles()
      {
         if (_column == null || Source == null)
            return true;

         if (boundColumn == null)
            return false;

         return !boundColumn.HasSource(Source);
      }

      public INotification ValidateValue(object valueToValidate)
      {
         if (validatableColumn == null)
            return new Notification();

         return validatableColumn.Validate(Source, valueToValidate);
      }

      public object GetValue()
      {
         return boundColumn?.GetValueFromSource(Source);
      }

      public void SetValue(object value)
      {
         boundColumn?.SetValueToSource(Source, value);
      }

      private IBoundColumn<TObjectType> boundColumn => _column as IBoundColumn<TObjectType>;

      private IValidatableColumn<TObjectType> validatableColumn => _column as IValidatableColumn<TObjectType>;

      public TObjectType Source { get; }

      public string DisplayText(string originalText)
      {
         if (HasInvalidHandles()) return originalText;
         var displayText = _column.GetDisplayValueFromSource(Source);
         return string.IsNullOrEmpty(displayText) ? originalText : displayText;
      }

      public RepositoryItem Repository()
      {
         return _column.RepositoryItemFor(Source);
      }

      public void ConfigureActiveEditor(BaseEdit activeEditor)
      {
         _column.ConfigureActiveEditor(activeEditor, Source);
      }

      public RepositoryItem EditRepository()
      {
         return _column.EditRepositoryItemFor(Source);
      }

      public void NotifyValueChanged(object oldValue, object newValue)
      {
         var autoBindColumn = _column as IAutoBindColumn<TObjectType>;
         autoBindColumn?.NotifyValueChanged(Source, oldValue, newValue);
      }
   }
}