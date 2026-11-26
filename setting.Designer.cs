namespace ytdlp
{
    partial class setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setting));
            label1 = new Label();
            panel1 = new Panel();
            choose = new Button();
            label3 = new Label();
            defaultPath = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            openAppFolder = new Button();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            checkUpdate = new Button();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(22, 20);
            label1.Name = "label1";
            label1.Size = new Size(82, 41);
            label1.TabIndex = 0;
            label1.Text = "設定";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(choose);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(defaultPath);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(22, 74);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(751, 134);
            panel1.TabIndex = 1;
            // 
            // choose
            // 
            choose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            choose.BackColor = Color.White;
            choose.FlatAppearance.BorderSize = 0;
            choose.FlatStyle = FlatStyle.Flat;
            choose.Location = new Point(653, 90);
            choose.Name = "choose";
            choose.Size = new Size(85, 31);
            choose.TabIndex = 5;
            choose.Text = "選擇";
            choose.UseVisualStyleBackColor = false;
            choose.Click += choose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 47);
            label3.Name = "label3";
            label3.Size = new Size(280, 23);
            label3.TabIndex = 4;
            label3.Text = "決定下載器啟動後的預設下載位置";
            // 
            // defaultPath
            // 
            defaultPath.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            defaultPath.BackColor = Color.White;
            defaultPath.BorderStyle = BorderStyle.None;
            defaultPath.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            defaultPath.Location = new Point(15, 90);
            defaultPath.Name = "defaultPath";
            defaultPath.PlaceholderText = "輸入資料夾路徑...";
            defaultPath.Size = new Size(632, 31);
            defaultPath.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.Location = new Point(13, 10);
            label2.Name = "label2";
            label2.Size = new Size(157, 30);
            label2.TabIndex = 2;
            label2.Text = "預設下載路徑";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(openAppFolder);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(22, 223);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(751, 85);
            panel2.TabIndex = 6;
            // 
            // openAppFolder
            // 
            openAppFolder.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            openAppFolder.BackColor = Color.White;
            openAppFolder.FlatAppearance.BorderSize = 0;
            openAppFolder.FlatStyle = FlatStyle.Flat;
            openAppFolder.Location = new Point(643, 23);
            openAppFolder.Name = "openAppFolder";
            openAppFolder.Size = new Size(95, 42);
            openAppFolder.TabIndex = 6;
            openAppFolder.Text = "開啟";
            openAppFolder.UseVisualStyleBackColor = false;
            openAppFolder.Click += openAppFolder_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 49);
            label4.Name = "label4";
            label4.Size = new Size(296, 23);
            label4.TabIndex = 4;
            label4.Text = "開啟檔案總管以查看本APP的資料夾";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label5.Location = new Point(15, 10);
            label5.Name = "label5";
            label5.Size = new Size(339, 30);
            label5.TabIndex = 2;
            label5.Text = "管理 ffmpeg 和 yt-dlp 的位置";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(checkUpdate);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(22, 324);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(751, 85);
            panel3.TabIndex = 7;
            // 
            // checkUpdate
            // 
            checkUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            checkUpdate.BackColor = Color.White;
            checkUpdate.FlatAppearance.BorderSize = 0;
            checkUpdate.FlatStyle = FlatStyle.Flat;
            checkUpdate.Location = new Point(611, 22);
            checkUpdate.Name = "checkUpdate";
            checkUpdate.Size = new Size(127, 42);
            checkUpdate.TabIndex = 6;
            checkUpdate.Text = "檢查更新";
            checkUpdate.UseVisualStyleBackColor = false;
            checkUpdate.Click += checkUpdate_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 52);
            label6.Name = "label6";
            label6.Size = new Size(236, 23);
            label6.TabIndex = 4;
            label6.Text = "檢查並更新 Youtube 下載器";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label7.Location = new Point(15, 10);
            label7.Name = "label7";
            label7.Size = new Size(109, 30);
            label7.TabIndex = 2;
            label7.Text = "檢查更新";
            // 
            // setting
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 441);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "setting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube 下載器 - 設定";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox defaultPath;
        private Label label3;
        private Button choose;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Button openAppFolder;
        private Panel panel3;
        private Button checkUpdate;
        private Label label6;
        private Label label7;
    }
}