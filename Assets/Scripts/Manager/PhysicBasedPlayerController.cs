using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicBasedPlayerController : PlayerControllerBase
{
    private Rigidbody2D m_rigidBody;
    [SerializeField] private float m_torque;
    [SerializeField] private float m_thurst;
    private float m_xMoveData;
    private float m_yMoveData;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
    public override void ProcessAxisData(Vector2 _moveVector)
    {
        m_xMoveData = _moveVector.x;
        m_yMoveData = _moveVector.y>0 ? _moveVector.y:0;

    }


    private void FixedUpdate()
    {
        m_rigidBody.AddForce(transform.up * m_yMoveData * m_thurst);
        m_rigidBody.AddTorque(-m_xMoveData * m_torque);
    }
    public override void ProcessMouseButtonDown(int v)
    {
        
    }

    public override void ProcessMouseButtonUp(int v)
    {
        
    }

    public override void ProcessMousePosition(Vector3 mousePositionInWorld)
    {
        
    }

    public override void ProcessMouseScrollDelta(Vector2 mouseScrollDelta)
    {
        
    }

    public override void ProcessPrimaryActionDown()
    {
        
    }

    public override void ProcessPrimaryActionUp()
    {
        
    }

    public override void ProcessSecondaryActionDown()
    {
        
    }

    public override void ProcessSecondaryActionUp()
    {
        
    }
}
