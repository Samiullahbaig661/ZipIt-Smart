namespace ZipITSmart.UI
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            Decompressor = new Button();
            Compressor = new Button();
            panel1 = new Panel();
            Exit_btn = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Decompressor
            // 
            Decompressor.AccessibleName = "Decompressor";
            Decompressor.BackColor = Color.DarkCyan;
            Decompressor.Cursor = Cursors.Hand;
            Decompressor.FlatStyle = FlatStyle.Popup;
            Decompressor.Font = new Font("Gill Sans Ultra Bold", 14.25F);
            Decompressor.ForeColor = Color.White;
            Decompressor.Location = new Point(82, 195);
            Decompressor.Margin = new Padding(2);
            Decompressor.Name = "Decompressor";
            Decompressor.Size = new Size(350, 41);
            Decompressor.TabIndex = 5;
            Decompressor.Text = "DECOMPRESSOR";
            Decompressor.UseVisualStyleBackColor = false;
            Decompressor.Click += Decompressor_Click;
            // 
            // Compressor
            // 
            Compressor.AccessibleName = "Compressor";
            Compressor.BackColor = Color.FromArgb(192, 64, 0);
            Compressor.Cursor = Cursors.Hand;
            Compressor.FlatStyle = FlatStyle.Popup;
            Compressor.Font = new Font("Gill Sans Ultra Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Compressor.ForeColor = Color.White;
            Compressor.Location = new Point(82, 136);
            Compressor.Margin = new Padding(2);
            Compressor.Name = "Compressor";
            Compressor.Size = new Size(350, 41);
            Compressor.TabIndex = 4;
            Compressor.Text = "COMPRESSOR";
            Compressor.UseVisualStyleBackColor = false;
            Compressor.Click += Compressor_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 64, 0);
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(Decompressor);
            panel1.Controls.Add(Exit_btn);
            panel1.Controls.Add(Compressor);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 11);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 324);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // Exit_btn
            // 
            Exit_btn.BackColor = Color.DarkRed;
            Exit_btn.FlatStyle = FlatStyle.Popup;
            Exit_btn.Font = new Font("Cooper Black", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Exit_btn.ForeColor = Color.WhiteSmoke;
            Exit_btn.Location = new Point(196, 268);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.Size = new Size(111, 32);
            Exit_btn.TabIndex = 7;
            Exit_btn.Text = "EXIT";
            Exit_btn.UseVisualStyleBackColor = false;
            Exit_btn.Click += Exit_btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Britannic Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.ImageAlign = ContentAlignment.TopCenter;
            label2.Location = new Point(177, 20);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(170, 36);
            label2.TabIndex = 3;
            label2.Text = "ZipITSmart";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(95, 77);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(329, 24);
            label1.TabIndex = 2;
            label1.Text = "File Compressor And Decompressor";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(539, 346);
            Controls.Add(panel1);
            Name = "HomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomePage";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button Decompressor;
        private Button Compressor;
        private Panel panel1;
        private Label label1;
        private Button Exit_btn;
        private Label label2;
    }
}