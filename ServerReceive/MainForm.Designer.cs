namespace ServerReceive
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_本日价格汇总 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton更新 = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox门店 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_add_note = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_view_note = new System.Windows.Forms.ToolStripButton();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem门店 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看门店ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.新增门店ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem销售 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem价格汇总 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem按天统计 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem单笔明细 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem商品明细 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem库存 = new System.Windows.Forms.ToolStripMenuItem();
            this.查看库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem窗口 = new System.Windows.Forms.ToolStripMenuItem();
            this.排列窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_本日价格汇总,
            this.toolStripButton1,
            this.toolStripButton更新,
            this.toolStripComboBox门店,
            this.toolStripButton_add_note,
            this.toolStripButton_view_note});
            this.toolStripMain.Location = new System.Drawing.Point(0, 25);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(784, 39);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripButton_本日价格汇总
            // 
            this.toolStripButton_本日价格汇总.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_本日价格汇总.Image = global::ServerReceive.Properties.Resources.yin_yang;
            this.toolStripButton_本日价格汇总.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_本日价格汇总.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_本日价格汇总.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripButton_本日价格汇总.Name = "toolStripButton_本日价格汇总";
            this.toolStripButton_本日价格汇总.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_本日价格汇总.ToolTipText = "本日价格汇总";
            this.toolStripButton_本日价格汇总.Click += new System.EventHandler(this.toolStripButton_本日价格汇总_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ServerReceive.Properties.Resources.date;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "按天统计（今天）";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton今天统计_Click);
            // 
            // toolStripButton更新
            // 
            this.toolStripButton更新.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton更新.Image = global::ServerReceive.Properties.Resources.Refresh;
            this.toolStripButton更新.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton更新.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton更新.Name = "toolStripButton更新";
            this.toolStripButton更新.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton更新.Text = "更新数据";
            this.toolStripButton更新.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripComboBox门店
            // 
            this.toolStripComboBox门店.Margin = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStripComboBox门店.Name = "toolStripComboBox门店";
            this.toolStripComboBox门店.Size = new System.Drawing.Size(130, 39);
            this.toolStripComboBox门店.ToolTipText = "选择门店";
            // 
            // toolStripButton_add_note
            // 
            this.toolStripButton_add_note.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_add_note.Image = global::ServerReceive.Properties.Resources.table_edit;
            this.toolStripButton_add_note.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_add_note.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_add_note.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton_add_note.Name = "toolStripButton_add_note";
            this.toolStripButton_add_note.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_add_note.Text = "toolStripButton3";
            this.toolStripButton_add_note.ToolTipText = "新增备注";
            // 
            // toolStripButton_view_note
            // 
            this.toolStripButton_view_note.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_view_note.Image = global::ServerReceive.Properties.Resources.report;
            this.toolStripButton_view_note.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_view_note.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_view_note.Name = "toolStripButton_view_note";
            this.toolStripButton_view_note.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_view_note.Text = "toolStripButton2";
            this.toolStripButton_view_note.ToolTipText = "查看备注";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem门店,
            this.toolStripMenuItem销售,
            this.toolStripMenuItem库存,
            this.ToolStripMenuItem窗口});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.MdiWindowListItem = this.ToolStripMenuItem窗口;
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 25);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            this.menuStripMain.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStripMain_ItemAdded);
            // 
            // toolStripMenuItem门店
            // 
            this.toolStripMenuItem门店.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看门店ToolStripMenuItem,
            this.toolStripSeparator2,
            this.新增门店ToolStripMenuItem});
            this.toolStripMenuItem门店.Name = "toolStripMenuItem门店";
            this.toolStripMenuItem门店.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem门店.Text = "门店";
            // 
            // 查看门店ToolStripMenuItem
            // 
            this.查看门店ToolStripMenuItem.Name = "查看门店ToolStripMenuItem";
            this.查看门店ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看门店ToolStripMenuItem.Text = "查看门店";
            this.查看门店ToolStripMenuItem.Click += new System.EventHandler(this.查看门店ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(121, 6);
            // 
            // 新增门店ToolStripMenuItem
            // 
            this.新增门店ToolStripMenuItem.Name = "新增门店ToolStripMenuItem";
            this.新增门店ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新增门店ToolStripMenuItem.Text = "新增门店";
            this.新增门店ToolStripMenuItem.Click += new System.EventHandler(this.新增门店ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem销售
            // 
            this.toolStripMenuItem销售.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem价格汇总,
            this.toolStripSeparator1,
            this.toolStripMenuItem按天统计,
            this.toolStripSeparator3,
            this.toolStripMenuItem单笔明细,
            this.toolStripMenuItem商品明细});
            this.toolStripMenuItem销售.Name = "toolStripMenuItem销售";
            this.toolStripMenuItem销售.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem销售.Text = "销售";
            // 
            // toolStripMenuItem价格汇总
            // 
            this.toolStripMenuItem价格汇总.Name = "toolStripMenuItem价格汇总";
            this.toolStripMenuItem价格汇总.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem价格汇总.Text = "价格汇总";
            this.toolStripMenuItem价格汇总.Click += new System.EventHandler(this.toolStripMenuItem价格汇总_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem按天统计
            // 
            this.toolStripMenuItem按天统计.Name = "toolStripMenuItem按天统计";
            this.toolStripMenuItem按天统计.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem按天统计.Text = "按天统计";
            this.toolStripMenuItem按天统计.Click += new System.EventHandler(this.toolStripMenuItem按天统计_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(121, 6);
            // 
            // toolStripMenuItem单笔明细
            // 
            this.toolStripMenuItem单笔明细.Name = "toolStripMenuItem单笔明细";
            this.toolStripMenuItem单笔明细.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem单笔明细.Text = "单笔明细";
            this.toolStripMenuItem单笔明细.Click += new System.EventHandler(this.toolStripMenuItem单笔明细_Click);
            // 
            // toolStripMenuItem商品明细
            // 
            this.toolStripMenuItem商品明细.Name = "toolStripMenuItem商品明细";
            this.toolStripMenuItem商品明细.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem商品明细.Text = "商品明细";
            this.toolStripMenuItem商品明细.Click += new System.EventHandler(this.toolStripMenuItem商品明细_Click);
            // 
            // toolStripMenuItem库存
            // 
            this.toolStripMenuItem库存.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看库存ToolStripMenuItem});
            this.toolStripMenuItem库存.Name = "toolStripMenuItem库存";
            this.toolStripMenuItem库存.Size = new System.Drawing.Size(44, 21);
            this.toolStripMenuItem库存.Text = "库存";
            // 
            // 查看库存ToolStripMenuItem
            // 
            this.查看库存ToolStripMenuItem.Name = "查看库存ToolStripMenuItem";
            this.查看库存ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查看库存ToolStripMenuItem.Text = "查看库存";
            this.查看库存ToolStripMenuItem.Click += new System.EventHandler(this.查看库存ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem窗口
            // 
            this.ToolStripMenuItem窗口.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.排列窗口ToolStripMenuItem,
            this.全部关闭ToolStripMenuItem});
            this.ToolStripMenuItem窗口.Name = "ToolStripMenuItem窗口";
            this.ToolStripMenuItem窗口.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItem窗口.Text = "窗口";
            // 
            // 排列窗口ToolStripMenuItem
            // 
            this.排列窗口ToolStripMenuItem.Name = "排列窗口ToolStripMenuItem";
            this.排列窗口ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.排列窗口ToolStripMenuItem.Text = "排列窗口";
            this.排列窗口ToolStripMenuItem.Click += new System.EventHandler(this.排列窗口ToolStripMenuItem_Click);
            // 
            // 全部关闭ToolStripMenuItem
            // 
            this.全部关闭ToolStripMenuItem.Name = "全部关闭ToolStripMenuItem";
            this.全部关闭ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全部关闭ToolStripMenuItem.Text = "全部关闭";
            this.全部关闭ToolStripMenuItem.Click += new System.EventHandler(this.全部关闭ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServerReceive";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButton更新;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem窗口;
        private System.Windows.Forms.ToolStripMenuItem 排列窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem销售;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem单笔明细;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem商品明细;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem门店;
        private System.Windows.Forms.ToolStripMenuItem 查看门店ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增门店ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem库存;
        private System.Windows.Forms.ToolStripMenuItem 查看库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox门店;
        private System.Windows.Forms.ToolStripMenuItem 全部关闭ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem价格汇总;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_本日价格汇总;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem按天统计;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton_view_note;
        private System.Windows.Forms.ToolStripButton toolStripButton_add_note;

    }
}

