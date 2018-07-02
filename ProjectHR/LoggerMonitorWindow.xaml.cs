using NLog;
using ProjectHR.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace ProjectHR
{
    /// <summary>
    /// Логика взаимодействия для LoggerMonitorWindow.xaml
    /// </summary>
    public partial class LoggerMonitorWindow : Window
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private UserControl _control;

        public LoggerMonitorWindow()
        {
            InitializeComponent();
            _control = LoggerMonitorWrapper.Instance;
            Grid.SetRow(_control, 1);
            mainGrid.Children.Add(_control);
            this.Closed += LoggerMonitorWindow_Closed;
        }

        private void LoggerMonitorWindow_Closed(object sender, System.EventArgs e)
        {
            mainGrid.Children.Remove(_control);
            MainController.LoggerMonitorWindow = null;
        }
    }
}
