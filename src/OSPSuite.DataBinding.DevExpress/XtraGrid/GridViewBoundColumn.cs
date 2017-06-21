using System;
using System.Collections.Generic;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using OSPSuite.Utility.Collections;
using OSPSuite.Utility.Extensions;
using OSPSuite.Utility.Format;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public interface IGridViewBoundColumn : IGridViewColumn, IBoundColumn
   {
   }

   public interface IGridViewBoundColumn<TObjectType> : IGridViewBoundColumn, IGridViewColumn<TObjectType>, IBoundColumn<TObjectType>
   {
      void BindTo(IEnumerable<TObjectType> objectsToBindTo);
   }

   public interface IGridViewBoundColumn<TObjectType, TPropertyType> : IGridViewBoundColumn<TObjectType>, IBoundColumn<TObjectType, TPropertyType>
   {
   }

   public class GridViewBoundColumn<TObjectType, TPropertyType> : GridViewColumnBase<TObjectType>, IGridViewBoundColumn<TObjectType, TPropertyType>
   {
      private readonly GridViewBinder<TObjectType> _parentBinder;
      private readonly PropertyInfo _propertyInfo;
      private readonly ICache<TObjectType, ICellBinder<TObjectType, TPropertyType>> _cellBinders;
      public event Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> OnValueUpdating = delegate { };
      public event Action<TObjectType, TPropertyType> OnValueUpdated = delegate { };

      public Func<TObjectType, IFormatter<TPropertyType>> Formatter { get; set; }
      private readonly IValidationEngine _validationEngine;

      public GridViewBoundColumn(GridViewBinder<TObjectType> parentBinder, PropertyInfo propertyInfo) :
         this(parentBinder, propertyInfo, new ValidationEngine(), new GridColumnCreator())
      {
      }

      private GridViewBoundColumn(GridViewBinder<TObjectType> parentBinder, PropertyInfo propertyInfo,
                                  IValidationEngine validationEngine, IGridColumnCreator gridColumnCreator)
      {
         _parentBinder = parentBinder;
         _propertyInfo = propertyInfo;
         _validationEngine = validationEngine;

         _cellBinders = new Cache<TObjectType, ICellBinder<TObjectType, TPropertyType>>(cell => cell.Source);

         XtraColumn = gridColumnCreator.CreateFor<TPropertyType>(parentBinder.GridView);
         DefaultRepositoryItem = this.DefaultRepository();

         this.WithCaption(PropertyName);
      }
      protected override RepositoryItem DefaultRepositoryItem { get; }

      public void BindTo(IEnumerable<TObjectType> objectsToBindTo)
      {
         //Remove all cells if necessary
         DeleteBinding();
         int dataSourceIndex = 0;
         foreach (var itemToBindTo in objectsToBindTo)
         {
            AddCellBinderFor(itemToBindTo, dataSourceIndex);
            dataSourceIndex++;
         }
      }

      protected virtual ICellBinder<TObjectType, TPropertyType> AddCellBinderFor(TObjectType itemToBindTo, int dataSourceIndex)
      {
         var cellBinder = new GridViewCellBinder<TObjectType, TPropertyType>(_propertyInfo, _parentBinder, XtraColumn, dataSourceIndex);
         cellBinder.Bind(itemToBindTo);
         _cellBinders.Add(cellBinder);

         //relay the change event of one cell to the change event of the column
         cellBinder.OnValueUpdating += (o, e) => OnValueUpdating(o, e);
         cellBinder.OnValueUpdated += (o, e) => OnValueUpdated(o, e);
         cellBinder.OnChanged += OnNotifyChanged;
         return cellBinder;
      }

      public object GetValueFromSource(TObjectType sourceObject)
      {
         return _cellBinders[sourceObject].GetValueFromSource();
      }

      public override string GetDisplayValueFromSource(TObjectType sourceObject)
      {
         if (Formatter == null || Formatter(sourceObject)==null) return string.Empty;
         return Formatter(sourceObject).Format(_cellBinders[sourceObject].GetValueFromSource());
      }

      public void SetValueToSource(TObjectType sourceObject, object value)
      {
         _cellBinders[sourceObject].SetValueToSource(value.ConvertedTo<TPropertyType>());
      }

      public string PropertyName => _propertyInfo.Name;

      public INotification Validate(TObjectType sourceObject, object value)
      {
         return _validationEngine.Validate(sourceObject, PropertyName, value);
      }

      public INotification Validate(TObjectType sourceObject)
      {
         return _validationEngine.Validate(sourceObject, PropertyName);
      }

      public void Update()
      {
         _cellBinders.Each(cell => cell.Update());
      }

      public bool HasSource(TObjectType sourceObject)
      {
         return _cellBinders.Contains(sourceObject);
      }

      public void Reset()
      {
         _cellBinders.Each(cell => cell.Reset());
      }

      public void DeleteBinding()
      {
         _cellBinders.Each(cell => cell.DeleteBinding());
         _cellBinders.Clear();
      }

      public override RepositoryItem RepositoryItemFor(TObjectType sourceObject)
      {
         return base.RepositoryItemFor(sourceObject).ConfigureWith(typeof (TPropertyType));
      }

      public override RepositoryItem EditRepositoryItemFor(TObjectType sourceObject)
      {
         return base.EditRepositoryItemFor(sourceObject).ConfigureWith(typeof (TPropertyType));
      }
   }
}