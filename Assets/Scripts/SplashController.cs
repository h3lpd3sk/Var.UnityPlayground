using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityScene = UnityEngine.SceneManagement.Scene;

public class SplashController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    
    IEnumerator Start()
    {
        var operation = SceneManager.LoadSceneAsync("Scenes/Main");
        operation.allowSceneActivation = false;
        while (operation.progress < 0.9f)
        {
            //yield return new WaitForSeconds(5f);
            slider.value = operation.progress;
            yield return null;
        }

        operation.allowSceneActivation = true;

        //onLoaded?.Invoke(SceneManager.GetSceneByName(sceneName));

        yield return new WaitWhile(() => !operation.isDone);
        yield return new WaitForEndOfFrame();

        //onActived?.Invoke(SceneManager.GetSceneByName(sceneName));
        //Object.Destroy(this);
        //yield break;
    }
}
