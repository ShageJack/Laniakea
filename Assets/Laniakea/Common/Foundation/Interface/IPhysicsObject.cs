using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicsObject
{
    double Mass();

    Vector3 Velocity();
    double Spinning();

}
