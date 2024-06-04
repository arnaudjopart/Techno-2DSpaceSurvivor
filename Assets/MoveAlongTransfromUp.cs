using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongTransfromUp : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        m_transform.position += m_transform.up * (m_speed * Time.deltaTime);
    }
}
