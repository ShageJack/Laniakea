using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPos
{
    public readonly long X;
    public readonly long Y;
    public readonly long Z;

    public BlockPos(long x, long y, long z)
    {
        this.X = x;
        Y = y;
        Z = z;
    }

    public static BlockPos operator +(BlockPos lhs, BlockPos rhs)
    {
        return new BlockPos(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
    }

    public static BlockPos operator -(BlockPos lhs, BlockPos rhs)
    {
        return new BlockPos(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z); 
    }

    public BlockPos Offset(long x, long y, long z)
    {
        return new BlockPos(X + x, Y + y, Z + z);
    }

    public BlockPos Mul(long mul)
    {
        return new BlockPos(X * mul, Y * mul, Z * mul);
    }

    public BlockPos Div(long div)
    {
        return new BlockPos(X / div, Y / div, Z / div);
    }

    public BlockPos Relative(Direction direction)
    {
        return this + DirectionUtils.GetDirectionPos(direction);
    }

    public override bool Equals(object obj)
    {
        if (obj is not BlockPos pos)
            return false;
        else
            return pos.X == X && pos.Y == Y && pos.Z == Z;
    }

    public override int GetHashCode()
    {
        return 31 * 31 + X.GetHashCode() + 31 * Y.GetHashCode() + Z.GetHashCode();
    }

}
