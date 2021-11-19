using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedRunWatchApplication
{
    public partial class SpeedRunWatchControl : UserControl
    {
        public string RealTime
        {
            get => labelRealTime.Text;
            set => labelRealTime.Text = value;
        }

        public string SpeedRun
        {
            get => labelSpeedRunTime.Text;
            set => labelSpeedRunTime.Text = value;
        }

        public SpeedRunWatchControl()
        {
            InitializeComponent();
        }

        private void RearrangeControl()
        {
            float font_size = FontUtil.GetFontSize(
                labelRealTime.CreateGraphics(),
                "XXXXXXXXXXXXXX",
                labelRealTime.Font,
                labelRealTime.DisplayRectangle.Width,
                labelRealTime.DisplayRectangle.Height,
                10,
                1,
                1000);
            labelRealTime.Font = new Font(labelRealTime.Font.FontFamily, font_size);
            labelSpeedRunTime.Font = new Font(labelSpeedRunTime.Font.FontFamily, font_size);

            int width = this.DisplayRectangle.Width;
            int height = this.DisplayRectangle.Height / 2;
            labelRealTime.Location = new Point(0, 0);
            labelRealTime.Width = width;
            labelRealTime.Height = height;

            labelSpeedRunTime.Location = new Point(0, height + 1);
            labelSpeedRunTime.Width = width;
            labelSpeedRunTime.Height = height;
        }

        private void SpeedRunWatchControl_Resize(object sender, EventArgs e)
        {
            RearrangeControl();
        }

        private void SpeedRunWatchControl_Load(object sender, EventArgs e)
        {
            RearrangeControl();
        }

        private void OnLabelMouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
