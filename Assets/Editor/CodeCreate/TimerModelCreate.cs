#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CreateCode
{
    public class TimerModelCreate : EditorWindow
    {
        private string filepath = "Assets/Scripts/System";
        private string createPath = "Assets/Scripts/System/TimerModel.cs";

        private bool clearCheck = false;
        private bool restartCheck = true;


        [MenuItem("CreateCode/TimerModel")]
        private static void DisplayWindow()
        {
            TimerModelCreate window = GetWindow<TimerModelCreate>();
            window.titleContent = new GUIContent("CreateMenu");
        }

        private void OnGUI()
        {
            var currentPosition = position;

            GUILayout.Label("�ȉ��̏ꏊ�ɐ�������܂�");
            GUILayout.Label(createPath);

            GUILayout.Label("���X�^�[�g�֐������܂����H");
            restartCheck = EditorGUILayout.Toggle(restartCheck);

            GUILayout.Label("Clear�֐������܂���?");
            clearCheck = EditorGUILayout.Toggle(clearCheck);

            GUILayout.Label("TImerModel�𓮂����ɂ�UniRx���K�v�ɂȂ�܂�");
            if (GUILayout.Button("����"))
            {
                SafeCreateDirectory(filepath);
                createPath = AssetDatabase.GenerateUniqueAssetPath(createPath);
                File.WriteAllText(createPath, CodeCreate());
                AssetDatabase.Refresh();
                Debug.Log("TimerModel�𐶐����܂���");
            }

            position = currentPosition;
        }

        private  DirectoryInfo SafeCreateDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                return null;
            }
            return Directory.CreateDirectory(path);
        }

        private string CodeCreate()
        {
            string code = @"using UnityEngine;
using UniRx;
using System;

namespace Other_Script 
{
    public class TimerModel
    {
        private float limit;
        private float count = 0;

        private Subject<Unit> endTimer = new();

        private CompositeDisposable disposables = new();

        public void SetTimer(float timeLimit)
        {
            limit = timeLimit;

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    count += Time.deltaTime;
                    if (count > limit)
                    {
                        endTimer.OnNext(Unit.Default);
                    }
                }).AddTo(disposables);
        }"; 
            
            if (restartCheck) 
            {
                code += @"
        public void RestertTimer()
        {
            count = 0;
        }";
            }
            if (clearCheck)
            {
                code += @"
        public void ClearTimer()
        {
            disposables.Clear();
        }";
            }
            code += @"
        public void EndTimer()
        {
            disposables.Dispose();
        }

        public IObservable<Unit> GetEndTimer()
        {
            return endTimer.AddTo(disposables);
        }
    }
}";
            return code;
        }
    }
}
#endif