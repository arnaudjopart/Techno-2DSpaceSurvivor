using System;
using UnityEngine;

public abstract class PlayerControllerBase : MonoBehaviour
{
    public abstract void ProcessAxisData(Vector2 moveVector);
    public abstract void ProcessMouseButtonDown(int v);
    public abstract void ProcessMouseButtonUp(int v);
    public abstract void ProcessMousePosition(Vector3 mousePositionInWorld);
    public abstract void ProcessMouseScrollDelta(Vector2 mouseScrollDelta);
    public abstract void ProcessPrimaryActionDown();
    public abstract void ProcessPrimaryActionUp();
    public abstract void ProcessSecondaryActionDown();
    public abstract void ProcessSecondaryActionUp();

    public virtual Vector2 GetVelocity()
    {
        return Vector3.up;
    }
}
