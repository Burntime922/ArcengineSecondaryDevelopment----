
namespace _2020114120王晨冲
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.旋转ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.自由旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.要素选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.框选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.圆选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.多边形选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性查询ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.要素编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.停止编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图层渲染器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBarXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl2 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.旋转ToolStripMenuItem,
            this.要素选择ToolStripMenuItem,
            this.按属性查询ToolStripMenuItem,
            this.要素编辑ToolStripMenuItem,
            this.图层渲染器ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1145, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewDoc,
            this.menuOpenDoc,
            this.menuSaveDoc,
            this.menuSaveAs,
            this.menuSeparator,
            this.menuExitApp});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(53, 24);
            this.menuFile.Text = "文件";
            this.menuFile.Click += new System.EventHandler(this.menuFile_Click);
            // 
            // menuNewDoc
            // 
            this.menuNewDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuNewDoc.Image")));
            this.menuNewDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuNewDoc.Name = "menuNewDoc";
            this.menuNewDoc.Size = new System.Drawing.Size(224, 26);
            this.menuNewDoc.Text = "新建文件";
            this.menuNewDoc.Click += new System.EventHandler(this.menuNewDoc_Click);
            // 
            // menuOpenDoc
            // 
            this.menuOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenDoc.Image")));
            this.menuOpenDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuOpenDoc.Name = "menuOpenDoc";
            this.menuOpenDoc.Size = new System.Drawing.Size(224, 26);
            this.menuOpenDoc.Text = "打开文件";
            this.menuOpenDoc.Click += new System.EventHandler(this.menuOpenDoc_Click);
            // 
            // menuSaveDoc
            // 
            this.menuSaveDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveDoc.Image")));
            this.menuSaveDoc.ImageTransparentColor = System.Drawing.Color.White;
            this.menuSaveDoc.Name = "menuSaveDoc";
            this.menuSaveDoc.Size = new System.Drawing.Size(224, 26);
            this.menuSaveDoc.Text = "保存文件";
            this.menuSaveDoc.Click += new System.EventHandler(this.menuSaveDoc_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(224, 26);
            this.menuSaveAs.Text = "另存为";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // menuSeparator
            // 
            this.menuSeparator.Name = "menuSeparator";
            this.menuSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // menuExitApp
            // 
            this.menuExitApp.Name = "menuExitApp";
            this.menuExitApp.Size = new System.Drawing.Size(224, 26);
            this.menuExitApp.Text = "退出";
            this.menuExitApp.Click += new System.EventHandler(this.menuExitApp_Click);
            // 
            // 旋转ToolStripMenuItem
            // 
            this.旋转ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.旋转ToolStripMenuItem1,
            this.自由旋转ToolStripMenuItem});
            this.旋转ToolStripMenuItem.Name = "旋转ToolStripMenuItem";
            this.旋转ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.旋转ToolStripMenuItem.Text = "旋转";
            // 
            // 旋转ToolStripMenuItem1
            // 
            this.旋转ToolStripMenuItem1.Name = "旋转ToolStripMenuItem1";
            this.旋转ToolStripMenuItem1.Size = new System.Drawing.Size(152, 26);
            this.旋转ToolStripMenuItem1.Text = "旋转";
            this.旋转ToolStripMenuItem1.Click += new System.EventHandler(this.旋转ToolStripMenuItem1_Click);
            // 
            // 自由旋转ToolStripMenuItem
            // 
            this.自由旋转ToolStripMenuItem.Name = "自由旋转ToolStripMenuItem";
            this.自由旋转ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.自由旋转ToolStripMenuItem.Text = "自由旋转";
            this.自由旋转ToolStripMenuItem.Click += new System.EventHandler(this.自由旋转ToolStripMenuItem_Click);
            // 
            // 要素选择ToolStripMenuItem
            // 
            this.要素选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.线选ToolStripMenuItem,
            this.框选ToolStripMenuItem,
            this.圆选ToolStripMenuItem,
            this.多边形选ToolStripMenuItem});
            this.要素选择ToolStripMenuItem.Name = "要素选择ToolStripMenuItem";
            this.要素选择ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.要素选择ToolStripMenuItem.Text = "要素选择";
            // 
            // 线选ToolStripMenuItem
            // 
            this.线选ToolStripMenuItem.Name = "线选ToolStripMenuItem";
            this.线选ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.线选ToolStripMenuItem.Text = "线选";
            this.线选ToolStripMenuItem.Click += new System.EventHandler(this.线选ToolStripMenuItem_Click);
            // 
            // 框选ToolStripMenuItem
            // 
            this.框选ToolStripMenuItem.Name = "框选ToolStripMenuItem";
            this.框选ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.框选ToolStripMenuItem.Text = "框选";
            this.框选ToolStripMenuItem.Click += new System.EventHandler(this.框选ToolStripMenuItem_Click);
            // 
            // 圆选ToolStripMenuItem
            // 
            this.圆选ToolStripMenuItem.Name = "圆选ToolStripMenuItem";
            this.圆选ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.圆选ToolStripMenuItem.Text = "圆选";
            this.圆选ToolStripMenuItem.Click += new System.EventHandler(this.圆选ToolStripMenuItem_Click);
            // 
            // 多边形选ToolStripMenuItem
            // 
            this.多边形选ToolStripMenuItem.Name = "多边形选ToolStripMenuItem";
            this.多边形选ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.多边形选ToolStripMenuItem.Text = "多边形选";
            this.多边形选ToolStripMenuItem.Click += new System.EventHandler(this.多边形选ToolStripMenuItem_Click);
            // 
            // 按属性查询ToolStripMenuItem
            // 
            this.按属性查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按属性查询ToolStripMenuItem1});
            this.按属性查询ToolStripMenuItem.Name = "按属性查询ToolStripMenuItem";
            this.按属性查询ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.按属性查询ToolStripMenuItem.Text = "查询";
            // 
            // 按属性查询ToolStripMenuItem1
            // 
            this.按属性查询ToolStripMenuItem1.Name = "按属性查询ToolStripMenuItem1";
            this.按属性查询ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.按属性查询ToolStripMenuItem1.Text = "按属性查询";
            this.按属性查询ToolStripMenuItem1.Click += new System.EventHandler(this.按属性查询ToolStripMenuItem1_Click);
            // 
            // 要素编辑ToolStripMenuItem
            // 
            this.要素编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始编辑ToolStripMenuItem,
            this.停止编辑ToolStripMenuItem});
            this.要素编辑ToolStripMenuItem.Name = "要素编辑ToolStripMenuItem";
            this.要素编辑ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.要素编辑ToolStripMenuItem.Text = "要素编辑";
            this.要素编辑ToolStripMenuItem.Click += new System.EventHandler(this.要素编辑ToolStripMenuItem_Click);
            // 
            // 开始编辑ToolStripMenuItem
            // 
            this.开始编辑ToolStripMenuItem.Name = "开始编辑ToolStripMenuItem";
            this.开始编辑ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.开始编辑ToolStripMenuItem.Text = "开始显示编辑窗口";
            this.开始编辑ToolStripMenuItem.Click += new System.EventHandler(this.开始编辑ToolStripMenuItem_Click);
            // 
            // 停止编辑ToolStripMenuItem
            // 
            this.停止编辑ToolStripMenuItem.Name = "停止编辑ToolStripMenuItem";
            this.停止编辑ToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.停止编辑ToolStripMenuItem.Text = "停止显示编辑窗口";
            this.停止编辑ToolStripMenuItem.Click += new System.EventHandler(this.停止编辑ToolStripMenuItem_Click);
            // 
            // 图层渲染器ToolStripMenuItem
            // 
            this.图层渲染器ToolStripMenuItem.Name = "图层渲染器ToolStripMenuItem";
            this.图层渲染器ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.图层渲染器ToolStripMenuItem.Text = "唯一值符号化渲染";
            this.图层渲染器ToolStripMenuItem.Click += new System.EventHandler(this.图层渲染器ToolStripMenuItem_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(372, 56);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(773, 594);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            this.axMapControl1.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl1_OnMouseUp);
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.axMapControl1_OnExtentUpdated_1);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1145, 28);
            this.axToolbarControl1.TabIndex = 3;
            this.axToolbarControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IToolbarControlEvents_Ax_OnMouseDownEventHandler(this.axToolbarControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(4, 56);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(368, 594);
            this.axTOCControl1.TabIndex = 4;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(466, 278);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 56);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 620);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarXY,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(4, 650);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1141, 26);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusBar1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // statusBarXY
            // 
            this.statusBarXY.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusBarXY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBarXY.Name = "statusBarXY";
            this.statusBarXY.Size = new System.Drawing.Size(71, 20);
            this.statusBarXY.Text = "Test 123";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Location = new System.Drawing.Point(12, 327);
            this.axMapControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(345, 283);
            this.axMapControl2.TabIndex = 8;
            this.axMapControl2.Visible = false;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            this.axMapControl2.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.axMapControl2_OnMouseUp);
            this.axMapControl2.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl2_OnMouseMove_1);
            // 
            // axToolbarControl2
            // 
            this.axToolbarControl2.Location = new System.Drawing.Point(372, 56);
            this.axToolbarControl2.Name = "axToolbarControl2";
            this.axToolbarControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl2.OcxState")));
            this.axToolbarControl2.Size = new System.Drawing.Size(761, 28);
            this.axToolbarControl2.TabIndex = 9;
            this.axToolbarControl2.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 676);
            this.Controls.Add(this.axToolbarControl2);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "MainForm";
            this.Text = "2020114120王晨冲供水管网地理信息系统的功能模块设计与界面设计";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNewDoc;
        private System.Windows.Forms.ToolStripMenuItem menuOpenDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveDoc;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExitApp;
        private System.Windows.Forms.ToolStripSeparator menuSeparator;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBarXY;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private System.Windows.Forms.ToolStripMenuItem 旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 旋转ToolStripMenuItem1;
        public ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.ToolStripMenuItem 要素选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 框选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 圆选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 多边形选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自由旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按属性查询ToolStripMenuItem1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl2;
        private System.Windows.Forms.ToolStripMenuItem 要素编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 停止编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图层渲染器ToolStripMenuItem;
    }
}

