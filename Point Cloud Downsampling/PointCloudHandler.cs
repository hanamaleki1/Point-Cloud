using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Point_Cloud_Downsampling
{
    class PointCloudHandler
    {
        static PointCloudHandler()
        {
        }
        private PointCloudHandler()
        {
        }
        public static PointCloudHandler Instance { get; } = new PointCloudHandler();

        //where to put these functions?
        public double AToRGB(double aVal)
        {
            double c = 255 - Math.Ceiling(((aVal + 2048) / 4096) * 255);
            return c;
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
                        while ( (line = sr.ReadLine()) != null)
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
                                    if (c.Length == 4)
                                    {
                                        string x = (Convert.ToDouble(c[0]) * scale).ToString();
                                        string y = (Convert.ToDouble(c[1]) * scale).ToString();
                                        string z = (Convert.ToDouble(c[2]) * scale).ToString();
                                        string col = AToRGB(Convert.ToDouble(c[3])).ToString();
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
                                Console.WriteLine("Processed: " + (cnt / 1000000).ToString() + " Million Pts,", (Math.Round(Convert.ToDouble((cnt / total) * 100))).ToString() + "%");
                            }
                        }
                        Console.WriteLine("Points Written: ", cnt);
                        return cnt;
                    }
                }
            }

        }
    }
}
