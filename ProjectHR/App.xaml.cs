using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using ProjectHR.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHR
{
    public partial class App : Application
    {
        private Logger log;
        public App()
        {
            ConfigureLogger();
            log = LogManager.GetCurrentClassLogger();
            Exit += App_Exit;
            //log.Info("The logger is configured, the application is running");
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            log.Info("The application stopped in normal mode");
        }

        private void ConfigureLogger()
        {
            var date = DateTime.Now;
            string timeStr = date.ToShortDateString() + "_" + date.ToShortTimeString();

            var t1 = LoggerMonitorWrapper.Instance.GetTarget();
            var wrapper1 = new AsyncTargetWrapper(t1, 5000, AsyncTargetWrapperOverflowAction.Discard);
           
            var t2 = new FileTarget();
            var wrapper2 = new AsyncTargetWrapper(t2, 5000, AsyncTargetWrapperOverflowAction.Discard);
            t2.Layout = "[${date}] (${level}) ${message} // ${callsite} at line ${callsite-linenumber}";
            t2.FileName = "${basedir}/Logs/" + timeStr + ".log";
            t2.KeepFileOpen = false;
            t2.Encoding = Encoding.UTF8;
            var config = new LoggingConfiguration();
            config.AddTarget("logControl", wrapper1);
            config.AddTarget("logfile", wrapper2);
            var rule1 = new LoggingRule("*", LogLevel.Trace, t1);
            var rule2 = new LoggingRule("*", LogLevel.Trace, t2);
            config.LoggingRules.Add(rule1);
            config.LoggingRules.Add(rule2);
            LogManager.Configuration = config;
        }
    }
}
