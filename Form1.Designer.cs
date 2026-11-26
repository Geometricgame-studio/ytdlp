namespace ytdlp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            download = new Button();
            targetUrl = new TextBox();
            list = new Panel();
            select = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            savePath = new TextBox();
            icon = new NotifyIcon(components);
            settings = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // download
            // 
            download.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            download.BackColor = Color.WhiteSmoke;
            download.FlatAppearance.BorderSize = 0;
            download.FlatStyle = FlatStyle.Flat;
            download.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            download.Location = new Point(1170, 12);
            download.Margin = new Padding(4);
            download.Name = "download";
            download.Size = new Size(143, 70);
            download.TabIndex = 0;
            download.Text = "下載";
            download.UseVisualStyleBackColor = false;
            download.Click += download_Click;
            // 
            // targetUrl
            // 
            targetUrl.BackColor = Color.WhiteSmoke;
            targetUrl.BorderStyle = BorderStyle.None;
            targetUrl.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
            targetUrl.Location = new Point(14, 17);
            targetUrl.Margin = new Padding(4);
            targetUrl.Name = "targetUrl";
            targetUrl.PlaceholderText = "輸入 URL...";
            targetUrl.Size = new Size(1107, 36);
            targetUrl.TabIndex = 1;
            // 
            // list
            // 
            list.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            list.AutoScroll = true;
            list.Location = new Point(15, 89);
            list.Margin = new Padding(4);
            list.Name = "list";
            list.Size = new Size(1310, 364);
            list.TabIndex = 2;
            // 
            // select
            // 
            select.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            select.BackColor = Color.WhiteSmoke;
            select.FlatAppearance.BorderSize = 0;
            select.FlatStyle = FlatStyle.Flat;
            select.Location = new Point(1170, 460);
            select.Margin = new Padding(4);
            select.Name = "select";
            select.Size = new Size(143, 70);
            select.TabIndex = 4;
            select.Text = "選擇";
            select.UseVisualStyleBackColor = false;
            select.Click += select_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(targetUrl);
            panel1.Location = new Point(26, 12);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1135, 70);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(savePath);
            panel2.Location = new Point(165, 460);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(996, 70);
            panel2.TabIndex = 6;
            // 
            // savePath
            // 
            savePath.BackColor = Color.WhiteSmoke;
            savePath.BorderStyle = BorderStyle.None;
            savePath.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 136);
            savePath.Location = new Point(14, 17);
            savePath.Margin = new Padding(4);
            savePath.Name = "savePath";
            savePath.PlaceholderText = "影片下載位置...";
            savePath.Size = new Size(1009, 36);
            savePath.TabIndex = 1;
            // 
            // icon
            // 
            icon.Icon = (Icon)resources.GetObject("icon.Icon");
            icon.Text = "Youtube 下載器";
            icon.Visible = true;
            // 
            // settings
            // 
            settings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            settings.BackColor = Color.WhiteSmoke;
            settings.FlatAppearance.BorderSize = 0;
            settings.FlatStyle = FlatStyle.Flat;
            settings.Location = new Point(15, 461);
            settings.Margin = new Padding(4);
            settings.Name = "settings";
            settings.Size = new Size(143, 70);
            settings.TabIndex = 7;
            settings.Text = "設定";
            settings.UseVisualStyleBackColor = false;
            settings.Click += settings_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1340, 542);
            Controls.Add(settings);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(select);
            Controls.Add(list);
            Controls.Add(download);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube 下載器";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button download;
        private TextBox targetUrl;
        private Panel list;
        private Button select;
        private Panel panel1;
        private Panel panel2;
        private TextBox savePath;
        private NotifyIcon icon;
        private Button settings;
    }
}
