using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    public partial class FormDynamicRepository : XtraForm
    {
        private readonly GridControl gridControl = new GridControl();
        private readonly PopupContainerControl popupControl = new PopupContainerControl();
        private readonly RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit = new RepositoryItemPopupContainerEdit();
        private IList<Parameter> _listOfParameter;
        private readonly GridViewBinder<Parameter> _gridViewBinder;

        public FormDynamicRepository()
        {
            CreateData();
            InitializeComponent();
            _gridViewBinder = new GridViewBinder<Parameter>(gridView1);

            InitializeBinding();
            gridControl.ForceInitialize();
            repositoryItemPopupContainerEdit.PopupControl = popupControl;
            repositoryItemPopupContainerEdit.CloseOnOuterMouseClick = false;
            gridControl.Dock = DockStyle.Fill;
            popupControl.Controls.Add(gridControl);
        }

        private void InitializeBinding()
        {
            _gridViewBinder.Bind(param => param.Name);
            _gridViewBinder.Bind(param => param.Value)
               .WithRepository(item => repositoryItemPopupContainerEdit)
               .WithEditorConfiguration(UpdateRepository);
            _gridViewBinder.BindToSource(_listOfParameter);
        }

        private void UpdateRepository(BaseEdit editor,Parameter obj)
        {
            gridControl.DataSource = obj.ListOfDouble;
        }


        private void CreateData()
        {
            _listOfParameter = new List<Parameter>();
            _listOfParameter.Add(new Parameter {Name = "Param1", Value = 1, ListOfDouble = new List<double> {1, 11, 111}});
            _listOfParameter.Add(new Parameter {Name = "Param2", Value = 2, ListOfDouble = new List<double> {2, 22, 222}});
            _listOfParameter.Add(new Parameter {Name = "Param3", Value = 3, ListOfDouble = new List<double> {3, 33, 333}});
        }
    }
}