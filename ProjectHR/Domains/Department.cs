//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectHR.Domains
{
    using System;
    using System.Collections.Generic;
    
    public partial class Department:IComparable
    {
        public int CompareTo(object obj)
        {
            var dep = obj as Department;
            return this.Title.CompareTo(dep.Title);
        }

        public override string ToString()
        {
            return Title;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            this.DepartmentStaff = new HashSet<Employee>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string MaxNumberEmployees { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> DepartmentStaff { get; set; }
    }
}
