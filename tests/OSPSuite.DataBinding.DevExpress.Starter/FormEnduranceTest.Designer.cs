using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    partial class FormEnduranceTest
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
                _gridViewBinder.Dispose();
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
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.labelControl1 = new LabelControl();
            this.tbNumOfItem = new TextEdit();
            this.btnBind = new SimpleButton();
            this.labelControl2 = new LabelControl();
            this.lblElaspedTime = new LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumOfItem.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Name = "";
            this.gridControl1.Location = new System.Drawing.Point(32, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(507, 362);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(118, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Number of items to bind:";
            // 
            // tbNumOfItem
            // 
            this.tbNumOfItem.EditValue = "100";
            this.tbNumOfItem.Location = new System.Drawing.Point(174, 10);
            this.tbNumOfItem.Name = "tbNumOfItem";
            this.tbNumOfItem.Size = new System.Drawing.Size(62, 20);
            this.tbNumOfItem.TabIndex = 2;
            // 
            // btnBind
            // 
            this.btnBind.Location = new System.Drawing.Point(255, 7);
            this.btnBind.Name = "btnBind";
            this.btnBind.Size = new System.Drawing.Size(75, 23);
            this.btnBind.TabIndex = 3;
            this.btnBind.Text = "Bind!!";
            this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(445, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(66, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Elapsed Time:";
            // 
            // lblElaspedTime
            // 
            this.lblElaspedTime.Location = new System.Drawing.Point(528, 12);
            this.lblElaspedTime.Name = "lblElaspedTime";
            this.lblElaspedTime.Size = new System.Drawing.Size(11, 13);
            this.lblElaspedTime.TabIndex = 5;
            this.lblElaspedTime.Text = "0s";
            // 
            // FormEnduranceTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 475);
            this.Controls.Add(this.lblElaspedTime);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnBind);
            this.Controls.Add(this.tbNumOfItem);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormEnduranceTest";
            this.Text = "FormEnduranceTest";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbNumOfItem.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private global::DevExpress.XtraGrid.GridControl gridControl1;
        private GridView gridView1;
        private global::DevExpress.XtraEditors.LabelControl labelControl1;
        private global::DevExpress.XtraEditors.TextEdit tbNumOfItem;
        private global::DevExpress.XtraEditors.SimpleButton btnBind;
        private global::DevExpress.XtraEditors.LabelControl labelControl2;
        private global::DevExpress.XtraEditors.LabelControl lblElaspedTime;
    }
}