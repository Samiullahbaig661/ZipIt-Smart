using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZipITSmart.UI
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Compressor_Click(object sender, EventArgs e)
        {
            CompressionPage compressForm = new CompressionPage();
            compressForm.Show();
            this.Hide();
        }

        private void Decompressor_Click(object sender, EventArgs e)
        {
            DecompressionPage decompressForm = new DecompressionPage();
            decompressForm.Show();
            this.Hide();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
