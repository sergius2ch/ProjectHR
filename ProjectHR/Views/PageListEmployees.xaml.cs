using ProjectHR.Controllers;
using ProjectHR.DataAccessLayer;
using ProjectHR.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIControls;

namespace ProjectHR.Views
{
    /// <summary>
    /// Логика взаимодействия для PageListEmployees.xaml
    /// </summary>
    public partial class PageListEmployees : Page
    {
        private DataManager _data = DataManager.Instance;
        private static List<LabelUpDown> _labels;
        private LabelUpDown _currentLabel;

        public PageListEmployees()
        {
            DataContext = MainController.Instance;
            InitializeComponent();
            _labels = new List<LabelUpDown> { lbLastname, lbFirstname, lbDepartment, lbSkillLevel };
            listBoxEmployees.ItemsSource = _data.Employees;
            Loaded += PageListEmployees_Loaded;
            _labels.ForEach(x=> x.MouseDown += LabelMouseDown);
        }

        private void LabelMouseDown(object sender, MouseButtonEventArgs e)
        {
            var lb = (sender as LabelUpDown);
            if (lb != _currentLabel)
            {
                lb.ShowArrow();
                _currentLabel.HideArrow();
                _currentLabel = lb;
            }
            string propertyName = _currentLabel.LabelText;
            if (propertyName == "Department")
                propertyName = "CurrentDepartment";
            ArrowType arrowType = _currentLabel.ArrowType;
            _data.OrderEmployees(propertyName, arrowType);
        }

        private void PageListEmployees_Loaded(object sender, RoutedEventArgs e)
        {
            _labels.ForEach(x => x.HideArrow());
            lbLastname.ShowArrow();
            _currentLabel = lbLastname;
        }

        private void ListEmployeesSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object obj = listBoxEmployees.SelectedItem;
            if (obj != null)
            {
                if (MainController.CurrentEmployee == null)
                    MainController.CurrentEmployee = new Models.EmployeeViewModel();
                MainController.CurrentEmployee.Wrap(obj as Employee);
            }
        }
    }
}
