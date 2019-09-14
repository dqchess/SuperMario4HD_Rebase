using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour
{

    public float speed = 10.0f;
    public float rotationSpeed = 2.0f;
    public Transform head;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up, mouseInput.x * rotationSpeed);

        gameObject.GetComponent<CharacterController>().Move(transform.TransformDirection(input * speed * Time.deltaTime));

        head.Rotate(Vector3.left, mouseInput.y * rotationSpeed);
    }
}
