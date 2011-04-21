namespace zasz.develop.Utils
{
    partial class DevUtil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevUtil));
            this.ImportPosts = new System.Windows.Forms.Button();
            this.ClearZaszStore = new System.Windows.Forms.Button();
            this.DevConsole = new System.Windows.Forms.TextBox();
            this.ClearConsole = new System.Windows.Forms.Button();
            this.UtilChooseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllBoth = new System.Windows.Forms.RadioButton();
            this.AllRest = new System.Windows.Forms.RadioButton();
            this.AllPro = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportPosts
            // 
            this.ImportPosts.Location = new System.Drawing.Point(28, 18);
            this.ImportPosts.Name = "ImportPosts";
            this.ImportPosts.Size = new System.Drawing.Size(140, 30);
            this.ImportPosts.TabIndex = 0;
            this.ImportPosts.Text = "Import Posts (BE.NET)";
            this.ImportPosts.UseVisualStyleBackColor = true;
            this.ImportPosts.Click += new System.EventHandler(this.ImportPostsClick);
            // 
            // ClearZaszStore
            // 
            this.ClearZaszStore.Location = new System.Drawing.Point(28, 72);
            this.ClearZaszStore.Name = "ClearZaszStore";
            this.ClearZaszStore.Size = new System.Drawing.Size(140, 30);
            this.ClearZaszStore.TabIndex = 1;
            this.ClearZaszStore.Text = "Clear ColdStorage";
            this.ClearZaszStore.UseVisualStyleBackColor = true;
            this.ClearZaszStore.Click += new System.EventHandler(this.ClearColdStorage_Click);
            // 
            // DevConsole
            // 
            this.DevConsole.Location = new System.Drawing.Point(585, 18);
            this.DevConsole.Multiline = true;
            this.DevConsole.Name = "DevConsole";
            this.DevConsole.ReadOnly = true;
            this.DevConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DevConsole.Size = new System.Drawing.Size(588, 507);
            this.DevConsole.TabIndex = 2;
            // 
            // ClearConsole
            // 
            this.ClearConsole.Location = new System.Drawing.Point(421, 18);
            this.ClearConsole.Name = "ClearConsole";
            this.ClearConsole.Size = new System.Drawing.Size(140, 30);
            this.ClearConsole.TabIndex = 3;
            this.ClearConsole.Text = "Clear Console";
            this.ClearConsole.UseVisualStyleBackColor = true;
            this.ClearConsole.Click += new System.EventHandler(this.ClearConsoleClick);
            // 
            // UtilChooseFolder
            // 
            this.UtilChooseFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.UtilChooseFolder.SelectedPath = "C:\\Documents and Settings\\thiagac\\My Documents\\Visual Studio 2010\\Projects\\Posts";
            this.UtilChooseFolder.ShowNewFolderButton = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllBoth);
            this.groupBox1.Controls.Add(this.AllRest);
            this.groupBox1.Controls.Add(this.AllPro);
            this.groupBox1.Location = new System.Drawing.Point(380, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site";
            // 
            // AllBoth
            // 
            this.AllBoth.AutoSize = true;
            this.AllBoth.Location = new System.Drawing.Point(41, 65);
            this.AllBoth.Name = "AllBoth";
            this.AllBoth.Size = new System.Drawing.Size(61, 17);
            this.AllBoth.TabIndex = 2;
            this.AllBoth.TabStop = true;
            this.AllBoth.Text = "All Both";
            this.AllBoth.UseVisualStyleBackColor = true;
            // 
            // AllRest
            // 
            this.AllRest.AutoSize = true;
            this.AllRest.Location = new System.Drawing.Point(41, 42);
            this.AllRest.Name = "AllRest";
            this.AllRest.Size = new System.Drawing.Size(61, 17);
            this.AllRest.TabIndex = 1;
            this.AllRest.TabStop = true;
            this.AllRest.Text = "All Rest";
            this.AllRest.UseVisualStyleBackColor = false;
            // 
            // AllPro
            // 
            this.AllPro.AutoSize = true;
            this.AllPro.Location = new System.Drawing.Point(41, 19);
            this.AllPro.Name = "AllPro";
            this.AllPro.Size = new System.Drawing.Size(55, 17);
            this.AllPro.TabIndex = 0;
            this.AllPro.TabStop = true;
            this.AllPro.Text = "All Pro";
            this.AllPro.UseVisualStyleBackColor = true;
            // 
            // DevUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 550);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearConsole);
            this.Controls.Add(this.DevConsole);
            this.Controls.Add(this.ClearZaszStore);
            this.Controls.Add(this.ImportPosts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DevUtil";
            this.Text = "Developer Utilities";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportPosts;
        private System.Windows.Forms.Button ClearZaszStore;
        private System.Windows.Forms.TextBox DevConsole;
        private System.Windows.Forms.Button ClearConsole;
        private System.Windows.Forms.FolderBrowserDialog UtilChooseFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AllBoth;
        private System.Windows.Forms.RadioButton AllRest;
        private System.Windows.Forms.RadioButton AllPro;
    }
}

