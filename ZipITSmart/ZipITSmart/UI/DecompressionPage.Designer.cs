namespace ZipITSmart.UI
{
    partial class DecompressionPage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbType = new ComboBox();
            txtInput = new TextBox();
            btnBrowse = new Button();
            btnDecompress = new Button();
            label1 = new Label();
            Back_btn = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.Items.AddRange(new object[] { "File", "Folder", "Image" });
            cmbType.Location = new Point(171, 104);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(152, 23);
            cmbType.TabIndex = 1;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(63, 147);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(260, 23);
            txtInput.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(353, 146);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse";
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnDecompress
            // 
            btnDecompress.Location = new Point(235, 214);
            btnDecompress.Name = "btnDecompress";
            btnDecompress.Size = new Size(88, 29);
            btnDecompress.TabIndex = 4;
            btnDecompress.Text = "Decompress";
            btnDecompress.Click += btnDecompress_Click;
            // 
            // label1
            // 
            label1.Location = new Point(76, 107);
            label1.Name = "label1";
            label1.Size = new Size(73, 23);
            label1.TabIndex = 0;
            label1.Text = "Select Type";
            // 
            // Back_btn
            // 
            Back_btn.Location = new Point(453, 234);
            Back_btn.Name = "Back_btn";
            Back_btn.Size = new Size(75, 23);
            Back_btn.TabIndex = 6;
            Back_btn.Text = "Back";
            Back_btn.UseVisualStyleBackColor = true;
            Back_btn.Click += Back_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(167, 22);
            label2.Name = "label2";
            label2.Size = new Size(208, 36);
            label2.TabIndex = 7;
            label2.Text = "Decompressor";
            label2.Click += label2_Click;
            // 
            // DecompressionPage
            // 
            ClientSize = new Size(540, 269);
            Controls.Add(label2);
            Controls.Add(Back_btn);
            Controls.Add(label1);
            Controls.Add(cmbType);
            Controls.Add(txtInput);
            Controls.Add(btnBrowse);
            Controls.Add(btnDecompress);
            Name = "DecompressionPage";
            Text = "Decompression";
            Load += DecompressionPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button Back_btn;
        private Label label2;
    }
}