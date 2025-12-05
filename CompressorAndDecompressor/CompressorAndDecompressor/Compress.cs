using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompressorAndDecompressor
{
    public partial class Compress: Form
    {
        public Compress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folderPath = txtFolderPath.Text;

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                MessageBox.Show("Please select a valid folder first.");
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Huffman Archive (*.huff)|*.huff";
                saveDialog.Title = "Save Compressed Folder";
                saveDialog.FileName = Path.GetFileName(folderPath) + ".huff";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var compressor = new CompressorAndDecompressor.FolderCompressor();
                        compressor.CompressFolder(folderPath, saveDialog.FileName);

                        MessageBox.Show("Folder compressed successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while compressing: " + ex.Message);
                    }
                }
            }
        }
    }
}
