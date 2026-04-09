using System.Diagnostics;

namespace LightLauncher
{
    public class MainForm : Form
    {
        private FlowLayoutPanel panel = new FlowLayoutPanel();
        private NotifyIcon trayIcon = new NotifyIcon();
        private List<AppItem> apps;

        public MainForm()
        {
            Text = "Light Launcher";
            Width = 800;
            Height = 500;

            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            Controls.Add(panel);

            LoadAppsToUI();
            SetupTray();

            FormClosing += MainForm_FormClosing;
        }

        private void LoadAppsToUI()
        {
            apps = AppManager.LoadApps();
            panel.Controls.Clear();

            foreach (var app in apps)
            {
                var btn = CreateAppButton(app);
                panel.Controls.Add(btn);
            }
        }

        private Control CreateAppButton(AppItem app)
        {
            var btn = new Button();
            btn.Width = 100;
            btn.Height = 100;
            btn.Text = app.Name;
            btn.TextAlign = ContentAlignment.BottomCenter;

            btn.DoubleClick += (s, e) =>
            {
                Process.Start(new ProcessStartInfo(app.Path) { UseShellExecute = true });
            };

            return btn;
        }

        private void SetupTray()
        {
            trayIcon.Icon = SystemIcons.Application;
            trayIcon.Visible = true;

            trayIcon.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    menu.Items.Add("Restore", null, (s, e) => Show());
                    menu.Items.Add("Exit", null, (s, e) => Application.Exit());
                    menu.Show(Cursor.Position);
                }
            };
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
