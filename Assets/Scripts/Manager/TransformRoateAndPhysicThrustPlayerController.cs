using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class TransformRoateAndPhysicThrustPlayerController : PlayerControllerBase
{
    private Rigidbody2D m_rigidBody;
    private float m_xMoveData;
    private float m_yMoveData;

    [Header("Physic parameters")]
    [SerializeField] private float m_rotationSpeed;
    [SerializeField] private float m_thurst;
    [SerializeField] private float m_maxVelocity;

    private void Awake()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
    }
    public override void ProcessAxisData(Vector2 _moveVector)
    {
        m_xMoveData = _moveVector.x;
        transform.Rotate(0, 0, -m_xMoveData*m_rotationSpeed * Time.deltaTime);
        m_yMoveData = _moveVector.y > 0 ? _moveVector.y : 0;

    }


    private void FixedUpdate()
    {
        m_rigidBody.AddForce(transform.up * m_yMoveData * m_thurst);
        if(m_rigidBody.velocity.magnitude > m_maxVelocity) 
        {
            m_rigidBody.velocity = m_rigidBody.velocity.normalized*m_maxVelocity;
        }
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

    public override Vector2 GetVelocity()
    {
        return m_rigidBody.velocity;
    }
}