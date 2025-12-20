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
            Decompressor = new Button();
            Compressor = new Button();
            panel1 = new Panel();
            label1 = new Label();
            Exit_btn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Decompressor
            // 
            Decompressor.AccessibleName = "Decompressor";
            Decompressor.Cursor = Cursors.Hand;
            Decompressor.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Decompressor.Location = new Point(466, 257);
            Decompressor.Margin = new Padding(2);
            Decompressor.Name = "Decompressor";
            Decompressor.Size = new Size(149, 67);
            Decompressor.TabIndex = 5;
            Decompressor.Text = "Decompress";
            Decompressor.UseVisualStyleBackColor = true;
            Decompressor.Click += Decompressor_Click;
            // 
            // Compressor
            // 
            Compressor.AccessibleName = "Compressor";
            Compressor.Cursor = Cursors.Hand;
            Compressor.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Compressor.Location = new Point(178, 257);
            Compressor.Margin = new Padding(2);
            Compressor.Name = "Compressor";
            Compressor.Size = new Size(148, 67);
            Compressor.TabIndex = 4;
            Compressor.Text = "Compress";
            Compressor.UseVisualStyleBackColor = true;
            Compressor.Click += Compressor_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Khaki;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(150, 127);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 62);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.ImageAlign = ContentAlignment.TopCenter;
            label1.Location = new Point(46, 14);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(358, 25);
            label1.TabIndex = 2;
            label1.Text = "File Compressor And Decompressor";
            // 
            // Exit_btn
            // 
            Exit_btn.Location = new Point(688, 386);
            Exit_btn.Name = "Exit_btn";
            Exit_btn.Size = new Size(75, 23);
            Exit_btn.TabIndex = 7;
            Exit_btn.Text = "Exit";
            Exit_btn.UseVisualStyleBackColor = true;
            Exit_btn.Click += Exit_btn_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Exit_btn);
            Controls.Add(Decompressor);
            Controls.Add(Compressor);
            Controls.Add(panel1);
            Name = "HomePage";
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
    }
}