using System;
using UnityEngine;

internal class EnemyController : MonoBehaviour
{
    private Transform m_target;
    [SerializeField] private float m_speed = 5;
    [SerializeField] private LayerMask m_layerMask;
    [SerializeField] private float m_avoidanceDistance=.2f;

    public void SetTarget(Transform _target)
    {
        m_target = _target;
    }

    private void Update()
    {
        if (m_target == null) return;
        var direction = m_target.position - transform.position;
        var normalizedDirection = direction.normalized;
        //transform.position += normalizedDirection * m_speed * Time.deltaTime;
        var nearbyColliders = Physics2D.CircleCastAll(transform.position, 4, Vector2.zero,0,m_layerMask);
        Vector3 avoidanceVector = Vector2.zero;
        foreach (var collider in nearbyColliders)
        {
           // print(nearbyColliders.Length);
            var neighbourgVector = -(collider.transform.position - transform.position).normalized;
            avoidanceVector += neighbourgVector;
            avoidanceVector = avoidanceVector.normalized*m_avoidanceDistance;
            
        }
        normalizedDirection += avoidanceVector;

        transform.position += normalizedDirection * (m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Rigidbody2D>().AddForce( other.gameObject.transform.up*3,ForceMode2D.Impulse);
    }
}