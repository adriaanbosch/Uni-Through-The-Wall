using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    public bool cursorLocked = true;

    void Start()
    {

    }

    void Update()
    {

        if (cursorLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cursorLocked = false;
            }
        }

        else if (cursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                cursorLocked = true;
            }
        }
    }
}
