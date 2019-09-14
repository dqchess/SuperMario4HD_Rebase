using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // m_* represents non-public member variables
    // access the animator component I need to reference
    Animator m_Animator;
    // represent the position of gameobject
    Vector3 m_Movement;
    // store the rotation 
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;

    // the angle in radians the character to turn per second
    public float turnSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    // FixedUpdate is called before the physics system solves any collisions
    // and other interactions that have happened
    void FixedUpdate()
    {
        // represents A/D keys and left/right keys
        float horizontal = Input.GetAxis("Horizontal");
        // represents W/S keys and up/down keys
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }
        // calculate my character's forward vector
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
         m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }
    // this method allows to apply root motion 
    // which means movement and rotation can be applied separately
    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement 
        * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
