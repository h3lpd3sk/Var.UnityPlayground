using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityScene = UnityEngine.SceneManagement.Scene;
using UnityEngine.Events;

public class SplashController : MonoBehaviour
{
    [SerializeField]
    private Slider slider = default;

    void Start()
    {
        var loader =  ServiceLocator.ServiceLocator.Create<Scene.Loader>();
        if (slider != null)
        {
            loader.OnProgress = progress => slider.value = progress;
        }
        loader.OnLoaded = (scene) => Debug.Log("OnLoaded");
        loader.OnComplete = (scene) => Debug.Log("OnComplete");
        loader.Load("Scenes/Main");
    }
}