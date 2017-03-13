using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OSPSuite.Utility.Collections;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public partial class FormRebindToDataSource : Form
    {
        private readonly GridViewBinder<Parameter> _gridViewBinder;
        private readonly GridViewBinder<Parameter> _gridViewBinder2;
        private readonly IList<Parameter> _parameterList;
        private readonly INotifyCache<string,Parameter> _richDictionary;

        public FormRebindToDataSource()
        {
            InitializeComponent();
            _gridViewBinder = new GridViewBinder<Parameter>(gridView1);
            _gridViewBinder2 = new GridViewBinder<Parameter>(gridView2);
            InitializeBinding(_gridViewBinder);
            InitializeBinding(_gridViewBinder2);
            _parameterList = new List<Parameter>();
            _richDictionary = new NotifyCache<string, Parameter>();

            _gridViewBinder.BindToSource(_parameterList);
            _gridViewBinder2.BindToSource(_richDictionary);
        }

        private void InitializeBinding(GridViewBinder<Parameter> gridViewBinder)
        {
            gridViewBinder.Bind(item => item.Name);
            gridViewBinder.Bind(item => item.Value);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            _parameterList.Add(new Parameter{Name = string.Format("Parameter {0}",_parameterList.Count),Value = _parameterList.Count});
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _gridViewBinder.Rebind();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            var name = string.Format("Parameter {0}", _richDictionary.Count());
            _richDictionary.Add(name,new Parameter { Name =name, Value = _richDictionary.Count() });
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            var name = string.Format("Parameter {0}", _richDictionary.Count() - 1);
            _richDictionary.Remove(name);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _richDictionary.Clear();
        }
    }
}
