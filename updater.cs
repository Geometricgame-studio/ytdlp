using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Windows.UI.ViewManagement;

namespace ytdlp
{
    public partial class updater : Form
    {
        public updater()
        {
            InitializeComponent();
        }

        private async Task<bool> HasNewVersionAsync()
        {
            const string versionUrl = "https://raw.githubusercontent.com/Geometricgame-studio/ytdlp/refs/heads/main/version.txt";

            string rawText = await Http.GetStringAsync(versionUrl);
            string remoteVersionText = rawText.Trim().TrimStart('\uFEFF', 'v', 'V');
            string currentVersionText = Program.version.Trim().TrimStart('\uFEFF', 'v', 'V');

            if (!Version.TryParse(remoteVersionText, out Version? remoteVer) ||
                !Version.TryParse(currentVersionText, out Version? currentVer))
            {
                return false;
            }

            return remoteVer > currentVer;
        }

        bool restart = false;

        async private void updater_Load(object sender, EventArgs e)
        {
            const string url = "https://github.com/Geometricgame-studio/ytdlp/releases/latest/download/ytdlp.exe";
            string savePath = Environment.ProcessPath + ".new";

            progressBar1.Value = 0;

            try
            {
                title.Text = "正在檢查更新...";

                bool needUpdate = await HasNewVersionAsync();
                if (!needUpdate)
                {
                    title.Text = $"目前已是最新版本";
                    status.Text = $"v{Program.version}";
                    this.Text = "目前已是最新版本";
                    return;
                }

                title.Text = "正在下載更新...";

                await DownloadFileWithProgressAsync(url, savePath);

                status.Text = "重新啟動 APP 以完成更新，這可能需要一些時間...";
                title.Text = "下載完成";
                this.Text = "下載完成";

                ok.Text = "重新啟動";

                restart = true;
            }
            catch (Exception ex)
            {
                title.Text = "下載失敗";
                status.Text = "請稍後再試一次";
                MessageBox.Show(ex.Message, "下載更新時發生錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
                ok.Visible = true;
            }
        }

        private static readonly System.Net.Http.HttpClient Http = new System.Net.Http.HttpClient();

        private async Task DownloadFileWithProgressAsync(string url, string savePath)
        {
            using HttpResponseMessage response = await Http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            long? totalBytes = response.Content.Headers.ContentLength;
            long totalRead = 0;
            byte[] buffer = new byte[8192];

            var progress = new Progress<long>(bytesRead =>
            {
                if (totalBytes is > 0)
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    int percent = Math.Clamp((int)(bytesRead * 100L / totalBytes.Value), 0, 100);
                    progressBar1.Value = percent;
                    status.Text = $"已下載: {percent}% ({bytesRead / 1024.0 / 1024.0:F2} MB)";
                    this.Text = $"正在更新 - {percent}%";
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    status.Text = $"已下載: {bytesRead / 1024.0 / 1024.0:F2} MB";
                    this.Text = "正在更新";
                }
            });

            await using Stream contentStream = await response.Content.ReadAsStreamAsync();
            await using FileStream fileStream = new FileStream(
                savePath, FileMode.Create, FileAccess.Write, FileShare.None, buffer.Length, useAsync: true);

            while (true)
            {
                int read = await contentStream.ReadAsync(buffer.AsMemory(0, buffer.Length));
                if (read == 0)
                    break;

                await fileStream.WriteAsync(buffer.AsMemory(0, read));
                totalRead += read;
                ((IProgress<long>)progress).Report(totalRead);
            }
        }

        private void InstallAndRestart(string currentExePath, string newExePath)
        {
            title.Text = "正在安裝新版本...";
            status.Text = "這可能需要一些時間...";

            string oldExePath = currentExePath + ".old";

            if (File.Exists(oldExePath))
                File.Delete(oldExePath);

            File.Move(currentExePath, oldExePath);

            try
            {
                File.Move(newExePath, currentExePath);
            }
            catch
            {
                if (File.Exists(oldExePath) && !File.Exists(currentExePath))
                    File.Move(oldExePath, currentExePath);
                throw;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = currentExePath,
                UseShellExecute = true
            });

            Application.Exit();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (restart)
            {
                string currentExePath = Environment.ProcessPath!;
                string newExePath = currentExePath + ".new";

                this.Text = "正在安裝新版本";

                Task.Delay(100);

                InstallAndRestart(currentExePath, newExePath);
            }
            else this.Close();
        }
    }
}
