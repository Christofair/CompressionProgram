
namespace BenchC
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.input_btn = new System.Windows.Forms.Button();
            this.input_textbox = new System.Windows.Forms.TextBox();
            this.output_textbox = new System.Windows.Forms.TextBox();
            this.output_btn = new System.Windows.Forms.Button();
            this.spakuj_btn = new System.Windows.Forms.Button();
            this.open_dir_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plik lub Folder do kompresji";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Plik wynikowy";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(13, 105);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(764, 11);
            this.progressBar1.TabIndex = 2;
            // 
            // input_btn
            // 
            this.input_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_btn.Location = new System.Drawing.Point(716, 22);
            this.input_btn.Name = "input_btn";
            this.input_btn.Size = new System.Drawing.Size(72, 23);
            this.input_btn.TabIndex = 3;
            this.input_btn.Text = "Wybierz";
            this.input_btn.UseVisualStyleBackColor = true;
            this.input_btn.Click += new System.EventHandler(this.input_btn_Click);
            // 
            // input_textbox
            // 
            this.input_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_textbox.Enabled = false;
            this.input_textbox.Location = new System.Drawing.Point(173, 22);
            this.input_textbox.Name = "input_textbox";
            this.input_textbox.Size = new System.Drawing.Size(537, 23);
            this.input_textbox.TabIndex = 4;
            // 
            // output_textbox
            // 
            this.output_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output_textbox.Enabled = false;
            this.output_textbox.Location = new System.Drawing.Point(173, 53);
            this.output_textbox.Name = "output_textbox";
            this.output_textbox.Size = new System.Drawing.Size(537, 23);
            this.output_textbox.TabIndex = 5;
            // 
            // output_btn
            // 
            this.output_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.output_btn.Location = new System.Drawing.Point(716, 53);
            this.output_btn.Name = "output_btn";
            this.output_btn.Size = new System.Drawing.Size(72, 23);
            this.output_btn.TabIndex = 6;
            this.output_btn.Text = "Wybierz";
            this.output_btn.UseVisualStyleBackColor = true;
            this.output_btn.Click += new System.EventHandler(this.output_btn_Click);
            // 
            // spakuj_btn
            // 
            this.spakuj_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.spakuj_btn.Location = new System.Drawing.Point(716, 128);
            this.spakuj_btn.Name = "spakuj_btn";
            this.spakuj_btn.Size = new System.Drawing.Size(72, 28);
            this.spakuj_btn.TabIndex = 7;
            this.spakuj_btn.Text = "Spakuj";
            this.spakuj_btn.UseVisualStyleBackColor = true;
            this.spakuj_btn.Click += new System.EventHandler(this.spakuj_btn_Click);
            // 
            // open_dir_btn
            // 
            this.open_dir_btn.Location = new System.Drawing.Point(14, 131);
            this.open_dir_btn.Name = "open_dir_btn";
            this.open_dir_btn.Size = new System.Drawing.Size(153, 23);
            this.open_dir_btn.TabIndex = 8;
            this.open_dir_btn.Text = "Otwórz folder wynikowy";
            this.open_dir_btn.UseVisualStyleBackColor = true;
            this.open_dir_btn.Click += new System.EventHandler(this.open_dir_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 166);
            this.Controls.Add(this.open_dir_btn);
            this.Controls.Add(this.spakuj_btn);
            this.Controls.Add(this.output_btn);
            this.Controls.Add(this.output_textbox);
            this.Controls.Add(this.input_textbox);
            this.Controls.Add(this.input_btn);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button input_btn;
        private System.Windows.Forms.TextBox input_textbox;
        private System.Windows.Forms.TextBox output_textbox;
        private System.Windows.Forms.Button output_btn;
        private System.Windows.Forms.Button spakuj_btn;
        private System.Windows.Forms.Button open_dir_btn;
    }
}

