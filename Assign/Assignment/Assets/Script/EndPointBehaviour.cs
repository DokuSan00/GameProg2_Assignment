using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col) {
        if (col.tag != "Player") return;
        GameManager.Instance.NextScene();
    }
}
