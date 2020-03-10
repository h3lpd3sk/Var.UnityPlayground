using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityScene = UnityEngine.SceneManagement.Scene;
using UnityEngine.Events;

public class SplashController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.Object scene;
    
    [SerializeField]
    private Slider slider;

    void Start()
    {
        var loader = ScriptableObject.CreateInstance<Scene.Loader>();
        if (slider != null)
        {
            loader.OnProgress += progress => slider.value = progress;
        }
        loader.OnLoaded += sceneInstance => Debug.Log("OnLoaded " + sceneInstance.GetType() + " " + sceneInstance.name);
        loader.OnComplete += sceneInstance => Debug.Log("OnComplete " + sceneInstance.GetType() + " " + sceneInstance.name);
        loader.Load(scene.name);
    }
}