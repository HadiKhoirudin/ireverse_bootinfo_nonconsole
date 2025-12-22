using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iReverse_BootInfo
{
    public partial class Main : Form
    {
        public static Main SharedUI { get; set; }

        public Main()
        {
            InitializeComponent();
            SharedUI = this;
            showlog();
        }

        public void showlog()
        {
            RichLogs("Boot Info Version : ", Color.White, true, false);
            RichLogs("2.0 32-bit.", Color.Cyan, true, true);

            RichLogs("Supported Chipset : ", Color.White, true, false);
            RichLogs("MediaTek, Qualcomm, Unisoc, & More.\n", Color.Cyan, true, true);

            RichLogs("Features          : ...", Color.White, true, true);
            RichLogs("AVB Version 2.0   : ", Color.White, true, false);
            RichLogs("Supported!", Color.Lime, true, true);

            RichLogs("LZ4 Decompression : ", Color.White, true, false);
            RichLogs("Supported!", Color.Lime, true, true);

            RichLogs("EROFS File System : ", Color.White, true, false);
            RichLogs("Supported!\n", Color.Lime, true, true);

            RichLogs("Instructions\n", Color.White, true, true);
            RichLogs("For Non A/B Device ", Color.White, true, true);
            RichLogs(" - Use recovery.img.\n", Color.Cyan, true, true);
            RichLogs("For A/B Device ", Color.White, true, true);
            RichLogs(" - Use boot_a.img or boot_b.img or recovery_a.img or recovery_b.img.\n", Color.Cyan, true, true);
            RichLogs("For EROFS ", Color.White, true, true);
            RichLogs(" - Use system_a.img or system_b.img take from super.img with 7z-Zip.", Color.Cyan, true, true);
        }

        public static void RichLogs(string msg, Color colour, bool isBold, bool NextLine = false)
        {
            if (SharedUI.richTextBox1.InvokeRequired)
            {
                SharedUI.richTextBox1.Invoke(new MethodInvoker(() =>
                {
                    SharedUI.richTextBox1.SelectionStart = SharedUI.richTextBox1.Text.Length;
                    Color selectionColor = SharedUI.richTextBox1.SelectionColor;
                    SharedUI.richTextBox1.SelectionColor = colour;
                    if (isBold)
                    {
                        SharedUI.richTextBox1.SelectionFont = new Font(SharedUI.richTextBox1.Font, FontStyle.Bold);
                    }
                    SharedUI.richTextBox1.AppendText(msg);
                    SharedUI.richTextBox1.SelectionColor = selectionColor;
                    SharedUI.richTextBox1.SelectionFont = new Font(SharedUI.richTextBox1.Font, FontStyle.Regular);
                    if (NextLine)
                    {
                        if (SharedUI.richTextBox1.TextLength > 0)
                        {
                            SharedUI.richTextBox1.AppendText("\r\n");
                            SharedUI.richTextBox1.ScrollToCaret();
                        }
                    }
                }));
            }
            else
            {
                SharedUI.richTextBox1.SelectionStart = SharedUI.richTextBox1.Text.Length;
                Color selectionColor = SharedUI.richTextBox1.SelectionColor;
                SharedUI.richTextBox1.SelectionColor = colour;
                if (isBold)
                {
                    SharedUI.richTextBox1.SelectionFont = new Font(SharedUI.richTextBox1.Font, FontStyle.Bold);
                }
                SharedUI.richTextBox1.AppendText(msg);
                SharedUI.richTextBox1.SelectionColor = selectionColor;
                SharedUI.richTextBox1.SelectionFont = new Font(SharedUI.richTextBox1.Font, FontStyle.Regular);
                if (NextLine)
                {
                    if (SharedUI.richTextBox1.TextLength > 0)
                    {
                        SharedUI.richTextBox1.AppendText("\r\n");
                        SharedUI.richTextBox1.ScrollToCaret();
                    }
                }
            }
        }

        private void label_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Recovery or Boot IMG file...",
                Filter = string.Format("{0}  |*.*|Other|*.*", "boot")
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_boot.Text = openFileDialog.FileName;
            }
        }

        private async void button_readinfo_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_boot.Text))
                return;

            richTextBox1.Clear();

            var fn = textBox_boot.Text;

            if (fn.ToLower().Contains("recovery") || fn.ToLower().Contains("boot"))
                await Task.Run(() => boot.boot.extract_boot_recovery(File.ReadAllBytes(fn)));
            else
                await Task.Run(() => boot.boot.extract_erofs(fn));
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            showlog();
        }
    }
}
