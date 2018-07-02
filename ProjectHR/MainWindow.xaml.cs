using NLog;
using ProjectHR.Controllers;
using System.Collections.Generic;
using System.Windows;
using UIControls;
using UIControls.Toasts;

namespace ProjectHR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController _ctrl = MainController.Instance;
        private Logger log = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            Toaster.SetParent(this);
            searchFrame.Visibility = Visibility.Hidden;
            DataContext = MainController.Instance;
            MainController.MainFrame = mainFrame;
            MainController.SearchFrame = searchFrame;
            MainController.ProgressBar = progressBar;
            log.Info("Main Window Started");
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, System.EventArgs e)
        {
            MainController.LoggerMonitorWindow?.Close();
            LoggerMonitorWrapper.Instance.Close();
            Toaster.Close();
        }
    }
}
