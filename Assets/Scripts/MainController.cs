﻿using System;
using System.Collections;
using System.Collections.Generic;
using Factory;
using ServiceLocator;
using UnityEngine;

public class MainController : MonoBehaviour
{   
    [SerializeField]
    private UnityEngine.Object scene;
    
    public void OnClick()
    {
        Debug.Log(":-)");
        
        var loader = ScriptableObject.CreateInstance<Scene.Loader>();
        //if (slider != null)
        //{
        //    loader.OnProgress = progress => slider.value = progress;
        //}
        loader.OnLoaded += sceneInstance => Debug.Log("OnLoaded " + sceneInstance.GetType() + " " + sceneInstance.name);
        loader.OnComplete += sceneInstance => Debug.Log("OnComplete " + sceneInstance.GetType() + " " + sceneInstance.name);
        loader.Load(scene.name);
    }
}
