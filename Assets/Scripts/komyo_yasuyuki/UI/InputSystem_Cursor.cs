using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem_Cursor : MonoBehaviour
{
    List<Cursor> cursorL = new List<Cursor>();
    // Start is called before the first frame update
    void Start()
    {
        if (Gamepad.current == null) return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
