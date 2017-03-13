using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    partial class FormSwitchDataSource
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
            this.gridView = new GridView();
            this.btnBndToSource1 = new SimpleButton();
            this.btnBndToSource2 = new SimpleButton();
            this.simpleButton1 = new SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(37, 12);
            this.gridControl1.MainView = this.gridView;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(712, 327);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.gridControl1;
            this.gridView.Name = "gridView";
            // 
            // btnBndToSource1
            // 
            this.btnBndToSource1.Location = new System.Drawing.Point(37, 433);
            this.btnBndToSource1.Name = "btnBndToSource1";
            this.btnBndToSource1.Size = new System.Drawing.Size(120, 23);
            this.btnBndToSource1.TabIndex = 1;
            this.btnBndToSource1.Text = "Bind to Source 1";
            this.btnBndToSource1.Click += new System.EventHandler(this.btnBndToSource1_Click);
            // 
            // btnBndToSource2
            // 
            this.btnBndToSource2.Location = new System.Drawing.Point(235, 433);
            this.btnBndToSource2.Name = "btnBndToSource2";
            this.btnBndToSource2.Size = new System.Drawing.Size(145, 23);
            this.btnBndToSource2.TabIndex = 2;
            this.btnBndToSource2.Text = "Bind To Source 2";
            this.btnBndToSource2.Click += new System.EventHandler(this.btnBndToSource2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(502, 424);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(145, 23);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Dispose";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // FormSwitchDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 544);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnBndToSource2);
            this.Controls.Add(this.btnBndToSource1);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormSwitchDataSource";
            this.Text = "FormSwitchDataSource";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private global::DevExpress.XtraGrid.GridControl gridControl1;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private global::DevExpress.XtraEditors.SimpleButton btnBndToSource1;
        private global::DevExpress.XtraEditors.SimpleButton btnBndToSource2;
        private SimpleButton simpleButton1;
    }
}