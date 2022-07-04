using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a cubic chunk, a slice of a block cluster
// chunk is only used to store and get block data quickly
// chunk will be immediately and dynamically loaded to memory on any request (from such as TileEntities) with a pretty long lifecycle
// unloading chunk will never unload TileEntities
public class Chunk
{
    public const int CHUNK_SIZE = 32;

    BlockPos chunkPos;
    BlockCluster cluster;
    BlockState[,,] cache;

    public Chunk(BlockCluster cluster, long x, long y, long z) {
        this.cluster = cluster;
        chunkPos = new BlockPos(x, y, z);
    }

    public Chunk(BlockCluster cluster, long x, long y, long z, BlockState[,,] cache)
    {
        this.cluster = cluster;
        chunkPos = new BlockPos(x, y, z);
        this.cache = cache;
    }

    public BlockState GetBlockState(BlockPos pos)
    {
        return GetBlockState(pos.X, pos.Y, pos.Z);
    }

    public BlockState GetBlockState(long x, long y, long z) {
        if (cache == null)
        {
            LoadFromCluster();
        }

        if (cache != null)
        {
            BlockPos pos = GetChunkOriginPos();
            return cache[x - pos.X, y - pos.Y, z - pos.Z];
        }

        return new BlockState(Blocks.AIR);
    }

    public void SetBlockState(BlockPos pos, BlockState state)
    {
        SetBlockState(pos.X, pos.Y, pos.Z, state);
    }

    public void SetBlockState(long x, long y, long z, BlockState state) 
    {
        if (cache == null)
        {
            LoadFromCluster();
        }

        if (cache != null)
        {
            BlockPos pos = GetChunkOriginPos();
            cache[x - pos.X, y - pos.Y, z - pos.Z] = state;
        }
    }

    public void LoadFromCluster()
    {
        throw new System.NotImplementedException();
    }

    public void SaveToCluster()
    {
        throw new System.NotImplementedException();
    }

    public BlockPos GetChunkPos()
    {
        return chunkPos;
    }

    public BlockPos GetChunkOriginPos() {
        return chunkPos.Mul(CHUNK_SIZE);
    }

    public BlockCluster GetCluster()
    {
        return cluster;
    }

    public BlockPos ConvertBlockPosToChunkCoord(long x, long y, long z)
    {
        return new BlockPos(x, y, z);
    }

    public Vector3 GetWorldPosition(BlockPos pos)
    {
        return cluster.GetWorldPosition(pos);
    }
    
    public Vector3 GetClusterCenter()
    {
        return cluster.GetCenter();
    }

    public Vector3 GetAxis()
    {
        return cluster.GetAxis();
    }

    public override bool Equals(object obj)
    {
        if (obj is not Chunk chunk)
            return false;
        else
            return chunk.chunkPos.Equals(this.chunkPos);
    }

    public override int GetHashCode()
    {
        return chunkPos.GetHashCode();
    }

}
