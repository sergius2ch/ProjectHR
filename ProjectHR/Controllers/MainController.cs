using NLog;
using ProjectHR.DataAccessLayer;
using ProjectHR.Domains;
using ProjectHR.Helpers;
using ProjectHR.Models;
using ProjectHR.Validations;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Reflection;

namespace ProjectHR.Controllers
{
    public class MainController : BaseSingleton<MainController>
    {
        public static LoggerMonitorWindow LoggerMonitorWindow { get; set; }

        public static Frame MainFrame { get; set; }

        public static Frame SearchFrame { get; set; }

        public static DataManager Data { private set; get; }

        public static EmployeeViewModel CurrentEmployee { get; set; }

        private static Employee employeeTemplate;

        

        public static RoutedUICommand SwitchLogMonitor { get; set; }

        public static RoutedUICommand SearchMode { get; set; }

        public static RoutedUICommand ViewAllEmployees { get; set; }

        public static RoutedUICommand SaveEmployee { get; set; }

        public static RoutedUICommand UpdateEmployee { get; set; }

        public static RoutedUICommand SelectExcelFile { get; set; }

        public static RoutedUICommand UndoEmployee { get; set; }

        public static RoutedUICommand NewEmployee { get; set; }

        public static RoutedUICommand ViewDetails { get; set; }

        public static RoutedUICommand ViewHistory { get; set; }

        public static RoutedUICommand EditEmployee { get; set; }

        public static RoutedUICommand TransferEmployee { get; set; }


        protected void RegisterAllCommandsViaReflections()
        {
            Type type = this.GetType();
            //--------------------
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
            List<MemberInfo> members = type.GetFields(bindingFlags)
                .Where(p => p.FieldType.Name.Contains("RoutedUICommand"))
                .Cast<MemberInfo>().ToList();
            //----------------------------
            Type commandType = typeof(RoutedUICommand);
            foreach (MemberInfo memInf  in members)
            {
                CommandBinding binding = null;
                string nameCommand = memInf.Name.SubstringInside("<", ">");
                var instanceCommand = (RoutedUICommand) Activator
                    .CreateInstance(commandType, new object[] { nameCommand, nameCommand, type});
                memInf.As<FieldInfo>().SetValue(this, instanceCommand);
                //-----------------------------------------------------
                string mNameExecuted = nameCommand + "Executed";
                MethodInfo methodInfoExec = type.GetMethod(mNameExecuted, bindingFlags);
                ExecutedRoutedEventHandler executedHandler = (a, e) => methodInfoExec.Invoke(a, new object[] { a, e });
                //------------------------------------------------------------------------------------
                string mNameCanExecuted = nameCommand + "CanExecuted";
                MethodInfo methodInfoCanExec = type.GetMethod(mNameCanExecuted, bindingFlags);
                CanExecuteRoutedEventHandler canExecuteHandler = null;
                if (methodInfoCanExec != null)
                    canExecuteHandler = (a, e) => methodInfoCanExec.Invoke(a, new object[] { a, e });
                //-------------------------------------------------------------------------------------
                binding = new CommandBinding(instanceCommand, executedHandler, canExecuteHandler);
                CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            }
        }

        private MainController()
        {
            Data = DataManager.Instance;
            RegisterAllCommandsViaReflections();
            //RegisterCommands();
            employeeTemplate = new Employee()
            {
                Firstname = "Иван",
                Secondname = "Иванович",
                Lastname = "Иванов",
                Birthday = new DateTime(2018, 3, 3),
                EmploymentDate = DateTime.Now,
            };
        }

        public static void ShowSearchResult(List<Employee> list)
        {
            Data.UpdateListEmployees(list);
        }

        public static string ProjectLocation
        {
            get
            {
                string exePath = Assembly.GetExecutingAssembly().Location;
                return System.IO.Path.GetDirectoryName(exePath);
            }
        }

        public static ProgressBar ProgressBar { get; internal set; }


