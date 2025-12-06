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

        private void txtFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Archive (.huff) select karo
                string archivePath;
                using (var openDialog = new OpenFileDialog())
                {
                    openDialog.Filter = "Huffman Archive (*.huff)|*.huff";
                    openDialog.Title = "Select Huffman Archive";

                    if (openDialog.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Archive select nahi kia. Operation cancel.");
                        return;
                    }

                    archivePath = openDialog.FileName;
                }

                // 2) Output folder select karo
                string outputFolder;
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select folder to save decompressed files";

                    if (folderDialog.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Output folder select nahi kia. Operation cancel.");
                        return;
                    }

                    outputFolder = folderDialog.SelectedPath;
                }

                // 3) Actual decompression
                var decompressor = new CompressorAndDecompressor.FolderDecompressor();
                decompressor.DecompressArchive(archivePath, outputFolder);

                MessageBox.Show("Archive decompressed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while decompressing:\n\n" + ex.ToString());
            }
        }
    }
}
