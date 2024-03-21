using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MotorController : MonoBehaviour
{
    public float Speed;
    private PlayerInput m_playerInput;
    private Rigidbody2D m_rb;
    private Vector2 m_inputVector;
    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        m_inputVector = Vector2.zero;   
        if(m_playerInput != null)
        {
            m_inputVector = m_playerInput.InputVector;
        }
        m_rb.velocity = m_inputVector * Speed;
    }
}
