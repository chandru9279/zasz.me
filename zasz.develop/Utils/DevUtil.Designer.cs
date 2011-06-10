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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Default = new System.Windows.Forms.RadioButton();
            this.AllBoth = new System.Windows.Forms.RadioButton();
            this.AllRest = new System.Windows.Forms.RadioButton();
            this.AllPro = new System.Windows.Forms.RadioButton();
            this.ClearPostContent = new System.Windows.Forms.Button();
            this.CommentsToWxr = new System.Windows.Forms.Button();
            this.CommentsProgress = new System.Windows.Forms.ProgressBar();
            this.SpamAmount = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowTagCloud = new System.Windows.Forms.Button();
            this.ClearUnusedTags = new System.Windows.Forms.Button();
            this.ChangeSiteName = new System.Windows.Forms.Button();
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
            this.ClearZaszStore.Click += new System.EventHandler(this.ClearColdStorageClick);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Default);
            this.groupBox1.Controls.Add(this.AllBoth);
            this.groupBox1.Controls.Add(this.AllRest);
            this.groupBox1.Controls.Add(this.AllPro);
            this.groupBox1.Location = new System.Drawing.Point(380, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 147);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Site";
            // 
            // Default
            // 
            this.Default.AutoSize = true;
            this.Default.Location = new System.Drawing.Point(41, 88);
            this.Default.Name = "Default";
            this.Default.Size = new System.Drawing.Size(96, 17);
            this.Default.TabIndex = 3;
            this.Default.TabStop = true;
            this.Default.Text = "InCode Deafult";
            this.Default.UseVisualStyleBackColor = true;
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
            // ClearPostContent
            // 
            this.ClearPostContent.Location = new System.Drawing.Point(28, 131);
            this.ClearPostContent.Name = "ClearPostContent";
            this.ClearPostContent.Size = new System.Drawing.Size(140, 29);
            this.ClearPostContent.TabIndex = 5;
            this.ClearPostContent.Text = "Clear Post Content";
            this.ClearPostContent.UseVisualStyleBackColor = true;
            this.ClearPostContent.Click += new System.EventHandler(this.ClearPostContentClick);
            // 
            // CommentsToWxr
            // 
            this.CommentsToWxr.Location = new System.Drawing.Point(28, 190);
            this.CommentsToWxr.Name = "CommentsToWxr";
            this.CommentsToWxr.Size = new System.Drawing.Size(140, 29);
            this.CommentsToWxr.TabIndex = 6;
            this.CommentsToWxr.Text = "Comments to WXR";
            this.CommentsToWxr.UseVisualStyleBackColor = true;
            this.CommentsToWxr.Click += new System.EventHandler(this.CommentsToWxrClick);
            // 
            // CommentsProgress
            // 
            this.CommentsProgress.Location = new System.Drawing.Point(229, 278);
            this.CommentsProgress.Name = "CommentsProgress";
            this.CommentsProgress.Size = new System.Drawing.Size(332, 23);
            this.CommentsProgress.Step = 1;
            this.CommentsProgress.TabIndex = 7;
            // 
            // SpamAmount
            // 
            this.SpamAmount.Location = new System.Drawing.Point(229, 333);
            this.SpamAmount.Name = "SpamAmount";
            this.SpamAmount.Size = new System.Drawing.Size(332, 23);
            this.SpamAmount.Step = 1;
            this.SpamAmount.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Comments Processing Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Spam Amount";
            // 
            // ShowTagCloud
            // 
            this.ShowTagCloud.Location = new System.Drawing.Point(28, 252);
            this.ShowTagCloud.Name = "ShowTagCloud";
            this.ShowTagCloud.Size = new System.Drawing.Size(140, 23);
            this.ShowTagCloud.TabIndex = 11;
            this.ShowTagCloud.Text = "Tag Cloud";
            this.ShowTagCloud.UseVisualStyleBackColor = true;
            this.ShowTagCloud.Click += new System.EventHandler(this.ShowTagCloudClick);
            // 
            // ClearUnusedTags
            // 
            this.ClearUnusedTags.Location = new System.Drawing.Point(28, 307);
            this.ClearUnusedTags.Name = "ClearUnusedTags";
            this.ClearUnusedTags.Size = new System.Drawing.Size(140, 23);
            this.ClearUnusedTags.TabIndex = 12;
            this.ClearUnusedTags.Text = "Clear Unused Tags";
            this.ClearUnusedTags.UseVisualStyleBackColor = true;
            this.ClearUnusedTags.Click += new System.EventHandler(this.ClearUnusedTagsClick);
            // 
            // ChangeSiteName
            // 
            this.ChangeSiteName.Location = new System.Drawing.Point(28, 362);
            this.ChangeSiteName.Name = "ChangeSiteName";
            this.ChangeSiteName.Size = new System.Drawing.Size(140, 23);
            this.ChangeSiteName.TabIndex = 13;
            this.ChangeSiteName.Text = "Change Site Name";
            this.ChangeSiteName.UseVisualStyleBackColor = true;
            this.ChangeSiteName.Click += new System.EventHandler(this.ChangeSiteNameClick);
            // 
            // DevUtil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 550);
            this.Controls.Add(this.ChangeSiteName);
            this.Controls.Add(this.ClearUnusedTags);
            this.Controls.Add(this.ShowTagCloud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpamAmount);
            this.Controls.Add(this.CommentsProgress);
            this.Controls.Add(this.CommentsToWxr);
            this.Controls.Add(this.ClearPostContent);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton AllBoth;
        private System.Windows.Forms.RadioButton AllRest;
        private System.Windows.Forms.RadioButton AllPro;
        private System.Windows.Forms.RadioButton Default;
        private System.Windows.Forms.Button ClearPostContent;
        private System.Windows.Forms.Button CommentsToWxr;
        private System.Windows.Forms.ProgressBar CommentsProgress;
        private System.Windows.Forms.ProgressBar SpamAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShowTagCloud;
        private System.Windows.Forms.Button ClearUnusedTags;
        private System.Windows.Forms.Button ChangeSiteName;
    }
}

