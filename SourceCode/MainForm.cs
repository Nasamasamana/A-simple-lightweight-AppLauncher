using System.Diagnostics;
using System.Windows.Forms;

namespace AppLauncher
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "A simple lightweight AppLauncher";
            Width = 800;
            Height = 500;

            var label = new Label()
            {
                Text = "Launcher is working!",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            Controls.Add(label);
        }
    }
}
