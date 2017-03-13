using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using OSPSuite.Utility.Format;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress
{
   public interface IColumn
   {
      string ColumnName { get; }
      string Caption { get; set; }
      bool ReadOnly { get; set; }
      bool Visible { get; set; }
      int FixedWidth { set; }
      int Width { get; set; }
   }

   public interface IXtraColumn<TXtraColumn> : IColumn
   {
      TXtraColumn XtraColumn { get; }
   }

   public interface IColumn<TObjectType> : IColumn
   {
      IRepositoryConfigurator<TObjectType> RepositoryConfigurator { get; set; }
      RepositoryItem RepositoryItemFor(TObjectType sourceObject);
      void ConfigureActiveEditor(BaseEdit activeEditor, TObjectType sourceObject);
      RepositoryItem EditRepositoryItemFor(TObjectType sourceObject);
      string GetDisplayValueFromSource(TObjectType sourceObject);

      /// <summary>
      ///    Notify that a value in the column for the bound object was changed. This event is fired
      ///    after the OnValueSet event
      /// </summary>
      event Action<TObjectType> OnChanged;
   }

   public interface IColumn<TObjectType, TPropertyType> : IColumn<TObjectType>
   {
      Func<TObjectType, IFormatter<TPropertyType>> Formatter { get; set; }

      /// <summary>
      ///    Action to perform when a value is set into a column. Event is raised only if validation
      ///    was successful.
      /// </summary>
      event Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> OnValueSet;
   }

   public interface IValidatableColumn<TObjectType> : IColumn<TObjectType>
   {
      string PropertyName { get; }
      INotification Validate(TObjectType sourceObject, object value);
      INotification Validate(TObjectType sourceObject);
   }

   public interface IAutoBindColumn<TObjectType> : IValidatableColumn<TObjectType>
   {
      void NotifyValueChanged(TObjectType sourceObject, object oldValue, object newValue);
   }

   public interface IBoundColumn : IColumn
   {
      void DeleteBinding();
   }

   public interface IBoundColumn<TObjectType> : IValidatableColumn<TObjectType>, IBoundColumn
   {
      void SetValueToSource(TObjectType sourceObject, object value);
      object GetValueFromSource(TObjectType sourceObject);
      void Reset();
      void Update();
      bool HasSource(TObjectType sourceObject);
   }

   public interface IBoundColumn<TObjectType, TPropertyType> : IBoundColumn<TObjectType>, IColumn<TObjectType, TPropertyType>
   {
   }

   public abstract class Column<XtraColumnType, TObjectType> : IColumn<TObjectType>, IXtraColumn<XtraColumnType>
   {
      protected Column()
      {
         RepositoryConfigurator = new RepositoryConfigurator<TObjectType>();
         RepositoryConfigurator.RepositoryProvider = source => DefaultRepositoryItem;
      }

      protected abstract RepositoryItem DefaultRepositoryItem { get; }
      public event Action<TObjectType> OnChanged = delegate { };

      public IRepositoryConfigurator<TObjectType> RepositoryConfigurator { get; set; }

      public virtual RepositoryItem RepositoryItemFor(TObjectType sourceObject)
      {
         return RepositoryConfigurator.RepositoryFor(sourceObject);
      }

      public virtual void ConfigureActiveEditor(BaseEdit activeEditor, TObjectType sourceObject)
      {
         RepositoryConfigurator.ConfigureEditor(activeEditor, sourceObject);
      }

      public virtual RepositoryItem EditRepositoryItemFor(TObjectType sourceObject)
      {
         return RepositoryConfigurator.EditRepositoryFor(sourceObject);
      }

      public abstract string GetDisplayValueFromSource(TObjectType sourceObject);

      public abstract string ColumnName { get; }
      public abstract string Caption { get; set; }
      public abstract bool ReadOnly { get; set; }
      public abstract bool Visible { get; set; }
      public abstract int FixedWidth { set; }
      public abstract int Width { get; set; }
      public XtraColumnType XtraColumn { get; protected set; }

      protected void OnNotifyChanged(TObjectType typeToBindTo)
      {
         OnChanged(typeToBindTo);
      }
   }
}