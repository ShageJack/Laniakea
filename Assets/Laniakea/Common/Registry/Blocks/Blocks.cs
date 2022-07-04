using System;
using System.Collections.Generic;
public static class Blocks
{
    public static AbstractBlock AIR = new AirBlock(new AbstractBlock.BlockProperties(true));
    public static AbstractBlock STONE = new StoneBlock(new AbstractBlock.BlockProperties(false));
}