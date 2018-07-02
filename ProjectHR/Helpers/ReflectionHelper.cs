using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectHR.Helpers
{
    public class PropertyGetterKey
    {
        public Type Type { get; set; }
        public string PropertyName { get; set; }
    }

    public class ReflectionHelper
    {

        public static RoutedEventHandlerInfo[] GetRoutedEventHandlers(Type type, object obj, RoutedEvent routedEvent)
        {
            // Get the EventHandlersStore instance which holds event handlers for the specified element.
            // The EventHandlersStore class is declared as internal.
            PropertyInfo eventHandlersStoreProperty = type.GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic);
            object eventHandlersStore = eventHandlersStoreProperty.GetValue(obj, null);

            // If no event handlers are subscribed, eventHandlersStore will be null.
            if (eventHandlersStore == null)
                return null;

            // Invoke the GetRoutedEventHandlers method on the EventHandlersStore instance 
            // for getting an array of the subscribed event handlers.
            MethodInfo getRoutedEventHandlers = eventHandlersStore.GetType().GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            return (RoutedEventHandlerInfo[])getRoutedEventHandlers.Invoke(eventHandlersStore, new object[] { routedEvent });
        }

        public static Delegate CreateDelegate(MethodInfo methodInfo, object target)
        {
            Func<Type[], Type> getType;
            var isAction = methodInfo.ReturnType.Equals((typeof(void)));
            var types = methodInfo.GetParameters().Select(p => p.ParameterType);
            if (isAction)
            {
                getType = System.Linq.Expressions.Expression.GetActionType;
            }
            else
            {
                getType = System.Linq.Expressions.Expression.GetFuncType;
                types = types.Concat(new[] { methodInfo.ReturnType });
            }
            if (methodInfo.IsStatic)
            {
                return Delegate.CreateDelegate(getType(types.ToArray()), methodInfo);
            }
            return Delegate.CreateDelegate(getType(types.ToArray()), target, methodInfo.Name);
        }


        private static Dictionary<PropertyGetterKey, Func<object, object>> propertyGetters = 
            new Dictionary<PropertyGetterKey, Func<object, object>>();

        private static Func<object, object> CreateGetter(Type type, string propertyName)
        {
            var param = System.Linq.Expressions.Expression.Parameter(typeof(object), "e");
            System.Linq.Expressions.Expression body = System.Linq.Expressions.Expression
                .PropertyOrField(System.Linq.Expressions.Expression.TypeAs(param, type), propertyName);
            if (body.Type.IsValueType)
                body = System.Linq.Expressions.Expression.Convert(body, typeof(object));
            var getterExpression = System.Linq.Expressions.Expression.Lambda<Func<object, object>>(body, param);
            return getterExpression.Compile();
        }

        public static Func<object, object> GetGetter(Type type, string propertyName)
        {
            Func<object, object> getter;

            var key = new PropertyGetterKey { Type = type, PropertyName = propertyName };

            if (propertyGetters.ContainsKey(key))
                getter = propertyGetters[key];
            else
            {
                getter = CreateGetter(type, propertyName);
                propertyGetters.Add(key, getter);
            }
            return getter;
        }

        public static object GetPropertyValue(object entity, string propertyName)
        {
            Func<object, object> getter = GetGetter(entity.GetType(), propertyName);
            return getter(entity);
        }

    }
}
