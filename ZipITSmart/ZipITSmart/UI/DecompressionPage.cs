using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZipITSmart.Models;
using ZipITSmart.Services;

namespace ZipITSmart.UI
{
    public partial class DecompressionPage : Form
    {
        private readonly CompressionDispatcher _dispatcher = new CompressionDispatcher();
        public DecompressionPage()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 1;
            button1.Enabled = false;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog();
            ofd.Filter = "Compressed Files|*.huf";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
                txtInput.Text = ofd.FileName;
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            try
            {
                string inputPath = txtInput.Text;
                if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath))
                {
                    MessageBox.Show("Select a valid input file.");
                    return;
                }

                byte marker;
                using (var fs = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                {
                    marker = (byte)fs.ReadByte();
                }

                string outputPath = "";

                if (marker == (byte)'D')
                {
                    using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                    {
                        fbd.Description = "Select folder to save decompressed files";
                        if (fbd.ShowDialog() == DialogResult.OK)
                            outputPath = fbd.SelectedPath;
                        else
                            return;
                    }
                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Title = "Select location for decompressed file";

                        if (marker == (byte)'I')
                            sfd.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
                        else
                            sfd.Filter = "All Files|*.*";

                        sfd.FileName = Path.GetFileNameWithoutExtension(inputPath);

                        if (sfd.ShowDialog() == DialogResult.OK)
                            outputPath = sfd.FileName;
                        else
                            return;
                    }
                }

                CompressionResult result = _dispatcher.Decompress(inputPath, outputPath);

                MessageBox.Show($"Decompression successful!\nOriginal Size: {result.OriginalSize} bytes\nCompressed Size: {result.CompressedSize} bytes");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Decompression failed: {ex.Message}");
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Back_btn_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void DecompressionPage_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}