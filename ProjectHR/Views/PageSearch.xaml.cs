using ProjectHR.Controllers;
using ProjectHR.DataAccessLayer;
using ProjectHR.Domains;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UIControls;

namespace ProjectHR.Views
{
    /// <summary>
    /// Логика взаимодействия для PageSearch.xaml
    /// </summary>
    public partial class PageSearch : Page
    {
        private DataManager _data = MainController.Data;

        public PageSearch()
        {
            DataContext = MainController.Instance;
            InitializeComponent();
            //-----------------------------------
            searchBox.SectionsList = _data.SearchItemsNames;
            searchBox.SectionsStyle = SearchTextBox.SectionsStyles.CheckBoxStyle;
            searchBox.OnSearch += SearchBoxOnSearch;
        }

        private void SearchBoxOnSearch(object sender, RoutedEventArgs e)
        {
            SearchEventArgs searchArgs = e as SearchEventArgs;
            List<string> sections = searchArgs.Sections;
            string key = searchArgs.Keyword.Trim();
            if (sections.Count == 0)
            {
                sections = _data.SearchItemsNames;
            }
            //-------------------------------------
            List<Employee> list = null;
            object objD = cbD.SelectedItem;
            object objS = cbS.SelectedItem;
            //-------------------------
            if (string.IsNullOrEmpty(key))
            {
                list = DataManager.FilterEmployees(objD, objS);
            } else
            if (objD != null || objS != null)
            {
                list = DataManager.FindEmployeesWithFilter(objD, objS, key, sections);
            }
            else
            {
                list = DataManager.FindEmployees(key, sections);
            }
            MainController.ShowSearchResult(list);
        }

        private void BtnResetSearchClick(object sender, RoutedEventArgs e)
        {
            searchBox.Text = "";
            cbD.SelectedItem = null;
            cbS.SelectedItem = null;
            _data.ResetListEmployees();
        }

        private void BtnGoSearchClick(object sender, RoutedEventArgs e)
        {
            var searchArgs = new SearchEventArgs()
            {
                Keyword = searchBox.Text,
                Sections = searchBox.SectionsList
            };
            SearchBoxOnSearch(btnGoSearch, searchArgs);
        }
    }
}
