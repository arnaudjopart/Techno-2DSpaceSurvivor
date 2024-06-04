using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
    public PlayerControllerBase controller;
    private MeshRenderer m_renderer;
    [SerializeField] private Vector2 m_factor;

    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var currentOffset = m_renderer.materials[0].GetTextureOffset("_MainTex");
        m_renderer.materials[0].SetTextureOffset("_MainTex", currentOffset - new Vector2(controller.GetVelocity().y, -controller.GetVelocity().x)*Time.deltaTime*m_factor); 
    }
}
