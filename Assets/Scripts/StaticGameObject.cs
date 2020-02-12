using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class StaticGameObject
{
    public static GameObject gameObject { get; private set; }

    static StaticGameObject()
    {
        gameObject = new GameObject(typeof(StaticGameObject).Name)
        {
            hideFlags = HideFlags.HideAndDontSave,
        };
    }
}