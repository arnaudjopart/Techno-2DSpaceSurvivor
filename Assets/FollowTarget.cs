using System;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform m_target;
    [SerializeField] private Vector3 m_offset = Vector3.back;

    public void SetTarget(Transform playerInstance)
    {
        m_target = playerInstance;

    }

    private void LateUpdate()
    {
        transform.position = m_target.position + m_offset;
    }
}