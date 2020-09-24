﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float m_DampTime = 0.2f;

    public Transform m_Target;

    private Vector3 m_MoveVelocity;
    private Vector3 m_DesiredPosition;

    private void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Move()
    {
        // Set desired position to target position
        m_DesiredPosition = m_Target.position;

        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }

    private void FixedUpdate()
    {
        Move();
    }
}