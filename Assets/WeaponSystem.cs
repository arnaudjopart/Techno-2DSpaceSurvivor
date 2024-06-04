using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Transform m_player;
    public List<WeaponBase> m_weapons = new();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrigin(Transform _playerInstanceTransform)
    {
        m_player = _playerInstanceTransform;
        foreach (var VARIABLE in m_weapons)
        {
            VARIABLE.m_player = _playerInstanceTransform;
        }
        
    }

    public void AddWeapon(GameObject _weapon)
    {
        var newInstance = Instantiate(_weapon, transform);
        if (!newInstance.TryGetComponent(out WeaponBase weapon)) return;
        m_weapons.Add(weapon);
        weapon.m_player = m_player;
    }
}

public class WeaponBase : MonoBehaviour
{
    public Transform m_player;
}