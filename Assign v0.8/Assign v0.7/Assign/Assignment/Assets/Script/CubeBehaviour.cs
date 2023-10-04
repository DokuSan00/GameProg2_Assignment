using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed;
    public ParticleSystem powerParticleToSpawn;
    public ParticleSystem pointParticleToSpawn;
    private Vector3 pos;
    void Start()
    {
        rotationSpeed = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curRotate = transform.eulerAngles;
        transform.localRotation = Quaternion.Euler(curRotate.x, curRotate.y + rotationSpeed * Time.deltaTime, curRotate.z);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag != "Player") return;
        if (gameObject.name == "Point_Cube") { 
            Destroy(transform.parent.gameObject);
            GameManager.Instance.AddScore();
            return;
        }

        transform.parent.gameObject.SetActive(false);
        PlayerMovement.Instance.JumpIncrement();
        Invoke("Respawn", 10);
        return;
    }

    void Respawn() {
        transform.parent.gameObject.SetActive(true);
    }
}
