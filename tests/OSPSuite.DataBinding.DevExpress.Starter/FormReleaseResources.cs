using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSPSuite.DataBinding.DevExpress.Tests;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public partial class FormReleaseResources : Form
    {
        private readonly GridViewBinder<IAnInterface> _gridBinder;

        public FormReleaseResources()
        {
            InitializeComponent();

            _gridBinder = new GridViewBinder<IAnInterface>(gridView1);
            var obj1 = new AnImplementation { FirstName = "Joe", LastName = "Black", Value = 10 };
            var obj2 = new AnImplementation { FirstName = "Jean", LastName = "Moulin", Value = 20 };
            var obj3 = new AnImplementation { FirstName = "Robes", LastName = "Pierre", Value = 30 };

            var sourceList = new List<IAnInterface> { obj1, obj2, obj3 };
            InitializeBinding();

            _gridBinder.BindToSource(sourceList);
        }

        private void InitializeBinding()
        {
            _gridBinder.Bind(item => item.FirstName).AsReadOnly();
            _gridBinder.Bind(item => item.LastName).WithOnValueUpdating(OnLastNameSet);
            _gridBinder.Bind(item => item.NullableValue).WithCaption("My Nullable Set");
            _gridBinder.Bind(item => item.Value).WithCaption("My Value Set");
            _gridBinder.Bind(item => item.Value).WithCaption("My Value Bar").OnValueUpdating += OnValueSet;

        
            _gridBinder.Changed += GridBinderChanged;

        }

        private void GridBinderChanged()
        {
                
        }

        private void OnValueSet(IAnInterface arg1, PropertyValueSetEventArgs<double> arg2)
        {
                
        }

        private void OnLastNameSet(IAnInterface arg1, PropertyValueSetEventArgs<string> arg2)
        {
            
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            _gridBinder.Dispose();
            GC.Collect();
        }
    }
}
