using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;

namespace ytdlp
{
    public partial class infos : Form
    {
        public infos(string imgurl, string titlet, string uploadert, string duration)
        {
            InitializeComponent();

            load_timg(imgurl);

            this.Text = "影片預覽 - " + titlet;
            title.Text = TruncateToMaxLines(title, titlet, 1);
            fullTitle.SetToolTip(title, titlet);
            uploader.Text = "由 " + uploadert + " 發布";
            longth.Text = "🕓 " + duration;
        }

        private static string TruncateToMaxLines(Label lbl, string text, int maxLines)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            int lineHeight = TextRenderer.MeasureText("A", lbl.Font).Height;
            int maxHeight = lineHeight * maxLines;
            Size proposedSize = new Size(lbl.Width, int.MaxValue);

            if (TextRenderer.MeasureText(text, lbl.Font, proposedSize, TextFormatFlags.WordBreak).Height <= maxHeight)
            {
                return text;
            }

            string ellipsis = "...";
            int low = 0;
            int high = text.Length;
            string best = ellipsis;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                string candidate = text.Substring(0, mid).TrimEnd() + ellipsis;
                int h = TextRenderer.MeasureText(candidate, lbl.Font, proposedSize, TextFormatFlags.WordBreak).Height;

                if (h <= maxHeight)
                {
                    best = candidate;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return best;
        }

        async private void load_timg(string url)
        {
            timg.Load(url);
        }

        private void infos_Load(object sender, EventArgs e)
        {
            outputFormat.Text = ".mp4";
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Program.outputSetting = new List<string> { outputFormat.Text.Substring(0, 4) };
        }
    }
}
