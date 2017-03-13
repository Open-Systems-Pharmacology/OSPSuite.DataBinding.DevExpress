using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using OSPSuite.BDDHelper;
using OSPSuite.BDDHelper.Extensions;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Tests
{
   public class When_an_unbound_column_binder_is_created : ContextSpecification<IGridViewBoundColumn<IAnInterface>>
   {
      private GridViewBinder<IAnInterface> _parentBinder;
      private GridView _gridView;

      protected override void Context()
      {
         _gridView = new GridViewForSpecs();
         _parentBinder = new GridViewBinder<IAnInterface>(_gridView);

         var propertyInfo = typeof(IAnInterface).GetProperty("FirstName");
         sut = new GridViewBoundColumn<IAnInterface, string>(_parentBinder, propertyInfo);
      }

      [Observation]
      public void the_underlying_column_should_have_been_initialized()
      {
         sut.XtraColumn.ShouldNotBeNull();
      }

      [Observation]
      public void the_underlying_column_should_be_visible()
      {
         sut.XtraColumn.Visible.ShouldBeTrue();
      }

      [Observation]
      public void the_field_name_should_not_be_equal_to_the_bound_property_name()
      {
         sut.XtraColumn.FieldName.Equals("FirstName").ShouldBeFalse();
      }

      [Observation]
      public void the_underlying_column_type_should_be_set_to_the_correct_type()
      {
         sut.XtraColumn.UnboundType.ShouldBeEqualTo(UnboundColumnType.String);
      }
   }

  
}