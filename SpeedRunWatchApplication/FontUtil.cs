using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRunWatchApplication
{
    static class FontUtil
    {
        public static float GetFontSize(Graphics gr, string text, Font font, int areaWidth, int areaHeight, int margin, float min_size, float max_size)
        {
            // Only bother if there's text.
            if (text.Length == 0 || gr == null) return min_size;

            // See how much room we have, allowing a bit
            // for the Label's internal margin.
            int wid = areaWidth - margin;
            int hgt = areaHeight - margin;

            // Make a Graphics object to measure the text.
            using (gr)
            {
                while (max_size - min_size > 0.1f)
                {
                    float pt = (min_size + max_size) / 2f;
                    using (Font test_font = new Font(font.FontFamily, pt))
                    {
                        // See if this font is too big.
                        SizeF text_size = gr.MeasureString(text, test_font);
                        if ((text_size.Width > wid) || (text_size.Height > hgt))
                            max_size = pt;
                        else
                            min_size = pt;
                    }
                }
                return min_size;
            }
        }
    }
}
