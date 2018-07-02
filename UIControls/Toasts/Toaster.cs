using NLog;
using System;
using System.Windows;
using UIControls.Utils;

namespace UIControls.Toasts
{
    public class Toaster : BaseSingleton<Toaster>
    {
        protected static ToastHost _Host = new ToastHost();

        public static TimeSpan DisplayTime = TimeSpan.FromSeconds(5);

        public static void SetParent(Window wnd)
        {
            var toaster = Toaster.Instance;
            _Host.SetParent(wnd);
        }

        private static ToastWrapper Create(string text, string msg = "")
        {
            string title = string.Empty;
            string message = string.Empty;
            if (string.IsNullOrEmpty(msg))
            {
                int i = text.IndexOf(' ');
                if (i < 0)
                {
                    message = text;
                }
                else
                {
                    title = text.Substring(0, i);
                    message = text.Substring(i, text.Length - i);
                }
            } else
            {
                title = text;
                message = msg;
            }
            ToastNotification notification = new ToastNotification()
            {
                Title = title,
                Message = message
            };
            //Create a toast and accompanying dispatcher timer.
            ToastWrapper toast = new ToastWrapper(notification);
            toast.ToastClosing += Toast_ToastClosing;
            //Add the toast to the host window
            _Host.Toasts.Add(notification);
            //display it for X seconds
            return toast;
        }

        public static void Success(string title, string msg = "")
        {
            ToastWrapper toast = Create(title, msg);
            toast.Type = ToastTypes.Success;
            toast.Show(DisplayTime);
        }

        public static void Warn(string title, string msg = "")
        {
            ToastWrapper toast = Create(title, msg);
            toast.Type = ToastTypes.Warning;
            toast.Show(DisplayTime);
        }

        public static void Error(string title, string msg = "")
        {
            ToastWrapper toast = Create(title, msg);
            toast.Type = ToastTypes.Error;
            toast.Show(DisplayTime);
        }

        public static void Info(string title, string msg = "")
        {
            ToastWrapper toast = Create(title, msg);
            toast.Type = ToastTypes.Info;
            toast.Show(DisplayTime);
        }

        private static void Toast_ToastClosing(object sender, ToastNotification e)
        {
            _Host.Toasts.Remove(e);
        }

        public static void Close()
        {
            _Host.Close();
        }
    }
}
