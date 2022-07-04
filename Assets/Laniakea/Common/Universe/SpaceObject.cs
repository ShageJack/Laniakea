using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpaceObject : IPositionedObject, IPhysicsObject, ITickable, IInitable, IQuitable
{
    // position
    Vector3 position;
    Vector3 axis;

    // physics
    double mass;
    Vector3 velocity;
    double spinning;

    bool Inited = false;

    public SpaceObject(Vector3 position, Vector3 axis, double mass, Vector3 velocity, double spinning)
    {
        this.position = position;
        this.axis = axis;
        this.mass = mass;
        this.velocity = velocity;
        this.spinning = spinning;
    }

    public abstract void Tick();

    public Vector3 Axis()
    {
        return axis;
    }

    public Vector3 Position()
    {
        return position;
    }

    public double Spinning()
    {
        return spinning;
    }

    public Vector3 Velocity()
    {
        return velocity;
    }

    public double Mass()
    {
        return mass;
    }

    public abstract void Init();

    public void SetInited()
    {
        Inited = true;
    }

    public bool IsInited()
    {
        return Inited;
    }

    public abstract void Quit();

    public void MoveTo(Vector3 pos)
    {
        position = pos;
    }

    public void SetAxis(Vector3 axis)
    {
        this.axis = axis;
    }
}
