using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NLog;
using ProjectHR.Controllers;
using ProjectHR.Domains;
using ProjectHR.Helpers;
using ProjectHR.Infrastructure;

namespace ProjectHR.DataAccessLayer
{
    /// <summary>
    /// EntityFramework Repository 
    /// for MS SQL Db from EDM (Entity Data Model) 
    /// </summary>
    public class EFRepository : IRepository
    {
        private ProjectModelContainer _container;
        protected static Logger log = LogManager.GetCurrentClassLogger();

        public EFRepository()
        {
            _container = new ProjectModelContainer();
        }

        async public Task<bool> AddEmployeeAsync(Employee empl)
        {
            _container.Employees.Add(empl);
            int rows = 0;
            try
            {
                rows = await _container.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Inspection.CurrentException = ex;
                Inspection.NotifyError(log, ex.Message);
                return false;
            }
            return (rows > 0);
        }


        public bool AddEmployee(Employee empl)
        {
            _container.Employees.Add(empl);
            int rows = 0;
            try
            {
                rows = _container.SaveChanges();
            }
            catch (Exception ex)
            {
                Inspection.CurrentException = ex;
                Inspection.NotifyError(log, ex.Message);
                return false;
            }
            return (rows > 0);
        }

        private void WriteChangesHistory(Employee freshEmpl, Employee prevEmpl)
        {
            Type t = freshEmpl.GetType();
            List<PropertyInfo> properties = t.GetProperties().ToList();
            properties.RemoveAll(p=>p.Name.StartsWith("Id"));
            foreach (var prop in properties)
            {
                string freshStr = ReflectionHelper.GetPropertyValue(freshEmpl, prop.Name).ToString();
                string prevStr = ReflectionHelper.GetPropertyValue(prevEmpl, prop.Name).ToString();
                if (freshStr != prevStr)
                {
                    var changeRecord = new Change()
                    {
                        ChangeDateTime = DateTime.Now,
                        NewValue = freshStr,
                        OldValue = prevStr,
                        PropertyName = prop.Name,
                        SubjectEmployee = prevEmpl
                    };
                    _container.Changes.Add(changeRecord);
                }
            }
        }

        async public Task<bool> UpdateEmployeeAsync(Employee empl)
        {
            return await Task<bool>.Run(() =>
            {
                int rows = 0;
                try
                {
                    var enity = _container.Employees.Find(empl.Id);
                    if (enity == null) return false;
                    WriteChangesHistory(empl, enity);
                    _container.Entry(enity).CurrentValues.SetValues(empl);
                    _container.Entry(enity).Reference(e => e.Skill).CurrentValue = empl.Skill;
                    _container.Entry(enity).Reference(e => e.ProbationPeriod).CurrentValue = empl.ProbationPeriod;
                    _container.Entry(enity).Reference(e => e.CurrentDepartment).CurrentValue = empl.CurrentDepartment;           
                    rows = _container.SaveChanges();
                }
                catch (Exception ex)
                {
                    Inspection.CurrentException = ex;
                    Inspection.NotifyError(log, ex.Message);
                    return false;
                }
                return (rows > 0);
            });
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _container.Departments;
        }

        public IEnumerable<Probation> GetProbations()
        {
            return _container.Probations;
        }

        public IEnumerable<SkillLevel> GetSkills()
        {
            return _container.SkillLevels;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _container.Employees.OrderBy(e => e.Lastname);
        }

        public IEnumerable<string> GetSearchItemsNames()
        {
            Type t = typeof(Employee);
            var properites = t.GetProperties()
                .Where(p=>p.Name.Contains("name"))
                .Select(p=>p.Name);
            return properites;
        }

        public IEnumerable<Employee> FindEmployees(string keyword, string propertyName)
        {
            Func<object, object> getter = ReflectionHelper.GetGetter(typeof(Employee), propertyName);
            var enumerableEmpl = GetEmployees()
                                        .Where(x => getter(x).ToString().ToLower().Contains(keyword))
                                        .Select(e => e);
            return enumerableEmpl;
        }

        public IEnumerable<Employee> FindEmployeesWithFilter(IEnumerable<Employee> filter, string keyword, string propertyName)
        {
            Func<object, object> getter = ReflectionHelper.GetGetter(typeof(Employee), propertyName);
            var enumerableEmpl = filter
                                       .Where(x => getter(x).ToString().ToLower().Contains(keyword))
                                       .Select(e => e);
            return enumerableEmpl;
        }
    }
}
