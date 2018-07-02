using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Helpers
{
    public static class ReflectionExtension
    {
        // <summary>
        /// Gets the member info
        /// </summary>
        /// <param name="obj">source object</param>
        /// <param name="memberName">name of member</param>
        /// <returns>instanse of MemberInfo corresponsing to member</returns>
        private static MemberInfo GetMemberInfo(object obj, string memberName)
        {
            var prps = new List<System.Reflection.PropertyInfo>();

            prps.Add(obj.GetType().GetProperty(memberName,
                                               BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance |
                                               BindingFlags.FlattenHierarchy));
            prps = Enumerable.ToList(Enumerable.Where(prps, i => !ReferenceEquals(i, null)));
            if (prps.Count != 0)
                return prps[0];

            var flds = new List<FieldInfo>();

            flds.Add(obj.GetType().GetField(memberName,
                                            BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance |
                                            BindingFlags.FlattenHierarchy));

            //to add more types of properties

            flds = Enumerable.ToList(Enumerable.Where(flds, i => !ReferenceEquals(i, null)));

            if (flds.Count != 0)
                return flds[0];

            return null;
        }

        /// <summary>
        /// Gets the public or private member using reflection.
        /// </summary>
        /// <param name="obj">The source target.</param>
        /// <param name="memberName">Name of the field or property.</param>
        /// <returns>the value of member</returns>
        public static object GetMemberValue(this object obj, string memberName)
        {
            var memInf = GetMemberInfo(obj, memberName);

            if (memInf == null)
                throw new Exception("memberName");

            if (memInf is PropertyInfo)
                return memInf.As<PropertyInfo>().GetValue(obj, null);

            if (memInf is FieldInfo)
                return memInf.As<FieldInfo>().GetValue(obj);

            throw new System.Exception();
        }

        /// <summary>
        /// Gets the public or private member using reflection.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="memberName">Name of the field or property.</param>
        /// <returns>Old Value</returns>
        public static object SetMemberValue(this object obj, string memberName, object newValue)
        {
            var memInf = GetMemberInfo(obj, memberName);


            if (memInf == null)
                throw new Exception("memberName");

            var oldValue = obj.GetMemberValue(memberName);

            if (memInf is PropertyInfo)
                memInf.As<PropertyInfo>().SetValue(obj, newValue, null);
            else if (memInf is FieldInfo)
                memInf.As<FieldInfo>().SetValue(obj, newValue);
            else
                throw new Exception();

            return oldValue;
        }

        [System.Diagnostics.DebuggerHidden]
        public static T As<T>(this object obj)
        {
            return (T)obj;
        }
    }
}
