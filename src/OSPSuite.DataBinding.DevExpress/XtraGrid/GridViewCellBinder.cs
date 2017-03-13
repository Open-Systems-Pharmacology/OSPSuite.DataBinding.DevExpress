using System.Reflection;
using DevExpress.XtraGrid.Columns;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public class GridViewCellBinder<TObjectType, TPropertyType> : CellBinder<TObjectType, TPropertyType>
   {
      private readonly GridViewBinder<TObjectType> _gridViewBinder;
      private readonly GridColumn _column;
      private readonly int _dataSourceIndex;

      public GridViewCellBinder(PropertyInfo propertyInfo, GridViewBinder<TObjectType> gridViewBinder, GridColumn column, int dataSourceIndex) : base(propertyInfo, gridViewBinder)
      {
         _gridViewBinder = gridViewBinder;
         _column = column;
         _dataSourceIndex = dataSourceIndex;
      }

      public override void SetValueToCell(TPropertyType value)
      {
         _gridViewBinder.GridView.SetRowCellValue(getRowHandle, _column, value);
      }

      private int getRowHandle => _gridViewBinder.GridView.GetRowHandle(_dataSourceIndex);
   }
}