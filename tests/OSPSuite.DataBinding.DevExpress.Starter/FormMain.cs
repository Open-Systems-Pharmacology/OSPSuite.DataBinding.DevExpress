using System;
using System.Windows.Forms;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnDynamicRepository_Click(object sender, EventArgs e)
        {
            new FormDynamicRepository().ShowDialog();
        }

        private void btnEnduranceTest_Click(object sender, EventArgs e)
        {
            new FormEnduranceTest().ShowDialog();
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            new FormNotification().ShowDialog();
        }

        private void btnRebindToDataSource_Click(object sender, EventArgs e)
        {
            new FormRebindToDataSource().ShowDialog();
        }

        private void btnSwitchDataSource_Click(object sender, EventArgs e)
        {
            new FormSwitchDataSource().ShowDialog();
        }

        private void btnMainTest_Click(object sender, EventArgs e)
        {
            new FormTest().ShowDialog();
        }

        private void btnTreeList_Click(object sender, EventArgs e)
        {
           // new FormTreeList().ShowDialog();
        }

        private void btnDispose_Click(object sender, EventArgs e)
        {
            new FormReleaseResources().ShowDialog();
        }
    }
}
