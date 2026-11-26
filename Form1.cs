using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using Windows.Storage;

namespace ytdlp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Panel> pnls = new List<Panel>();

        private static readonly HttpClient _httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromMinutes(2)
        };

        private static string GetYtDlpPath()
        {
            return Path.Combine(AppContext.BaseDirectory, "yt-dlp.exe");
        }

        public static async Task<bool> EnsureLatestYtDlpAsync(IProgress<string>? status = null)
        {
            string exePath = GetYtDlpPath();
            status?.Report("正在檢查更新...");

            string? localVersion = await GetLocalYtDlpVersionAsync(exePath);
            string? latestVersion = await GetLatestGitHubVersionAsync();

            if (string.IsNullOrEmpty(latestVersion))
            {
                if (!string.IsNullOrEmpty(localVersion))
                {
                    status?.Report($"無法連線檢查更新，使用現有版本 ({localVersion})");
                    return true;
                }

                status?.Report("正在擷取資訊...");
                return false;
            }

            if (!string.IsNullOrEmpty(localVersion) &&
                string.Equals(localVersion, latestVersion, StringComparison.OrdinalIgnoreCase))
            {
                status?.Report($"正在擷取資訊...");
                return true;
            }

            return await DownloadLatestYtDlpAsync(status);
        }

        async private void download_Click(object sender, EventArgs e)
        {
            string ytDlpPath = GetYtDlpPath();
            string ffmpegPath = GetFfmpegPath();

            Panel pnl = new Panel();
            Button bok = new Button();
            Button bcl = new Button();
            Label tt = new Label();
            Label dt = new Label();
            PictureBox pb = new PictureBox();

            pnl.BackColor = Color.White;
            pnl.Location = new Point(12, 12 + pnls.Count() * 82);
            pnl.Size = new Size(list.Width - 24, 74);
            pnl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnl.Paint += (_, pe) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1f);
                pe.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            };

            pb.Location = new Point(8, 8);
            pb.Size = new Size(102, 62);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BackColor = Color.FromArgb(241, 245, 249);

            int btnW = 78;
            int btnH = 38;
            int btnY = (pnl.Height - btnH) / 2;
            int rightMargin = 12;
            int gap = 8;

            bok.Text = "下載";
            bok.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bok.FlatStyle = FlatStyle.Flat;
            bok.FlatAppearance.BorderSize = 0;
            bok.BackColor = Color.LightGray;
            bok.Font = new Font("Microsoft JhengHei UI", 9.5f, FontStyle.Bold);
            bok.Size = new Size(btnW, btnH);
            bok.Location = new Point(pnl.Width - rightMargin - btnW, btnY);
            bok.Enabled = false;

            bcl.Text = "取消";
            bcl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            bcl.FlatStyle = FlatStyle.Flat;
            bcl.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            bcl.FlatAppearance.BorderSize = 1;
            bcl.BackColor = Color.FromArgb(248, 250, 252);
            bcl.ForeColor = Color.FromArgb(51, 65, 85);
            bcl.Font = new Font("Microsoft JhengHei UI", 9.5f);
            bcl.Size = new Size(btnW, btnH);
            bcl.Location = new Point(pnl.Width - rightMargin - btnW * 2 - gap, btnY);
            bcl.Click += (_, _) => { pnls.Remove(pnl); list.Controls.Remove(pnl); };

            int textLeft = pb.Right + 12;
            int textWidth = Math.Max(80, bcl.Left - textLeft - 12);

            tt.Text = targetUrl.Text;
            tt.Location = new Point(textLeft, 10);
            tt.Size = new Size(textWidth, 34);
            tt.Font = new Font("Microsoft JhengHei UI", 10.5f, FontStyle.Bold);
            tt.ForeColor = Color.FromArgb(15, 23, 42);
            tt.AutoSize = false;

            dt.Text = "正在擷取資訊...";
            dt.Location = new Point(textLeft, 46);
            dt.Size = new Size(textWidth, 24);
            dt.Font = new Font("Microsoft JhengHei UI", 8.5f);
            dt.ForeColor = Color.FromArgb(90, 106, 129);
            dt.AutoSize = false;

            pnl.Controls.Add(pb);
            pnl.Controls.Add(tt);
            pnl.Controls.Add(dt);
            pnl.Controls.Add(bok);
            pnl.Controls.Add(bcl);

            list.Controls.Add(pnl);

            pnls.Add(pnl);

            if (!File.Exists(ytDlpPath))
            {
                var progress = new Progress<string>(msg => dt.Text = msg);
                bool ok = await DownloadLatestYtDlpAsync(progress);
                if (!ok) return;
            }

            if (!File.Exists(ffmpegPath))
            {
                var progress = new Progress<string>(msg => dt.Text = msg);
                bool ok = await EnsureFfmpegAsync(progress);
                if (!ok) return;
            }

            if (File.Exists(ytDlpPath))
            {
                DateTime lastWrite = File.GetLastWriteTimeUtc(ytDlpPath);
                TimeSpan age = DateTime.UtcNow - lastWrite;

                if (age > TimeSpan.FromMinutes(10))
                {
                    var progress = new Progress<string>(msg => dt.Text = msg);
                    await EnsureLatestYtDlpAsync(progress);

                    try
                    {
                        File.SetLastWriteTimeUtc(ytDlpPath, DateTime.UtcNow);
                    }
                    catch { }
                }
            }

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "yt-dlp.exe",
                    Arguments = $"--dump-json --no-warnings \"{targetUrl.Text}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            string jsonOutput = await process.StandardOutput.ReadToEndAsync();
            string errorOutput = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (process.ExitCode == 0 && !string.IsNullOrEmpty(jsonOutput))
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonOutput))
                {
                    JsonElement root = doc.RootElement;

                    string title = root.GetProperty("title").GetString();
                    string uploader = root.GetProperty("uploader").GetString();
                    string thumbnail = root.GetProperty("thumbnail").GetString();
                    string duration = root.GetProperty("duration_string").GetString();

                    string currentUrl = targetUrl.Text;
                    string currentSavePath = savePath.Text;
                    string formattedDuration = formatDuration(duration);
                    string infoLine = "時長: " + formattedDuration + " 上傳者: " + uploader;

                    tt.Text = title;
                    dt.Text = infoLine;

                    bok.Click += (_, _) =>
                    {
                        handleDownload(title, uploader, thumbnail, formattedDuration, currentUrl, currentSavePath, dt, infoLine, bok, bcl);
                    };
                    bok.Enabled = true;
                    bok.BackColor = Color.FromArgb(97, 216, 242);

                    try
                    {
                        pb.LoadAsync(thumbnail);
                    }
                    catch { }
                }
            }
            else
            {
                tt.Text = "下載失敗: 連結無效";
                dt.Text = "";

                bcl.Text = "完成";
                bok.BackColor = Color.LightGray;
                bok.Enabled = false;
            }
        }

        private static string formatDuration(string duration)
        {
            string result = "00:00";

            if (duration.Length < 3) result = "00:" + duration;
            if (duration.Length == 4) result = "0" + duration;
            else result = duration;

            return result;
        }

        private static string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(c, '_');
            }
            return name.Trim();
        }

        async private void handleDownload(
            string title,
            string uploader,
            string thumbnail,
            string duration,
            string videoURL,
            string currentSavePath,
            Label dt,
            string dttext,
            Button bok,
            Button bcl)
        {
            string safeTitle = SanitizeFileName(title);
            string ext = Program.outputSetting.Count() > 0 ? Program.outputSetting[0].ToLower() : ".mp4";
            string expectedFile = Path.Combine(currentSavePath, safeTitle + ext);

            if (Program.outputSetting.Count() > 0 && File.Exists(expectedFile))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = expectedFile,
                    UseShellExecute = true
                });

                bok.Text = "開啟";
                bok.Enabled = true;
                bcl.Text = "完成";
                bcl.Enabled = true;

                return;
            }

            if (new infos(thumbnail, title, uploader, duration).ShowDialog() == DialogResult.OK)
            {
                string selectedExt = Program.outputSetting.Count() > 0 ? Program.outputSetting[0].ToLower() : "auto";

                bok.Enabled = false;
                bcl.Enabled = false;
                bok.BackColor = Color.LightGray;

                dt.Text = "正在下載... (" + selectedExt + ")";

                string arguments;
                switch (selectedExt)
                {
                    case ".mp4":
                        arguments = "-f \"bv+ba/b\" --merge-output-format mp4";
                        break;
                    case ".mp3":
                        arguments = "-x --audio-format mp3 --audio-quality 0";
                        break;
                    case ".wav":
                        arguments = "-x --audio-format wav";
                        break;
                    case ".ogg":
                        arguments = "-x --audio-format vorbis";
                        break;
                    default:
                        arguments = "-f best";
                        break;
                }

                string finalArgs = $"{arguments} -P \"{currentSavePath}\" -o \"%(title)s.%(ext)s\" \"{videoURL}\" --no-warnings";

                using Process p = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = GetYtDlpPath(),
                        Arguments = finalArgs,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        CreateNoWindow = true
                    }
                };

                p.Start();

                var outputTask = Task.Run(() =>
                {
                    while (!p.StandardOutput.EndOfStream)
                    {
                        string? line = p.StandardOutput.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        if (line.Contains("[download]") && line.Contains('%'))
                        {
                            int pctIndex = line.IndexOf('%');
                            int startIndex = line.LastIndexOf(' ', pctIndex);
                            string progressText = startIndex >= 0
                                ? line.Substring(startIndex + 1, pctIndex - startIndex).Trim()
                                : "";

                            if (!string.IsNullOrEmpty(progressText) && !dt.IsDisposed)
                            {
                                dt.Invoke(() =>
                                {
                                    if (!dt.IsDisposed)
                                        dt.Text = $"正在下載 {progressText} ({selectedExt})";
                                });
                            }
                        }
                        else if (line.Contains("[Merger]") || line.Contains("[ExtractAudio]"))
                        {
                            if (!dt.IsDisposed)
                            {
                                dt.Invoke(() =>
                                {
                                    if (!dt.IsDisposed)
                                        dt.Text = $"正在轉檔 ({selectedExt})";
                                });
                            }
                        }
                    }
                });

                await Task.WhenAll(outputTask, p.WaitForExitAsync());

                if (!bok.IsDisposed)
                {
                    bok.Text = "開啟";
                    bok.Enabled = true;
                    bok.BackColor = Color.FromArgb(97, 216, 242);
                }

                if (!bcl.IsDisposed)
                {
                    bcl.Text = "完成";
                    bcl.Enabled = true;
                }

                if (!dt.IsDisposed)
                {
                    dt.Text = dttext;
                }
            }
        }

        private static string GetFfmpegPath()
        {
            return Path.Combine(AppContext.BaseDirectory, "ffmpeg.exe");
        }

        public static async Task<bool> EnsureFfmpegAsync(IProgress<string>? status = null)
        {
            string ffmpegPath = GetFfmpegPath();
            if (File.Exists(ffmpegPath)) return true;

            const string zipUrl = "https://github.com/FFmpeg-Builds/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip";
            string tempZip = Path.Combine(Path.GetTempPath(), $"ffmpeg_{Guid.NewGuid():N}.zip");
            string tempExtractDir = Path.Combine(Path.GetTempPath(), $"ffmpeg_extract_{Guid.NewGuid():N}");

            try
            {
                status?.Report("正在下載 ffmpeg... 0%");

                using var request = new HttpRequestMessage(HttpMethod.Get, zipUrl);
                request.Headers.UserAgent.ParseAdd("WinForms-YtDlp-App");

                using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                long? totalBytes = response.Content.Headers.ContentLength;
                long readBytes = 0;
                int lastPct = -1;
                byte[] buffer = new byte[81920];

                await using (var input = await response.Content.ReadAsStreamAsync())
                await using (var output = new FileStream(tempZip, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    int bytesRead;
                    while ((bytesRead = await input.ReadAsync(buffer)) > 0)
                    {
                        await output.WriteAsync(buffer.AsMemory(0, bytesRead));
                        readBytes += bytesRead;

                        if (totalBytes.HasValue && totalBytes.Value > 0)
                        {
                            int pct = (int)(readBytes * 100 / totalBytes.Value);
                            if (pct != lastPct)
                            {
                                lastPct = pct;
                                status?.Report($"正在下載 ffmpeg... {pct}%");
                            }
                        }
                        else
                        {
                            double mb = readBytes / (1024.0 * 1024.0);
                            status?.Report($"正在下載 ffmpeg... {mb:F1} MB");
                        }
                    }
                }

                status?.Report("正在解壓縮 ffmpeg...");
                System.IO.Compression.ZipFile.ExtractToDirectory(tempZip, tempExtractDir, overwriteFiles: true);

                string? foundExe = Directory.GetFiles(tempExtractDir, "ffmpeg.exe", SearchOption.AllDirectories)
                                            .FirstOrDefault();

                if (string.IsNullOrEmpty(foundExe))
                {
                    status?.Report("找不到 ffmpeg.exe");
                    return false;
                }

                File.Copy(foundExe, ffmpegPath, overwrite: true);
                return true;
            }
            catch (Exception ex)
            {
                status?.Report($"ffmpeg 下載失敗: {ex.Message}");
                return false;
            }
            finally
            {
                try { if (File.Exists(tempZip)) File.Delete(tempZip); } catch { }
                try { if (Directory.Exists(tempExtractDir)) Directory.Delete(tempExtractDir, recursive: true); } catch { }
            }
        }

        public static async Task<bool> DownloadLatestYtDlpAsync(IProgress<string>? status = null)
        {
            const string url = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
            string targetPath = GetYtDlpPath();
            string tempPath = targetPath + ".tmp";

            try
            {
                status?.Report("正在下載 yt-dlp... 0%");

                using var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.UserAgent.ParseAdd("WinForms-YtDlp-Updater");

                using var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                long? totalBytes = response.Content.Headers.ContentLength;
                long readBytes = 0;
                byte[] buffer = new byte[81920];

                await using var input = await response.Content.ReadAsStreamAsync();
                await using var output = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None);

                int bytesRead;
                while ((bytesRead = await input.ReadAsync(buffer)) > 0)
                {
                    await output.WriteAsync(buffer.AsMemory(0, bytesRead));
                    readBytes += bytesRead;

                    if (totalBytes.HasValue && totalBytes.Value > 0)
                    {
                        int pct = (int)(readBytes * 100 / totalBytes.Value);
                        status?.Report($"正在下載 yt-dlp... {pct}%");
                    }
                }

                output.Close();

                if (new FileInfo(tempPath).Length < 100_000)
                {
                    throw new InvalidDataException("下載的檔案大小異常。");
                }

                File.Move(tempPath, targetPath, overwrite: true);
                status?.Report("正在擷取資訊...");
                return true;
            }
            catch (Exception ex)
            {
                if (File.Exists(tempPath))
                {
                    try { File.Delete(tempPath); } catch { }
                }
                status?.Report($"yt-dlp 下載失敗，請稍後再試一次: {ex.Message}");
                return false;
            }
        }

        private static async Task<string?> GetLatestGitHubVersionAsync()
        {
            const string apiUrl = "https://api.github.com/repos/yt-dlp/yt-dlp/releases/latest";

            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
                request.Headers.UserAgent.ParseAdd("WinForms-YtDlp-App");
                request.Headers.Accept.ParseAdd("application/vnd.github+json");

                using var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                await using var stream = await response.Content.ReadAsStreamAsync();
                using var doc = await JsonDocument.ParseAsync(stream);

                if (doc.RootElement.TryGetProperty("tag_name", out var tagProp))
                {
                    return tagProp.GetString()?.Trim();
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        private static async Task<string?> GetLocalYtDlpVersionAsync(string exePath)
        {
            if (!File.Exists(exePath)) return null;

            try
            {
                using var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = exePath,
                        Arguments = "--version",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = await process.StandardOutput.ReadToEndAsync();
                await process.WaitForExitAsync();

                if (process.ExitCode != 0) return null;
                return output.Trim();
            }
            catch
            {
                return null;
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Multiselect = false;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                savePath.Text = fbd.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string downloads = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\ytdlps";

            savePath.Text = downloads;

            string? exePath = Environment.ProcessPath;
            if (!string.IsNullOrEmpty(exePath) && File.Exists(exePath + ".old"))
            {
                try
                {
                    File.Delete(exePath + ".old");
                }
                catch { }
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            new setting().ShowDialog();
        }
    }
}
