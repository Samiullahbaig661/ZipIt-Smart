using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using ZipITSmart.Core.Archive;
using ZipITSmart.Models;
using ZipITSmart.Services;

namespace ZipITSmart.UI
{
    public partial class CompressionPage : Form
    {
        private readonly CompressionDispatcher _dispatcher = new CompressionDispatcher();
        public CompressionPage()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 1;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem == null)
            {
                MessageBox.Show("Please select a type from the dropdown.");
                return;
            }

            string type = cmbType.SelectedItem.ToString().ToLower();

            if (type == "folder")
            {
                using var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                    txtInput.Text = fbd.SelectedPath;
            }
            else 
            {
                using var ofd = new OpenFileDialog();
                ofd.Multiselect = false;

                if (type == "image")
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
                else
                    ofd.Filter = "All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                    txtInput.Text = ofd.FileName;
            }
        }
        private void btnCompress_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbType.SelectedItem == null)
                {
                    MessageBox.Show("Please select a type.");
                    return;
                }

                string type = cmbType.SelectedItem.ToString().ToLower();
                string inputPath = txtInput.Text;

                if (string.IsNullOrWhiteSpace(inputPath) || !File.Exists(inputPath) && !Directory.Exists(inputPath))
                {
                    MessageBox.Show("Select a valid input path.");
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Title = "Select output file location";

                    string defaultName = Path.GetFileNameWithoutExtension(inputPath);
                    sfd.FileName = defaultName + ".huf";

                    switch (type)
                    {
                        case "image":
                            sfd.Filter = "Compressed Image (*.huf)|*.huf";
                            break;
                        case "file":
                            sfd.Filter = "Compressed File (*.huf)|*.huf";
                            break;
                        case "folder":
                            sfd.Filter = "Compressed Folder (*.huf)|*.huf";
                            break;
                        default:
                            sfd.Filter = "Compressed (*.huf)|*.huf";
                            break;
                    }

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string outputPath = sfd.FileName;
                        CompressionResult result = _dispatcher.Compress(type, inputPath, outputPath);

                        MessageBox.Show($"Compression successful!\nOriginal Size: {result.OriginalSize} bytes\nCompressed Size: {result.CompressedSize} bytes\nRatio: {result.CompressionRatio:P2}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Compression failed: {ex.Message}");
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

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CompressionPage_Load(object sender, EventArgs e)
        {

        }
    }
}
