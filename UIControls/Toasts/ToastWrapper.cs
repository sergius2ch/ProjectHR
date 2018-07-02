using System;
using System.Windows.Threading;

namespace UIControls.Toasts
{
    public class ToastWrapper
    {
        private DispatcherTimer _Timer;
        private ToastNotification _Notification;

        public event EventHandler<ToastNotification> ToastClosing;

        public ToastTypes Type
        {
            set
            {
                _Notification.ToastType = value;
            }
        }

        public ToastWrapper(ToastNotification notification)
        {
            _Notification = notification;
            _Notification.Dismissed += Notification_Dismissed;
        }

        private void Notification_Dismissed(object sender, EventArgs e)
        {
            OnToastClosing();
            _Timer.Stop();
            _Timer.Tick -= Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _Timer.Tick -= Timer_Tick;
            _Timer.Stop();
            OnToastClosing();
        }

        protected void OnToastClosing()
        {
            _Notification.Dismissed -= Notification_Dismissed;
            var eh = ToastClosing;

            if (eh != null)
                eh(this, _Notification);
        }

        internal void Show(TimeSpan displayTime)
        {
            _Timer = new DispatcherTimer();
            _Timer.Interval = displayTime;
            _Timer.Tick += Timer_Tick;
            _Timer.Start();
        }
    }
}
