using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    partial class FormReleaseResources
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
            this.gridView1 = new GridView();
            this.btnDispose = new SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(47, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // btnDispose
            // 
            this.btnDispose.Location = new System.Drawing.Point(47, 331);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(75, 23);
            this.btnDispose.TabIndex = 1;
            this.btnDispose.Text = "Dispose";
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // FormReleaseResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 419);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.gridControl1);
            this.Name = "FormReleaseResources";
            this.Text = "FormReleaseResources";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private global::DevExpress.XtraGrid.GridControl gridControl1;
        private global::DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private global::DevExpress.XtraEditors.SimpleButton btnDispose;
    }
}