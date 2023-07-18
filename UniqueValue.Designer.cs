
namespace _2020114120王晨冲
{
    partial class UniqueValue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxLayers = new System.Windows.Forms.ComboBox();
            this.cbxFields = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "字段：";
            // 
            // cbxLayers
            // 
            this.cbxLayers.FormattingEnabled = true;
            this.cbxLayers.Location = new System.Drawing.Point(187, 57);
            this.cbxLayers.Name = "cbxLayers";
            this.cbxLayers.Size = new System.Drawing.Size(377, 23);
            this.cbxLayers.TabIndex = 2;
            this.cbxLayers.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbxFields
            // 
            this.cbxFields.FormattingEnabled = true;
            this.cbxFields.Location = new System.Drawing.Point(187, 129);
            this.cbxFields.Name = "cbxFields";
            this.cbxFields.Size = new System.Drawing.Size(377, 23);
            this.cbxFields.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UniqueValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 315);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxFields);
            this.Controls.Add(this.cbxLayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UniqueValue";
            this.Text = "唯一值符号化";
            this.Load += new System.EventHandler(this.UniqueValue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxLayers;
        private System.Windows.Forms.ComboBox cbxFields;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}