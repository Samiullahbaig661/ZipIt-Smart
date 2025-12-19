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
    public partial class Decompress : Form
    {
        public Decompress()
        {
            InitializeComponent();
            button7.Enabled = false;
            button4.Enabled = false;
            button6.Enabled = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                // Allow both image files and compressed .huff files
                openDialog.Filter = "All Supported Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.huff|" +
                                   "Image Files (*.jpg, *.jpeg, *.png, *.bmp, *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|" +
                                   "Compressed Files (*.huff)|*.huff|" +
                                   "All Files (*.*)|*.*";
                openDialog.Title = "Select Image File or Compressed File";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openDialog.FileName;
                    string extension = Path.GetExtension(openDialog.FileName).ToLower();

                    if (extension == ".huff")
                    {
                        // It's a compressed file - enable decompress button
                        button4.Enabled = true;

                        // Show message
                        FileInfo fileInfo = new FileInfo(openDialog.FileName);
                        MessageBox.Show($"Compressed file selected:\n\n" +
                                      $"File: {Path.GetFileName(openDialog.FileName)}\n" +
                                      $"Size: {fileInfo.Length / 1024} KB\n\n" +
                                      $"Click 'Decompress Image' to extract the image.",
                                      "Compressed File Selected",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    else
                    {
                        // It's a regular image file - disable decompress button
                        button4.Enabled = false;

                        // Show image info
                        FileInfo fileInfo = new FileInfo(openDialog.FileName);
                        MessageBox.Show($"Image file selected:\n\n" +
                                      $"Name: {Path.GetFileName(openDialog.FileName)}\n" +
                                      $"Size: {fileInfo.Length / 1024} KB\n" +
                                      $"Type: {extension.ToUpper()}",
                                      "Image Selected",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string compressedPath = textBox2.Text;

            if (string.IsNullOrWhiteSpace(compressedPath) || !File.Exists(compressedPath))
            {
                MessageBox.Show("Please select a compressed file first.",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

            // Check if it's a .huff file
            if (Path.GetExtension(compressedPath).ToLower() != ".huff")
            {
                MessageBox.Show("Please select a .huff compressed file to decompress.\n\n" +
                              "Only files with .huff extension can be decompressed.",
                              "Invalid File Type",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                return;
            }

            // Select where to save decompressed image
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "JPEG Image (*.jpg)|*.jpg|" +
                                   "PNG Image (*.png)|*.png|" +
                                   "Bitmap Image (*.bmp)|*.bmp|" +
                                   "GIF Image (*.gif)|*.gif|" +
                                   "All Files (*.*)|*.*";
                saveDialog.Title = "Save Decompressed Image";
                saveDialog.FileName = "decompressed_image";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor; // Show wait cursor

                        ImageCompressorDecompressor decompressor = new ImageCompressorDecompressor();
                        decompressor.DecompressImage(compressedPath, saveDialog.FileName);

                        // Show result
                        FileInfo decompressedFile = new FileInfo(saveDialog.FileName);
                        MessageBox.Show($"✅ Image decompressed successfully!\n\n" +
                                      $"Saved as: {Path.GetFileName(saveDialog.FileName)}\n" +
                                      $"Size: {decompressedFile.Length / 1024} KB\n" +
                                      $"Location: {Path.GetDirectoryName(saveDialog.FileName)}",
                                      "Decompression Complete",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Clear the textbox and disable button after successful decompression
                        textBox2.Text = "";
                        button4.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Decompression failed!\n\n" +
                                      $"Error: {ex.Message}\n\n" +
                                      $"This may not be a valid compressed image file.",
                                      "Decompression Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                    finally
                    {
                        Cursor = Cursors.Default; // Restore cursor
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 backToHome = new Form1();
            backToHome.Show();
            this.Hide();
        }
    }
}
    


