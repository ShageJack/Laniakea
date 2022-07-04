using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSystem<T> where T : ITickable
{

    List<T> tickableList;
    public AbstractSystem()
    {
        tickableList = new List<T>();
        Init();
    }
   
    public virtual List<T> getObjects()
    {
        return tickableList;
    }

    // initialize from presistent data and so on
    public abstract void Init();
    
    public virtual void Tick()
    {
        tickableList.ForEach(tickable => {
            tickable.Tick();

            if (tickable is IInitable initable && !initable.IsInited())
                initable.SafeInit();
        });
    }

    // save persistent data on exit and so on
    public virtual void Exit()
    {
        foreach (var tickable in tickableList)
        {
            if (tickable is IQuitable quitable)
                quitable.Quit();
        }
    }

    public virtual void RegisterObject(params T[] objs)
    {
        foreach (var obj in objs) {
            tickableList.Add(obj);
        }
    }
}
