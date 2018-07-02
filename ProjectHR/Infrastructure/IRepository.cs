using ProjectHR.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Infrastructure
{
    public interface IRepository
    {
        IEnumerable<Employee> GetEmployees();
        IEnumerable<Department> GetDepartments();
        IEnumerable<SkillLevel> GetSkills();
        IEnumerable<Probation> GetProbations();
        Task<bool> AddEmployeeAsync(Employee empl);
        bool AddEmployee(Employee empl);
        Task<bool> UpdateEmployeeAsync(Employee empl);

        IEnumerable<string> GetSearchItemsNames();
        IEnumerable<Employee> FindEmployees(string keyword, string propertyName);
        IEnumerable<Employee> FindEmployeesWithFilter(IEnumerable<Employee> filter, string keyword, string propertyName);
    }
}
