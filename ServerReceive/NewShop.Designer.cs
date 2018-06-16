namespace ServerReceive
{
    partial class NewShop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewShop));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_worker = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(77, 30);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(205, 21);
            this.textBox_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "地址：";
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(77, 71);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(205, 21);
            this.textBox_address.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "电话：";
            // 
            // textBox_tel
            // 
            this.textBox_tel.Location = new System.Drawing.Point(77, 112);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(205, 21);
            this.textBox_tel.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "店长：";
            // 
            // textBox_worker
            // 
            this.textBox_worker.Location = new System.Drawing.Point(77, 153);
            this.textBox_worker.Name = "textBox_worker";
            this.textBox_worker.Size = new System.Drawing.Size(205, 21);
            this.textBox_worker.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "代码：";
            // 
            // textBox_pname
            // 
            this.textBox_pname.Location = new System.Drawing.Point(77, 194);
            this.textBox_pname.Name = "textBox_pname";
            this.textBox_pname.Size = new System.Drawing.Size(205, 21);
            this.textBox_pname.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(19, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(130, 259);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 33);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // NewShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 316);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox_pname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_worker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_tel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增门店";
            this.Shown += new System.EventHandler(this.NewShop_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_worker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOK;
    }
}