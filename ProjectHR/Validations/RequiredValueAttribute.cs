using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Validations
{
    public class RequiredValueAttribute
        : MyValidationAttribute
    {
        public RequiredValueAttribute()
        {
            this.ErrorMessage = "Обязательно значение";
        }

        public override bool IsValid(object obj)
        {
            string strValue = string.Empty;
            if (obj != null) strValue = obj.ToString();
            return
             (!string.IsNullOrWhiteSpace(strValue));
        }
    }
}
