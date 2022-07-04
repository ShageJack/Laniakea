using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState
{
    readonly AbstractBlock block;

    public BlockState(AbstractBlock block)
    {
        this.block = block;
    }

    public AbstractBlock GetBlock()
    {
        return block;
    }

    public bool IsAir()
    {
        return block == null || block is AirBlock;
    }
}
