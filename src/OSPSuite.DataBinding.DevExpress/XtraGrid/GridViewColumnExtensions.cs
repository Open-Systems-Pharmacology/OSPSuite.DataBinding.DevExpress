using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using OSPSuite.Utility.Format;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public static class GridViewColumnExtensions
   {
      public static TColumn WithShowButton<TColumn>(this  TColumn column, ShowButtonModeEnum showButtonMode) where TColumn : IGridViewColumn
      {
         column.XtraColumn.ShowButtonMode = showButtonMode;
         return column;
      }

      /// <summary>
      /// Using this property, the column will be shown in the column chooser, even if the column is hidden.
      /// Per default, any hidden column does not appear in the column chooser
      /// </summary>
      /// <param name="column">The grid view column for which the property should be set</param>
      /// <param name="showColumn">If set to true, the column will be visible in column chooser</param>
      public static TColumn WithShowInColumnChooser<TColumn>(this  TColumn column,bool  showColumn) where TColumn : IGridViewColumn
      {
         column.XtraColumn.OptionsColumn.ShowInCustomizationForm = showColumn;
         return column;
      }

      /// <summary>
      /// Sets the filer popup mode for the column. Default ist CheckedList 
      /// </summary>
      public static TColumn WithFilterPopupMode<TColumn>(this TColumn column, FilterPopupMode filterPopupMode) where TColumn : IGridViewColumn
      {
         column.FilterPopupMode = filterPopupMode;
         return column;
      }

      /// <summary>
      /// Sets the tool tip for the given column
      /// </summary>
      public static TColumn WithToolTip<TColumn>(this TColumn column, string toolTip) where TColumn : IGridViewColumn
      {
         column.XtraColumn.ToolTip = toolTip;
         return column;
      }

      /// <summary>
      /// Configures the repository that will be used to display the bound properties. This will also be the default value for the edit repository
      /// if none was provided
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithRepository<TObjectType, TPropertyType>(
         this IGridViewBoundColumn<TObjectType, TPropertyType> boundColumn,
         Func<TObjectType, RepositoryItem> repositoryProvider)
      {
         boundColumn.RepositoryConfigurator.RepositoryProvider = repositoryProvider;
         return boundColumn;
      }


      /// <summary>
      /// Sets the type of the repository that will be used to edit the bound properties. To configure the settings of the editor
      /// depending on the object values, please use the editor configuration properties
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithEditRepository<TObjectType, TPropertyType>(
         this IGridViewBoundColumn<TObjectType, TPropertyType> boundColumn,
         Func<TObjectType, RepositoryItem> editRepositoryProvider)
      {
         boundColumn.RepositoryConfigurator.EditRepositoryProvider = editRepositoryProvider;
         return boundColumn;
      }

      /// <summary>
      /// Configures the active editor repository. This function will be fired just before the active editor is being shown
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithEditorConfiguration<TObjectType, TPropertyType>(
         this IGridViewBoundColumn<TObjectType, TPropertyType> column,
         Action<BaseEdit,TObjectType> activeEditorConfiguration)
      {
         column.RepositoryConfigurator.ActiveEditorConfiguration = activeEditorConfiguration;
         return column;
      }


      /// <summary>
      /// Configures the repository that will be used to display the bound properties. This will also be the default value for the edit repository
      /// if none was provided
      /// </summary>
      public static IGridViewColumn<TObjectType> WithRepository<TObjectType>(
      this IGridViewColumn<TObjectType> boundColumn,
      Func<TObjectType, RepositoryItem> repositoryProvider)
      {
         boundColumn.RepositoryConfigurator.RepositoryProvider = repositoryProvider;
         return boundColumn;
      }


      /// <summary>
      /// Sets the type of the repository that will be used to edit the bound properties. To configure the settings of the editor
      /// depending on the object values, please use the editor configuration properties
      /// </summary>
      public static IGridViewColumn<TObjectType> WithEditRepository<TObjectType>(
         this IGridViewColumn<TObjectType> boundColumn,
         Func<TObjectType, RepositoryItem> editRepositoryProvider)
      {
         boundColumn.RepositoryConfigurator.EditRepositoryProvider = editRepositoryProvider;
         return boundColumn;
      }

      /// <summary>
      /// Configures the active editor repository. This function will be fired just before the active editor is being shown
      /// </summary>
      public static IGridViewColumn<TObjectType> WithEditorConfiguration<TObjectType>(
         this IGridViewColumn<TObjectType> column,
         Action<BaseEdit, TObjectType> activeEditorConfiguration)
      {
         column.RepositoryConfigurator.ActiveEditorConfiguration = activeEditorConfiguration;
         return column;
      }

      /// <summary>
      /// Configures the repository that will be used to display the bound properties. This will also be the default value for the edit repository
      /// if none was provided
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithRepository<TObjectType, TPropertyType>(
         this IGridViewAutoBindColumn<TObjectType, TPropertyType> boundColumn,
         Func<TObjectType, RepositoryItem> repositoryProvider)
      {
         boundColumn.RepositoryConfigurator.RepositoryProvider = repositoryProvider;
         return boundColumn;
      }


      /// <summary>
      /// Sets the type of the repository that will be used to edit the bound properties. To configure the settings of the editor
      /// depending on the object values, please use the editor configuration properties
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithEditRepository<TObjectType, TPropertyType>(
         this IGridViewAutoBindColumn<TObjectType, TPropertyType> boundColumn,
         Func<TObjectType, RepositoryItem> editRepositoryProvider)
      {
         boundColumn.RepositoryConfigurator.EditRepositoryProvider = editRepositoryProvider;
         return boundColumn;
      }

      /// <summary>
      /// Configures the active editor repository. This function will be fired just before the active editor is being shown
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithEditorConfiguration<TObjectType, TPropertyType>(
         this IGridViewAutoBindColumn<TObjectType, TPropertyType> column,
         Action<BaseEdit, TObjectType> activeEditorConfiguration)
      {
         column.RepositoryConfigurator.ActiveEditorConfiguration = activeEditorConfiguration;
         return column;
      }

      /// <summary>
      /// Specifies the format that will be used to display the bound properties when the value is being displayed
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithFormat<TObjectType, TPropertyType>(this IGridViewBoundColumn<TObjectType, TPropertyType> column, IFormatter<TPropertyType> formatter)
      {
         return column.WithFormat(source => formatter);
      }

      /// <summary>
      /// Specifies the format that will be used to display the bound properties when the value is being displayed
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithFormat<TObjectType, TPropertyType>(this IGridViewBoundColumn<TObjectType, TPropertyType> column,
                                                                                                        Func<TObjectType, IFormatter<TPropertyType>> formatterProvider)
      {
         column.Formatter = formatterProvider;
         return column;
      }

      /// <summary>
      /// Specifies the format that will be used to display the bound properties when the value is being displayed
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithFormat<TObjectType, TPropertyType>(this IGridViewAutoBindColumn<TObjectType, TPropertyType> column, IFormatter<TPropertyType> formatter)
      {
         return column.WithFormat(source => formatter);
      }

      /// <summary>
      /// Specifies the format that will be used to display the bound properties when the value is being displayed
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithFormat<TObjectType, TPropertyType>(this IGridViewAutoBindColumn<TObjectType, TPropertyType> column,
                                                                                                        Func<TObjectType, IFormatter<TPropertyType>> formatterProvider)
      {
         column.Formatter = formatterProvider;
         return column;
      }

      /// <summary>
      /// Specifies the event handler that will subscribe to the OnValueSet event
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithOnValueSet<TObjectType, TPropertyType>(this IGridViewBoundColumn<TObjectType, TPropertyType> column,
                                                                                                        Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> onValueSetEventHandler)
      {
         column.OnValueSet+= onValueSetEventHandler;
         return column;
      }

      /// <summary>
      /// Specifies the event handler that will subscribe to the OnValueSet event
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithOnValueSet<TObjectType, TPropertyType>(this IGridViewAutoBindColumn<TObjectType, TPropertyType> column,
                                                                                                        Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> onValueSetEventHandler)
      {
         column.OnValueSet += onValueSetEventHandler;
         return column;
      }

      /// <summary>
      /// Specifies the event handler that will subscribe to the OnChanged event
      /// </summary>
      public static IGridViewBoundColumn<TObjectType, TPropertyType> WithOnChanged<TObjectType, TPropertyType>(this IGridViewBoundColumn<TObjectType, TPropertyType> column,
                                                                                                        Action<TObjectType> onChangedEventHandler)
      {
         column.OnChanged += onChangedEventHandler;
         return column;
      }


      /// <summary>
      /// Specifies the event handler that will subscribe to the OnChanged event
      /// </summary>
      public static IGridViewAutoBindColumn<TObjectType, TPropertyType> WithOnChanged<TObjectType, TPropertyType>(this IGridViewAutoBindColumn<TObjectType, TPropertyType> column,
                                                                                                        Action<TObjectType> onChangedEventHandler)
      {
         column.OnChanged += onChangedEventHandler;
         return column;
      }
   }
}