        // replaced with method RegisterAllCommandsViaReflections
        private void RegisterCommands()
        {
            /*
            CommandBinding binding = null;
            Type t = this.GetType();
            SwitchLogMonitor = new RoutedUICommand("SwitchLogMonitor", "SwitchLogMonitor", t);
            binding = new CommandBinding(SwitchLogMonitor, SwitchLogMonitorExecuted, null);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //---------------------------------------------------------------------
            SearchMode = new RoutedUICommand("SearchMode", "SearchMode", t);
            binding = new CommandBinding(SearchMode, SearchModeExecuted, SearchModeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //---------------------------------------------------------------------
            ViewAllEmployees = new RoutedUICommand("ViewAllEmployees", "ViewAllEmployees", t);
            binding = new CommandBinding(ViewAllEmployees, ViewAllEmployeesExecuted, null);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //---------------------------------------------------------------------
            SaveEmployee = new RoutedUICommand("Save", "SaveEmployee", t);
            binding = new CommandBinding(SaveEmployee, SaveEmployeeExecuted, SaveEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            UpdateEmployee = new RoutedUICommand("Update", "UpdateEmployee", t);
            binding = new CommandBinding(UpdateEmployee, UpdateEmployeeExecuted, UpdateEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            UndoEmployee = new RoutedUICommand("Undo", "UndoEmployee", t);
            binding = new CommandBinding(UndoEmployee, UndoEmployeeExecuted, UndoEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //---------------------------------------------------------------------
            NewEmployee = new RoutedUICommand("NewEmployee", "NewEmployee", t);
            binding = new CommandBinding(NewEmployee, NewEmployeeExecuted, NewEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //---------------------------------------------------------------------
            ViewDetails = new RoutedUICommand("ViewDetails", "ViewDetails", t);
            binding = new CommandBinding(ViewDetails, ViewDetailsExecuted, ViewDetailsCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            ViewHistory = new RoutedUICommand("ViewHistory", "ViewHistory", t);
            binding = new CommandBinding(ViewHistory, ViewHistoryExecuted, ViewHistoryCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            EditEmployee = new RoutedUICommand("EditEmployee", "EditEmployee", t);
            binding = new CommandBinding(EditEmployee, EditEmployeeExecuted, EditEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            TransferEmployee = new RoutedUICommand("TransferEmployee", "TransferEmployee", t);
            binding = new CommandBinding(TransferEmployee, TransferEmployeeExecuted, TransferEmployeeCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            //----------------------------------------------------------------------
            SelectExcelFile = new RoutedUICommand("SelectExcelFile", "SelectExcelFile", t);
            binding = new CommandBinding(SelectExcelFile, SelectExcelFileExecuted, null);
            CommandManager.RegisterClassCommandBinding(typeof(MainWindow), binding);
            */
        }

        private static bool IsListEmployeesVisible = true;
        private static bool IsSearchActive = false;

        private static void SwitchLogMonitorExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (LoggerMonitorWindow == null)
                LoggerMonitorWindow = new LoggerMonitorWindow();
            if (LoggerMonitorWindow.Visibility == Visibility.Visible)
            {
                LoggerMonitorWindow.Visibility = Visibility.Hidden;
            }
            else
            {
                LoggerMonitorWindow.Show();
            }
            e.Handled = true;
        }

