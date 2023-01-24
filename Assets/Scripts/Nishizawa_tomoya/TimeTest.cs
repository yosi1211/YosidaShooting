using UnityEngine;
using UnityEngine.UI;

public class TimeTest : MonoBehaviour
{
    //このスクリプトはテキストにつける
    static public int second;
    static public int minutu;
    float time = 0f;
    Text scoretext = null;

    private void Start()
    {
        scoretext = GetComponent<Text>();
    }

    void Update()
    {
        time += Time.deltaTime;
        minutu = (int)time / 60;
        second = (int)time % 60;
        string minutuText, secondText;

        if (minutu < 10)
        {
            minutuText = "0" + minutu.ToString();
        }
        else
        {
            minutuText = minutu.ToString();
        }

        if(second < 10)
        {
            secondText = "0" + second.ToString();
        }
        else
        {
            secondText = second.ToString();
        }

        scoretext.text = minutuText + ":" + secondText ;
    }
}
