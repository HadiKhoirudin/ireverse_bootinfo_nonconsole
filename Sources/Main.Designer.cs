
namespace iReverse_BootInfo
{
    partial class Main
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
            this.panel_header = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            this.panel_footer = new System.Windows.Forms.Panel();
            this.button_browse = new System.Windows.Forms.Button();
            this.button_readinfo = new System.Windows.Forms.Button();
            this.textBox_boot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel_header.SuspendLayout();
            this.panel_footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_header
            // 
            this.panel_header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel_header.Controls.Add(this.label1);
            this.panel_header.Controls.Add(this.label_close);
            this.panel_header.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_header.Location = new System.Drawing.Point(0, 0);
            this.panel_header.Name = "panel_header";
            this.panel_header.Size = new System.Drawing.Size(602, 42);
            this.panel_header.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F);
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(497, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "iReverse Boot EROFS Info - Non Console - C# Version  x86";
            // 
            // label_close
            // 
            this.label_close.AutoSize = true;
            this.label_close.BackColor = System.Drawing.Color.White;
            this.label_close.ForeColor = System.Drawing.Color.Black;
            this.label_close.Location = new System.Drawing.Point(570, 14);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(13, 13);
            this.label_close.TabIndex = 0;
            this.label_close.Text = "X";
            this.label_close.Click += new System.EventHandler(this.label_close_Click);
            // 
            // panel_footer
            // 
            this.panel_footer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel_footer.Controls.Add(this.button_browse);
            this.panel_footer.Controls.Add(this.button_readinfo);
            this.panel_footer.Controls.Add(this.textBox_boot);
            this.panel_footer.Controls.Add(this.label2);
            this.panel_footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_footer.Location = new System.Drawing.Point(0, 313);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(602, 45);
            this.panel_footer.TabIndex = 1;
            // 
            // button_browse
            // 
            this.button_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_browse.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.button_browse.Location = new System.Drawing.Point(467, 12);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(25, 21);
            this.button_browse.TabIndex = 2;
            this.button_browse.Text = "+";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_Click);
            // 
            // button_readinfo
            // 
            this.button_readinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_readinfo.Location = new System.Drawing.Point(515, 11);
            this.button_readinfo.Name = "button_readinfo";
            this.button_readinfo.Size = new System.Drawing.Size(75, 23);
            this.button_readinfo.TabIndex = 2;
            this.button_readinfo.Text = "Read Info";
            this.button_readinfo.UseVisualStyleBackColor = true;
            this.button_readinfo.Click += new System.EventHandler(this.button_readinfo_Click);
            // 
            // textBox_boot
            // 
            this.textBox_boot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_boot.Location = new System.Drawing.Point(234, 13);
            this.textBox_boot.Name = "textBox_boot";
            this.textBox_boot.Size = new System.Drawing.Size(258, 20);
            this.textBox_boot.TabIndex = 1;
            this.textBox_boot.Text = "boot.img";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input Recovery / Boot EROFS file : ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 42);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(602, 271);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.DoubleClick += new System.EventHandler(this.richTextBox1_DoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(602, 358);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel_header);
            this.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iReverse BootInfo C# - Version";
            this.panel_header.ResumeLayout(false);
            this.panel_header.PerformLayout();
            this.panel_footer.ResumeLayout(false);
            this.panel_footer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_header;
        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_readinfo;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.TextBox textBox_boot;
    }
}

