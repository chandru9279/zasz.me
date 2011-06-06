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
            this.Cloud = new System.Windows.Forms.PictureBox();
            this.Words = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.MaxFontSize = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinFontSize = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Height = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Angle = new System.Windows.Forms.TextBox();
            this.FontsCombo = new System.Windows.Forms.ComboBox();
            this.StrategyCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Cloud)).BeginInit();
            this.SuspendLayout();
            // 
            // Cloud
            // 
            this.Cloud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Cloud.Location = new System.Drawing.Point(338, 35);
            this.Cloud.Name = "Cloud";
            this.Cloud.Size = new System.Drawing.Size(100, 50);
            this.Cloud.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Cloud.TabIndex = 0;
            this.Cloud.TabStop = false;
            // 
            // Words
            // 
            this.Words.Location = new System.Drawing.Point(44, 35);
            this.Words.Multiline = true;
            this.Words.Name = "Words";
            this.Words.Size = new System.Drawing.Size(246, 160);
            this.Words.TabIndex = 1;
            this.Words.Text = "asp.net, 15\r\ngames, 10\r\nfun, 18\r\nbooks, 5\r\nmusic, 9\r\ncrapo, 8\r\ndota, 6\r\n";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(116, 224);
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
            this.MaxFontSize.Text = "4";
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
            this.MinFontSize.Text = "1";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Width";
            // 
            // Width
            // 
            this.Width.Location = new System.Drawing.Point(116, 358);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(100, 20);
            this.Width.TabIndex = 9;
            this.Width.Text = "500";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Height";
            // 
            // Height
            // 
            this.Height.Location = new System.Drawing.Point(116, 384);
            this.Height.Name = "Height";
            this.Height.Size = new System.Drawing.Size(100, 20);
            this.Height.TabIndex = 11;
            this.Height.Text = "500";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Angle";
            // 
            // Angle
            // 
            this.Angle.Location = new System.Drawing.Point(116, 410);
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(100, 20);
            this.Angle.TabIndex = 13;
            this.Angle.Text = "-45";
            // 
            // FontsCombo
            // 
            this.FontsCombo.FormattingEnabled = true;
            this.FontsCombo.Location = new System.Drawing.Point(116, 331);
            this.FontsCombo.Name = "FontsCombo";
            this.FontsCombo.Size = new System.Drawing.Size(174, 21);
            this.FontsCombo.TabIndex = 15;
            // 
            // StrategyCombo
            // 
            this.StrategyCombo.FormattingEnabled = true;
            this.StrategyCombo.Location = new System.Drawing.Point(116, 436);
            this.StrategyCombo.Name = "StrategyCombo";
            this.StrategyCombo.Size = new System.Drawing.Size(174, 21);
            this.StrategyCombo.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Strategy";
            // 
            // TagCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 499);
            this.Controls.Add(this.StrategyCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.FontsCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Angle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Height);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Width);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MinFontSize);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxFontSize);
            this.Controls.Add(this.Generate);
            this.Controls.Add(this.Words);
            this.Controls.Add(this.Cloud);
            this.Name = "TagCloud";
            this.Text = "TagCloud";
            this.Load += new System.EventHandler(this.TagCloudLoad);
            ((System.ComponentModel.ISupportInitialize)(this.Cloud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Cloud;
        private System.Windows.Forms.TextBox Words;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.TextBox MaxFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MinFontSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Width;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Height;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Angle;
        private System.Windows.Forms.ComboBox FontsCombo;
        private System.Windows.Forms.ComboBox StrategyCombo;
        private System.Windows.Forms.Label label7;
    }
}