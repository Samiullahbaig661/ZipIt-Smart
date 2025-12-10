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
            button4.Enabled = false;
            button2.Enabled = false;
            button6.Enabled = false;
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
                //1) Select an Archieve
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

        private void button4_Click(object sender, EventArgs e)
        {
            string imagePath = textBox2.Text;

            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
            {
                MessageBox.Show("Please select a valid image file first.");
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Huffman Compressed Image (*.huff)|*.huff";
                saveDialog.Title = "Save Compressed Image";
                saveDialog.FileName = Path.GetFileNameWithoutExtension(imagePath) + ".huff";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor; // Show wait cursor

                        ImageCompressorDecompressor compressor = new ImageCompressorDecompressor();
                        compressor.CompressImage(imagePath, saveDialog.FileName);

                        // Calculate compression ratio
                        long originalSize = new FileInfo(imagePath).Length;
                        long compressedSize = new FileInfo(saveDialog.FileName).Length;
                        double ratio = (1 - (double)compressedSize / originalSize) * 100;

                        MessageBox.Show($"Image compressed successfully!\n\n" +
                                      $"Original: {originalSize / 1024} KB\n" +
                                      $"Compressed: {compressedSize / 1024} KB\n" +
                                      $"Reduction: {ratio:F1}%\n\n" +
                                      $"Saved as: {Path.GetFileName(saveDialog.FileName)}",
                                      "Compression Complete",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while compressing image: " + ex.Message,
                                      "Error",
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
       

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openDialog.Title = "Select Image File";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openDialog.FileName;
                    button4.Enabled = true; // Enable compress button

                    // Show file info in message box
                    FileInfo fileInfo = new FileInfo(openDialog.FileName);
                    MessageBox.Show($"Image selected:\n" +
                                  $"Name: {Path.GetFileName(openDialog.FileName)}\n" +
                                  $"Size: {fileInfo.Length / 1024} KB\n" +
                                  $"Type: {Path.GetExtension(openDialog.FileName).ToUpper()}",
                                  "Image Selected",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 back = new Form1();
            back.Show();
            this.Hide();
        }
    }
}
