using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControllerBase m_playerController;
    [SerializeField] private KeyCode m_primaryAction;
    private KeyCode m_secondaryAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ConnectPlayer(PlayerControllerBase _playerController)
    {
        if (_playerController == null) throw new NullReferenceException(tag);

        m_playerController = _playerController;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerController == null) return;

        var movementOnX = Input.GetAxisRaw("Horizontal");
        var movementOnY = Input.GetAxisRaw("Vertical");

        var moveVector = new Vector2(movementOnX, movementOnY).normalized;

        print(movementOnX);
        m_playerController.ProcessAxisData(moveVector);

        var mousePosition = Input.mousePosition;
        var mousePositionInWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, - Camera.main.transform.position.z));

        m_playerController.ProcessMousePosition(mousePositionInWorld);

        if (Input.GetMouseButtonDown(0)) m_playerController.ProcessMouseButtonDown(0);
        if (Input.GetMouseButtonDown(1)) m_playerController.ProcessMouseButtonDown(1);
        if (Input.GetMouseButtonDown(2)) m_playerController.ProcessMouseButtonDown(2);
        if (Input.GetMouseButtonUp(0)) m_playerController.ProcessMouseButtonUp(0);
        if (Input.GetMouseButtonUp(1)) m_playerController.ProcessMouseButtonUp(1);
        if (Input.GetMouseButtonUp(2)) m_playerController.ProcessMouseButtonUp(2);

        m_playerController.ProcessMouseScrollDelta(Input.mouseScrollDelta);

        if (Input.GetKeyDown(m_primaryAction)) m_playerController.ProcessPrimaryActionDown();
        if (Input.GetKeyUp(m_primaryAction)) m_playerController.ProcessPrimaryActionUp();
        if (Input.GetKeyDown(m_secondaryAction)) m_playerController.ProcessSecondaryActionDown();
        if (Input.GetKeyUp(m_secondaryAction)) m_playerController.ProcessSecondaryActionUp();
    }
}
