using Microsoft.WindowsAPICodePack.Dialogs;
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

        public int PtsToXyz(string inPath, string outPath, double scale = 1.0000, double sampleRate = 1.0)
        {
            using (FileStream fs = new FileStream(inPath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    using (StreamWriter sw = new StreamWriter(outPath, false))
                    {
                        //string[] lines = File.ReadAllLines(inPath);
                        int cnt = 1;
                        int total = 1;
                        string line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            //the first line of the pts file contains the total point count
                            if (cnt == 1)
                            {
                                total = line.Length; //?????????????
                            }
                            Random rand = new Random();
                            if (rand.NextDouble() < sampleRate)
                            {
                                //for all other lines:
                                if (cnt > 1)
                                {
                                    string[] c = line.Split(' ');
                                    string newLine = c[0] + " " + c[1] + " " + c[2] + "\n";

                                    //if this line contains a brightness value:
                                    //should I add if user wants to keep color here?
                                    if (c.Length == 4 && RemoveColorInfo.Checked == false)
                                    {
                                        string x = (Convert.ToDouble(c[0]) * scale).ToString();
                                        string y = (Convert.ToDouble(c[1]) * scale).ToString();
                                        string z = (Convert.ToDouble(c[2]) * scale).ToString();
                                        string col = PointCloudHandler.Instance.AToRGB(Convert.ToDouble(c[3])).ToString();
                                        newLine = x + " " + y + " " + z + " " + col + " " + col + " " + col + "\n";
                                    }
                                    else
                                    {
                                        if (scale != 0 && scale != 1.0000)
                                        {
                                            c = c.Select(i => (Convert.ToDouble(i) * scale).ToString()).ToArray();
                                        }
                                        newLine = c[0] + " " + c[1] + " " + c[2] + "\n";
                                    }
                                    sw.WriteLine(newLine);
                                }

                            }
                            cnt++;
                            

                            if (cnt % 1000000 == 0)
                            {
                                label4.Text = cnt.ToString();
                                Console.WriteLine("Processed: " + (cnt / 1000000).ToString() + " Million Pts,", (Math.Round(Convert.ToDouble((cnt / total) * 100))).ToString() + "%");
                            }
                        }
                        Console.WriteLine("Points Written: ", cnt);
                        return cnt;
                    }
                }
            }

        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (this.inputFile.Text.Trim() == "") { MessageBox.Show("Please input a point cloud file."); return; }
            if (this.outputFolder.Text.Trim() == "") { MessageBox.Show("Please input a folder to save the point cloud file."); return; }
            if (this.downsamplingValue.Text.Trim() == "") { MessageBox.Show("Please enter a downsampling value."); return; }

            string inPath = inputFile.Text;
            if ((inPath.Contains(".pts")) == false){ MessageBox.Show("Selected file needs to be in pts format."); return; }

            //see if value is number and between 0 and 1:
            double dsValue;
            try { dsValue = Convert.ToDouble(downsamplingValue.Text); }
            catch { dsValue = -1; }
            if(dsValue < 0 || dsValue > 1) { MessageBox.Show("Downsampling value needs to be a number between 0 and 1."); return; }

            string outPath = outputFolder.Text + "\\" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + "_downsampled by " + dsValue.ToString() + ".xyz"; //change to xyz

            PtsToXyz(inPath, outPath, 1, Convert.ToDouble(downsamplingValue.Text));
            MessageBox.Show("Process Completed.");

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
