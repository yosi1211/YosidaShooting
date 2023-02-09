using UnityEngine;
using UnityEngine.UI;
using Other_Script;
using UniRx;

namespace SceneaManger
{
    public class LoadingController : MonoBehaviour
    {

        [SerializeField, Header("ロード画面で表示する画面")]
        private GameObject loadingUI;

        [SerializeField, Header("シーン移動の進行度")]
        private Slider loadSlider;

        [SerializeField, Header("ロード画面での最低待機時間")]
        private float waitingTiiime = 5f;

        TimerModel timer = new();
        AsyncOperation load;

        public void LoadData(AsyncOperation _load)
        {
            if(load == null){
            load = _load;
            load.allowSceneActivation = false;
            loadingUI.SetActive(true);
            while (!load.isDone)
            {

                var progressVal = Mathf.Clamp01(load.progress / 0.9f);

                loadSlider.value = progressVal;
                if (loadSlider.value >= 0.9f)
                {
                    break;
                }
            }
            Debug.Log("sss");
            timer.GetEndTimer()
                .Subscribe(_ => load.allowSceneActivation = true);
            timer.SetTimer(waitingTiiime);
            }
        }

        private void OnDestroy()
        {
            timer.EndTimer();
        }
    }
}