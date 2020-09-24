using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float m_Speed = 12f;                             // How fast the tank moves (Forwards/Backwards)
    public float m_TurnSpeed = 180f;                        // How fast the tank turns (Left/Right, degrees per second)

    private Rigidbody m_RigidBody;
    private float m_MovementInputValue;                     // The current value of the movement input
    private float m_TurnInputValue;                         // The current value of the movement input

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // When the player is turned on, make sure it is not kinematic
        m_RigidBody.isKinematic = false;

        // Also reset the input values
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving
        m_RigidBody.isKinematic = true;
    }


    // Update is called once per frame
    void Update()
    {
        m_MovementInputValue = Input.GetAxis("Vertical");
        m_TurnInputValue = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        // Create a vector in the direction the player is facing with a magnitude based on the input, speed and time between frames
        Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
        m_RigidBody.MovePosition(m_RigidBody.position + movement);
    }

    private void Turn()
    {
        // Determine the number of degrees to be turned based on the input, speed and time between frames
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

        // Make this into a rotation on the y axis
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);

        // Apply this rotation to the rigidbody
        m_RigidBody.MoveRotation(m_RigidBody.rotation * turnRotation);
    }
}
