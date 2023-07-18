
namespace _2020114120王晨冲
{
    partial class QureyByattribute
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
            this.comboBoxLayerName = new System.Windows.Forms.ComboBox();
            this.comBoxSelectMethod = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listBoxFields = new System.Windows.Forms.ListBox();
            this.listBoxValue = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSelectResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.bnt_equal = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.lableSelectResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "选择方式";
            // 
            // comboBoxLayerName
            // 
            this.comboBoxLayerName.FormattingEnabled = true;
            this.comboBoxLayerName.Location = new System.Drawing.Point(203, 32);
            this.comboBoxLayerName.Name = "comboBoxLayerName";
            this.comboBoxLayerName.Size = new System.Drawing.Size(335, 23);
            this.comboBoxLayerName.TabIndex = 1;
            this.comboBoxLayerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayerName_SelectedIndexChanged);
            // 
            // comBoxSelectMethod
            // 
            this.comBoxSelectMethod.FormattingEnabled = true;
            this.comBoxSelectMethod.Items.AddRange(new object[] {
            "创建新选择集",
            "添加到当前选择集",
            "从当前选择集中删除",
            "从当前选择集中选择"});
            this.comBoxSelectMethod.Location = new System.Drawing.Point(203, 79);
            this.comBoxSelectMethod.Name = "comBoxSelectMethod";
            this.comBoxSelectMethod.Size = new System.Drawing.Size(335, 23);
            this.comBoxSelectMethod.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(595, 36);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(134, 19);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "只显示可选图层";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // listBoxFields
            // 
            this.listBoxFields.FormattingEnabled = true;
            this.listBoxFields.ItemHeight = 15;
            this.listBoxFields.Location = new System.Drawing.Point(77, 118);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new System.Drawing.Size(182, 169);
            this.listBoxFields.TabIndex = 3;
            this.listBoxFields.SelectedIndexChanged += new System.EventHandler(this.listBoxFields_SelectedIndexChanged);
            this.listBoxFields.DoubleClick += new System.EventHandler(this.listBoxFields_DoubleClick);
            // 
            // listBoxValue
            // 
            this.listBoxValue.FormattingEnabled = true;
            this.listBoxValue.ItemHeight = 15;
            this.listBoxValue.Location = new System.Drawing.Point(485, 118);
            this.listBoxValue.Name = "listBoxValue";
            this.listBoxValue.Size = new System.Drawing.Size(182, 169);
            this.listBoxValue.TabIndex = 3;
            this.listBoxValue.SelectedIndexChanged += new System.EventHandler(this.listBoxValue_SelectedIndexChanged);
            this.listBoxValue.DoubleClick += new System.EventHandler(this.listBoxValue_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(513, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "获取唯一属性值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSelectResult
            // 
            this.txtSelectResult.Location = new System.Drawing.Point(77, 336);
            this.txtSelectResult.Multiline = true;
            this.txtSelectResult.Name = "txtSelectResult";
            this.txtSelectResult.Size = new System.Drawing.Size(597, 67);
            this.txtSelectResult.TabIndex = 5;
            this.txtSelectResult.TextChanged += new System.EventHandler(this.txtSelectResult_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "清除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(485, 415);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 31);
            this.button3.TabIndex = 4;
            this.button3.Text = "确定";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(577, 415);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 31);
            this.button4.TabIndex = 4;
            this.button4.Text = "应用";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(669, 415);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 31);
            this.button5.TabIndex = 4;
            this.button5.Text = "关闭";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // bnt_equal
            // 
            this.bnt_equal.Location = new System.Drawing.Point(265, 118);
            this.bnt_equal.Name = "bnt_equal";
            this.bnt_equal.Size = new System.Drawing.Size(86, 31);
            this.bnt_equal.TabIndex = 4;
            this.bnt_equal.Text = "=";
            this.bnt_equal.UseVisualStyleBackColor = true;
            this.bnt_equal.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(265, 188);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 31);
            this.button7.TabIndex = 4;
            this.button7.Text = "<";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(265, 256);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 31);
            this.button8.TabIndex = 4;
            this.button8.Text = ">";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lableSelectResult
            // 
            this.lableSelectResult.Location = new System.Drawing.Point(77, 294);
            this.lableSelectResult.Name = "lableSelectResult";
            this.lableSelectResult.Size = new System.Drawing.Size(182, 25);
            this.lableSelectResult.TabIndex = 6;
            // 
            // QureyByattribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lableSelectResult);
            this.Controls.Add(this.txtSelectResult);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.bnt_equal);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxValue);
            this.Controls.Add(this.listBoxFields);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.comBoxSelectMethod);
            this.Controls.Add(this.comboBoxLayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "QureyByattribute";
            this.Text = "QureyByAttribute";
            this.Load += new System.EventHandler(this.QureyByAttribute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxLayerName;
        private System.Windows.Forms.ComboBox comBoxSelectMethod;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ListBox listBoxFields;
        private System.Windows.Forms.ListBox listBoxValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSelectResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button bnt_equal;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox lableSelectResult;
    }
}