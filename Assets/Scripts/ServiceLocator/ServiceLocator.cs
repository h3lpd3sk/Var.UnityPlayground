using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/**
 * @see https://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/
 * @see http://2024studios.blogspot.com/2017/06/hi-everyone-when-working-with-unity-and.html
 * @see https://digitalrune.github.io/DigitalRune-Documentation/html/ce7bca46-717a-4dfb-a154-acb6ee1e8ad9.htm
 * @see 
 */
namespace ServiceLocator
{
    /*
    public interface ILocator<T>
    {
        T Resolve();
    }

    public interface IProvider<T> : ILocator<T> 
    {}

    public class Container<T> 
    {
        private List<ILocator<T>> services = new List<ILocator<T>>();

        private IProvider<T>[] providers
        {
            get => services.Where(x => x is IProvider<T>).ToArray() as IProvider<T>[];
        }

        private ILocator<T>[] locators
        {
            get => services.Where(x => !(x is IProvider<T>)).ToArray();
        }

        public void AddService(ILocator<T> service)
        {
            services.Add(service);
        }
        public T GetInstance()
        {
            var instance = locators.Select(x => x.Resolve()).FirstOrDefault();
            if (instance == null)
            {
                return providers.Select(x => x.Resolve()).FirstOrDefault();
            }
            return instance;
        }
        public T[] GetInstances()
        {
            var instances = locators.Select(x => x.Resolve()).ToArray();
            if (instances == null)
            {
                return providers.Select(x => x.Resolve()).ToArray();
            }
            return instances;
        }
    }

    public class A {
        public A(){ }
    }
    public class AProvider : IProvider<A>
    {
        public A Resolve()
        {
            return new A();
        }
    }

    public class ALocator: ILocator<A>
    {
        private A[] _a = new A[]{ };

        public A Resolve()
        {
            return _a.FirstOrDefault();
        }
    }

    class Test {
        Test() {
            var container = new Container<A>();
            container.AddService(new AProvider());
            var a = container.GetInstance();
        }
    }

    class Factory {

        public T Create<T>() where T:class {
            //typeof(T).GetConstructor();
            //return Activator.CreateInstance(typeof(T).ToString());
        }
    }
    */

    //public interface IServiceLocator
    //{
    //T Resolve<T>();
    //T Create<T>(params object[] arguments);
    //}

    //class Provider<T> {}

    //public class ServiceContainer : Dictionary<Type, Func<object>>
    //{
    //}
    public class Container<T> where T: class
    {
        private IDictionary<Type, T> services = new Dictionary<Type, T>();

        public T GetService()
        {
            T instance = default(T);
            if (services.TryGetValue(typeof(T), out instance))
            {
                return instance;
            }

            if (typeof(T).IsSubclassOf(typeof(ScriptableObject)))
            { 
            
            }

            //if (typeof(T).IsGenericType(ScriptableObject)) { 
            //
            //}

            //try
            //{
            //    instance = Activator.CreateInstance<T>();
            //}
            //catch (){ }

            return instance;
        }

        public T Create(){
            var instance = Activator.CreateInstance<T>();
            try
            {
                services.Add(typeof(T), instance);
            }
            catch (KeyNotFoundException e) {
                throw new ApplicationException("The requested service is not registered");
            }
            return instance;
        }
    }

    public static class ServiceLocator //:IServiceLocator
    {
        private static IDictionary<Type, Type> containers = new Dictionary<Type, Type>();
        //private readonly ServiceContainer _serviceContainer = new ServiceContainer();

        //public void Register<T>(Func<T> resolver)
       // {
            //if (_serviceContainer.ContainsKey(typeof(T)))
            //{
                //
            //}
            //_serviceContainer[typeof(T)] = () => resolver();
        //}
 
        //public T Resolve<T>()
        //{
            //if(_serviceContainer.TryGetValue(typeof(T), out var resolver))
            //{
                //return (T)resolver();
            //}
            //return default(T);
        //}
      

        public static T Create<T>() where T: ScriptableObject//, new()
        {
            T instance = null;
            //if(typeof(T) is ScriptableObject)
            if (typeof(T).IsSubclassOf(typeof(ScriptableObject)))
            {
                instance = ScriptableObject.CreateInstance<T>();
            }
            return instance;
        }
    }
}
