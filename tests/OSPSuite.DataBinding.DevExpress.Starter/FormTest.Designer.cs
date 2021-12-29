using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
   partial class FormTest
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
            _screenBinder.Dispose();
            _gridBinder.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
         this.dxErrorProvider = new DXErrorProvider(this.components);
         this.dxValidationProvider = new DXValidationProvider(this.components);
         this.textEdit = new TextEdit();
         this.lableText = new LabelControl();
         this.btnApply = new SimpleButton();
         this.textEditDouble = new TextEdit();
         this.textEditLastName = new TextEdit();
         this.gridControl = new GridControl();
         this.gridView1 = new GridView();
         this.anotherTextBox = new TextEdit();
         this.rtbDump = new System.Windows.Forms.RichTextBox();
         this.btnReset = new SimpleButton();
         this.comboBoxEdit1 = new ComboBoxEdit();
         this.textNullableEdit = new TextEdit();
         this.imageComboBoxEdit1 = new ImageComboBoxEdit();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.chkEdit = new CheckEdit();
         this.listBoxControl = new ListBoxControl();
         this.colorEdit = new ColorEdit();
         this.mruEdit1 = new MRUEdit();
         this.memoEdit = new MemoEdit();
         this.textEditForInt = new TextEdit();
         this.nullableColorEdit = new ColorEdit();
         ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditDouble.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.anotherTextBox.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textNullableEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxControl)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.mruEdit1.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditForInt.Properties)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.nullableColorEdit.Properties)).BeginInit();
         this.SuspendLayout();
         // 
         // dxErrorProvider
         // 
         this.dxErrorProvider.ContainerControl = this;
         // 
         // textEdit
         // 
         this.textEdit.Location = new System.Drawing.Point(157, 37);
         this.textEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.textEdit.Name = "textEdit";
         this.textEdit.Size = new System.Drawing.Size(133, 22);
         this.textEdit.TabIndex = 0;
         // 
         // lableText
         // 
         this.lableText.Location = new System.Drawing.Point(40, 46);
         this.lableText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.lableText.Name = "lableText";
         this.lableText.Size = new System.Drawing.Size(75, 16);
         this.lableText.TabIndex = 1;
         this.lableText.Text = "labelControl1";
         // 
         // btnApply
         // 
         this.btnApply.Location = new System.Drawing.Point(440, 551);
         this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.btnApply.Name = "btnApply";
         this.btnApply.Size = new System.Drawing.Size(133, 26);
         this.btnApply.TabIndex = 2;
         this.btnApply.Text = "Apply";
         // 
         // textEditDouble
         // 
         this.textEditDouble.Location = new System.Drawing.Point(441, 37);
         this.textEditDouble.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.textEditDouble.Name = "textEditDouble";
         this.textEditDouble.Size = new System.Drawing.Size(133, 22);
         this.textEditDouble.TabIndex = 5;
         // 
         // textEditLastName
         // 
         this.textEditLastName.Location = new System.Drawing.Point(300, 37);
         this.textEditLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.textEditLastName.Name = "textEditLastName";
         this.textEditLastName.Size = new System.Drawing.Size(133, 22);
         this.textEditLastName.TabIndex = 6;
         // 
         // gridControl
         // 
         this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.gridControl.Location = new System.Drawing.Point(40, 180);
         this.gridControl.MainView = this.gridView1;
         this.gridControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.gridControl.Name = "gridControl";
         this.gridControl.Size = new System.Drawing.Size(533, 353);
         this.gridControl.TabIndex = 7;
         this.gridControl.ViewCollection.AddRange(new BaseView[] {
            this.gridView1});
         // 
         // gridView1
         // 
         this.gridView1.DetailHeight = 431;
         this.gridView1.GridControl = this.gridControl;
         this.gridView1.Name = "gridView1";
         // 
         // anotherTextBox
         // 
         this.anotherTextBox.Location = new System.Drawing.Point(300, 100);
         this.anotherTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.anotherTextBox.Name = "anotherTextBox";
         this.anotherTextBox.Size = new System.Drawing.Size(133, 22);
         this.anotherTextBox.TabIndex = 8;
         // 
         // rtbDump
         // 
         this.rtbDump.Location = new System.Drawing.Point(613, 375);
         this.rtbDump.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.rtbDump.Name = "rtbDump";
         this.rtbDump.Size = new System.Drawing.Size(551, 201);
         this.rtbDump.TabIndex = 9;
         this.rtbDump.Text = "";
         // 
         // btnReset
         // 
         this.btnReset.Location = new System.Drawing.Point(300, 551);
         this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.btnReset.Name = "btnReset";
         this.btnReset.Size = new System.Drawing.Size(133, 26);
         this.btnReset.TabIndex = 10;
         this.btnReset.Text = "Reset";
         // 
         // comboBoxEdit1
         // 
         this.comboBoxEdit1.Location = new System.Drawing.Point(443, 103);
         this.comboBoxEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.comboBoxEdit1.Name = "comboBoxEdit1";
         this.comboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
         this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "ss",
            "bb",
            "nn"});
         this.comboBoxEdit1.Size = new System.Drawing.Size(133, 22);
         this.comboBoxEdit1.TabIndex = 11;
         // 
         // textNullableEdit
         // 
         this.textNullableEdit.Location = new System.Drawing.Point(595, 37);
         this.textNullableEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.textNullableEdit.Name = "textNullableEdit";
         this.textNullableEdit.Size = new System.Drawing.Size(133, 22);
         this.textNullableEdit.TabIndex = 12;
         // 
         // imageComboBoxEdit1
         // 
         this.imageComboBoxEdit1.Location = new System.Drawing.Point(613, 103);
         this.imageComboBoxEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
         this.imageComboBoxEdit1.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
         this.imageComboBoxEdit1.Size = new System.Drawing.Size(133, 22);
         this.imageComboBoxEdit1.TabIndex = 13;
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "CreateIndividual.ico");
         this.imageList1.Images.SetKeyName(1, "History.ico");
         this.imageList1.Images.SetKeyName(2, "Label.ico");
         this.imageList1.Images.SetKeyName(3, "NewProject.ico");
         this.imageList1.Images.SetKeyName(4, "ObservedDataFolder.ico");
         this.imageList1.Images.SetKeyName(5, "OpenProject.ico");
         this.imageList1.Images.SetKeyName(6, "Parameters.ico");
         this.imageList1.Images.SetKeyName(7, "PKSim.ico");
         this.imageList1.Images.SetKeyName(8, "SaveProject.ico");
         this.imageList1.Images.SetKeyName(9, "SimulationFolder.ico");
         // 
         // chkEdit
         // 
         this.chkEdit.Location = new System.Drawing.Point(772, 37);
         this.chkEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.chkEdit.Name = "chkEdit";
         this.chkEdit.Properties.Caption = "checkEdit1";
         this.chkEdit.Size = new System.Drawing.Size(100, 24);
         this.chkEdit.TabIndex = 14;
         // 
         // listBoxControl
         // 
         this.listBoxControl.Location = new System.Drawing.Point(947, 39);
         this.listBoxControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.listBoxControl.Name = "listBoxControl";
         this.listBoxControl.Size = new System.Drawing.Size(160, 117);
         this.listBoxControl.TabIndex = 15;
         // 
         // colorEdit
         // 
         this.colorEdit.EditValue = System.Drawing.Color.Empty;
         this.colorEdit.Location = new System.Drawing.Point(144, 100);
         this.colorEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.colorEdit.Name = "colorEdit";
         this.colorEdit.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
         this.colorEdit.Size = new System.Drawing.Size(133, 22);
         this.colorEdit.TabIndex = 16;
         // 
         // mruEdit1
         // 
         this.mruEdit1.Location = new System.Drawing.Point(797, 107);
         this.mruEdit1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.mruEdit1.Name = "mruEdit1";
         this.mruEdit1.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
         this.mruEdit1.Size = new System.Drawing.Size(133, 22);
         this.mruEdit1.TabIndex = 17;
         // 
         // memoEdit
         // 
         this.memoEdit.Location = new System.Drawing.Point(613, 177);
         this.memoEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.memoEdit.Name = "memoEdit";
         this.memoEdit.Size = new System.Drawing.Size(552, 142);
         this.memoEdit.TabIndex = 18;
         // 
         // textEditForInt
         // 
         this.textEditForInt.Location = new System.Drawing.Point(595, 5);
         this.textEditForInt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.textEditForInt.Name = "textEditForInt";
         this.textEditForInt.Size = new System.Drawing.Size(133, 22);
         this.textEditForInt.TabIndex = 19;
         // 
         // nullableColorEdit
         // 
         this.nullableColorEdit.EditValue = System.Drawing.Color.Empty;
         this.nullableColorEdit.Location = new System.Drawing.Point(144, 134);
         this.nullableColorEdit.Margin = new System.Windows.Forms.Padding(4);
         this.nullableColorEdit.Name = "nullableColorEdit";
         this.nullableColorEdit.Properties.Buttons.AddRange(new EditorButton[] {
            new EditorButton(ButtonPredefines.Combo)});
         this.nullableColorEdit.Size = new System.Drawing.Size(133, 22);
         this.nullableColorEdit.TabIndex = 20;
         // 
         // FormTest
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1237, 598);
         this.Controls.Add(this.nullableColorEdit);
         this.Controls.Add(this.textEditForInt);
         this.Controls.Add(this.memoEdit);
         this.Controls.Add(this.mruEdit1);
         this.Controls.Add(this.colorEdit);
         this.Controls.Add(this.listBoxControl);
         this.Controls.Add(this.chkEdit);
         this.Controls.Add(this.imageComboBoxEdit1);
         this.Controls.Add(this.textNullableEdit);
         this.Controls.Add(this.comboBoxEdit1);
         this.Controls.Add(this.btnReset);
         this.Controls.Add(this.rtbDump);
         this.Controls.Add(this.anotherTextBox);
         this.Controls.Add(this.gridControl);
         this.Controls.Add(this.textEditLastName);
         this.Controls.Add(this.textEditDouble);
         this.Controls.Add(this.btnApply);
         this.Controls.Add(this.lableText);
         this.Controls.Add(this.textEdit);
         this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
         this.Name = "FormTest";
         this.Text = "FormTest";
         ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditDouble.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditLastName.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.anotherTextBox.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textNullableEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.chkEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.listBoxControl)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.mruEdit1.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.textEditForInt.Properties)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.nullableColorEdit.Properties)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private DXErrorProvider dxErrorProvider;
      private DXValidationProvider dxValidationProvider;
      private TextEdit textEdit;
      private SimpleButton btnApply;
      private LabelControl lableText;
      private TextEdit textEditDouble;
      private TextEdit textEditLastName;
      private GridControl gridControl;
      private GridView gridView1;
      private TextEdit anotherTextBox;
      private System.Windows.Forms.RichTextBox rtbDump;
      private SimpleButton btnReset;
      private ComboBoxEdit comboBoxEdit1;
      private TextEdit textNullableEdit;
      private ImageComboBoxEdit imageComboBoxEdit1;
      private System.Windows.Forms.ImageList imageList1;
      private CheckEdit chkEdit;
      private ListBoxControl listBoxControl;
      private ColorEdit colorEdit;
      private MRUEdit mruEdit1;
      private MemoEdit memoEdit;
      private TextEdit textEditForInt;
      private ColorEdit nullableColorEdit;
   }
}