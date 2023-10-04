using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    
    public float Sensitivity {
        get { return sensitivity; }
        set { sensitivity = value; }
    }

    public float sensitivity = 2f;

    Vector2 rotation = Vector2.zero;
    public Transform focusPoint;
    public float pLerp = 3.0f;
    public float rLerp = 2f;

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, focusPoint.position, pLerp);
        transform.position = Vector3.Lerp(transform.position, focusPoint.position, pLerp);
    }
}
