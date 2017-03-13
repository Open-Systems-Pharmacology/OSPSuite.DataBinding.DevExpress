using System;
using System.Drawing;
using DevExpress.XtraEditors.Repository;

namespace OSPSuite.DataBinding.DevExpress
{
   public static class ColumnExtensions
   {
      /// <summary>
      /// Sets the column caption
      /// </summary>
      public static T WithCaption<T>(this T column, string columnCaption) where T : IColumn
      {
         column.Caption = columnCaption;
         return column;
      }

      /// <summary>
      /// Sets the column as readonly
      /// </summary>
      public static T AsReadOnly<T>(this T column) where T : IColumn
      {
         column.ReadOnly = true;
         return column;
      }

      /// <summary>
      /// Sets the column as hidden
      /// </summary>
      public static T AsHidden<T>(this T column) where T : IColumn
      {
         column.Visible = false;
         return column;
      }

      /// <summary>
      /// Fixes the column width with the given value
      /// </summary>
      public static T WithFixedWidth<T>(this T column, int columnWidth) where T : IColumn
      {
         column.FixedWidth = columnWidth;
         return column;
      }

      /// <summary>
      /// Sets the initial column width
      /// </summary>
      public static T WithWidth<T>(this T column, int columnWidth) where T : IColumn
      {
         column.Width = columnWidth;
         return column;
      }

      public static RepositoryItem DefaultRepository<TObjectType, TPropertyType>(this IColumn<TObjectType, TPropertyType> column)
      {
         //The default editor's type depends on the column's data type. 
         //DateTime columns use the DevExpress.XtraEditors.DateEdit editor as a default. 
         //Boolean columns use DevExpress.XtraEditors.CheckEdit editors. 
         //Columns of other types use DevExpress.XtraEditors.TextEdit editors by default.

         if (typeof(TPropertyType) == typeof(DateTime))
            return new RepositoryItemDateEdit();

         if (typeof(TPropertyType) == typeof(bool))
            return new RepositoryItemCheckEdit();

         if (typeof(TPropertyType) == typeof(Color))
            return new RepositoryItemColorEdit();

         return new RepositoryItemTextEdit();

      }
   }
}