using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UniRx;
using System;

namespace SceneaManger
{
    public class SceneManagerController : MonoBehaviour
    {
        private Subject<AsyncOperation> loadScene = new Subject<AsyncOperation>();

        public void LoadScene(string scenePath)
        {
            loadScene.OnNext(SceneManager.LoadSceneAsync(scenePath));
        }

        public IObservable<AsyncOperation> GetLoadScene()
        {
            return loadScene;
        }
    }
}