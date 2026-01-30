using System;
using System.Drawing;
using System.Windows.Forms;

namespace GoodbyeAhmetWPF.Services
{
    public class NotificationService : IDisposable
    {
        private static NotificationService? _instance;
        public static NotificationService Instance => _instance ??= new NotificationService();

        private NotifyIcon _notifyIcon;
        private ContextMenuStrip _contextMenu;

        private NotificationService()
        {
            _notifyIcon = new NotifyIcon();
            _contextMenu = new ContextMenuStrip();
            _notifyIcon.ContextMenuStrip = _contextMenu;

            // Need an icon. I can pull it from the current application or a resource
            // For now, I'll try to extract the icon from the entry assembly.
            try
            {
                // Try to use the application icon
                _notifyIcon.Icon = Icon.ExtractAssociatedIcon(System.Environment.ProcessPath ?? System.Reflection.Assembly.GetEntryAssembly()!.Location);
            }
            catch
            {
                _notifyIcon.Icon = SystemIcons.Application;
            }
            _notifyIcon.Visible = true;
            _notifyIcon.Text = "GoodbyeAhmet";
        }

        public void SetDoubleClickAction(Action action)
        {
            // Remove previous handlers if any (though difficult with lambda, assuming single assignment scenario)
            // Ideally we clear click handlers but NotifyIcon doesn't expose list elegantly.
            // We'll just assign a new handler wrapper.
            _notifyIcon.DoubleClick += (s, e) => action?.Invoke();
        }

        public void AddContextMenuItem(string text, Action action)
        {
            _contextMenu.Items.Add(text, null, (s, e) => action?.Invoke());
        }

        public void ShowNotification(string title, string content, ToolTipIcon icon = ToolTipIcon.Info)
        {
            _notifyIcon.ShowBalloonTip(3000, title, content, icon);
        }

        public void Dispose()
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();
            _contextMenu.Dispose();
        }
    }
}
