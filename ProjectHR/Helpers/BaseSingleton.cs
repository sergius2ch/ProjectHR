using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHR.Helpers
{
    public abstract class BaseSingleton<T>
    {
        protected static Logger log = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<T> _instance;

        public static T Instance { get { return _instance.Value; } }

        static BaseSingleton()
        {
            _instance = new Lazy<T>(() =>
            {
                try
                {
                    // Binding flags include private constructors.
                    var constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                    return (T)constructor.Invoke(null);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Problems with constructor");
                }
            });
        }
    }
}
