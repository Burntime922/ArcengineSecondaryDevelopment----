
namespace _2020114120王晨冲
{
    partial class BufferDlg
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLayers = new System.Windows.Forms.ComboBox();
            this.cboUnits = new System.Windows.Forms.ComboBox();
            this.txtBufferDistance = new System.Windows.Forms.TextBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnOutputLayer = new System.Windows.Forms.Button();
            this.btnBuffer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBuffer);
            this.groupBox1.Controls.Add(this.btnOutputLayer);
            this.groupBox1.Controls.Add(this.txtOutputPath);
            this.groupBox1.Controls.Add(this.txtBufferDistance);
            this.groupBox1.Controls.Add(this.cboUnits);
            this.groupBox1.Controls.Add(this.cboLayers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.txtMessages);
            this.groupBox2.Location = new System.Drawing.Point(12, 222);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = " 选择图层";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "缓冲距离";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "输出图层";
            // 
            // cboLayers
            // 
            this.cboLayers.FormattingEnabled = true;
            this.cboLayers.Location = new System.Drawing.Point(216, 43);
            this.cboLayers.Name = "cboLayers";
            this.cboLayers.Size = new System.Drawing.Size(395, 23);
            this.cboLayers.TabIndex = 1;
            // 
            // cboUnits
            // 
            this.cboUnits.FormattingEnabled = true;
            this.cboUnits.Items.AddRange(new object[] {
            "Unknown",
            "",
            "Inches",
            "",
            "Points",
            "",
            "Feet",
            "",
            "Yards",
            "",
            "Miles",
            "",
            "NauticalMiles",
            "",
            "Millimeters",
            "",
            "Centimeters",
            "",
            "Decimeters",
            "",
            "Meters",
            "",
            "Kilometers",
            "",
            "DecimalDegrees"});
            this.cboUnits.Location = new System.Drawing.Point(395, 84);
            this.cboUnits.Name = "cboUnits";
            this.cboUnits.Size = new System.Drawing.Size(216, 23);
            this.cboUnits.TabIndex = 2;
            // 
            // txtBufferDistance
            // 
            this.txtBufferDistance.Location = new System.Drawing.Point(216, 92);
            this.txtBufferDistance.Name = "txtBufferDistance";
            this.txtBufferDistance.Size = new System.Drawing.Size(100, 25);
            this.txtBufferDistance.TabIndex = 3;
            this.txtBufferDistance.Text = "0.1";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(216, 136);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.ReadOnly = true;
            this.txtOutputPath.Size = new System.Drawing.Size(395, 25);
            this.txtOutputPath.TabIndex = 4;
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(46, 24);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(674, 144);
            this.txtMessages.TabIndex = 0;
            // 
            // btnOutputLayer
            // 
            this.btnOutputLayer.Location = new System.Drawing.Point(645, 137);
            this.btnOutputLayer.Name = "btnOutputLayer";
            this.btnOutputLayer.Size = new System.Drawing.Size(87, 29);
            this.btnOutputLayer.TabIndex = 5;
            this.btnOutputLayer.Text = "存放位置";
            this.btnOutputLayer.UseVisualStyleBackColor = true;
            this.btnOutputLayer.Click += new System.EventHandler(this.btnOutputLayer_Click);
            // 
            // btnBuffer
            // 
            this.btnBuffer.Location = new System.Drawing.Point(325, 167);
            this.btnBuffer.Name = "btnBuffer";
            this.btnBuffer.Size = new System.Drawing.Size(109, 31);
            this.btnBuffer.TabIndex = 6;
            this.btnBuffer.Text = "缓冲区分析";
            this.btnBuffer.UseVisualStyleBackColor = true;
            this.btnBuffer.Click += new System.EventHandler(this.btnBuffer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(345, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // BufferDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BufferDlg";
            this.Text = "缓冲区分析";
            this.Load += new System.EventHandler(this.BufferDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuffer;
        private System.Windows.Forms.Button btnOutputLayer;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.TextBox txtBufferDistance;
        private System.Windows.Forms.ComboBox cboUnits;
        private System.Windows.Forms.ComboBox cboLayers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMessages;
    }
}