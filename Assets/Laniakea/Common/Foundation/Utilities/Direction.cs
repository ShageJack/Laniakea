using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public enum Direction
{
    NORTH = 0,
    SOUTH = 1,
    UP = 2,
    DOWN = 3,
    WEST = 4,
    EAST = 5
}

public class DirectionUtils
{
    public static BlockPos GetDirectionPos(Direction direction)
    {
        return direction switch
        {
            Direction.UP => new BlockPos(0, 1, 0),
            Direction.DOWN => new BlockPos(0, -1, 0),
            Direction.NORTH => new BlockPos(0, 0, -1),
            Direction.SOUTH => new BlockPos(0, 0, 1),
            Direction.WEST => new BlockPos(-1, 0, 0),
            Direction.EAST => new BlockPos(1, 0, 0),
            _ => throw new ArgumentException()
        };
    }
}
