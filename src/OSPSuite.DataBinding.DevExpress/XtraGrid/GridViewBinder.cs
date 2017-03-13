using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using OSPSuite.Utility.Collections;
using OSPSuite.Utility.Extensions;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public class GridViewBinder<T> : IGridViewBinder
   {
      /// <summary>
      ///    The actual grid view the control is binding to.
      /// </summary>
      public GridView GridView { get; private set; }

      private IEnumerable<T> _objectsToBindTo;
      private readonly ICache<string, IBoundColumn<T>> _boundColumns;
      private readonly ICache<string, IColumn<T>> _unboundColumns;
      public bool IsLatched { get; set; }
      public event Action Changed = delegate { };

      public BindingMode BindingMode { get; set; }

      /// <summary>
      ///    The ValidationMode value determines how the binder will react to error notification
      ///    Default value is
      ///    <value>ValidationMode.LeavingCell</value>
      /// </summary>
      public ValidationMode ValidationMode { get; set; }

      //member is only used to speed up access to member from index
      private IList<T> _objectsToBindToList;
      private readonly IValidationEngine _validationEngine;

      public GridViewBinder(GridView gridView)
      {
         GridView = gridView;
         GridView.CustomRowCellEdit += showCustomCellContent;
         GridView.CustomRowCellEditForEditing += showCustomCellEditForEditing;
         GridView.ShownEditor += beforeShowingEditor;
         GridView.ValidatingEditor += onValidatingEditor;
         GridView.ValidateRow += onValidatingRow;
         GridView.CustomUnboundColumnData += onCustomUnboundColumnData;
         GridView.CustomColumnDisplayText += onCustomColumnDisplayText;
         GridView.CellValueChanged += onCellValueChanged;
         GridView.InvalidRowException += (o, e) => { e.ExceptionMode = ExceptionMode.NoAction; };
         BindingMode = BindingMode.TwoWay;
         ValidationMode = ValidationMode.LeavingCell;
         _boundColumns = new Cache<string, IBoundColumn<T>>(col => col.ColumnName, s => null);
         _unboundColumns = new Cache<string, IColumn<T>>(col => col.ColumnName, s => null);

         _validationEngine = new ValidationEngine();
      }

      private void registerColumn(IColumn<T> column)
      {
         column.OnChanged += source => notifyOnChangedEvent();
         var boundColumn = column as IBoundColumn<T>;
         if (boundColumn != null)
            _boundColumns.Add(boundColumn);
         else
            _unboundColumns.Add(column);
      }

      private IColumn<T> getColumnByName(string columnName)
      {
         return _boundColumns[columnName] ?? _unboundColumns[columnName];
      }

      /// <summary>
      ///    Resets grid view with all orignal values of the source list when BindToSource was called
      /// </summary>
      public void Reset()
      {
         //First reset all values and then notify change
         this.DoWithinLatch(() => _boundColumns.Each(element => element.Reset()));
         notifyOnChangedEvent();
      }

      /// <summary>
      ///    Refreshes the binder to reflect the changes made to the date source.
      ///    Each cell will be updated according to the actual content of the data source.
      ///    However, changes in the data source length (add or remove from items) will not be taken into accounts.
      ///    Please use the Rebind method instead.
      /// </summary>
      public void Update()
      {
         this.DoWithinLatch(() => _boundColumns.Each(element => element.Update()));
         notifyOnChangedEvent();
      }

      private void notifyOnChangedEvent()
      {
         this.DoWithinLatch(Changed);
      }

      private void beforeShowingEditor(object sender, EventArgs e)
      {
         var cell = RetrieveActiveCell();
         if (cell.HasInvalidHandles()) return;

         cell.ConfigureActiveEditor(activeEditor);
      }

      private void onValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
      {
         if (!dataAvailable()) return;
         if (ValidationMode == ValidationMode.LeavingRow) return;

         var cell = RetrieveActiveCell();
         if (cell.HasInvalidHandles()) return;

         var notification = cell.ValidateValue(e.Value);

         if (!notification.HasError()) return;

         e.ErrorText = notification.ErrorNotification;
         e.Valid = false;
      }

      /// <summary>
      ///    Binds the screen to the given source collection
      /// </summary>
      public void BindToSource(IEnumerable<T> objectsToBindTo)
      {
         RemoveCollectionChangedHandler();

         _objectsToBindTo = objectsToBindTo;

         _objectsToBindToList = objectsToBindTo.IsAnImplementationOf<IList<T>>()
            ? objectsToBindTo.DowncastTo<IList<T>>()
            : _objectsToBindTo.ToList();

         _boundColumns.Each(item => item.DowncastTo<IGridViewBoundColumn<T>>().BindTo(_objectsToBindTo));

         setDataSourceInGridControl();

         AddCollectionChangedHandler();
      }

      /// <summary>
      ///    Returns the source enumeration that was use for binding
      /// </summary>
      public IEnumerable<T> Source => _objectsToBindTo;

      public string ErrorMessage => ErrorMessages.ToString("\n");

      private void setDataSourceInGridControl()
      {
         //the view is not the main view, we do not want to reset the datasource
         if (!viewIsMainView()) return;
         GridView.GridControl.DataSource = _objectsToBindToList;
      }

      private bool viewIsMainView()
      {
         var gridControl = GridView?.GridControl;

         if (gridControl == null) return false;
         return gridControl.MainView == GridView;
      }

      /// <summary>
      ///    Adds one column to the grid that will be managed by the grid view binder.
      /// </summary>
      public void AddColumn(IGridViewColumn<T> column)
      {
         registerColumn(column);
      }

      /// <summary>
      ///    Returns the object from the enumeration source that has the focus on the grid
      /// </summary>
      public T FocusedElement => ElementAt(GridView.FocusedRowHandle);

      /// <summary>
      ///    Returns the element from the enumeration source for which the row handle is equal to
      ///    <paramref name="rowHandle" />
      /// </summary>
      /// <param name="rowHandle">The row handle retrieved from the grid. DO NOT use data source index </param>
      public T ElementAt(int rowHandle)
      {
         return SourceElementAt(GridView.GetDataSourceRowIndex(rowHandle));
      }

      /// <summary>
      ///    Returns the element from the enumeration source that may be located under the mouse cursor
      /// </summary>
      /// <param name="controlMousePosition">The current position of the mouse</param>
      public T ElementAt(Point controlMousePosition)
      {
         var hi = GridView.CalcHitInfo(controlMousePosition);
         return hi.InDataRow ? ElementAt(hi.RowHandle) : default(T);
      }

      /// <summary>
      ///    Returns the element from the enumeration source that should receive the tool tip
      /// </summary>
      /// <param name="e">Tool tip controller event argument for which an element should be retrieved</param>
      public T ElementAt(ToolTipControllerGetActiveObjectInfoEventArgs e)
      {
         if (e.SelectedControl != GridView.GridControl)
            return default(T);

         return ElementAt(e.ControlMousePosition);
      }

      /// <summary>
      ///    Returns the element from the enumeration source at the position
      ///    <para>dataSourceIndex</para>
      /// </summary>
      /// <remarks>
      ///    DO NOT use the rowHandle from the grid. If only the the rowhandle is available, please use ElementAt
      /// </remarks>
      /// <param name="dataSourceIndex">The data source index</param>
      public T SourceElementAt(int dataSourceIndex)
      {
         if (!dataSourceIndexIsValid(dataSourceIndex))
            return default(T);

         return _objectsToBindToList[dataSourceIndex];
      }

      /// <summary>
      ///    Returns the row handle for the row bound to the given <para>boundObject</para>
      /// </summary>
      public int RowHandleFor(T boundObject)
      {
         var dataSourceIndex = _objectsToBindToList.IndexOf(boundObject);
         if (dataSourceIndex < 0) return -1;
         return GridView.GetRowHandle(dataSourceIndex);
      }

      private void onCustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
      {
         if (!dataAvailable(e.ListSourceRowIndex)) return;
         //we do not use the row handle here because of a possible problem with DevExpress control. See note
         var cell = retrieveCellFromSourceIndex(e.Column.Name, e.ListSourceRowIndex);
         e.DisplayText = cell.DisplayText(e.DisplayText);
      }

      private void onCustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
      {
         //Event is sometimes called event if data source is set to nothing.
         //These check insure that we are not firing events when calling dispose 
         //or if data source was deleted externaly
         if (!dataAvailable(e.ListSourceRowIndex)) return;

         //we do not use the row handle here because of a possible problem with DevExpress control. See note
         var cell = retrieveCellFromSourceIndex(e.Column.Name, e.ListSourceRowIndex);

         if (cell.HasInvalidHandles()) return;

         if (e.IsGetData)
         {
            e.Value = cell.GetValue();
            return;
         }
         if (e.IsSetData)
         {
            cell.SetValue(e.Value);
         }

         //NOTE FROM DEVEXPRESS
         //Do not use methods provided by a View object (for instance, GetRowCellValue, SetRowCellValue, etc.) 
         //to get/set cell values in the CustomUnboundColumnData event. These methods take row handles as parameters. 
         //However, the CustomUnboundColumnData event may be called when a View object has not been initialized.
         //In this instance, row handles are not initialized properly. Calling these methods may also result in recursive calls to the event. 
      }

      private void onCellValueChanged(object sender, CellValueChangedEventArgs e)
      {
         if (!dataAvailable()) return;
         if (GridView.ActiveEditor == null) return;

         var cell = retrieveCellFromRowHandle(e.Column.Name, e.RowHandle);
         if (cell.HasInvalidHandles()) return;

         cell.NotifyValueChanged(GridView.ActiveEditor.OldEditValue, GridView.ActiveEditor.EditValue);
      }

      private void onValidatingRow(object sender, ValidateRowEventArgs e)
      {
         if (!dataAvailable()) return;
         if (ValidationMode == ValidationMode.LeavingCell) return;

         //notify error for all validatable columns, either bound or not
         foreach (var columnBinder in allValidatableColumns())
         {
            var cell = retrieveCellFromRowHandle(columnBinder.ColumnName, e.RowHandle);
            if (cell.HasInvalidHandles()) continue;
            var notification = columnBinder.Validate(cell.Source);
            if (notification.HasError()) e.Valid = false;
            GridView.SetColumnError(xtraColumnFor(columnBinder), notification.ErrorNotification);
         }
      }

      private IEnumerable<IValidatableColumn<T>> allValidatableColumns()
      {
         var boundValidatable = from boundColumn in _boundColumns
            select boundColumn as IValidatableColumn<T>;

         var unboundValidatable = from unboundColumn in _unboundColumns
            let validableColumn = unboundColumn as IValidatableColumn<T>
            where validableColumn != null
            select validableColumn;

         return boundValidatable.Union(unboundValidatable);
      }

      private GridColumn xtraColumnFor(IColumn column)
      {
         return column.DowncastTo<IGridViewColumn>().XtraColumn;
      }

      private void showCustomCellContent(object sender, CustomRowCellEditEventArgs e)
      {
         var cell = retrieveCellFromRowHandle(e.Column.Name, e.RowHandle);
         if (cell.HasInvalidHandles()) return;

         e.RepositoryItem = cell.Repository();
      }

      private void showCustomCellEditForEditing(object sendter, CustomRowCellEditEventArgs e)
      {
         var cell = retrieveCellFromRowHandle(e.Column.Name, e.RowHandle);
         if (cell.HasInvalidHandles()) return;

         e.RepositoryItem = cell.EditRepository();
      }

      public bool HasError
      {
         get
         {
            if (_objectsToBindTo == null) return false;

            var allValidatables = from boundObject in _objectsToBindTo
               let validatable = boundObject as IValidatable
               where validatable != null
               select validatable;

            return allValidatables.Any(x => x.IsValid() == false);
         }
      }

      public IEnumerable<string> ErrorMessages
      {
         get
         {
            if (_objectsToBindTo == null)
               return Enumerable.Empty<string>();

            return from boundObject in _objectsToBindTo
               let validatable = boundObject as IValidatable
               where validatable != null
               where !validatable.IsValid()
               select notificationFor(validatable).ErrorNotification;
         }
      }

      private INotification notificationFor(IValidatable validatable)
      {
         try
         {
            return _validationEngine.Validate(validatable);
         }
         catch (Exception e)
         {
            return new Notification(e.Message);
         }
      }

      private CellProperties<T> RetrieveActiveCell()
      {
         return retrieveCellFromRowHandle(GridView.FocusedColumn.Name, GridView.FocusedRowHandle);
      }

      private CellProperties<T> retrieveCellFromRowHandle(string columnName, int rowHandle)
      {
         return retrieveCellFromSourceIndex(columnName, GridView.GetDataSourceRowIndex(rowHandle));
      }

      private CellProperties<T> retrieveCellFromSourceIndex(string columnName, int dataSourceIndex)
      {
         return new CellProperties<T>(getColumnByName(columnName), SourceElementAt(dataSourceIndex));
      }

      #region Collection Changed Event

      private void rebindOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {
         Rebind();
      }

      private void RemoveCollectionChangedHandler()
      {
         var notifyCollection = _objectsToBindTo as INotifyCollectionChanged;
         if (notifyCollection != null)
            notifyCollection.CollectionChanged -= rebindOnCollectionChanged;
      }

      private void AddCollectionChangedHandler()
      {
         var notifyCollection = _objectsToBindTo as INotifyCollectionChanged;
         if (notifyCollection != null)
            notifyCollection.CollectionChanged += rebindOnCollectionChanged;
      }

      #endregion

      public void DeleteBinding()
      {
         if (viewIsMainView())
            GridView.GridControl.DataSource = null;

         _boundColumns.Each(col => col.DeleteBinding());
         RemoveCollectionChangedHandler();

         _objectsToBindTo = null;
         _objectsToBindToList = null;
      }

      /// <summary>
      ///    Rebinds to the provided data source to reflect the changes made.
      ///    This function should be called for example when the length of the data source changed.
      /// </summary>
      public void Rebind()
      {
         if (_objectsToBindTo == null) return;
         this.DoWithinLatch(
            () =>
            {
               BindToSource(_objectsToBindTo);
               GridView?.RefreshData();
            });

         notifyOnChangedEvent();
      }

      private bool dataAvailable()
      {
         if (GridView == null) return false;
         return GridView.DataSource != null;
      }

      private bool dataAvailable(int listSourceIndex)
      {
         return dataAvailable() && dataSourceIndexIsValid(listSourceIndex);
      }

      private bool dataSourceIndexIsValid(int dataSourceIndex)
      {
         return _objectsToBindToList != null && dataSourceIndex >= 0 && dataSourceIndex < _objectsToBindToList.Count;
      }

      private BaseEdit activeEditor => GridView.ActiveEditor;

      protected virtual void Cleanup()
      {
         DeleteBinding();
         _boundColumns.Clear();
         _unboundColumns.Clear();
         Changed = delegate { };

         if (GridView == null) return;
         GridView.CustomRowCellEdit -= showCustomCellContent;
         GridView.ShownEditor -= beforeShowingEditor;
         GridView.ValidatingEditor -= onValidatingEditor;
         GridView.ValidateRow -= onValidatingRow;
         GridView.CustomUnboundColumnData -= onCustomUnboundColumnData;
         GridView.CustomColumnDisplayText -= onCustomColumnDisplayText;
         GridView = null;
      }

      #region Disposable properties

      private bool _disposed;

      public void Dispose()
      {
         if (_disposed) return;

         Cleanup();
         GC.SuppressFinalize(this);
         _disposed = true;
      }

      ~GridViewBinder()
      {
         Cleanup();
      }

      #endregion
   }
}