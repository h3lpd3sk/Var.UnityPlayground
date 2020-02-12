using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * @see https://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/
 * @see http://2024studios.blogspot.com/2017/06/hi-everyone-when-working-with-unity-and.html
 */
namespace ServiceLocator
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        //T Create<T>(params object[] arguments);
    }

    public class ServiceContainer : Dictionary<Type, Func<object>>
    {
    }

    public static class ServiceLocator //:IServiceLocator
    {
        /*
        private readonly ServiceContainer _serviceContainer = new ServiceContainer();

        public void Register<T>(Func<T> resolver)
        {
            if (_serviceContainer.ContainsKey(typeof(T)))
            {
                //
            }
            _serviceContainer[typeof(T)] = () => resolver();
        }
 
        public T Resolve<T>()
        {
            if(_serviceContainer.TryGetValue(typeof(T), out var resolver))
            {
                return (T)resolver();
            }
            return default(T);
        }
        */

        public static T Create<T>() where T:ScriptableObject //, new()
        {
            T instance = null;
            if (typeof(T).IsSubclassOf(typeof(ScriptableObject)))
            {
                instance = ScriptableObject.CreateInstance<T>();
            }
            return instance;
        }
    }
}
