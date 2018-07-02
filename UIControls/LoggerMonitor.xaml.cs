using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIControls.Utils;

namespace UIControls
{
    public partial class LoggerMonitor : UserControl
    {
        readonly MemoryEventTarget _logTarget;

        public static ObservableCollection<LogEventInfo> LogCollection { get; set; }

        public Target GetTarget()
        {
            return _logTarget;
        }

        public LoggerMonitor()
        {
            LogCollection = new ObservableCollection<LogEventInfo>();
            InitializeComponent();
            // init memory queue
            _logTarget = new MemoryEventTarget();
            _logTarget.EventReceived += EventReceived;
            // NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(_logTarget, LogLevel.Trace);
        }

        private void EventReceived(LogEventInfo message)
        {
            Dispatcher.Invoke(new Action(() => {
                if (LogCollection.Count >= 50) LogCollection.RemoveAt(LogCollection.Count - 1);
                LogCollection.Add(message);
            }));
        }

        public void ScrollToLast()
        {
            logView.ScrollIntoView(logView.Items.Count - 1);
        }

        public void Close()
        {
            _logTarget.EventReceived -= EventReceived;
            LogCollection.Clear();
            _logTarget.Dispose();
        }
    }
}
