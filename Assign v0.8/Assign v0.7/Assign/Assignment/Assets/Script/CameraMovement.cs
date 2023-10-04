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
    public float pLerp = .5f;
    public float rLerp = 2f;

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, focusPoint.position, pLerp);
        
        rotation.x = Input.GetAxis("Mouse X") * sensitivity;
        rotation.y = Input.GetAxis("Mouse Y") * sensitivity;
        transform.position = Vector3.Lerp(transform.position, focusPoint.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, focusPoint.rotation, rLerp);
        // transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0);
        // transform.LookAt(focusPoint.position);

        // Vector3 deltaMove = new Vector3(-rotation.x, -rotation.y, 0) * Time.deltaTime;
        // rotation.x += Input.GetAxis(xAxis) * sensitivity;
        // rotation.y += Input.GetAxis(yAxis) * sensitivity;
        // var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        // // var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);


        // // set parent(player) horizontal rotation -> cam + runner looks same dir
        // transform.parent.localRotation = xQuat;
        // // set cam vertical rotation 
        // // -> allow player to look up without change the vertical rotation of model
        // // transform.localRotation = yQuat;

        // var rotateVal = Quaternion.Euler(new Vector3(-rotation.y, rotation.x, 0));
        // Debug.Log(rotateVal);
        // transform.rotation = rotateVal;
        // transform.LookAt(focusPoint.transform.position, Vector3.up);
    }
}
