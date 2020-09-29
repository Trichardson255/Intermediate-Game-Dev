using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float m_Speed = 12f;                             // How fast the tank moves (Forwards/Backwards)
    public float m_TurnSpeed = 180f;                        // How fast the tank turns (Left/Right, degrees per second)

    private Rigidbody m_RigidBody;
    // private float m_MovementInputValue;                     // The current value of the movement input
    // private float m_TurnInputValue;                         // The current value of the movement input

    private Vector3 m_MovementDir;
    private Vector3 movement;


    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        // When the player is turned on, make sure it is not kinematic
        m_RigidBody.isKinematic = false;

        // Also reset the input values
        // m_MovementInputValue = 0f;
        // m_TurnInputValue = 0f;
        m_MovementDir = Vector3.zero;
    }

    private void OnDisable()
    {
        // When the tank is turned off, set it to kinematic so it stops moving
        m_RigidBody.isKinematic = true;
    }


    // Update is called once per frame
    void Update()
    {
        // m_MovementInputValue = Input.GetAxis("Vertical");
        // m_TurnInputValue = Input.GetAxis("Horizontal");

        m_MovementDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float MoveX = m_MovementDir.x * m_Speed;
        float MoveZ = m_MovementDir.z * m_Speed;

        movement = new Vector3(MoveX, 0, MoveZ);

        // Create a vector in the direction the player is facing with a magnitude based on the input, speed and time between frames
        //Vector3 movement = transform.position * m_MovementDir * m_Speed * Time.deltaTime;

        // Apply this movement to the rigidbody's position
        m_RigidBody.MovePosition(transform.position + movement * Time.deltaTime);
    }

   
}
