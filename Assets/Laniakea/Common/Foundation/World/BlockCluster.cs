using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCluster
{
    readonly IPositionedObject source;
    long radius;
    Dictionary<BlockPos, Chunk> loadedChunks = new Dictionary<BlockPos, Chunk>();

    public BlockCluster(IPositionedObject source, long radius)
    {
        this.source = source;
        this.radius = radius;
    }

    public Chunk GetOrLoadChunk(long chunkX, long chunkY, long chunkZ)
    {
        long RX = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, chunkX);
        long RZ = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, chunkZ);
        long RY = (long)Mathf.Abs(chunkY);

        if (loadedChunks.TryGetValue(new BlockPos(RX, RY, RZ), out Chunk chunk))
        {
            return chunk;
        }
        else
        {
            return CreateChunk(RX, RY, RZ);
        }
    }

    public void LoadChunk(Chunk chunk)
    {
        loadedChunks.Add(chunk.GetChunkPos(), chunk);
        chunk.LoadFromCluster();
    }

    public void UnloadChunk(Chunk chunk)
    {
        if (loadedChunks.Remove(chunk.GetChunkPos()))
        {
            chunk.SaveToCluster();
        }
    }

    public void SaveAll()
    {
        foreach(var chunk in loadedChunks)
        {
            chunk.Value.SaveToCluster();
        }
    }

    public Chunk CreateChunk(long chunkX, long chunkY, long chunkZ)
    {
        Chunk chunk = new(this, chunkX, chunkY, chunkZ);
        LoadChunk(chunk);
        return chunk;
    }

    public BlockState GetBlockState(BlockPos pos)
    {
        return GetBlockState(pos.X, pos.Y, pos.Z);
    }

    public BlockState GetBlockState(long x, long y, long z)
    {
        long RX = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, x);
        long RZ = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, z);
        long RY = (long)Mathf.Abs(y);

        return GetOrLoadChunk(RX / Chunk.CHUNK_SIZE, RY / Chunk.CHUNK_SIZE, RZ / Chunk.CHUNK_SIZE).GetBlockState(RX, RY, RZ);
    }

    public void SetBlockState(BlockPos pos, BlockState state)
    {
        SetBlockState(pos.X, pos.Y, pos.Z, state);
    }

    public void SetBlockState(long x, long y, long z, BlockState state)
    {
        long RX = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, x);
        long RZ = (long)MathUtils.Ranged(-Mathf.PI * radius, Mathf.PI * radius, z);
        long RY = (long)Mathf.Abs(y);

        GetOrLoadChunk(RX / Chunk.CHUNK_SIZE, RY / Chunk.CHUNK_SIZE, RZ / Chunk.CHUNK_SIZE).SetBlockState(RX, RY, RZ, state);
    }

    public Vector3 GetAxis()
    {
        return source.Axis();
    }

    // get actual world position
    public Vector3 GetWorldPosition(BlockPos pos)
    {
        throw new System.NotImplementedException();
    }

    public Vector3 GetCenter()
    {
        return source.Position();
    }

    // get cluster persistent data

    // generation
}
