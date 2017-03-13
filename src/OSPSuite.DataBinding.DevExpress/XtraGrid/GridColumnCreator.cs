using System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using OSPSuite.DataBinding.DevExpress.Extensions;
using OSPSuite.DataBinding.DevExpress.Mappers;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public interface IGridColumnCreator
   {
      GridColumn CreateFor<TPropertyType>(GridView gridView);
      GridColumn CreateFor<TPropertyType>(string propertyName, GridView gridView);
   }

   public class GridColumnCreator : IGridColumnCreator
   {
      private readonly ITypeToColumnTypeMapper _columnTypeMapper;
      private readonly ITypeToHorzAlignmentMapper _horzAlignmentMapper;

      public GridColumnCreator() : this(new TypeToColumnTypeMapper(), new TypeToHorzAlignmentMapper())
      {
      }

      protected GridColumnCreator(ITypeToColumnTypeMapper columnTypeMapper, ITypeToHorzAlignmentMapper horzAlignmentMapper)
      {
         _columnTypeMapper = columnTypeMapper;
         _horzAlignmentMapper = horzAlignmentMapper;
      }

      public GridColumn CreateFor<TPropertyType>(GridView gridView)
      {
         //it is necessary to create a unique id since the grid view binds to the property name event though the unbound type 
         //is set to unbound.
         var fieldName = Guid.NewGuid().ToString();
         var column = CreateFor<TPropertyType>(fieldName, gridView);
         column.UnboundType = _columnTypeMapper.MapFrom(typeof(TPropertyType));
         column.AppearanceCell.TextOptions.HAlignment = _horzAlignmentMapper.MapFrom(typeof(TPropertyType));
         return column;
      }

      public GridColumn CreateFor<TPropertyType>(string propertyName, GridView gridView)
      {
         var column = gridView.Columns.AddField(propertyName);
         column.Name = propertyName;
         column.VisibleIndex = gridView.Columns.Count - 1;
         column.Visible = true;
         column.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
         //per default, colummns are visible in customization form
         column.OptionsColumn.ShowInCustomizationForm = true;
         column.DisplayFormat.AddDefaultFormattingFor<TPropertyType>();
         return column;
      }
   }
}