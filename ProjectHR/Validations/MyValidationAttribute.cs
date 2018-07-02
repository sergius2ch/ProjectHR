using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Validations
{
    /// <summary>
    /// Базовый класс для валидации свойств модели!
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    abstract public class MyValidationAttribute : Attribute
    {
        private string _errorMsg;
        /// <summary>
        /// сообщение об ошибки валидации
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }
        /// <summary>
        /// функция проверки валидности
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        abstract public bool IsValid(object obj);
    }
}
