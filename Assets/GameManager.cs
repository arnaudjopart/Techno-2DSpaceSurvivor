using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager m_inputManager;
    [SerializeField] private GameObject m_playerPrefab;

    [SerializeField] private FollowTarget m_camera;
    [SerializeField] private BackgroundOffset m_backgroundOffset;
    [SerializeField] private EnemySpawner m_spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        var playerInstance = Instantiate(m_playerPrefab);
        m_backgroundOffset.controller = playerInstance.GetComponent<PlayerControllerBase>();
        m_inputManager.ConnectPlayer(playerInstance.GetComponent<PlayerControllerBase>());
        m_spawnManager.SetEnemyTarget(playerInstance.transform);
        m_camera.SetTarget(playerInstance.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
