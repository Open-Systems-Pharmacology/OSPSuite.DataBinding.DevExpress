using DevExpress.XtraEditors;

namespace OSPSuite.DataBinding.DevExpress.Starter
{
    partial class FormMain
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
            this.btnDynamicRepository = new SimpleButton();
            this.btnEnduranceTest = new SimpleButton();
            this.btnNotification = new SimpleButton();
            this.btnRebindToDataSource = new SimpleButton();
            this.btnSwitchDataSource = new SimpleButton();
            this.btnMainTest = new SimpleButton();
            this.btnTreeList = new SimpleButton();
            this.btnDispose = new SimpleButton();
            this.SuspendLayout();
            // 
            // btnDynamicRepository
            // 
            this.btnDynamicRepository.Location = new System.Drawing.Point(49, 29);
            this.btnDynamicRepository.Name = "btnDynamicRepository";
            this.btnDynamicRepository.Size = new System.Drawing.Size(116, 23);
            this.btnDynamicRepository.TabIndex = 0;
            this.btnDynamicRepository.Text = "Dynamic Repository";
            this.btnDynamicRepository.Click += new System.EventHandler(this.btnDynamicRepository_Click);
            // 
            // btnEnduranceTest
            // 
            this.btnEnduranceTest.Location = new System.Drawing.Point(218, 29);
            this.btnEnduranceTest.Name = "btnEnduranceTest";
            this.btnEnduranceTest.Size = new System.Drawing.Size(139, 23);
            this.btnEnduranceTest.TabIndex = 1;
            this.btnEnduranceTest.Text = "Endurance Test";
            this.btnEnduranceTest.Click += new System.EventHandler(this.btnEnduranceTest_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.Location = new System.Drawing.Point(377, 29);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(75, 23);
            this.btnNotification.TabIndex = 2;
            this.btnNotification.Text = "Notification";
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnRebindToDataSource
            // 
            this.btnRebindToDataSource.Location = new System.Drawing.Point(49, 127);
            this.btnRebindToDataSource.Name = "btnRebindToDataSource";
            this.btnRebindToDataSource.Size = new System.Drawing.Size(116, 23);
            this.btnRebindToDataSource.TabIndex = 3;
            this.btnRebindToDataSource.Text = "Rebind to data source";
            this.btnRebindToDataSource.Click += new System.EventHandler(this.btnRebindToDataSource_Click);
            // 
            // btnSwitchDataSource
            // 
            this.btnSwitchDataSource.Location = new System.Drawing.Point(218, 127);
            this.btnSwitchDataSource.Name = "btnSwitchDataSource";
            this.btnSwitchDataSource.Size = new System.Drawing.Size(111, 23);
            this.btnSwitchDataSource.TabIndex = 4;
            this.btnSwitchDataSource.Text = "Switch Data Source";
            this.btnSwitchDataSource.Click += new System.EventHandler(this.btnSwitchDataSource_Click);
            // 
            // btnMainTest
            // 
            this.btnMainTest.Location = new System.Drawing.Point(377, 127);
            this.btnMainTest.Name = "btnMainTest";
            this.btnMainTest.Size = new System.Drawing.Size(75, 23);
            this.btnMainTest.TabIndex = 5;
            this.btnMainTest.Text = "Main Test";
            this.btnMainTest.Click += new System.EventHandler(this.btnMainTest_Click);
            // 
            // btnTreeList
            // 
            this.btnTreeList.Location = new System.Drawing.Point(483, 127);
            this.btnTreeList.Name = "btnTreeList";
            this.btnTreeList.Size = new System.Drawing.Size(75, 23);
            this.btnTreeList.TabIndex = 6;
            this.btnTreeList.Text = "Tree List";
            this.btnTreeList.Click += new System.EventHandler(this.btnTreeList_Click);
            // 
            // btnDispose
            // 
            this.btnDispose.Location = new System.Drawing.Point(483, 29);
            this.btnDispose.Name = "btnDispose";
            this.btnDispose.Size = new System.Drawing.Size(75, 23);
            this.btnDispose.TabIndex = 7;
            this.btnDispose.Text = "Dispose";
            this.btnDispose.Click += new System.EventHandler(this.btnDispose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 405);
            this.Controls.Add(this.btnDispose);
            this.Controls.Add(this.btnTreeList);
            this.Controls.Add(this.btnMainTest);
            this.Controls.Add(this.btnSwitchDataSource);
            this.Controls.Add(this.btnRebindToDataSource);
            this.Controls.Add(this.btnNotification);
            this.Controls.Add(this.btnEnduranceTest);
            this.Controls.Add(this.btnDynamicRepository);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private global::DevExpress.XtraEditors.SimpleButton btnDynamicRepository;
        private global::DevExpress.XtraEditors.SimpleButton btnEnduranceTest;
        private global::DevExpress.XtraEditors.SimpleButton btnNotification;
        private global::DevExpress.XtraEditors.SimpleButton btnRebindToDataSource;
        private global::DevExpress.XtraEditors.SimpleButton btnSwitchDataSource;
        private global::DevExpress.XtraEditors.SimpleButton btnMainTest;
        private global::DevExpress.XtraEditors.SimpleButton btnTreeList;
        private SimpleButton btnDispose;
    }
}