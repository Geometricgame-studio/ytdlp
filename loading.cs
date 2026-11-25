using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ytdlp
{
    public partial class loading : Form
    {
        public loading()
        {
            InitializeComponent();
        }

        private async void loading_Load(object sender, EventArgs e)
        {
            while (true)
            {
                this.Text = "載入中";
                await Task.Delay(500);
                this.Text = "載入中.";
                await Task.Delay(500);
                this.Text = "載入中..";
                await Task.Delay(500);
                this.Text = "載入中...";
                await Task.Delay(500);
            }
        }
    }
}
