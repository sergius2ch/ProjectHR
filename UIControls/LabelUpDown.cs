using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace UIControls
{
    public enum ArrowType
    {
        DownArrow,
        UpArrow
    };

    public class LabelUpDown : Label
    {
        public static DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(LabelUpDown));

        public static DependencyProperty LabelTextColorProperty =
            DependencyProperty.Register(
                "LabelTextColor",
                typeof(Brush),
                typeof(LabelUpDown));


        private Path _arrow1, _arrow2;
        private bool _flag = false;

        static LabelUpDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(LabelUpDown),
                new FrameworkPropertyMetadata(typeof(LabelUpDown)));
        }

        public LabelUpDown() : base()
        {

        }

        public ArrowType ArrowType
        {
            get
            {
                if (_flag)
                {
                    return ArrowType.DownArrow;
                }
                else
                {
                    return ArrowType.UpArrow;
                }
            }
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public Brush LabelTextColor
        {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _arrow1 = GetTemplateChild("PART_Arrow1") as Path;
            _arrow2 = GetTemplateChild("PART_Arrow2") as Path;
            this.MouseLeftButtonDown += LabelUpDown_MouseLeftButtonDown;
            LabelTextColor = Foreground;
        }

        public void HideArrow()
        {
            _arrow1.Visibility = Visibility.Collapsed;
            _arrow2.Visibility = Visibility.Collapsed;
        }

        public void ShowArrow()
        {
            if (_flag)
            {
                _arrow1.Visibility = Visibility.Visible;
                _arrow2.Visibility = Visibility.Collapsed;
            }
            else
            {
                _arrow1.Visibility = Visibility.Collapsed;
                _arrow2.Visibility = Visibility.Visible;
            }
        }

        private void LabelUpDown_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _flag = !_flag;
            if (_flag)
            {
                _arrow1.Visibility = Visibility.Visible;
                _arrow2.Visibility = Visibility.Collapsed;
            }
            else
            {
                _arrow1.Visibility = Visibility.Collapsed;
                _arrow2.Visibility = Visibility.Visible;
            }
        }
    }
}
