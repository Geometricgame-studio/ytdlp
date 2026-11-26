using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ytdlp
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void choose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.Multiselect = false;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                defaultPath.Text = fbd.SelectedPath;
            }
        }

        private void openAppFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(AppContext.BaseDirectory))
            {
                Process.Start("explorer.exe", AppContext.BaseDirectory);
            }
        }

        private void checkUpdate_Click(object sender, EventArgs e)
        {
            new updater().ShowDialog();
        }
    }
}
