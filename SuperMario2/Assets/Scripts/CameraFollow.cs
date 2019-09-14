using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 6.0f;
    public float cameraY = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMove = new Vector3(target.position.x + 3.0f, cameraY, 
            target.position.z - distance);
        transform.position = cameraMove;
    }
    private void LateUpdate()
    {
        //GetComponent<Camera>().transform.position.y = cameraY;
    }
}
