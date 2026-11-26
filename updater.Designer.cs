namespace ytdlp
{
    partial class updater
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
            progressBar1 = new ProgressBar();
            title = new Label();
            status = new Label();
            ok = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 122);
            progressBar1.MarqueeAnimationSpeed = 10;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(611, 34);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            progressBar1.Value = 100;
            // 
            // title
            // 
            title.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 136);
            title.Location = new Point(26, 18);
            title.Name = "title";
            title.Size = new Size(597, 44);
            title.TabIndex = 1;
            title.Text = "正在檢查更新..";
            // 
            // status
            // 
            status.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 136);
            status.Location = new Point(26, 62);
            status.Name = "status";
            status.Size = new Size(577, 61);
            status.TabIndex = 2;
            // 
            // ok
            // 
            ok.BackColor = Color.DeepSkyBlue;
            ok.FlatAppearance.BorderSize = 0;
            ok.FlatStyle = FlatStyle.Flat;
            ok.ForeColor = Color.White;
            ok.Location = new Point(494, 114);
            ok.Name = "ok";
            ok.Size = new Size(109, 34);
            ok.TabIndex = 3;
            ok.Text = "關閉";
            ok.UseVisualStyleBackColor = false;
            ok.Visible = false;
            ok.Click += ok_Click;
            // 
            // updater
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(611, 156);
            ControlBox = false;
            Controls.Add(ok);
            Controls.Add(status);
            Controls.Add(title);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "updater";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "正在檢查更新";
            Load += updater_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar1;
        private Label title;
        private Label status;
        private Button ok;
    }
}