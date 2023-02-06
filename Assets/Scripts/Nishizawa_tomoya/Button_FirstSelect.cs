using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_FirstSelect : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.Select();
    }
}
