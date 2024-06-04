using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InputManager m_inputManager;
    [SerializeField] private GameObject m_playerPrefab;
    
    [SerializeField] private BackgroundOffset m_backgroundOffset;
    [SerializeField] private EnemySpawner m_spawnManager;
    [SerializeField] private CinemachineVirtualCamera m_virtualCamera;
    [SerializeField] private WeaponSystem m_weaponSystem;

    // Start is called before the first frame update
    void Start()
    {
        var playerInstance = Instantiate(m_playerPrefab);
        m_backgroundOffset.controller = playerInstance.GetComponent<PlayerControllerBase>();
        m_inputManager.ConnectPlayer(playerInstance.GetComponent<PlayerControllerBase>());
        m_spawnManager.SetEnemyTarget(playerInstance.transform);
        m_virtualCamera.Follow = playerInstance.transform;
        m_weaponSystem.SetOrigin(playerInstance.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
