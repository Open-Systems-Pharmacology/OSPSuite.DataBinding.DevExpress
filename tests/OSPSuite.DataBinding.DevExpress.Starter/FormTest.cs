using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using OSPSuite.Utility.Format;
using OSPSuite.DataBinding.DevExpress.Tests;
using OSPSuite.DataBinding.DevExpress.XtraGrid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
   public partial class FormTest : Form
   {
      private readonly ScreenBinder<IAnInterface> _screenBinder;
      private readonly IAnInterface _source;
      private readonly GridViewBinder<IAnInterface> _gridBinder;
      private readonly ScreenBinder<IAnInterface> _screenBinder2;
      private readonly RepositoryItemButtonEdit _repositoryItemButton;

      public FormTest()
      {
         InitializeComponent();
         _screenBinder = new ScreenBinder<IAnInterface>();
         _screenBinder2 = new ScreenBinder<IAnInterface>();
         _gridBinder = new GridViewBinder<IAnInterface>(gridView1);
         InitBinding();

         _repositoryItemButton = new RepositoryItemButtonEdit();
         _repositoryItemButton.Buttons.Add(new EditorButton());

         _repositoryItemButton.AutoHeight = false;

         _repositoryItemButton.Buttons.Add(new EditorButton(ButtonPredefines.Glyph, "AAAA", -1, true, true, false, HorzAlignment.Center, null));

         _source = new AnImplementation {FirstName = "Joe", LastName = "Black", Value = 10};
         _source.Log = new List<string> {"Line1", "Line2"};
         _screenBinder.BindToSource(_source);
         _screenBinder2.BindToSource(_source);

         var obj2 = new AnImplementation {FirstName = "Jean", LastName = "Moulin", Value = 20};
         var obj3 = new AnImplementation {FirstName = "Robes", LastName = "Pierre", Value = 30};

         var sourceList = new List<IAnInterface> {_source, obj2, obj3};
         _gridBinder.BindToSource(GetSource(sourceList));

         var edit0 = gridView1.Columns[0].RealColumnEdit;
         var edit1 = gridView1.Columns[1].RealColumnEdit;
         var edit2 = gridView1.Columns[2].RealColumnEdit;
         var edit3 = gridView1.Columns[3].RealColumnEdit;

         bool equal = false;
         if (ReferenceEquals(edit0, edit1))
            equal = true;

         if (ReferenceEquals(edit0, edit2))
            equal = true;

         if (ReferenceEquals(edit0, edit3))
            equal = true;

         if (ReferenceEquals(edit1, edit2))
            equal = true;

         if (ReferenceEquals(edit1, edit3))
            equal = true;

         if (ReferenceEquals(edit2, edit3))
            equal = true;
      }

      private IEnumerable<IAnInterface> GetSource(IEnumerable<IAnInterface> enumerable)
      {
         foreach (var anInterface in enumerable)
         {
            yield return anInterface;
         }
      }

      private void InitBinding()
      {
         _screenBinder.Bind(item => item.FirstName).To(textEdit);

         _screenBinder.Bind(item => item.LastName).To(textEditLastName);

         _screenBinder.Bind(item => item.Value).To(textEditDouble);
         _screenBinder.Bind(item => item.Log).To(memoEdit);

         _screenBinder.Bind(item => item.NullableValue).To(textNullableEdit);
         _screenBinder.Bind(item => item.MyColor).To(colorEdit);
         _screenBinder.Bind(item => item.FirstName).To(mruEdit1);
         _screenBinder.Bind(item => item.ValueFromList).To(comboBoxEdit1).WithValues(item => item.ListOfValues).AndDisplays(item => item.ListOfDisplayValues);
         _screenBinder.Bind(item => item.ValueFromList).To(listBoxControl).WithValues(item => item.ListOfValues).AndDisplays(item => item.ListOfDisplayValues);

         _screenBinder.Bind(iten => iten.BoolValue).To(chkEdit).WithCaption("one caption").OnValueSet += OnBoolValueSet;

         _screenBinder.Bind(item => item.ValueFromList).To(imageComboBoxEdit1)
            .WithImages(ImagesFor)
            .WithValues(item => item.ListOfValues)
            .AndDisplays(item => item.ListOfDisplayValues);

         _screenBinder.OnValidationError += OnValidationError;
         _screenBinder.OnValidated += OnValidated;

         _screenBinder2.Bind(item => item.LastName).To(anotherTextBox);

         _gridBinder.Bind(item => item.FirstName).AsReadOnly();
         _gridBinder.Bind(item => item.LastName).OnValueSet += OnLastNameSet;
         _gridBinder.Bind(item => item.NullableValue).WithCaption("My Nullable Set");
         _gridBinder.Bind(item => item.Value)
            .WithCaption("My Value Set");

         _gridBinder.Bind(item => item.Value)
            .WithRepository(MyBarRepository)
            .WithEditRepository(MyRepoForDouble)
            .WithCaption("My Value Bar").OnValueSet += OnValueSet;

         _gridBinder.AutoBind(item => item.Value)
            .WithRepository(MyRepoForDouble)
            .WithCaption("My Value Bar");

         _gridBinder.AutoBind(item => item.IntValue)
            .WithCaption("Int Value")
            .WithFilterPopupMode(FilterPopupMode.Default)
            .WithOnValueSet(AutoBindOnValueSet);

         _gridBinder.AddUnboundColumn()
            .WithCaption("A great button")
            .WithRepository(RepositoryItemButton)
            .WithShowButton(ShowButtonModeEnum.ShowAlways);

         _gridBinder.Changed += GridBinderChanged;
         _screenBinder.Changed += GridBinderChanged;
         _screenBinder.Changing += () => AddLine("Screen Binder Changing");
         btnReset.Click += (o, e) => _gridBinder.Reset();
         btnApply.Click += (o, e) => _gridBinder.Update();
      }

      private void AutoBindOnValueSet(IAnInterface arg1, PropertyValueSetEventArgs<int> arg2)
      {
         AddLine(string.Format("Autobind value was set from : {0} to {1}", arg2.OldValue, arg2.NewValue));
      }

      private IFormatter<double> GetFormat(IAnInterface anInterface)
      {
         return new MyFormmater(anInterface);
      }

      private class MyFormmater : IFormatter<double>
      {
         private readonly IAnInterface _anInterface;

         public MyFormmater(IAnInterface anInterface)
         {
            _anInterface = anInterface;
         }

         public string Format(double valueToFormat)
         {
            return string.Format("{0} for {1}", valueToFormat, _anInterface.FirstName);
         }
      }

      private RepositoryItem MyBarRepository(IAnInterface arg)
      {
         var repositoryItem = new RepositoryItemProgressBar();
         repositoryItem.Minimum = 0;
         repositoryItem.Maximum = 100;
         return repositoryItem;
      }

      private void OnBoolValueSet(IAnInterface arg1, PropertyValueSetEventArgs<bool> arg2)
      {
         AddLine(string.Format("Boolean value was set from : {0} to {1}", arg2.OldValue ? "checked" : "unchecked", arg2.NewValue ? "checked" : "unchecked"));
      }

      private RepositoryItem RepositoryItemButton(IAnInterface arg)
      {
         return _repositoryItemButton;
      }

      private void OnLastNameSet(IAnInterface arg1, PropertyValueSetEventArgs<string> arg2)
      {
         AddLine(string.Format("Last name set: new = {0}, old = {1}", arg2.NewValue, arg1.LastName));
      }

      private int ImagesFor(string arg)
      {
         return 2;
      }

      private RepositoryItem MyRepoForDouble(IAnInterface source)
      {
         var repositoryItem = new RepositoryItemTrackBar();
         repositoryItem.TickStyle = TickStyle.TopLeft;
         repositoryItem.Minimum = 0;
         repositoryItem.Maximum = 100;
         return repositoryItem;
      }

      private void OnValueSet(IAnInterface arg1, PropertyValueSetEventArgs<double> arg)
      {
         AddLine(string.Format("Value set: new = {0}, old = {1}", arg.NewValue, arg1.Value));
      }

      private void GridBinderChanged()
      {
         AddLine("Grid Binder On Changed");
      }

      private void AddLine(string message)
      {
         rtbDump.AppendText(string.Format("{0}\n", message));
      }

      private void OnValidated(object control)
      {
         dxErrorProvider.SetError(control as Control, string.Empty);
      }

      private void OnValidationError(object control, string message)
      {
         dxErrorProvider.SetError(control as Control, message);
      }
   }
}