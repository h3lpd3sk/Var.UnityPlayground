using System;
using UnityEngine;

/**
 * AttributeTargets.Assembly | 
                    AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Enum |
                    AttributeTargets.Constructor |
                    AttributeTargets.Method |
                    AttributeTargets.Field |
                    AttributeTargets.Interface  |
                    AttributeTargets.Delegate,
                    
                    static X CreateY_CreateInstance_String()
{
    return (X)Activator.CreateInstance("Program", "Y").Unwrap();
}

static X CreateY_CreateInstance_Arg(int z)
{
    return (X)Activator.CreateInstance(typeof(Y), new object[] { z, });
}
 */

// @see http://www.herlitz.nu/2015/10/21/servicelocator-singleton-pattern-with-annotation-mapping/
namespace ServiceLocator
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = true)]
    public sealed class LocateAttribute : Attribute
    {
        private Type RegisteredType;
        
        public LocateAttribute()
        {
            Debug.Log("A");
        }
        public LocateAttribute(Type type)
        {
            RegisteredType = type;
            //RegisteredType = type;
            Debug.Log("B");
            //return type.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
        /*
        public InjectAttribute(Type type, bool singleton)
        {
            RegisteredType = type;
            LifetimeManager = singleton ? new ContainerControlledLifetimeManager() : null;
        }
        */
    }
}