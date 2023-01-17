using UnityEngine;
using UnityEditor;
using System.IO;

public enum lineFeelCode
{
    CR = 0,
    LF = 1,
    CRLF = 2
};

namespace Mytool
{
    public class LineFeedCodeConversion : EditorWindow
    {
        private string filepath = "";

        private lineFeelCode lineFeel_Code;

        [MenuItem("MyTools/LineFeedCodeConversion")]
        private static void DisplayWindow()
        {
            LineFeedCodeConversion window = GetWindow<LineFeedCodeConversion>();
            window.titleContent = new GUIContent("���s�R�[�h�ϊ�");
        }

        private void OnGUI()
        {
            GUILayout.Label("�t�@�C���p�X");
            GUILayout.Label(filepath, GUILayout.Height(20));

            if (GUILayout.Button("�p�X�̎w��"))
            {
                filepath = EditorUtility.OpenFilePanel("Select Asset", Application.dataPath, "csv");
                if (string.IsNullOrEmpty(filepath))
                {
                    return;
                }
            }

            GUILayout.Label("���ꂷ����s�R�[�h��I�����Ă�������");
            lineFeel_Code = (lineFeelCode)EditorGUILayout.EnumPopup("���s�R�[�h", lineFeel_Code);

            if (filepath != "")
            {
                if (GUILayout.Button("�ϊ�"))
                {
                    Conversion();
                    Debug.Log("�ϊ����������܂����B");
                }
            }
            else
            {
                GUILayout.Label("�t�@�C���p�X��ݒ肵�Ă�������");
            }
        }

        private void Conversion()
        {
            StreamReader sr = new StreamReader(filepath);
            string writing = "";
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                line = line.Replace("\n", "").Replace("\r\r", "");
                switch (lineFeel_Code)
                {
                    case lineFeelCode.CR:
                        line += "\r";
                        break;
                    case lineFeelCode.LF:
                        line += "\n";
                        break;
                    case lineFeelCode.CRLF:
                        line += "\r\n";
                        break;
                }
                writing += line;
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(filepath);
            sw.Write(writing);
            sw.Close();
        }
    }
}