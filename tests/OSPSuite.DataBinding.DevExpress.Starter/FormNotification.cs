using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors;
using OSPSuite.Utility.Validation;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
   public partial class FormNotification : XtraForm
   {
      private readonly GridViewBinder<IAnInterface> _gridViewBinderLeavingRow;
      private readonly GridViewBinder<IAnInterface> _gridViewBinderLeavingCell;
      private readonly IList<IAnInterface> _source;

      public FormNotification()
      {
         InitializeComponent();
         _gridViewBinderLeavingCell = new GridViewBinder<IAnInterface>(gridView1) {ValidationMode = ValidationMode.LeavingCell};
         _gridViewBinderLeavingRow = new GridViewBinder<IAnInterface>(gridView2) {ValidationMode = ValidationMode.LeavingRow};

         _source = CreateSource();
         CreateBinding(_gridViewBinderLeavingCell);
         CreateBinding(_gridViewBinderLeavingRow);
      }

      public IList<IAnInterface> CreateSource()
      {
         var obj2 = new AnImplementation {FirstName = "", LastName = "Moulin", Value = 20};
         var obj3 = new AnImplementation {FirstName = "", LastName = "Pierre", Value = double.NaN};

         return new BindingList<IAnInterface> {obj2, obj3};
      }

      public void CreateBinding(GridViewBinder<IAnInterface> gridViewBinder)
      {
         gridViewBinder.Bind(item => item.FirstName);
         gridViewBinder.Bind(item => item.LastName);
         gridViewBinder.AutoBind(item => item.Value);
         gridViewBinder.AutoBind(item => item.FirstName);
         gridViewBinder.BindToSource(_source);
      }

      private void validateData()
      {
         foreach (var  nInfo in _source)
         {
            nInfo.Validate();
         }
      }
   }
}