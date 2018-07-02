using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectHR.Validations
{
    public class RegExPatternAttribute
        : MyValidationAttribute
    {
        protected Regex rx;

        public RegExPatternAttribute()
        {
            this.ErrorMessage = "Не соответсвует шаблону";
        }

        public string Pattern
        {
            get { return string.Empty; }
            set
            {
                rx = new Regex(value,
                    RegexOptions.Compiled);
            }
        }

        public override bool IsValid(object obj)
        {
            if (obj == null) return false;
            string strValue = obj.ToString();
            bool result = rx.IsMatch(strValue);
            return result;
            //return m.Success;
        }
    }
}
