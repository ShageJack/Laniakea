using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrestrialPlanet : AbstractPlanet
{
    public TerrestrialPlanet(Vector3 position, Vector3 axis, double mass, Vector3 velocity, double spinning) : base(position, axis, mass, velocity, spinning)
    {

    }

    public override void Init()
    {
        Cluster = new BlockCluster(this, Random.Range(1024, 16384));
        // world generation
    }

    public override void Tick() {

    }
}
