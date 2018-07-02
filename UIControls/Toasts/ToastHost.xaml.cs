using System;
using System.Windows;
using UIControls.Utils;

namespace UIControls.Toasts
{
    /// <summary>
    /// Логика взаимодействия для ToastHost.xaml
    /// </summary>
    public partial class ToastHost : Window
    {
        protected Vector _DeltaPos;
        protected Window _Parent;

        public NotifyObservableCollection<ToastNotification> Toasts
        {
            get { return (NotifyObservableCollection<ToastNotification>)GetValue(ToastsProperty); }
            set { SetValue(ToastsProperty, value); }
        }

        public static readonly DependencyProperty ToastsProperty =
            DependencyProperty.Register("Toasts", typeof(NotifyObservableCollection<ToastNotification>),
                typeof(ToastHost), new PropertyMetadata(new NotifyObservableCollection<ToastNotification>()));

        public ToastHost()
        {
            InitializeComponent();
            _DeltaPos = new Vector(10, +20);
            Toasts.Changed += ToastsChanged;
        }

        private void ToastsChanged()
        {
            if (Toasts.Count == 0)
            {
                this.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (this.Visibility == Visibility.Collapsed)
                {
                    this.Show();
                    SetPosition();
                }
            }
        }

        public void SetParent(Window wnd)
        {
            _Parent = wnd;
            _Parent.SizeChanged += _ParentSizeChanged;
            _Parent.LocationChanged += _Parent_LocationChanged;
            _Parent.StateChanged += _ParentStateChanged;
        }

        private void SetPosition()
        {
            int Left = 0;
            int Top = 0;
            if (_Parent.WindowState != WindowState.Maximized)
            {
                if (! double.IsNaN(_Parent.Left))
                {
                    Left = (int)_Parent.Left;
                    Top = (int)_Parent.Top;
                }
            }
            this.Left = Left + _Parent.ActualWidth - this.ActualWidth + _DeltaPos.X;
            this.Top = Top + _DeltaPos.Y;
        }

        private void _ParentStateChanged(object sender, EventArgs e)
        {
            SetPosition();
        }

        private void _Parent_LocationChanged(object sender, EventArgs e)
        {
            SetPosition();
        }

        private void _ParentSizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetPosition();
        }
    }
}
