using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractEntity : ITickable, IInitable, IQuitable, IPositionedObject, IPhysicsObject
{
    private bool isInited = false;

    public Vector3 position = Vector3.zero;
    public Vector3 axis = Vector3.zero;

    public double mass = 0;
    public Vector3 velocity = Vector3.zero;
    public double spinning = 0;
    public abstract void Init();
    public bool IsInited()
    {
        return isInited;
    }
    public void SetInited()
    {
        isInited = true;
    }
    public abstract void Tick();

    public abstract void Quit();

    public void LoadNearbyChunk()
    {

    }

    public Vector3 Position()
    {
        return position;
    }

    public Vector3 Axis()
    {
        return axis;
    }

    public double Mass()
    {
        return mass;
    }

    public Vector3 Velocity()
    {
        return velocity;
    }

    public double Spinning()
    {
        return spinning;
    }

    public void MoveTo(Vector3 pos)
    {
        position = pos;
    }

    public void SetAxis(Vector3 axis)
    {
        this.axis = axis;
    }
}
