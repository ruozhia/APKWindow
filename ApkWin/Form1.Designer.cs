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
            this.rich_tv_test = new System.Windows.Forms.RichTextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.imv_icon = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.保存图标至桌面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imv_icon)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rich_tv_test
            // 
            this.rich_tv_test.Location = new System.Drawing.Point(12, 12);
            this.rich_tv_test.Name = "rich_tv_test";
            this.rich_tv_test.Size = new System.Drawing.Size(482, 415);
            this.rich_tv_test.TabIndex = 2;
            this.rich_tv_test.Text = "";
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(561, 78);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(195, 349);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "拖拽到此处";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.button1_Click);
            // 
            // imv_icon
            // 
            this.imv_icon.ContextMenuStrip = this.contextMenuStrip1;
            this.imv_icon.Location = new System.Drawing.Point(608, 12);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
            // 
            // 保存图标至桌面ToolStripMenuItem
            // 
            this.保存图标至桌面ToolStripMenuItem.Name = "保存图标至桌面ToolStripMenuItem";
            this.保存图标至桌面ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.保存图标至桌面ToolStripMenuItem.Text = "保存图标至桌面";
            this.保存图标至桌面ToolStripMenuItem.Click += new System.EventHandler(this.保存图标至桌面ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imv_icon);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.rich_tv_test);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imv_icon)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich_tv_test;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.PictureBox imv_icon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 保存图标至桌面ToolStripMenuItem;
    }
}

