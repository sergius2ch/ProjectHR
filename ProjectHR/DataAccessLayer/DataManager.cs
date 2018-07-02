using ProjectHR.Domains;
using ProjectHR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;
using ProjectHR.Validations;
using ProjectHR.Helpers;
using UIControls;

namespace ProjectHR.DataAccessLayer
{
    /// <summary>
    /// Data management system with
    /// 1) dependency for IRepository in future for "Dependency Injection Pattern"
    /// 2) singleton pattern 
    /// </summary>
    public class DataManager : BaseSingleton<DataManager>
    {

        private static IRepository _repo;

        public bool AddEmployee(Employee empl)
        {
            bool isDone = _repo.AddEmployee(empl);
            return isDone;
        }

        async public Task<bool> AddEmployeeAsync(Employee empl)
        {
            bool isDone = await _repo.AddEmployeeAsync(empl);
            return isDone;
        }

        async public Task<bool> UpdateEmployee(Employee empl)
        {
            bool isDone = await _repo.UpdateEmployeeAsync(empl);
            return isDone;
        }


        private DataManager()
        {
            _repo = new EFRepository();            
        }

        public static List<Department> Departments
        {
            get
            {
                return _repo.GetDepartments().ToList();
            }
        }

        public void OrderEmployees(string propertyName, ArrowType arrowType)
        {
            Func<object, object> getter = ReflectionHelper.GetGetter(typeof(Employee), propertyName);
            if (arrowType == ArrowType.DownArrow)
                _observeEmployees.Sort(x => getter(x));
            else
                _observeEmployees.SortDescending(x => getter(x));
        }

        /// <summary>
        /// Filtering Employees By Department and/or SkillLevel
        /// </summary>
        /// <param name="objD">boxing Department</param>
        /// <param name="objS">boxing Skill</param>
        /// <returns>List of Employees</returns>
        public static List<Employee> FilterEmployees(object objD, object objS)
        {
            IEnumerable<Employee> filter = FilterEmployeesEnumerable(objD, objS);
            return filter.ToList();
        }

        private static IEnumerable<Employee> FilterEmployeesEnumerable(object objD, object objS)
        {
            IEnumerable<Employee> filter = Enumerable.Empty<Employee>();
            Department dep = null;
            SkillLevel skill = null;
            if (objD != null)
            {
                dep = (Department)objD;
                filter = dep.DepartmentStaff;
            }
            if (objS != null)
            {
                skill = (SkillLevel)objS;
                if (filter.Count() > 0)
                    filter = filter.Intersect(skill.Employees);
                else filter = skill.Employees;
            }
            return filter;
        }

        /// <summary>
        /// Find Employees by keyword with Filtering By Department and/or SkillLevel
        /// </summary>
        /// <param name="objD">boxing Department</param>
        /// <param name="objS">boxing Skill</param>
        /// <param name="keyword">keyword for search</param>
        /// <param name="properties">properties for test</param>
        /// <returns></returns>
        public static List<Employee> FindEmployeesWithFilter(object objD, object objS, string keyword, List<string> properties)
        {
            IEnumerable<Employee> filter = FilterEmployeesEnumerable(objD, objS);
            keyword = keyword.Trim().ToLower();
            IEnumerable<Employee> result = Enumerable.Empty<Employee>();
            foreach (var propertyName in properties)
            {
                IEnumerable<Employee> enumerableEmpl = _repo.FindEmployeesWithFilter(filter, keyword, propertyName);
                result = result.Union(enumerableEmpl);
            }
            return result.ToList();
        }

        public static List<Employee> FindEmployees(string keyword, List<string> properties)
        {
            keyword = keyword.Trim().ToLower();
            IEnumerable<Employee> result = Enumerable.Empty<Employee>();
            foreach (var propertyName in properties)
            {
                IEnumerable<Employee> enumerableEmpl = _repo.FindEmployees(keyword, propertyName);
                result = result.Union(enumerableEmpl);
            }
            return result.ToList();
        }

        public static List<Probation> ProbationPeriods
        {
            get
            {
                return _repo.GetProbations().ToList();
            }
        }

        public static List<SkillLevel> SkillLevels
        {
            get
            {
                return _repo.GetSkills().ToList();
            }
        }

        private MyObservableCollection<Employee> _observeEmployees;

        public void UpdateListEmployees(List<Employee> employees)
        {
            _observeEmployees.Clear();
            _observeEmployees.AddRange(employees);
        }

        public void ResetListEmployees()
        {
            _observeEmployees.Clear();
            _observeEmployees.AddRange(_repo.GetEmployees().ToList());
        }

        public MyObservableCollection<Employee> Employees
        {
            get
            {
                _observeEmployees = new MyObservableCollection<Employee>(_repo.GetEmployees().ToList());
                return _observeEmployees;
            }
        }

        public List<string> SearchItemsNames
        {
            get
            {
                return _repo.GetSearchItemsNames().ToList();
            }
        }
    }
}
