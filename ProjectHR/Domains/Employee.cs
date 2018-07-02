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
    
    public partial class Employee
    {
        public override string ToString()
        {
            return $"{Lastname} {Firstname[0]}. {Secondname[0]}.";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.PropertiesChanges = new HashSet<Change>();
        }
    
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Lastname { get; set; }
        public System.DateTime Birthday { get; set; }
        public System.DateTime EmploymentDate { get; set; }
    
        public virtual Probation ProbationPeriod { get; set; }
        public virtual Department CurrentDepartment { get; set; }
        public virtual SkillLevel Skill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Change> PropertiesChanges { get; set; }
    }
}
