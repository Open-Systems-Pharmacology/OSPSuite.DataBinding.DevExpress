using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using FakeItEasy;
using NUnit.Framework;
using OSPSuite.BDDHelper;
using OSPSuite.BDDHelper.Extensions;
using OSPSuite.Utility.Collections;
using OSPSuite.DataBinding.DevExpress.XtraGrid;
using OSPSuite.Utility.Extensions;

namespace OSPSuite.DataBinding.DevExpress.Tests
{
   public abstract class concern_for_GridViewBinder : ContextSpecification<GridViewBinder<IAnInterface>>
   {
      protected IList<IAnInterface> _list;
      protected GridControl _grid;
      protected GridViewForSpecs _gridView;
      protected IAnInterface _anImplementation1;
      protected IAnInterface _anImplementation2;
      protected IAnInterface _anImplementation3;

      protected override void Context()
      {
         _anImplementation1 = new AnImplementation {FirstName = "Joe", LastName = "Black"};
         _anImplementation2 = new AnImplementation {FirstName = "Jean", LastName = "Moulin"};
         _anImplementation3 = new AnImplementation {FirstName = "Robes", LastName = "Pierre"};

         _list = new List<IAnInterface> {_anImplementation1, _anImplementation2, _anImplementation3};

         _grid = new GridControl();
         _gridView = new GridViewForSpecs();
         _grid.MainView = _gridView;
         _grid.ViewCollection.Add(_gridView);
         _gridView.GridControl = _grid;
         sut = new GridViewBinder<IAnInterface>(_gridView);
      }
   }

   public class When_binding_to_a_property_using_the_dynamic_data_binding : concern_for_GridViewBinder
   {
      protected override void Because()
      {
         sut.Bind(item => item.FirstName);
         sut.Bind(item => item.LastName);
      }

      [Test]
      public void should_add_a_column_for_each_bound_property()
      {
         _gridView.Columns.Count.ShouldBeEqualTo(2);
      }
   }

   public class When_binding_to_the_source : concern_for_GridViewBinder
   {
      protected IGridViewBoundColumn<IAnInterface> _col1;
      protected IGridViewBoundColumn<IAnInterface> _col2;

      protected override void Context()
      {
         base.Context();
         _col1 = A.Fake<IGridViewBoundColumn<IAnInterface>>();
         _col2 = A.Fake<IGridViewBoundColumn<IAnInterface>>();
         A.CallTo(() => _col1.XtraColumn).Returns(new GridColumn());
         A.CallTo(() => _col2.XtraColumn).Returns(new GridColumn());
         A.CallTo(() => _col1.ColumnName).Returns("col1");
         A.CallTo(() => _col2.ColumnName).Returns("col2");
         A.CallTo(() => _col1.HasSource(A<IAnInterface>._)).Returns(true);
         A.CallTo(() => _col2.HasSource(A<IAnInterface>._)).Returns(true);
         sut.AddColumn(_col1);
         sut.AddColumn(_col2);
      }

      protected override void Because()
      {
         sut.BindToSource(_list);
      }

      [Observation]
      public void should_reutrn_the_binding_list_when_ask_for_the_source()
      {
         sut.Source.ShouldBeEqualTo(_list);
      }

      [Observation]
      public void should_set_the_data_source_into_the_grid_control()
      {
         _grid.DataSource.ShouldBeEqualTo(_list);
      }

      [Observation]
      public void should_iterate_through_all_the_columns_and_leverage_the_binding()
      {
         A.CallTo(() => _col1.BindTo(_list)).MustHaveHappened();
         A.CallTo(() => _col2.BindTo(_list)).MustHaveHappened();
      }
   }

   public class When_binding_to_a_source_implementing_the_notify_collection_changed_interface : concern_for_GridViewBinder
   {
      private INotifyList<IAnInterface> _richList;
      private bool _notifyRegistered;

      protected override void Context()
      {
         base.Context();
         _richList = A.Fake<INotifyList<IAnInterface>>();
         _list = _richList;
         sut.Changed += () => { _notifyRegistered = true; };
         sut.BindToSource(_list);
      }

      protected override void Because()
      {
         _richList.CollectionChanged += Raise.FreeForm.With(_richList, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
      }

      [Observation]
      public void should_register_to_the_collection_change_event()
      {
         _notifyRegistered.ShouldBeTrue();
      }
   }

   public class When_binding_to_a_source_implementing_the_notify_collection_changed_interface_notifying_a_change : concern_for_GridViewBinder
   {
      private INotifyList<IAnInterface> _richList;

      protected override void Context()
      {
         base.Context();
         _richList = new NotifyList<IAnInterface>();
         sut.BindToSource(_richList);
      }

      protected override void Because()
      {
         _richList.Add(new AnImplementation());
      }

