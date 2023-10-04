using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Cursor.visible = !Cursor.visible;
    }
}
