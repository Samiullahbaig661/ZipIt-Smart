using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompressorAndDecompressor
{
    public partial class Decompress: Form
    {
        public Decompress()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFolderPath.Text))
                {
                    MessageBox.Show("No Huffman files selected");
                    return;
                }

                string[] huffFiles = txtFolderPath.Text
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                if (huffFiles.Length == 0)
                {
                    MessageBox.Show("No valid Huffman files found");
                    return;
                }

                string outputFolder;
                using (var folderDialog = new FolderBrowserDialog())
                {
                    folderDialog.Description = "Select folder to save decompressed files";

                    if (folderDialog.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Output folder not selected");
                        return;
                    }

                    outputFolder = folderDialog.SelectedPath;
                }

                var decompressor = new FolderDecompressor();

                foreach (string archivePath in huffFiles)
                {
                    decompressor.DecompressArchive(archivePath, outputFolder);
                }

                MessageBox.Show("All archives were decompressed successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while decompressing\n\n" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Huffman Files (*.huff)|*.huff";
                dialog.Title = "Select Huffman Files";
                dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtFolderPath.Clear();

                    foreach (string file in dialog.FileNames)
                    {
                        txtFolderPath.AppendText(file + Environment.NewLine);
                    }
                }
            }
        }
    }
}
