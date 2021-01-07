using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Point_Cloud_Downsampling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //change this to not folder picker: (pts file)
        private void BrowseForInput_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = false;

            //dialog.Filters.Add(new CommonFileDialogFilter("Image files", "*.jpg;*.jpeg;*.png;"));
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //folder.Text = dialog.ToString();
                inputFile.Text = dialog.FileName;
            }
        }

        private void BrowseForOutputFolder_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputFolder.Text = dialog.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void keepColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //keepColors.DataSource = new String[]{ "Yes","No"};
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (this.inputFile.Text.Trim() == "") { MessageBox.Show("Please input a point cloud file."); return; }
            if (this.outputFolder.Text.Trim() == "") { MessageBox.Show("Please input a folder to save the point cloud file."); return; }
            if (this.downsamplingValue.Text.Trim() == "") { MessageBox.Show("Please enter a downsampling value."); return; }

            //see if point cloud is in correct format:
            string inPath = inputFile.Text;
            if ((inPath.Contains(".pts")) == false){ MessageBox.Show("Selected file needs to be in pts format."); return; }

            //see if value is number and between 0 and 1:
            double dsValue;
            try { dsValue = Convert.ToDouble(downsamplingValue.Text); }
            catch { dsValue = -1; }
            if(dsValue < 0 || dsValue > 1) { MessageBox.Show("Downsampling value needs to be a number between 0 and 1."); return; }

            string outPath = outputFolder.Text + "\\" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + "_downsampled by " + dsValue.ToString() + ".txt"; //change to xyz

            PointCloudHandler.Instance.PtsToXyz(inPath, outPath, 1, 0.5);

        }
    }
}
