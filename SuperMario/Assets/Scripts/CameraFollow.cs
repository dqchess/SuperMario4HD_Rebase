using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 5.0f;
    public float staticCameraY = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMove = new Vector3(player.position.x + 6, 0, player.position.z - distanceFromPlayer);
        transform.position += cameraMove;
    }

    private void LateUpdate()
    {
        // GetComponent<Camera>().main.transform.position.y = staticCameraY;
    }
}


