using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laniakea : MonoBehaviour
{

    private const float TICK_TIME = 0.05f;
    
    private long tick = 0;
    private float tickTimer = 0;

    private UniverseSystem UniverseSystem;
    private BodySystem BodySystem;

    // game loop
    private void Tick() {
        UniverseSystem.Tick();
        BodySystem.Tick();
    }

    // game start-up
    void Start()
    {
        // initialize game registery


        // initialize game system
        UniverseSystem = new UniverseSystem();
        BodySystem = new BodySystem();
    }

    void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= TICK_TIME)
        {
            tickTimer -= TICK_TIME;
            Tick();
            tick++;
        }
    }

    void Awake()
    {
        tickTimer = 0;
    }

    void OnApplicationQuit()
    {
        UniverseSystem.Exit();
        BodySystem.Exit();
    }
}
