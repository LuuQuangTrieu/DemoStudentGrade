namespace Tinh_diem_hoc_sinh
{
    partial class Form7
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
            this.Tc = new System.Windows.Forms.TextBox();
            this.TID = new System.Windows.Forms.TextBox();
            this.Tt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tc
            // 
            this.Tc.Location = new System.Drawing.Point(1, 227);
            this.Tc.Multiline = true;
            this.Tc.Name = "Tc";
            this.Tc.Size = new System.Drawing.Size(1047, 275);
            this.Tc.TabIndex = 0;
            this.Tc.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TID
            // 
            this.TID.Location = new System.Drawing.Point(113, 131);
            this.TID.Multiline = true;
            this.TID.Name = "TID";
            this.TID.Size = new System.Drawing.Size(234, 41);
            this.TID.TabIndex = 1;
            this.TID.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Tt
            // 
            this.Tt.Location = new System.Drawing.Point(571, 131);
            this.Tt.Multiline = true;
            this.Tt.Name = "Tt";
            this.Tt.Size = new System.Drawing.Size(318, 41);
            this.Tt.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Tinh_diem_hoc_sinh.Properties.Resources.OIP__2_;
            this.pictureBox1.Location = new System.Drawing.Point(28, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 503);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tt);
            this.Controls.Add(this.TID);
            this.Controls.Add(this.Tc);
            this.Name = "Form7";
            this.Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Tc;
        private System.Windows.Forms.TextBox TID;
        private System.Windows.Forms.TextBox Tt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}