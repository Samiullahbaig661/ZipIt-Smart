namespace ZipITSmart.UI
{
    partial class DecompressionPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDecompress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecompressionPage));
            cmbType = new ComboBox();
            txtInput = new TextBox();
            btnBrowse = new Button();
            btnDecompress = new Button();
            label2 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            button4 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold);
            cmbType.Items.AddRange(new object[] { "File", "Folder", "Image" });
            cmbType.Location = new Point(161, 92);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(283, 32);
            cmbType.TabIndex = 1;
            // 
            // txtInput
            // 
            txtInput.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold);
            txtInput.Location = new Point(161, 154);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(283, 32);
            txtInput.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.DarkCyan;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Britannic Bold", 12F);
            btnBrowse.Location = new Point(31, 153);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(109, 30);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnDecompress
            // 
            btnDecompress.BackColor = Color.DarkCyan;
            btnDecompress.BackgroundImageLayout = ImageLayout.Center;
            btnDecompress.FlatStyle = FlatStyle.Popup;
            btnDecompress.Font = new Font("Gill Sans Ultra Bold", 14.25F);
            btnDecompress.ForeColor = Color.White;
            btnDecompress.Location = new Point(128, 223);
            btnDecompress.Name = "btnDecompress";
            btnDecompress.Size = new Size(241, 41);
            btnDecompress.TabIndex = 4;
            btnDecompress.Text = "DECOMPRESS";
            btnDecompress.UseVisualStyleBackColor = false;
            btnDecompress.Click += btnDecompress_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(152, 14);
            label2.Name = "label2";
            label2.Size = new Size(264, 45);
            label2.TabIndex = 7;
            label2.Text = "Decompressor";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkCyan;
            button1.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Britannic Bold", 11F);
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(31, 90);
            button1.Name = "button1";
            button1.Size = new Size(109, 32);
            button1.TabIndex = 8;
            button1.Text = "Select Type";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnBrowse);
            panel1.Controls.Add(txtInput);
            panel1.Controls.Add(cmbType);
            panel1.Controls.Add(btnDecompress);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 322);
            panel1.TabIndex = 9;
            // 
            // button4
            // 
            button4.BackColor = Color.Maroon;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(430, 272);
            button4.Name = "button4";
            button4.Size = new Size(69, 35);
            button4.TabIndex = 5;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // DecompressionPage
            // 
            BackColor = Color.Black;
            ClientSize = new Size(539, 346);
            Controls.Add(panel1);
            Name = "DecompressionPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Decompression";
            Load += DecompressionPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        private Label label2;
        private Button button1;
        private Panel panel1;
        private Button button4;
    }
}