namespace ZipITSmart.UI
{
    partial class CompressionPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCompress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompressionPage));
            cmbType = new ComboBox();
            txtInput = new TextBox();
            btnBrowse = new Button();
            btnCompress = new Button();
            label2 = new Label();
            panel1 = new Panel();
            button4 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbType.Items.AddRange(new object[] { "File", "Folder", "Image" });
            cmbType.Location = new Point(161, 91);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(283, 27);
            cmbType.TabIndex = 1;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // txtInput
            // 
            txtInput.Font = new Font("Times New Roman", 12.75F, FontStyle.Bold);
            txtInput.Location = new Point(162, 156);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(283, 27);
            txtInput.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(192, 64, 0);
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnBrowse.FlatAppearance.BorderSize = 0;
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Britannic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowse.ImageAlign = ContentAlignment.TopCenter;
            btnBrowse.Location = new Point(29, 153);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(101, 30);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCompress
            // 
            btnCompress.BackColor = Color.FromArgb(192, 64, 0);
            btnCompress.BackgroundImageLayout = ImageLayout.Center;
            btnCompress.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            btnCompress.FlatAppearance.BorderSize = 0;
            btnCompress.FlatStyle = FlatStyle.Popup;
            btnCompress.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCompress.ForeColor = Color.White;
            btnCompress.Location = new Point(144, 217);
            btnCompress.Name = "btnCompress";
            btnCompress.Size = new Size(219, 46);
            btnCompress.TabIndex = 4;
            btnCompress.Text = "COMPRESS";
            btnCompress.UseVisualStyleBackColor = false;
            btnCompress.Click += btnCompress_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(162, 14);
            label2.Name = "label2";
            label2.Size = new Size(180, 36);
            label2.TabIndex = 6;
            label2.Text = "Compressor";
            label2.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(cmbType);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnBrowse);
            panel1.Controls.Add(txtInput);
            panel1.Controls.Add(btnCompress);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(515, 322);
            panel1.TabIndex = 7;
            // 
            // button4
            // 
            button4.BackColor = Color.Maroon;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(430, 271);
            button4.Name = "button4";
            button4.Size = new Size(69, 35);
            button4.TabIndex = 8;
            button4.Text = "Back";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(192, 64, 0);
            button1.FlatAppearance.BorderColor = Color.FromArgb(192, 64, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Britannic Bold", 11F);
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(29, 88);
            button1.Name = "button1";
            button1.Size = new Size(101, 32);
            button1.TabIndex = 7;
            button1.Text = "Select Type";
            button1.UseVisualStyleBackColor = false;
            // 
            // CompressionPage
            // 
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(539, 346);
            Controls.Add(panel1);
            Name = "CompressionPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compression";
            Load += CompressionPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        private Label label2;
        private Panel panel1;
        private Button button1;
        private Button button4;
    }
}