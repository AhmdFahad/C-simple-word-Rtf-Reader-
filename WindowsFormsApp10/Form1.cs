using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhmadFahad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //part one 
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //if the file not a rtf file
            if (Path.GetExtension(openFileDialog1.FileName) != ".rtf")
            {
                MessageBox.Show("file is not rtf");
                return;
            }
            //to cheak its a rtf file
            listBox1.Items.Add(openFileDialog1.FileName);

        }
        //part two
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(listBox1.GetItemText(listBox1.SelectedItem));
        }

        //part three
        public void find() {

            string x = textBox1.Text;
            textBox1.Clear();
            int startindex=0,counter=0;
            
            while (startindex<richTextBox1.Text.Length) {
                int wordindex = richTextBox1.Find(x, startindex, RichTextBoxFinds.None);
                if (wordindex != -1)
                {
                    richTextBox1.SelectionStart = wordindex;
                    richTextBox1.SelectionLength = x.Length;
                    richTextBox1.SelectionColor = Color.Blue;
                }
                else
                    break;
                startindex = wordindex + x.Length;
            }
            
            richTextBox1.Find(textBox1.Text, RichTextBoxFinds.MatchCase);
            richTextBox1.SelectionColor = Color.Blue;
        }
        //part four
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style^ FontStyle.Italic);
        }
        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
        }
        //part five
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //Save
            if (comboBox1.SelectedIndex == 0)
                richTextBox1.SaveFile(listBox1.GetItemText(listBox1.SelectedItem));
            //clear
            else if (comboBox1.SelectedIndex == 1)
                richTextBox1.Clear();
            //find >>> part three
            else {
                find(); 
            }
        }

    }
}
