namespace ApkWin
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_test = new System.Windows.Forms.Button();
            this.imv_icon = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存图标至桌面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_label = new System.Windows.Forms.TextBox();
            this.tb_package_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_version_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_version_code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_target_sdk_version = new System.Windows.Forms.TextBox();
            this.tb_min_sdk_version = new System.Windows.Forms.TextBox();
            this.tv_test = new System.Windows.Forms.Label();
            this.rtb_permission = new System.Windows.Forms.RichTextBox();
            this.tb_md5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imv_icon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(563, 117);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(195, 301);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "拖拽到此处";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.button1_Click);
            // 
            // imv_icon
            // 
            this.imv_icon.ContextMenuStrip = this.contextMenuStrip1;
            this.imv_icon.Location = new System.Drawing.Point(608, 24);
            this.imv_icon.Name = "imv_icon";
            this.imv_icon.Size = new System.Drawing.Size(100, 50);
            this.imv_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imv_icon.TabIndex = 4;
            this.imv_icon.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存图标至桌面ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // 保存图标至桌面ToolStripMenuItem
            // 
            this.保存图标至桌面ToolStripMenuItem.Name = "保存图标至桌面ToolStripMenuItem";
            this.保存图标至桌面ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.保存图标至桌面ToolStripMenuItem.Text = "保存图标至桌面";
            this.保存图标至桌面ToolStripMenuItem.Click += new System.EventHandler(this.保存图标至桌面ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(608, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "关联.apk文件";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "label";
            // 
            // tb_label
            // 
            this.tb_label.Location = new System.Drawing.Point(87, 53);
            this.tb_label.Name = "tb_label";
            this.tb_label.ReadOnly = true;
            this.tb_label.Size = new System.Drawing.Size(428, 21);
            this.tb_label.TabIndex = 8;
            // 
            // tb_package_name
            // 
            this.tb_package_name.Location = new System.Drawing.Point(87, 97);
            this.tb_package_name.Name = "tb_package_name";
            this.tb_package_name.ReadOnly = true;
            this.tb_package_name.Size = new System.Drawing.Size(428, 21);
            this.tb_package_name.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "packageName";
            // 
            // tb_version_name
            // 
            this.tb_version_name.Location = new System.Drawing.Point(87, 145);
            this.tb_version_name.Name = "tb_version_name";
            this.tb_version_name.ReadOnly = true;
            this.tb_version_name.Size = new System.Drawing.Size(428, 21);
            this.tb_version_name.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "versionName";
            // 
            // tb_version_code
            // 
            this.tb_version_code.Location = new System.Drawing.Point(87, 188);
            this.tb_version_code.Name = "tb_version_code";
            this.tb_version_code.ReadOnly = true;
            this.tb_version_code.Size = new System.Drawing.Size(44, 21);
            this.tb_version_code.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "versionCode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "targetSdkVersion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "permission";
            // 
            // tb_target_sdk_version
            // 
            this.tb_target_sdk_version.Location = new System.Drawing.Point(284, 188);
            this.tb_target_sdk_version.Name = "tb_target_sdk_version";
            this.tb_target_sdk_version.ReadOnly = true;
            this.tb_target_sdk_version.Size = new System.Drawing.Size(48, 21);
            this.tb_target_sdk_version.TabIndex = 21;
            // 
            // tb_min_sdk_version
            // 
            this.tb_min_sdk_version.Location = new System.Drawing.Point(467, 188);
            this.tb_min_sdk_version.Name = "tb_min_sdk_version";
            this.tb_min_sdk_version.ReadOnly = true;
            this.tb_min_sdk_version.Size = new System.Drawing.Size(48, 21);
            this.tb_min_sdk_version.TabIndex = 23;
            // 
            // tv_test
            // 
            this.tv_test.AutoSize = true;
            this.tv_test.Location = new System.Drawing.Point(366, 194);
            this.tv_test.Name = "tv_test";
            this.tv_test.Size = new System.Drawing.Size(83, 12);
            this.tv_test.TabIndex = 22;
            this.tv_test.Text = "minSdkVersion";
            // 
            // rtb_permission
            // 
            this.rtb_permission.Location = new System.Drawing.Point(87, 243);
            this.rtb_permission.Name = "rtb_permission";
            this.rtb_permission.ReadOnly = true;
            this.rtb_permission.Size = new System.Drawing.Size(428, 119);
            this.rtb_permission.TabIndex = 24;
            this.rtb_permission.Text = "";
            // 
            // tb_md5
            // 
            this.tb_md5.Location = new System.Drawing.Point(87, 397);
            this.tb_md5.Name = "tb_md5";
            this.tb_md5.ReadOnly = true;
            this.tb_md5.Size = new System.Drawing.Size(428, 21);
            this.tb_md5.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "MD5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tb_md5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rtb_permission);
            this.Controls.Add(this.tb_min_sdk_version);
            this.Controls.Add(this.tv_test);
            this.Controls.Add(this.tb_target_sdk_version);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_version_code);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_version_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_package_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imv_icon);
            this.Controls.Add(this.btn_test);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imv_icon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.PictureBox imv_icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存图标至桌面ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_label;
        private System.Windows.Forms.TextBox tb_package_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_version_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_version_code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_target_sdk_version;
        private System.Windows.Forms.TextBox tb_min_sdk_version;
        private System.Windows.Forms.Label tv_test;
        private System.Windows.Forms.RichTextBox rtb_permission;
        private System.Windows.Forms.TextBox tb_md5;
        private System.Windows.Forms.Label label7;
    }
}

