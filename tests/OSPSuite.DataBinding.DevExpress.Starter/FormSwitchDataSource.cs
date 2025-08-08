using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
   public partial class FormSwitchDataSource : Form
   {
      private readonly GridViewBinder<IAnInterface> _gridBinder;
      private readonly List<IAnInterface> _source1;
      private readonly List<IAnInterface> _source2;

      public FormSwitchDataSource()
      {
         InitializeComponent();
         _gridBinder = new GridViewBinder<IAnInterface>(gridView);

         _source1 = new List<IAnInterface>
         {
            new AnImplementation { FirstName = "toto11", Value = 11 },
            new AnImplementation { FirstName = "toto12", Value = 12 },
            new AnImplementation { FirstName = "toto13", Value = 13 },
         };
         _source2 = new List<IAnInterface>
         {
            new AnImplementation { FirstName = "toto21", Value = 21 },
            new AnImplementation { FirstName = "toto22", Value = 22 },
            new AnImplementation { FirstName = "toto23", Value = 23 },
         };

         _gridBinder.Bind(item => item.FirstName);
         _gridBinder.Bind(item => item.Value);
      }

      private void btnBndToSource1_Click(object sender, EventArgs e)
      {
         _gridBinder.BindToSource(_source1);
      }

      private void btnBndToSource2_Click(object sender, EventArgs e)
      {
         _gridBinder.BindToSource(_source2);
      }

      private void simpleButton1_Click(object sender, EventArgs e)
      {
         _gridBinder.Dispose();
      }
   }
}