using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_exam
{
    public partial class Notepad : Form
    {
        public Notepad()
        {
            InitializeComponent();
        }
        public void SaveFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
            this.Text = save.FileName;
        }
       
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text=="")
                MessageBox.Show("Нечего удалять");
            else if (MessageBox.Show("Вы уверены что хотите удалить весь текст ?", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                richTextBox1.Clear();
        }

        private void openFileToolStrip(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.RichText);
            this.Text=open.FileName;
        }

        private void exitToolStrip(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStrip(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void copyToolStrip(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
                richTextBox1.Copy();
        }

        private void pasteToolStrip(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStrip(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
                richTextBox1.ClearUndo();
            }
        }

        private void redoToolStrip(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void fontToolStrip(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = richTextBox1.SelectionFont;
            if(font.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionFont = font.Font;
            }
        }

        private void colorToolStrip(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if(color.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.BackColor = color.Color;
            }
        }

        private void see_helpToolStrip(object sender, EventArgs e)
        {
            Справка form2 = new Справка();
            form2.Show();
        }

        private void AboutToolStrip(object sender, EventArgs e)
        {
            //MessageBox.Show("Блокнот", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
            About about = new About();
            about.ShowDialog();
        }

        private void saveToolStrip(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void color_textToolStrip(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = richTextBox1.SelectionColor;
            if(color.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionColor = color.Color;
            }
        }

        private void saveToolsbar(object sender, EventArgs e)
        {
            SaveFile();
        }

        
        /// /////////////////////////////////////////////////////////////////////////////////
        
        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            int index = 0;
            String temp = richTextBox1.Text;
            richTextBox1.Text = "";
            richTextBox1.Text = temp;
            while(index < richTextBox1.Text.LastIndexOf(toolStripTextBoxSearch.Text))
            {
                richTextBox1.Find(toolStripTextBoxSearch.Text,index,richTextBox1.TextLength,RichTextBoxFinds.None);
                richTextBox1.SelectionColor = Color.Orange;
                index = richTextBox1.Text.IndexOf(toolStripTextBoxSearch.Text, index) + 1;
            }
        }

        private void toolStripTextBoxSearch_clickbutton(object sender, EventArgs e)
        {
            if(toolStripTextBoxSearch.Text!="")
            {
                toolStripTextBoxSearch.Clear();
            }
        }

        private void openFileToolbar_click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(open.FileName, RichTextBoxStreamType.RichText);
            this.Text = open.FileName;
        }

        private void toolStripComboBoxFontText_Click(object sender, EventArgs e)
        {
            foreach(FontFamily fontf in FontFamily.Families)
            {
                toolStripComboBoxFontText.Items.Add(fontf.Name);
            }
           
        }

        private void toolStripComboBox_SelectedIndex(object sender, EventArgs e)
        {
            Font font = new Font(toolStripComboBoxFontText.SelectedItem.ToString(),fontDialog1.Font.Size, fontDialog1.Font.Style);

            fontDialog1.Font = font;

            if(richTextBox1.SelectedText != null)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
            else if (richTextBox1.SelectedText == null)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
           
            richTextBox1.Focus();
        }

        private void toolStripComboBoxSizeFont_Click(object sender, EventArgs e)
        {
            toolStripComboBoxSizeFont.Items.Clear();
            int temp = 8;
            for (int i = 0; i < 13; i++)
            {
                toolStripComboBoxSizeFont.Items.Add(temp);
                if (temp < 12)
                    temp++;
                else
                    temp += 2;
            }
            toolStripComboBoxSizeFont.Items.Add(32);
            toolStripComboBoxSizeFont.Items.Add(48);
            toolStripComboBoxSizeFont.Items.Add(72);
                      
        }

        private void toolStripComboBoxSizeFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font ff = new Font(fontDialog1.Font.Name, float.Parse(toolStripComboBoxSizeFont.SelectedItem.ToString()), fontDialog1.Font.Style);
            fontDialog1.Font = ff;

            if(richTextBox1.SelectedText!=null)
            {
                richTextBox1.SelectionFont=fontDialog1.Font;
                richTextBox1.SelectionColor=fontDialog1.Color;
            }
            else if(richTextBox1.SelectedText==null)
            {
                richTextBox1.Font=fontDialog1.Font;
                richTextBox1.ForeColor=fontDialog1.Color;
            }
            richTextBox1.Focus();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            

            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void toolStripButtonUnderlined_Click(object sender, EventArgs e)
        {
            if (toolStripButtonUnderlined.Enabled == false)
                toolStripButtonUnderlined.Enabled = true;

            if (richTextBox1.SelectionFont != null)
            {
                System.Drawing.Font currentFont = richTextBox1.SelectionFont;
                System.Drawing.FontStyle newFontStyle;

                if (richTextBox1.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                }

                richTextBox1.SelectionFont = new Font(
                   currentFont.FontFamily,
                   currentFont.Size,
                   newFontStyle
                );
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            ColorDialog colordialog = new ColorDialog();

            colordialog.Color = richTextBox1.SelectionColor;
            if(colordialog.ShowDialog()==System.Windows.Forms.DialogResult.OK &&
                colordialog.Color!=richTextBox1.SelectionColor)
            {
                richTextBox1.SelectionColor = colordialog.Color;
            }
            //richTextBox1.SelectionColor = toolStripButtonPaintText.ForeColor;
        }

        private void toolStripButtonFoneColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorfone = new ColorDialog();
            colorfone.Color = richTextBox1.BackColor;

            if(colorfone.ShowDialog()==System.Windows.Forms.DialogResult.OK && colorfone.Color!=richTextBox1.BackColor)
            {
                richTextBox1.BackColor = colorfone.Color;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripComboBoxFontText.Text = richTextBox1.SelectionFont.Name;
            toolStripComboBoxSizeFont.Text = richTextBox1.SelectionFont.Size.ToString();
        }

        private void toolStripButton4_Click_2(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
