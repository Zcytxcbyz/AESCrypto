using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace AESCrypto
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            richTextBox1.AllowDrop = true;
            richTextBox2.AllowDrop = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = AES.AESEncrypt(richTextBox1.Text, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = AES.AESDecrypt(richTextBox2.Text, textBox1.Text);
        }
        #region 右键菜单
        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void 剪切ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开";
            ofd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr=new StreamReader(fs,Encoding.UTF8);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存";
            sfd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(richTextBox1.Text);
                sw.Close();
                fs.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开";
            ofd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存";
            sfd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(richTextBox2.Text);
                sw.Close();
                fs.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开";
            ofd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs, Encoding.UTF8);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存";
            sfd.Filter = "所有文件|*.*|文本文件|*.txt|文本文档|*.doc";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.Write(textBox1.Text);
                sw.Close();
                fs.Close();
            }
        }
        #region 失败代码
        /*
        private void richTextBox1_DragEnter(object sender,DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
        }
        private void richTextBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
        }
        private void richTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] MyPathArray = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string MyPath in MyPathArray)
                {
                    this.richTextBox1.LoadFile(MyPath, RichTextBoxStreamType.PlainText);
                }
            }
        }
        private void richTextBox2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] MyPathArray = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string MyPath in MyPathArray)
                {
                    this.richTextBox2.LoadFile(MyPath, RichTextBoxStreamType.PlainText);
                }
            }
        }
       */
        #endregion
    }
}
