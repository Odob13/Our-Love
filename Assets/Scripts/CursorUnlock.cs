using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUnlock : MonoBehaviour
{
    private bool l = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && l)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            l= false;
        }
        else if(Input.GetKeyDown(KeyCode.R) && !l)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            l= true;
        }

    }
}
