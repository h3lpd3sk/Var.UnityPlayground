using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityScene = UnityEngine.SceneManagement.Scene;
using UnityEngine.Events;
    
namespace Scene
{
    class Loader : ScriptableObject
    {
        public UnityAction<float> OnProgress;
        public UnityAction<UnityScene> OnLoaded;
        public UnityAction<UnityScene> OnComplete;

        public void Load(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var behaviour = StaticGameObject.behaviour;
            behaviour.StartCoroutine(LoadRoutine(sceneName, mode));
        }

        private IEnumerator LoadRoutine(string sceneName, LoadSceneMode mode)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;
            while (operation.progress < 0.9f)
            {
                OnProgress?.Invoke(operation.progress);
                yield return null;
            }
            operation.allowSceneActivation = true;

            OnLoaded?.Invoke(SceneManager.GetSceneByName(sceneName));

            yield return new WaitWhile(() => !operation.isDone);
            yield return new WaitForEndOfFrame();

            OnComplete?.Invoke(SceneManager.GetSceneByName(sceneName));
            Destroy(this);
        }
    }
}
