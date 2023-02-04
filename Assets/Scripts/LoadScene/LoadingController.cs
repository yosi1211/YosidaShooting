using UnityEngine;
using UnityEngine.UI;

namespace SceneaManger
{
    public class LoadingController : MonoBehaviour
    {

        [SerializeField, Header("ロード画面で表示する画面")]
        private GameObject loadingUI;

        [SerializeField, Header("シーン移動の進行度")]
        private Slider loadSlider;

        public void LoadData(AsyncOperation load)
        {
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
        }
    }
}