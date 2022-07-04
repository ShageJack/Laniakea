using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPositionedObject
{
    Vector3 Position();
    Vector3 Axis();

    void MoveTo(Vector3 pos);
    void SetAxis(Vector3 axis);

    public void Rotate(Quaternion rotation)
    {
        SetAxis(rotation * Axis());
    }
}
