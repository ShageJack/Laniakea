using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameRenderer : MonoBehaviour
{
    public MeshRenderer meshRenderer;
	public MeshFilter meshFilter;

	int vertexIndex = 0;
	List<Vector3> vertices = new List<Vector3>();
	List<int> triangles = new List<int>();
	List<Vector2> uvs = new List<Vector2>();

	void Start () {
		

		CreateMesh();
	}

	void Update() {

	}

	void RenderChunk(Chunk chunk)
    {
		BlockPos origin = chunk.GetChunkOriginPos();
		Vector3 clusterCenter = chunk.GetClusterCenter();

		for (int x = 0; x < Chunk.CHUNK_SIZE; x++)
        {
			for (int y = 0; y < Chunk.CHUNK_SIZE; y++)
            {
				for (int z = 0 ; z < Chunk.CHUNK_SIZE; z++)
                {
					BlockPos pos = origin.Offset(x, y, z);

					foreach (Direction direction in EnumUtils.GetValues<Direction>()) 
					{
						BlockState state = chunk.GetCluster().GetBlockState(pos.Relative(direction));
						if (state.IsAir() || state.GetBlock().IsTransparent()) 
						{
							DrawBlockFace(clusterCenter, chunk.GetWorldPosition(pos), chunk.GetAxis(), chunk.GetBlockState(pos), direction);
                        }
					}
					
                }
            }
        }
    }

	void DrawBlockFace(Vector3 clusterCenter, Vector3 position, Vector3 axis, BlockState state, Direction direction) {

		for (int i = 0; i < 6; i++)
		{
			// TODO: render a bended cube face...

			int triangleVertexIndex = VoxelData.voxelTriangles[(int)direction, i];
			vertices.Add(VoxelData.voxelVertices[triangleVertexIndex] + position);
			triangles.Add(vertexIndex);

			uvs.Add(VoxelData.voxelUVs[i]);

			vertexIndex++;
		}
	}

	void CreateMesh()
    {
		Mesh mesh = new Mesh();
		mesh.vertices = vertices.ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.ToArray();

		mesh.RecalculateNormals();

		meshFilter.mesh = mesh;
	}
}
