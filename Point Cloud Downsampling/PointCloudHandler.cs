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


    }
}
