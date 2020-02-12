using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using ServiceLocator;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(":-)");
        
        var loader = ServiceLocator.ServiceLocator.Create<Scene.Loader>(); //ScriptableObject.CreateInstance<Scene.Loader>();
        //if (slider != null)
        //{
        //    loader.OnProgress = progress => slider.value = progress;
        //}
        loader.OnLoaded = (scene) => Debug.Log("OnLoaded");
        loader.OnComplete = (scene) => Debug.Log("OnComplete");
        loader.Load("Scenes/Game");
    }
}
