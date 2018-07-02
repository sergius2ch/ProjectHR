using ProjectHR.Controllers;
using ProjectHR.DataAccessLayer;
using ProjectHR.Domains;
using ProjectHR.Models;
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

namespace ProjectHR.Views
{
    /// <summary>
    /// Логика взаимодействия для PageEmployeeHistory.xaml
    /// </summary>
    public partial class PageEmployeeHistory : Page
    {
        public PageEmployeeHistory()
        {
            InitializeComponent();
            DataContext = MainController.Instance;
            //------------------------------------
            EmployeeViewModel emplView = MainController.CurrentEmployee;
            Employee empl = emplView.Source;
            listBoxHistory.ItemsSource = empl
                .PropertiesChanges
                .OrderBy(x=>x.ChangeDateTime)
                .ToList();
        }
    }
}
