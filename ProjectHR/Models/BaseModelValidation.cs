using ProjectHR.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Models
{
    public class BaseModelValidation
            : BaseModel, IDataErrorInfo
    {
        /// <summary>
        /// словарь, в котором для имени свойства (модели)
        /// храним массив валидаторов
        /// </summary>
        protected Dictionary<string, MyValidationAttribute[]>
            validators;
        /// <summary>
        /// словарь, в котором для имени свойства (модели)
        /// храним делегат, возвращающий значение / get
        /// </summary>
        protected Dictionary<string, Func<BaseModelValidation, object>>
            propertyGetters;


        /// <summary>
        /// Метод для свойства
        /// возвращает массив
        /// аттрибутов MyValidationAttribute
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        protected MyValidationAttribute[]
            GetValidators(PropertyInfo prop)
        {
            return (MyValidationAttribute[])
            prop.GetCustomAttributes(typeof
                (MyValidationAttribute), true);
        }


        /// <summary>
        /// Метод возвращает делегат,
        /// позваоляющий для данного свойства
        /// брать его значение
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        protected
            Func<BaseModelValidation, object>
            GetPropertyGetter(PropertyInfo prop)
        {
            return new Func<BaseModelValidation, object>(
                model => prop.GetValue(model, null));
        }

        public BaseModelValidation()
        {
            // собираем информацию о
            // свойствах, их валидаторах
            // и getter
            this.validators = this.GetType()
                .GetProperties()
                .Where(p => this.GetValidators(p).Length != 0)
                .ToDictionary(p => p.Name,
                             p => this.GetValidators(p));
            //-------------------------------------------
            this.propertyGetters = this.GetType()
                .GetProperties()
                .Where(p => this.GetValidators(p).Length != 0)
                .ToDictionary(p => p.Name,
                              p => this.GetPropertyGetter(p));
        }


        public string Error
        {
            get
            {
                var errors =
                    from validator in validators
                    from attribute in validator.Value
                    where !attribute.IsValid(
                        this.propertyGetters[validator.Key](this))
                    select attribute.ErrorMessage;
                return string.Join("\r\n", errors);
            }
        }

        public string this[string propName]
        {
            get
            {
                // есть ли у нас для данного 
                // свойства валидатор?
                if (validators.ContainsKey(propName))
                {
                    // 1) считываем значение свойства:
                    var propValue = propertyGetters[propName](this);
                    // 2) перебираем все валидаторы
                    // если есть ошибка, - собираем
                    var errorMessages =
                        this.validators[propName]
                        .Where(v => !v.IsValid(propValue))
                        .Select(v => v.ErrorMessage)
                        .ToArray();
                    // массив ошибок но в виде одной строки
                    return string.Join("\r\n", errorMessages);
                }
                return string.Empty;
            }
        }
    };
}
