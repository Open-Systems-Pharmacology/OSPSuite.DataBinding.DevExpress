using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public interface IGridViewColumn : IXtraColumn<GridColumn>
   {
      FilterPopupMode FilterPopupMode { get; set; }
   }

   public interface IGridViewColumn<TObjectType> : IColumn<TObjectType>, IGridViewColumn
   {
   }

   public abstract class GridViewColumnBase<TObjectType> : Column<GridColumn, TObjectType>, IGridViewColumn<TObjectType>
   {
      protected override RepositoryItem DefaultRepositoryItem
      {
         get { return XtraColumn.RealColumnEdit; }
      }

      public override bool ReadOnly
      {
         get { return XtraColumn.OptionsColumn.ReadOnly; }

         set
         {
            XtraColumn.OptionsColumn.AllowEdit = !value;
            XtraColumn.OptionsColumn.ReadOnly = value;
            XtraColumn.OptionsColumn.AllowFocus = !value;
         }
      }

      public override bool Visible
      {
         get { return XtraColumn.Visible; }
         set { XtraColumn.Visible = value; }
      }

      public override string ColumnName
      {
         get { return XtraColumn.Name; }
      }

      public override string Caption
      {
         get { return XtraColumn.Caption; }
         set { XtraColumn.Caption = value; }
      }

      public override int Width
      {
         set { XtraColumn.Width = value; }
         get { return XtraColumn.Width; }
      }

      public override int FixedWidth
      {
         set
         {
            Width = value;
            XtraColumn.OptionsColumn.FixedWidth = true;
         }
      }

      public FilterPopupMode FilterPopupMode
      {
         get { return XtraColumn.OptionsFilter.FilterPopupMode; }
         set { XtraColumn.OptionsFilter.FilterPopupMode = value; }
      }
   }

   public class GridViewColumn<TObjectType> : GridViewColumnBase<TObjectType>
   {
      public GridViewColumn(GridViewBinder<TObjectType> parentBinder) : this(parentBinder, new GridColumnCreator())
      {
      }

      public GridViewColumn(GridViewBinder<TObjectType> parentBinder, IGridColumnCreator columnCreator)
      {
         XtraColumn = columnCreator.CreateFor<TObjectType>(parentBinder.GridView);
      }

      public override string GetDisplayValueFromSource(TObjectType sourceObject)
      {
         //no special display so far
         return string.Empty;
      }
   }
}