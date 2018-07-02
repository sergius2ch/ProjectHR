using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIControls.Toasts;

namespace ProjectHR.Controllers
{
    /// <summary>
    /// Notification center 
    /// </summary>
    public class Inspection
    {
        public static Exception CurrentException;

        public static void NotifySuccess(Logger log, string msg)
        {
            log.Info(msg);
            Toaster.Success("Success", msg);
            CurrentException = null;
        }

        public static void ShowMessage(Logger log, string msg)
        {
            log.Info(msg);
            Toaster.Info("Message", msg);
            CurrentException = null;
        }

        public static void NotifyError(Logger log, string msg)
        {
            log.Warn(msg);
            if (CurrentException != null)
                log.Error(CurrentException);
            Toaster.Error("Error", msg);
            CurrentException = null;
        }
    }
}
