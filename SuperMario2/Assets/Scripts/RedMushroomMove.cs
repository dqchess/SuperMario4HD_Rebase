using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMushroomMove : MonoBehaviour
{
    public float leftPoint = 0.0f;
    public float rightPoint = 2.5f;
    public int direction = 1; //1 means moving right, 2 means moving left

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.parent = null;
        if (direction == 1)
        {
            transform.Translate(Vector3.right * 2 * Time.deltaTime, Space.World);
            direction = 1;
        }
        if (this.transform.position.x > rightPoint)
        {
            direction = 2;
        }
        if (direction == 2)
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime, Space.World);
            direction = 2;
        }
        if (this.transform.position.x < leftPoint)
        {
            direction = 1;
        }
    }
}
