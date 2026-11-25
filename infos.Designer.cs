namespace ytdlp
{
    partial class infos
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
            components = new System.ComponentModel.Container();
            timg = new PictureBox();
            title = new Label();
            uploader = new Label();
            ok = new Button();
            cancel = new Button();
            outputFormat = new ComboBox();
            label1 = new Label();
            longth = new Label();
            fullTitle = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)timg).BeginInit();
            SuspendLayout();
            // 
            // timg
            // 
            timg.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            timg.Location = new Point(1, 121);
            timg.Name = "timg";
            timg.Size = new Size(796, 291);
            timg.SizeMode = PictureBoxSizeMode.Zoom;
            timg.TabIndex = 0;
            timg.TabStop = false;
            // 
            // title
            // 
            title.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            title.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 136);
            title.Location = new Point(12, 9);
            title.Name = "title";
            title.Size = new Size(774, 44);
            title.TabIndex = 1;
            title.Text = "正在載入影片標題...";
            title.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // uploader
            // 
            uploader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            uploader.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            uploader.Location = new Point(12, 53);
            uploader.Name = "uploader";
            uploader.Size = new Size(628, 41);
            uploader.TabIndex = 2;
            uploader.Text = "正在載入影片詳細資料...";
            uploader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ok
            // 
            ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok.BackColor = Color.FromArgb(58, 129, 235);
            ok.DialogResult = DialogResult.OK;
            ok.FlatStyle = FlatStyle.Flat;
            ok.Font = new Font("Microsoft JhengHei UI", 10F);
            ok.ForeColor = Color.White;
            ok.Location = new Point(690, 439);
            ok.Name = "ok";
            ok.Size = new Size(96, 41);
            ok.TabIndex = 3;
            ok.Text = "下載";
            ok.UseVisualStyleBackColor = false;
            ok.Click += ok_Click;
            // 
            // cancel
            // 
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancel.DialogResult = DialogResult.Cancel;
            cancel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            cancel.FlatStyle = FlatStyle.Flat;
            cancel.Font = new Font("Microsoft JhengHei UI", 10F);
            cancel.ForeColor = Color.FromArgb(51, 65, 85);
            cancel.Location = new Point(588, 439);
            cancel.Name = "cancel";
            cancel.Size = new Size(96, 41);
            cancel.TabIndex = 4;
            cancel.Text = "取消";
            cancel.UseVisualStyleBackColor = true;
            // 
            // outputFormat
            // 
            outputFormat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            outputFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            outputFormat.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            outputFormat.FormattingEnabled = true;
            outputFormat.Items.AddRange(new object[] { ".mp4", ".mp3 (僅有音效)", ".ogg (僅有音效)", ".wav (僅有音效)" });
            outputFormat.Location = new Point(175, 440);
            outputFormat.Name = "outputFormat";
            outputFormat.Size = new Size(267, 38);
            outputFormat.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label1.Location = new Point(12, 443);
            label1.Name = "label1";
            label1.Size = new Size(157, 30);
            label1.TabIndex = 6;
            label1.Text = "檔案輸出格式";
            // 
            // longth
            // 
            longth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            longth.BackColor = Color.White;
            longth.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            longth.ForeColor = SystemColors.ControlText;
            longth.Location = new Point(646, 52);
            longth.Name = "longth";
            longth.Size = new Size(140, 42);
            longth.TabIndex = 7;
            longth.Text = "00:00";
            longth.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fullTitle
            // 
            fullTitle.BackColor = Color.DimGray;
            fullTitle.ForeColor = Color.WhiteSmoke;
            // 
            // infos
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(798, 496);
            Controls.Add(longth);
            Controls.Add(label1);
            Controls.Add(outputFormat);
            Controls.Add(cancel);
            Controls.Add(ok);
            Controls.Add(uploader);
            Controls.Add(title);
            Controls.Add(timg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "infos";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "影片資訊";
            Load += infos_Load;
            ((System.ComponentModel.ISupportInitialize)timg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox timg;
        private Label title;
        private Label uploader;
        private Button ok;
        private Button cancel;
        private ComboBox outputFormat;
        private Label label1;
        private Label longth;
        private ToolTip fullTitle;
    }
}