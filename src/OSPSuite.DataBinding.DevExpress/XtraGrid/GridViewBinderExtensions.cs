using System;
using System.Linq.Expressions;
using OSPSuite.Utility.Reflection;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public static class GridViewBinderExtensions
   {
      /// <summary>
      /// Binds the property to the grid using the data binding features.
      /// Before setting the value, the event OnSetValue is raised allowing any listener to take over the actual set action.
      /// Error notification if available if the source implements the IValidatable interface
      /// </summary>
      public static IGridViewBoundColumn<TypeToBindTo, PropertyType> Bind<TypeToBindTo, PropertyType>
         (this GridViewBinder<TypeToBindTo> gridViewBinder, Expression<Func<TypeToBindTo, PropertyType>> propertyToBindTo)
      {
         //Resolve property info for the given expression
         var propertyInfo = new ExpressionInspectorFactory().Create<TypeToBindTo>().PropertyFor(propertyToBindTo);

         //Create a column binder and add it to the gridview binder
         var boundColumn = new GridViewBoundColumn<TypeToBindTo, PropertyType>(gridViewBinder, propertyInfo);
         gridViewBinder.AddColumn(boundColumn);
         return boundColumn;
      }

      /// <summary>
      /// Binds the property to the grid using the dev express data binding features.
      /// (i.e. Value will be set automtically into bound objects). 
      /// Error notification if available however, if the source implements the IValidatable interface
      /// or the IDxErrorInfo
      /// </summary>
      public static IGridViewAutoBindColumn<TypeToBindTo, PropertyType> AutoBind<TypeToBindTo, PropertyType>
         (this GridViewBinder<TypeToBindTo> gridViewBinder, Expression<Func<TypeToBindTo, PropertyType>> propertyToBindTo)
      {
         //Resolve property info for the given expression
         var propertyInfo = new ExpressionInspectorFactory().Create<TypeToBindTo>().PropertyFor(propertyToBindTo);

         //Create a column binder and add it to the gridview binder
         var columnBinder = new GridViewAutoBindColumn<TypeToBindTo, PropertyType>(gridViewBinder,propertyInfo);
         gridViewBinder.AddColumn(columnBinder);
         return columnBinder;
      }

      /// <summary>
      /// Adds a column to the grid that should be managed by the user
      /// </summary>
      public static IGridViewColumn<TypeToBindTo> AddUnboundColumn<TypeToBindTo>(this GridViewBinder<TypeToBindTo> gridViewBinder)
      {
         var column = new GridViewColumn<TypeToBindTo>(gridViewBinder);
         gridViewBinder.AddColumn(column);
         return column;
      }
   }
}