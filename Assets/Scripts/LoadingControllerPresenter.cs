using UnityEngine;
using UniRx;

namespace SceneaManger
{
    public class LoadingControllerPresenter : MonoBehaviour
    {
        [SerializeField, Header("以下参照スクリプト----------------------")]
        private LoadingController loading;

        [SerializeField]
        private SceneManagerController sceneManager;

        void Start()
        {
            sceneManager.GetLoadScene()
                .Subscribe(scene => loading.LoadData(scene))
                .AddTo(this);
        }
    }
}