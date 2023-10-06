using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    //set movement type 
    public int movementType;
    //1: UpDown/SideWay, 2: Spin
    Dictionary<int, string> movementTypeMap = new Dictionary<int, string>()
    {
        {1, "UpDown"},
        {2, "Spin"}
    };

    public float totalMoveTime = 0;
    public float speed = 1;
    public float rotationSpeed = 1;

    Vector3 upDown = Vector3.right;
    float movedTime;
    string _methodToExecute;

    void Start() {
        _methodToExecute = movementTypeMap[movementType];
        movedTime = totalMoveTime;
    }

    // Update is called once per frame
    void Update() {
        Invoke(_methodToExecute, 0.0f);
    }

    void UpDown() {
        transform.Translate(upDown * speed * Time.deltaTime);
        movedTime -= Time.deltaTime;
        if (movedTime <= 0) {
            movedTime = totalMoveTime;
            upDown *= -1;
        }
    }

    void Spin() {
        transform.Rotate(upDown * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col) {
        Debug.Log(col.tag);
        if (col.tag != "Player") return;
        GameManager.Instance.Restart();
    }
}
