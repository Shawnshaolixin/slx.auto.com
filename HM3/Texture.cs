using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace HM3
{
    /// <summary>
    /// 纹理
    /// </summary>
    public class Texture
    {
        public Texture(string name)
        {
            image_data = Cv2.ImRead(name);
            Cv2.CvtColor(image_data, image_data, ColorConversionCodes.RGB2BGR);
            width = image_data.Cols;
            height = image_data.Rows;
        }
        private Mat image_data { get; set; }
        public int width { get; set; }
        int height { get; set; }

        public Vector3 getColor(float u, float v)
        {
            var u_img = u * width;
            var v_img = (1 - v) * height;
            var color = image_data.At<Vec3b>((int)v_img, (int)u_img);
            return new Vector3(color[0], color[1], color[2]);

        }

    }
}
