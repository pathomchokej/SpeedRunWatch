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
        private ContextMenuStrip _popupMenu = new ContextMenuStrip();

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
            _control.ControlMouseDown += FormMain_MouseDown;
            _control.ControlMouseUp += FormMain_MouseUp;

            _timer.Interval = 100;
            _timer.Tick += OnTick;

            InitializePopupMenu();
        }

        private void InitializePopupMenu()
        {
            //_popupMenu.Items.Add("Configuration");
            //_popupMenu.Items.Add("Borderless");
            //_popupMenu.Items.Add(new ToolStripSeparator());
            _popupMenu.Items.Add("Exit");
            _popupMenu.ItemClicked += OnPopupMenuItemClicked;
        }

        private void RefreshScreen()
        {
            string realTime, speedRuntTime;
            _watch.GetTime(out realTime, out speedRuntTime);
            _control.RealTime = realTime;
            _control.SpeedRun = speedRuntTime;
        }

        private void OnPopupMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            switch(item.Text.ToUpper())
            {
                case "EXIT":
                    Application.Exit();
                    break;
            }
        }

        private void OnGlobalKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    this.PauseORResume(this, e);
                    break;

                case Keys.Oemcomma:
                    this.Start(this, e);
                    break;

                case Keys.OemPeriod:
                    this.Reset(this, e);
                    break;
            }
        }

        private void OnTick(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshScreen();
            InterceptKeys.StartHook();
            InterceptKeys.KeyUp += OnGlobalKeyUp;
        }

        private void PauseORResume(object sender, EventArgs e)
        {
            switch (_watch.ControlState)
            {
                case SpeedRunWatch.State.Pause:
                    _watch.Resume();
                    break;

                case SpeedRunWatch.State.Running:
                    _watch.Pause();
                    break;
            }
        }

        private void Start(object sender, EventArgs e)
        {
            switch (_watch.ControlState)
            {
                case SpeedRunWatch.State.Stop:
                    _watch.Start();
                    _timer.Start();
                    break;
            }
        }

        private void Reset(object sender, EventArgs e)
        {
            _watch.Stop();
            _timer.Stop();
        }
        protected override void OnClosed(EventArgs e)
        {
            InterceptKeys.EndHook();
        }

        private void ShowPopupMenu(Point location)
        {
            _popupMenu.Show(PointToScreen(location));
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ShowPopupMenu(e.Location);
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
