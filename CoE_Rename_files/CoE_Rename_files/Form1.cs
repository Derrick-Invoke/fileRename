using CoE_Rename_files.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoE_Rename_files
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            var folderpath = folder.SelectedPath;
            label1.Text = folderpath.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                Folders.GetPdfFiles(Folders.GetSubFolders(label1.Text));
                MessageBox.Show("Successfully renamed all files");

            }
            else
            {
                MessageBox.Show("Please select a folde before rename files");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label1.Text != "")
            {
                Folders.MovePdfFiles(Folders.GetSubFolders(label1.Text));
                MessageBox.Show("Files successfully moved.");

            }
            else
            {
                MessageBox.Show("Please select a folde before rename files");
            }
        }
    }
}
