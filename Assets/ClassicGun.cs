using UnityEngine;

public class ClassicGun : WeaponBase
{
    [SerializeField] private float m_shootFrequencyInShootPerSecond;
    private float m_timer;
    private float m_shootDelay;
    [SerializeField] private GameObject m_projectile;
    [SerializeField]private Vector3 m_offset;

    private void Awake()
    {
        m_shootDelay = 1 / m_shootFrequencyInShootPerSecond;
        m_timer = m_shootDelay;
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;
        if (!(m_timer <= 0)) return;
        m_timer = m_shootDelay;
        Shoot();
    }

    private void Shoot()
    {
        var instance = Instantiate(m_projectile, m_player.position, m_player.rotation*Quaternion.LookRotation(Vector3.forward,transform.TransformDirection(m_offset)));
    }
}