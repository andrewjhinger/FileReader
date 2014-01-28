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
using System.Security;

namespace FileReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (throwCheckBox.Checked == true)
                    {
                        throw new MyFileException("Custom file exception");
                    }
                    else
                    {

                        String input = string.Empty;
                        OpenFileDialog dialog = new OpenFileDialog();
                        dialog.Filter =
                                 "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                        dialog.InitialDirectory = "C:";
                        dialog.Title = "Select a text file";

                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            richTextBox1.LoadFile(dialog.FileName, RichTextBoxStreamType.PlainText);
                            toolStripStatusLabel1.Text = dialog.SafeFileName;
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    // Write error.
                    MessageBox.Show(ex.Message);
                    Console.WriteLine(ex.ToString());
                }
            }
            catch (MyFileException Ex)
            {
                MessageBox.Show(Ex.Message);
                Console.WriteLine(Ex.ToString());
            }
        }


        private void CustomFileExceptions()
        {
            throw new MyFileException("Test custom file exception");
        }

        class MyFileException : ApplicationException
        {
            public MyFileException(string exceptionText) : base(exceptionText) { }
            public MyFileException(string exceptionText, Exception innerException) : base(exceptionText, innerException) { }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            toolStripStatusLabel1.Text = "";
        }

        private void throwCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (throwCheckBox.Checked == true)
            {
                noneCheckBox.Checked = false;
            }
        }

        private void noneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noneCheckBox.Checked == true)
            {
                throwCheckBox.Checked = false;
            }
        }









    }
}
