using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlanet : AbstractBody
{

    public BlockCluster Cluster;

    public AbstractPlanet(Vector3 position, Vector3 axis, double mass, Vector3 velocity, double spinning) : base(position, axis, mass, velocity, spinning)
    {

    }

    public override void Quit()
    {
        if (Cluster != null)
            Cluster.SaveAll();
    }

}
