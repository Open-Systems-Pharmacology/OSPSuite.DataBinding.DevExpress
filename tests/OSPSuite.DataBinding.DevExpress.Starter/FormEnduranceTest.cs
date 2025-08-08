using OSPSuite.DataBinding.DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public partial class FormEnduranceTest : Form
    {
        private GridViewBinder<IAnInterface> _gridViewBinder;
        private IList<IAnInterface> _sourceList;

        public FormEnduranceTest()
        {
            InitializeComponent();
        }

        private void IntitalizeBinding()
        {

            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            
            if (_gridViewBinder != null)
                _gridViewBinder.Dispose();

            _gridViewBinder = null;
            _sourceList = null;

            GC.Collect();

            _sourceList = new List<IAnInterface>();
            _gridViewBinder = new GridViewBinder<IAnInterface>(gridView1);
            
       
            _gridViewBinder.Bind(item => item.FirstName); 
            _gridViewBinder.Bind(item => item.LastName); 
            _gridViewBinder.Bind(item => item.Value); 
        }

        private void btnBind_Click(object sender, System.EventArgs e)
        {
            IntitalizeBinding();
            double numOfItem;
            if(double.TryParse(tbNumOfItem.Text,out numOfItem)==false) return;

   
            for (int i = 0; i < numOfItem; i++)
            {
                _sourceList.Add(new AnImplementation{FirstName = "FirstName_"+i,LastName="LastName_"+i,Value = i});
            }

            var sw = System.Diagnostics.Stopwatch.StartNew();
            sw.Start();
            _gridViewBinder.BindToSource(_sourceList);
            sw.Stop();

            lblElaspedTime.Text = sw.Elapsed.Seconds.ToString();
        }
    }
}
