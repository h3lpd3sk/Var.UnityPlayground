using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Factory
{
    public interface IFactory<out T>
    {
        T Create([CanBeNull] params object[] arguments);
    }
}
