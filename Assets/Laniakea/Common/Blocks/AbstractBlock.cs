using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBlock
{
    readonly bool isTransparent;
    public AbstractBlock(BlockProperties properties)
    {
        isTransparent = properties.isTransparent;
    }

    public bool IsTransparent()
    {
        return isTransparent;
    }

    public class BlockProperties
    {
        public bool isTransparent;
        public BlockProperties(bool isTransparent)
        {
            this.isTransparent = isTransparent;
        }
    }
}
