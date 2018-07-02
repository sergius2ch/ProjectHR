using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Validations
{
    public class TextLengthAttribute
        : MyValidationAttribute
    {
        public int MaxLength { get; set; }
        public int MinLength { get; set; }

        public TextLengthAttribute()
        {
            this.ErrorMessage = "Недопустимая длина текста";
            MinLength = 0;
            MaxLength = int.MaxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj == null) return false;
            string strValue = obj.ToString();
            return (strValue.Length >= MinLength &&
                    strValue.Length <= MaxLength);
        }
    }
}
