
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_currentSpawnPool;
    private Transform m_target;
    private float m_spawnDelay=5;
    private float m_spawnTimer=5;
    [SerializeField] private float m_spawnDistance = 20;

    public void SetPrefabList(List<GameObject> _list)
    {
        m_currentSpawnPool = _list;
    }

    public void SetSpawnTimer(float _timer)
    {
        m_spawnDelay = _timer;
        m_spawnTimer = _timer;
    }
    public void SetEnemyTarget(Transform _targetTransform)
    {
        m_target = _targetTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer-= Time.deltaTime;
        if(m_spawnTimer < 0)
        {
            m_spawnTimer = m_spawnDelay;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var randomPositionOnCircle = Random.insideUnitCircle.normalized * m_spawnDistance;
        var instance = Instantiate(m_currentSpawnPool[0], (Vector2)m_target.position+ randomPositionOnCircle, Quaternion.identity);
        instance.GetComponent<EnemyController>().SetTarget(m_target);
    }
}
