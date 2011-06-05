namespace zasz.develop.Utils
{
    partial class TagCloud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagCloud));
            this.Cloud = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.MaxFontSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinFontSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FontName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Cloud)).BeginInit();
            this.SuspendLayout();
            // 
            // Cloud
            // 
            this.Cloud.Location = new System.Drawing.Point(371, 35);
            this.Cloud.Name = "Cloud";
            this.Cloud.Size = new System.Drawing.Size(100, 50);
            this.Cloud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Cloud.TabIndex = 0;
            this.Cloud.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(44, 35);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 160);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(44, 224);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(75, 23);
            this.Generate.TabIndex = 2;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.GenerateClick);
            // 
            // MaxFontSize
            // 
            this.MaxFontSize.Location = new System.Drawing.Point(116, 280);
            this.MaxFontSize.Name = "MaxFontSize";
            this.MaxFontSize.Size = new System.Drawing.Size(100, 20);
            this.MaxFontSize.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MaxFontSize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MinFontSize";
            // 
            // MinFontSize
            // 
            this.MinFontSize.Location = new System.Drawing.Point(116, 306);
            this.MinFontSize.Name = "MinFontSize";
            this.MinFontSize.Size = new System.Drawing.Size(100, 20);
            this.MinFontSize.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 335);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "FontName";
            // 
            // FontName
            // 
            this.FontName.Location = new System.Drawing.Point(116, 332);
            this.FontName.Name = "FontName";
            this.FontName.Size = new System.Drawing.Size(100, 20);
            this.FontName.TabIndex = 7;
            // 
            // TagCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 441);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FontName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MinFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxFontSize);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Cloud);
            this.Name = "TagCloud";
            this.Text = "TagCloud";
            ((System.ComponentModel.ISupportInitialize)(this.Cloud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Cloud;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox MaxFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MinFontSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FontName;
    }
}