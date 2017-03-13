using System;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using OSPSuite.Utility.Extensions;
using OSPSuite.Utility.Format;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public interface IGridViewAutoBindColumn<TObjectType> : IGridViewColumn<TObjectType>, IAutoBindColumn<TObjectType>
   {
   }

   public interface IGridViewAutoBindColumn<TObjectType, TPropertyType> : IGridViewAutoBindColumn<TObjectType>, IColumn<TObjectType, TPropertyType>
   {
   }

   public class GridViewAutoBindColumn<TObjectType, TPropertyType> : GridViewColumnBase<TObjectType>, IGridViewAutoBindColumn<TObjectType, TPropertyType>
   {
      private readonly PropertyInfo _propertyInfo;
      private readonly IValidationEngine _validationEngine;
      public Func<TObjectType, IFormatter<TPropertyType>> Formatter { get; set; }
      public event Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> OnValueSet = delegate { };

      public GridViewAutoBindColumn(GridViewBinder<TObjectType> parentBinder, PropertyInfo propertyInfo)
         : this(parentBinder, propertyInfo, new ValidationEngine(), new GridColumnCreator())
      {
         _propertyInfo = propertyInfo;
      }

      protected GridViewAutoBindColumn(GridViewBinder<TObjectType> parentBinder, PropertyInfo propertyInfo, IValidationEngine validationEngine, IGridColumnCreator columnCreator)
      {
         _propertyInfo = propertyInfo;
         _validationEngine = validationEngine;
         XtraColumn = columnCreator.CreateFor<TPropertyType>(PropertyName, parentBinder.GridView);
         DefaultRepositoryItem = this.DefaultRepository();
         this.WithCaption(PropertyName);
      }

      public string PropertyName => _propertyInfo.Name;

      protected override RepositoryItem DefaultRepositoryItem { get; }

      public INotification Validate(TObjectType sourceObject, object value)
      {
         return _validationEngine.Validate(sourceObject, PropertyName, value);
      }

      public INotification Validate(TObjectType sourceObject)
      {
         return _validationEngine.Validate(sourceObject, PropertyName);
      }

      public override RepositoryItem RepositoryItemFor(TObjectType sourceObject)
      {
         return base.RepositoryItemFor(sourceObject).ConfigureWith(typeof(TPropertyType));
      }

      public override RepositoryItem EditRepositoryItemFor(TObjectType sourceObject)
      {
         return base.EditRepositoryItemFor(sourceObject).ConfigureWith(typeof(TPropertyType));
      }

      public override string GetDisplayValueFromSource(TObjectType sourceObject)
      {
         if (Formatter?.Invoke(sourceObject) == null)
            return string.Empty;

         return Formatter(sourceObject).Format(_propertyInfo.GetValue(sourceObject, null).ConvertedTo<TPropertyType>());
      }

      public void NotifyValueChanged(TObjectType sourceObject, object oldValue, object newValue)
      {
         OnValueSet(sourceObject, new PropertyValueSetEventArgs<TPropertyType>(PropertyName, oldValue.ConvertedTo<TPropertyType>(), newValue.ConvertedTo<TPropertyType>()));
         OnNotifyChanged(sourceObject);
      }
   }
}