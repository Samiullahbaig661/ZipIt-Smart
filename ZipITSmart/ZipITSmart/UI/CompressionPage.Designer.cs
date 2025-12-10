namespace ZipITSmart.UI
{
    partial class CompressionPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbType = new ComboBox();
            txtInput = new TextBox();
            btnBrowse = new Button();
            btnCompress = new Button();
            label1 = new Label();
            Back_btn = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.AddRange(new object[] { "File", "Folder", "Image" });
            cmbType.Location = new Point(147, 78);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(159, 23);
            cmbType.TabIndex = 1;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(40, 130);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(260, 23);
            txtInput.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(317, 130);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCompress
            // 
            btnCompress.Location = new Point(194, 201);
            btnCompress.Name = "btnCompress";
            btnCompress.Size = new Size(75, 23);
            btnCompress.TabIndex = 4;
            btnCompress.Text = "Compress";
            btnCompress.Click += btnCompress_Click;
            // 
            // label1
            // 
            label1.Location = new Point(40, 78);
            label1.Name = "label1";
            label1.Size = new Size(69, 23);
            label1.TabIndex = 0;
            label1.Text = "Select Type";
            // 
            // Back_btn
            // 
            Back_btn.Location = new Point(412, 237);
            Back_btn.Name = "Back_btn";
            Back_btn.Size = new Size(75, 23);
            Back_btn.TabIndex = 5;
            Back_btn.Text = "Back";
            Back_btn.UseVisualStyleBackColor = true;
            Back_btn.Click += Back_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(168, 22);
            label2.Name = "label2";
            label2.Size = new Size(180, 36);
            label2.TabIndex = 6;
            label2.Text = "Compressor";
            label2.Click += label2_Click;
            // 
            // CompressionPage
            // 
            ClientSize = new Size(499, 282);
            Controls.Add(label2);
            Controls.Add(Back_btn);
            Controls.Add(label1);
            Controls.Add(cmbType);
            Controls.Add(txtInput);
            Controls.Add(btnBrowse);
            Controls.Add(btnCompress);
            Name = "CompressionPage";
            Text = "Compression";
            Load += CompressionPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button Back_btn;
        private Label label2;
    }
}