        private static void SearchModeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = IsListEmployeesVisible;
        }

        private static void SearchModeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            IsSearchActive = !IsSearchActive;
            SearchFrame.Visibility = IsSearchActive ? Visibility.Visible : Visibility.Hidden;
            e.Handled = true;
        }

        private static void ActivateView(string name)
        {
            log.Info("ActivateView "+name);
            //-----------------------------
            if (name.EndsWith("Details") || name.EndsWith("History"))
                IsListEmployeesVisible = false;
            else
                IsListEmployeesVisible = true;
            SearchFrame.Visibility = (IsListEmployeesVisible && IsSearchActive) ? Visibility.Visible : Visibility.Hidden;
            Uri uri = new Uri($"Views/{name}.xaml", UriKind.Relative);
            var page = (Page)Application.LoadComponent(uri);
            MainFrame.Content = page;
        }

        private static void ViewAllEmployeesExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentEmployee = null;
            IsListEmployeesVisible = true;
            ActivateView("PageListEmployees");
            e.Handled = true;
        }

        private static bool IsDepartmentAlreadyFull(Employee empl)
        {
            Department dep = empl.CurrentDepartment;
            int quantity = dep.DepartmentStaff.Count;
            int.TryParse(dep.MaxNumberEmployees, out int max);
            return (quantity == max);
        }

        async private static void SaveEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (CurrentEmployee.Skill.Level > 2)
            {
                Inspection.NotifyError(log, "A new employee can not be assigned a level above 2!");
                return;
            }
            Employee empl = CurrentEmployee.ApplyChanges();
            if (empl.Id == 0)
            {
                if (IsDepartmentAlreadyFull(empl))
                {
                    MessageBoxResult res = 
                    MessageBox.Show( "The Department is already full \r\n" 
                                   + "Please, confirm the appointment of the employee as a Director", 
                                    "Warning", 
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Warning);
                    if (res == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                bool isDone = await Data.AddEmployeeAsync(empl);
                if (isDone)
                {
                    CurrentEmployee.Wrap(empl);
                    CurrentEmployee.SetEdit();
                    Inspection.NotifySuccess(log, $"Employee {empl} Saved!");
                } else
                {
                    Inspection.NotifyError(log, "Can't save!");
                }
            }
            e.Handled = true;
        }

        private static void SaveEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool isValid = MyValidator.IsModelValid(sender as DependencyObject);
            e.CanExecute = CurrentEmployee.Id == 0 && CurrentEmployee.IsChanged && isValid;
        }

        async private static void UpdateEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Employee empl = CurrentEmployee.ApplyChanges();
            if (empl.Id != 0)
            {
                bool isDone = await Data.UpdateEmployee(empl);
                if (isDone)
                {
                    CurrentEmployee.Wrap(empl);
                    CurrentEmployee.SetEdit();
                    Inspection.NotifySuccess(log, $"Employee {empl} Updated!");
                }
                else
                {
                    Inspection.NotifyError(log, "Сan't update!");
                }
            }
            e.Handled = true;
        }

        private static void UpdateEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool isValid = MyValidator.IsModelValid(sender as DependencyObject);
            e.CanExecute = CurrentEmployee.Id != 0 && CurrentEmployee.IsChanged && isValid;
        }

        private static void UndoEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentEmployee.Restore();
            var empl = CurrentEmployee;
            Inspection.NotifySuccess(log, $"Employee {empl} restore!");
            e.Handled = true;
        }

        private static void UndoEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentEmployee.IsChanged;
        }

        private static void NewEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            employeeTemplate.EmploymentDate = DateTime.Now;
            Employee empl = employeeTemplate;
            if (CurrentEmployee == null) CurrentEmployee = new EmployeeViewModel();
            CurrentEmployee.Wrap(empl);
            CurrentEmployee.SetCreate();
            ActivateView("PageEmployeeDetails");
            e.Handled = true;
        }

        private static void NewEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private static void ViewDetailsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentEmployee.SetView();
            ActivateView("PageEmployeeDetails");
            e.Handled = true;
        }

        private static void ViewDetailsCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentEmployee != null;
        }
        private static void ViewHistoryExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ActivateView("PageEmployeeHistory");
            e.Handled = true;
        }

        private static void ViewHistoryCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentEmployee != null;
        }

        private static void EditEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            CurrentEmployee.SetEdit();
            ActivateView("PageEmployeeDetails");
            e.Handled = true;
        }

        private static void EditEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
           e.CanExecute = CurrentEmployee != null;
        }

        private static void TransferEmployeeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            bool canTransfer = IsTransferPossible();
            if (canTransfer)
            {
                CurrentEmployee.SetTransfer();
                ActivateView("PageEmployeeDetails");
                e.Handled = true;
            }
            else
            {
                var empl = CurrentEmployee;
                Inspection.NotifyError(log, $"Transfer is not possible, probation period for '{empl}' is not over");
            }
        }

        private static bool IsTransferPossible()
        {
            var today = DateTime.Now;
            var delta = today - CurrentEmployee.EmploymentDate;
            int monthsPassed = (int) (delta.TotalDays / 30);
            int monthsProbation = CurrentEmployee.ProbationPeriod.DurationInMonth;
            return (monthsPassed >= monthsProbation);
        }

        private static void TransferEmployeeCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CurrentEmployee != null;
        }

        async private static void SelectExcelFileExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (ExcelImporter.SelectExcelFile())
            {
                if (ExcelImporter.OpenReadExcelFile())
                {
                    ProgressBar.Visibility = Visibility.Visible;
                    var progressReport = new Progress<int>(percent => ProgressBar.Value = percent);
                    await ExcelImporter.ProceedEmployeesRecordsAsync(progressReport);
                    ProgressBar.Visibility = Visibility.Hidden;
                    Inspection.NotifySuccess(log, "Xls import completed!");
                    Data.ResetListEmployees();
                }
            }
            e.Handled = true;
        }
    }
}
