using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractStar : AbstractBody
{   public AbstractStar(Vector3 position, Vector3 axis, double mass, Vector3 velocity, double spinning) : base(position, axis, mass, velocity, spinning)
    {

    }
}
