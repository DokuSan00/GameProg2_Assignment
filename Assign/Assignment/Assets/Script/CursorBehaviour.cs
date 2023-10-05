using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    bool cursorLocked;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = Cursor.lockState == CursorLockMode.Locked;;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Cursor.lockState = cursorLocked ? CursorLockMode.None : CursorLockMode.Locked;
            cursorLocked = !cursorLocked;
        }
    }
}
