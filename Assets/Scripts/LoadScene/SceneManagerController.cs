using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System;

namespace SceneaManger
{
    public class SceneManagerController : MonoBehaviour
    {

        private int count = 0;
        private Subject<AsyncOperation> loadScene = new Subject<AsyncOperation>();


        public void LoadScene(string _scenePath)
        {
            if (count == 0)
            {
                loadScene.OnNext(SceneManager.LoadSceneAsync(_scenePath));
                count++;
            }
        }

        public IObservable<AsyncOperation> GetLoadScene()
        {
            return loadScene;
        }
    }
}