using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QLBH_NoiThatViwood
{
    public static class ThemeColor
    {

        /// <summary>
        /// Danh sách màu hiển thị
        /// </summary>
        public static List<string> ColorList = new List<string>
        {
           "#1FC75E",// xanh lá đậm
           "#F59948", //cam
           "#9DD34A", //xanh lá
           "#17C4AC", //xanh dương

        };


        /// <summary>
        /// Phương thức thay đổi độ sáng của màu
        /// </summary>
        /// <param name="color"> Màu sắc </param>
        /// <param name="correctionFactor"> hệ số điều chỉnh  </param>
        /// <returns> Đối tượng Color mới </returns>
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }

            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }

    }
}
