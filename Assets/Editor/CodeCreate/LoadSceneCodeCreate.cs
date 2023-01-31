#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CreateCode
{
    public class LoadSceneCodeCreate : EditorWindow
    {

        //�����o���X�N���v�g�̖��O
        private string sceneManagerCodeName = "SceneManagerController";
        private string loadControllerCodeName = "LoadingController";
        private string loadControllerPresenterCodeName = "Presenter";

        //�����o���t�H���_�p�X
        private string createPath = "Assets/Scripts/";

        private bool sceneMangerControllerCheck = true;
        private bool loadControllerCreateCheck = true;
        private bool presenterCreateCheck = true;

        [MenuItem("CreateCode/SceneManagerController")]
        private static void DisplayWindow()
        {
            LoadSceneCodeCreate window = GetWindow<LoadSceneCodeCreate>();
            window.titleContent = new GUIContent("CreateMenu");
        }

        private void OnGUI()
        {
            var currentPosition = position;
            //�V�[���}�l�[�W���[�̐���
            GUILayout.Label("�V�[���}�l�[�W���[�X�N���v�g�����܂���?");
            sceneMangerControllerCheck = EditorGUILayout.Toggle(sceneMangerControllerCheck);

            if (sceneMangerControllerCheck)
            {
                GUILayout.Label("Scene�ڍs�X�N���v�g�̖��O����͂��Ă�������");
                sceneManagerCodeName = EditorGUILayout.TextField(sceneManagerCodeName, GUILayout.Height(20));
            }

            //���[�h�V�[��UI�̐���
            GUILayout.Label("���[�h�V�[��UI�����X�N���v�g�����܂���?");
            loadControllerCreateCheck = EditorGUILayout.Toggle(loadControllerCreateCheck);

            if (loadControllerCreateCheck)
            {
                GUILayout.Label("���[�h�V�[��UI�����X�N���v�g�̖��O����͂��Ă�������");
                loadControllerCodeName = EditorGUILayout.TextField(loadControllerCodeName, GUILayout.Height(20));

                GUILayout.Label("���̖��O��Presenter����������܂��B");
                loadControllerPresenterCodeName = loadControllerCodeName + "Presenter";
                GUILayout.Label(loadControllerPresenterCodeName);
                GUILayout.Label("Presenter�𐶐����܂���?");
                presenterCreateCheck = EditorGUILayout.Toggle(presenterCreateCheck);
            }

            GUILayout.Label("�ȉ��̏ꏊ�ɐ�������܂��B");
            #region
            if (sceneMangerControllerCheck)
            {
                GUILayout.Label("SceneManger : " + createPath + sceneManagerCodeName + "cs");
            }
            if (loadControllerCreateCheck)
            {
                GUILayout.Label("LoadSceneController : " + createPath + loadControllerCodeName + "cs");
                GUILayout.Label("LoadScenePresenter : " + createPath + loadControllerPresenterCodeName);
            }
            #endregion

            GUILayout.Label("UniRx��Addressable���Ȃ��ƃG���[���o�܂��B");
            if (GUILayout.Button("�X�N���v�g����"))
            {
                if (sceneMangerControllerCheck)
                {
                    string filePath = createPath + sceneManagerCodeName + ".cs";
                    filePath = AssetDatabase.GenerateUniqueAssetPath(filePath);
                    File.WriteAllText(filePath,SceneManagerCode());
                    AssetDatabase.Refresh();
                    Debug.Log(sceneManagerCodeName + "�𐶐����܂����B");
                }

                if (loadControllerCreateCheck)
                {
                    string filePath = createPath + loadControllerCodeName + ".cs";
                    filePath = AssetDatabase.GenerateUniqueAssetPath(filePath);
                    File.WriteAllText(filePath, LoadControllerCode());
                    AssetDatabase.Refresh();
                    Debug.Log(loadControllerCodeName + "�𐶐����܂����B");

                    if (presenterCreateCheck)
                    {
                        filePath = createPath + loadControllerPresenterCodeName + ".cs";
                        filePath = AssetDatabase.GenerateUniqueAssetPath(filePath);
                        File.WriteAllText(filePath, LoadControllerPresenterCode());
                        AssetDatabase.Refresh();
                        Debug.Log(loadControllerPresenterCodeName + "�𐶐����܂����B");
                    }
                }
            }

            position = currentPosition;
        }

        private string SceneManagerCode()
        {
            string code = @"using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UniRx;
using System;

namespace SceneaManger
{
    public class " + sceneManagerCodeName + @" : MonoBehaviour
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
}";
            return code;
        }

        private string LoadControllerCode()
        {
            string code = @"using UnityEngine;
using UnityEngine.UI;

namespace SceneaManger
{
    public class " + loadControllerCodeName + @" : MonoBehaviour
    {

        [SerializeField, Header(""���[�h��ʂŕ\��������"")]
        private GameObject loadingUI;

        [SerializeField, Header(""�V�[���ړ��̐i�s�x"")]
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
}";
            return code;
        }

        private string LoadControllerPresenterCode()
        {
            string code = @"using UnityEngine;
using UniRx;

namespace SceneaManger
{
    public class LoadingControllerPresenter : MonoBehaviour
    {
        [SerializeField, Header(""�ȉ��Q�ƃX�N���v�g----------------------"")]
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
}";
            return code;
        }
    }
}
#endif