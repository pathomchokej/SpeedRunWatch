using SpeedRunWatchLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeedRunWatchApplication
{
    public partial class FormMain : Form
    {
        private SpeedRunWatch _watch = new SpeedRunWatch();
        private SpeedRunWatchControl _control = new SpeedRunWatchControl();
        private Timer _timer = new Timer();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FormMain()
        {
            InitializeComponent();

            this.panelDisplay.Controls.Add(_control);
            _control.Dock = DockStyle.Fill;

            _timer.Interval = 100;
            _timer.Tick += OnTick;
        }

        private void OnGlobalKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Oemcomma:
                    this.buttonControl_Click(this, e);
                    break;

                case Keys.OemPeriod:
                    this.buttonReset_Click(this, e);
                    break;
            }
        }

        private void RefreshScreen()
        {
            string realTime, speedRuntTime;
             _watch.GetTime(out realTime, out speedRuntTime);
            _control.RealTime = realTime;
            _control.SpeedRun = speedRuntTime;
        }

        private void OnTick(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            switch (_watch.ControlState)
            {
                case SpeedRunWatch.State.Stop:
                    _watch.Start();
                    _timer.Start();
                    break;

                case SpeedRunWatch.State.Pause:
                    _watch.Resume();
                    break;

                case SpeedRunWatch.State.Running:
                    _watch.Pause();
                    break;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            _watch.Stop();
            _timer.Stop();
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshScreen();
            InterceptKeys.StartHook();
            InterceptKeys.KeyUp += OnGlobalKeyUp;
        }

        protected override void OnClosed(EventArgs e)
        {
            InterceptKeys.EndHook();
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                MessageBox.Show("Context Menu");
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