      [Observation]
      public void should_rebind_to_the_data_source_any_time_that_the_source_notifies_a_change()
      {
         _gridView.RefreshDataCalled.ShouldBeTrue();
      }
   }

   public class When_disposing_the_grid_view_binder : concern_for_GridViewBinder
   {
      private WeakReference _wrMember;
      private WeakReference _wrList;

      protected override void Context()
      {
         base.Context();
         sut.Bind(item => item.FirstName);
         sut.Bind(item => item.LastName);
         sut.Bind(item => item.Value);
         sut.BindToSource(_list);
         _wrMember = new WeakReference(_anImplementation1);
         _wrList = new WeakReference(_list);
      }

      protected override void Because()
      {
         _list = null;
         _anImplementation1 = null;
         sut.Dispose();
         GC.Collect();
      }

      [Observation]
      public void the_bound_objects_should_not_be_held_in_memory()
      {
         _wrMember.IsAlive.ShouldBeFalse();
      }

      [Observation]
      public void the_bound_list_should_not_be_hold_in_memory()
      {
         _wrList.IsAlive.ShouldBeFalse();
      }
   }

   public class When_deleting_the_binding_to_the_source : concern_for_GridViewBinder
   {
      private WeakReference _wrMember;
      private WeakReference _wrList;

      protected override void Context()
      {
         base.Context();
         sut.Bind(item => item.FirstName);
         sut.Bind(item => item.LastName);
         sut.Bind(item => item.Value);
         sut.BindToSource(_list);
         _wrMember = new WeakReference(_anImplementation1);
         _wrList = new WeakReference(_list);
      }

      protected override void Because()
      {
         _list = null;
         _anImplementation1 = null;
         sut.DeleteBinding();
         GC.Collect();
      }

      [Observation]
      public void the_bound_objects_should_not_be_hold_in_memory_()
      {
         _wrMember.IsAlive.ShouldBeFalse();
      }

      [Observation]
      public void the_bound_list_should_not_be_held_in_memory()
      {
         _wrList.IsAlive.ShouldBeFalse();
      }
   }

   public class When_the_grid_view_binder_is_asked_if_it_has_some_error : concern_for_GridViewBinder
   {
      protected override void Context()
      {
         base.Context();
         _list = new List<IAnInterface> {_anImplementation1};
         sut.BindToSource(_list);
      }

      [Observation]
      public void should_return_false_if_all_bound_objects_are_valid()
      {
         sut.HasError.ShouldBeFalse();
      }

      [Observation]
      public void should_return_true_if_one_bound_element_has_error()
      {
         _anImplementation1.FirstName = string.Empty;
         sut.HasError.ShouldBeTrue();
      }
   }

   public class When_the_grid_view_binder_is_asked_if_it_has_some_error_before_it_was_bound_to_any_object : concern_for_GridViewBinder
   {
      protected override void Context()
      {
         base.Context();
         _list = new List<IAnInterface> {_anImplementation1};
      }

      [Observation]
      public void should_return_false_()
      {
         sut.HasError.ShouldBeFalse();
      }
   }

   public class When_the_grid_view_binder_is_binding_to_a_view_that_is_not_the_main_view_of_in_the_hierarchy : concern_for_GridViewBinder
   {
      protected override void Context()
      {
         _grid = new GridControl();
         _gridView = new GridViewForSpecs();
         _grid.MainView = new GridView();
         _grid.ViewCollection.Add(_gridView);
         _gridView.GridControl = _grid;
         sut = new GridViewBinder<IAnInterface>(_gridView);
         _list = new List<IAnInterface> {_anImplementation1};
      }

      protected override void Because()
      {
         sut.BindToSource(_list);
      }

      [Observation]
      public void should_not_set_the_data_source_in_the_parent_grid()
      {
         _grid.DataSource.ShouldBeNull();
      }
   }

   public class When_the_grid_view_binder_is_binding_to_a_view_that_is_the_main_view_of_in_the_hierarchy : concern_for_GridViewBinder
   {
      protected override void Context()
      {
         _anImplementation1 = new AnImplementation {FirstName = "Joe", LastName = "Black"};
         _grid = new GridControl();
         _gridView = new GridViewForSpecs();
         _grid.MainView = _gridView;
         _grid.ViewCollection.Add(_gridView);
         _gridView.GridControl = _grid;
         sut = new GridViewBinder<IAnInterface>(_gridView);
         _list = new List<IAnInterface> {_anImplementation1};
      }

      protected override void Because()
      {
         sut.BindToSource(_list);
      }

      [Observation]
      public void should_set_the_data_source_in_the_parent_grid()
      {
         _grid.DataSource.ShouldNotBeNull();
      }
   }
}