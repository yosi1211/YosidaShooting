#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

namespace CreateCode
{
    public class ObjectPoolCreateCode : EditorWindow
    {
        private string variableName = "ObjectPoolManager";
        private string createPath = "Assets/Scripts/";

        [MenuItem("CreateCode/ObjectPoolManager")]
        private static void ShowWindow()
        {
            ObjectPoolCreateCode window = GetWindow<ObjectPoolCreateCode>();
            window.titleContent = new GUIContent("CraeteMenu");
        }

        private void OnGUI()
        {
            GUILayout.Label("�X�N���v�g������͂��Ă�������");
            variableName = EditorGUILayout.TextField(variableName, GUILayout.Height(20));

            GUILayout.Label("�ȉ��̏ꏊ�ɐ�������܂�");
            GUILayout.Label(createPath + variableName + ".cs");

            if (GUILayout.Button("�X�N���v�g����"))
            {
                CraeteCode();
            }
        }

        private void CraeteCode()
        {
            string filepath = createPath + variableName + ".cs";
            filepath = AssetDatabase.GenerateUniqueAssetPath(filepath);
            File.WriteAllText(filepath, SetCode());
            AssetDatabase.Refresh();
            Debug.Log(filepath);
        }

        private string SetCode()
        {
            string code = @"
using System.Collections.Generic;
using UnityEngine;

public class " + variableName + @" : MonoBehaviour
{
    [SerializeField,Header(""��������I�u�W�F�N�g"")]
    private GameObject createObj;

    private List<GameObject> objectPoolList = new();
    public void Create()
    {
        GameObject obj = Instantiate(createObj);
        obj.SetActive(false);
        obj.transform.parent = transform;
        objectPoolList.Add(obj);
    }

    public GameObject GetCreateObj(Transform parentobj)
    {
        GameObject obj = objectPoolList[0];
        obj.SetActive(true);
        obj.transform.parent = parentobj;
        objectPoolList.Remove(obj);
        return obj;
    }

    public void DeleteObj(GameObject obj)
    {
        objectPoolList.Add(obj);
        obj.SetActive(false);
        obj.transform.parent = transform;
    }
}";

            return code;
        }
    }
}
#endif