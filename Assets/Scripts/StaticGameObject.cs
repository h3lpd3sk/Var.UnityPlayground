using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class StaticGameObject
{
    public static GameObject gameObject { get; private set; }

    public static MonoBehaviour behaviour { get; private set; }

    private sealed class Behaviour: MonoBehaviour { }
    
    static StaticGameObject()
    {
        gameObject = new GameObject(typeof(StaticGameObject).Name)
        {
            hideFlags = HideFlags.HideAndDontSave,
        };
        behaviour = gameObject.AddComponent<Behaviour>();
    }
}