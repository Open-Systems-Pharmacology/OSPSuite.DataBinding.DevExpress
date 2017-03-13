using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    partial class FormRebindToDataSource
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
            this.simpleButton1 = new SimpleButton();
            this.simpleButton2 = new SimpleButton();
            this.gridControl1 = new GridControl();
            this.gridView1 = new GridView();
            this.gridControl2 = new GridControl();
            this.gridView2 = new GridView();
            this.simpleButton3 = new SimpleButton();
            this.simpleButton4 = new SimpleButton();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(214, 262);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(104, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Rebind";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(84, 262);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(111, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Add Element To List";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(306, 234);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(347, 12);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(306, 234);
            this.gridControl2.TabIndex = 3;
            this.gridControl2.ViewCollection.AddRange(new BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(497, 262);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(156, 23);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Add Element To Notify  List";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(347, 262);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(124, 23);
            this.simpleButton4.TabIndex = 5;
            this.simpleButton4.Text = "Delete last element";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(347, 301);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormRebindToDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 373);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "FormRebindToDataSource";
            this.Text = "FormRebindToDataSource";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        private GridControl gridControl1;
        private GridView gridView1;
        private GridControl gridControl2;
        private GridView gridView2;
        private SimpleButton simpleButton3;
        private SimpleButton simpleButton4;
        private System.Windows.Forms.Button btnClear;
    }
}