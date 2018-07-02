using ProjectHR.Domains;
using ProjectHR.Validations;
using System;

namespace ProjectHR.Models
{
    /// <summary>
    /// class Wrapper for Employee with 
    /// 1) Model Validation Support
    /// 2) boolean properties for permissions to edit
    /// 3) INotifyPropertyChanged interface implementation for two way data binding
    /// 4) Undo and Aply changes function
    /// </summary>
    public class EmployeeViewModel : BaseModelValidation
    {
        private Employee _clone;
        private Employee _source;

        public bool IsChanged
        {
            get { return _isChanged; }
            set { _isChanged = value; }
        }

        #region basic properties of the employee

        [RequiredValue(ErrorMessage = "Name required!")]
        [TextLength(MinLength = 2, MaxLength = 20, ErrorMessage = "The length of the text must be between 2 and 20 characters")]
        [RegExPattern(Pattern = @"\b[а-яА-Я]{1,}\b", ErrorMessage = "Text only in Russian letters!")]
        public string Firstname
        {
            get
            {
                return _clone.Firstname;
            }
            set
            {
                _clone.Firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        [RequiredValue(ErrorMessage = "Secondname required!")]
        [TextLength(MinLength = 2, MaxLength = 20, ErrorMessage = "The length of the text must be between 2 and 20 characters")]
        [RegExPattern(Pattern = @"\b[а-яА-Я]{1,}\b", ErrorMessage = "Text only in Russian letters!")]
        public string Secondname
        {
            get
            {
                return _clone.Secondname;
            }
            set
            {
                _clone.Secondname = value;
                OnPropertyChanged("Secondname");
            }
        }

        [RequiredValue(ErrorMessage = "Lastname required!")]
        [TextLength(MinLength = 2, MaxLength = 20, ErrorMessage = "The length of the text must be between 2 and 20 characters")]
        [RegExPattern(Pattern = @"\b[а-яА-Я]{1,}\b", ErrorMessage = "Text only in Russian letters!")]
        public string Lastname
        {
            get
            {
                return _clone.Lastname;
            }
            set
            {
                _clone.Lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        [RequiredValue(ErrorMessage = "Birthday required!")]
        public DateTime Birthday
        {
            get
            {
                return _clone.Birthday;
            }
            set
            {
                _clone.Birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public DateTime EmploymentDate
        {
            get
            {
                return _clone.EmploymentDate;
            }
            set
            {
                _clone.EmploymentDate = value;
                OnPropertyChanged("EmploymentDate");
            }
        }

        [RequiredValue(ErrorMessage = "The probation period must be specified!")]
        public Probation ProbationPeriod
        {
            get
            {
                return _clone.ProbationPeriod;
            }
            set
            {
                _clone.ProbationPeriod = value;
                OnPropertyChanged("ProbationPeriod");
            }
        }
        
        [RequiredValue(ErrorMessage = "Department must be specified!")]
        public Department CurrentDepartment
        {
            get
            {
                return _clone.CurrentDepartment;
            }
            set
            {
                _clone.CurrentDepartment = value;
                OnPropertyChanged("CurrentDepartment");
            }
        }

        [RequiredValue(ErrorMessage = "The level of qualification must specify!")]
        public SkillLevel Skill
        {
            get
            {
                return _clone.Skill;
            }
            set
            {
                _clone.Skill = value;
                OnPropertyChanged("Skill");
            }
        }

        public int Id
        {
            get
            {
                return _clone.Id;
            }
            set
            {
                _clone.Id = value;
                OnPropertyChanged("Id");
            }
        }
        #endregion

        public bool CanChangeBasics { get; private set; }
        public bool CanChangeProbation { get; private set; }
        public bool CanChangeEmploymentDate { get; private set; }
        public bool CanChangeDepartment { get; private set; }
        public bool CanChangeSkill { get; private set; }


        public void SetView()
        {
            CanChangeBasics = false;
            CanChangeProbation = false;
            CanChangeDepartment = false;
            CanChangeEmploymentDate = false;
            CanChangeSkill = false;
            _isChanged = false;
        }

        public void SetCreate()
        {
            CanChangeBasics = true;
            CanChangeProbation = true;
            CanChangeDepartment = true;
            CanChangeEmploymentDate = true;
            CanChangeSkill = true;
            _isChanged = false;
        }

        public void SetEdit()
        {
            CanChangeBasics = true;
            CanChangeProbation = false;
            CanChangeDepartment = false;
            CanChangeEmploymentDate = true;
            CanChangeSkill = true;
            _isChanged = false;
        }

        public void SetTransfer()
        {
            CanChangeBasics = false;
            CanChangeProbation = false;
            CanChangeDepartment = true;
            CanChangeEmploymentDate = false;
            CanChangeSkill = false;
            _isChanged = false;
        }

        public EmployeeViewModel()
        {
            _clone = new Employee();
        }

        public Employee ApplyChanges()
        {
            _source = _clone;
            _isChanged = false;
            return _clone;
        }

        public void Restore()
        {
            Wrap(_source);
            _isChanged = false;
        }

        public Employee Source
        {
            get
            {
                return _source;
            }
        }

        public void Wrap(Employee empl)
        {
            _source = empl;
            Birthday = empl.Birthday;
            CurrentDepartment = empl.CurrentDepartment;
            EmploymentDate = empl.EmploymentDate;
            Firstname = empl.Firstname;
            Secondname = empl.Secondname;
            Id = empl.Id;
            Lastname = empl.Lastname;
            ProbationPeriod = empl.ProbationPeriod;
            Skill = empl.Skill;
        }
    }
}
