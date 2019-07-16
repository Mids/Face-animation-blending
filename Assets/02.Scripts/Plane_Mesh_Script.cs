using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Mesh_Script : MonoBehaviour
{
	// Put wrapper in the inspector
	public testdllWrapper DllWrapper;

	public Vector2[] UV_MaterialDisplay = new Vector2[]
	{
		new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) // 4 UV with all directions! (Plane has 4 uvMaps)
	};

	public Material material;

	private Vector3[] _vertexList;
	private int[] _faceList;
	private Vector2[] _uvMaterialDisplay;

	public void SetMeshFromFaceObj(SHxFaceObj obj)
	{
		unsafe
		{
			// Get Vertices
			_vertexList = new Vector3[obj.m_numVtx];
			for (int i = 0; i < obj.m_numVtx; i++)
			{
				_vertexList[i] = new Vector3(obj.m_pVtxList[i].x, obj.m_pVtxList[i].y, obj.m_pVtxList[i].z);
			}

			// Get Facet
			_faceList = new int[obj.m_numVtxFace * 3];
			for (int i = 0; i < obj.m_numVtxFace; i++)
			{
				_faceList[3 * i] = obj.m_pVtxFaceList[i].v1;
				_faceList[3 * i + 1] = obj.m_pVtxFaceList[i].v2;
				_faceList[3 * i + 2] = obj.m_pVtxFaceList[i].v3;
			}
		}
	}

	public void LoadMesh()
	{
		SetMeshFromFaceObj(DllWrapper.GetFaceObj());
		Mesh mesh = new Mesh();
		transform.GetComponent<MeshFilter>();

		if (!transform.GetComponent<MeshFilter>() || !transform.GetComponent<MeshRenderer>()) //If you havent got any meshrenderer or filter
		{
			transform.gameObject.AddComponent<MeshFilter>();
			transform.gameObject.AddComponent<MeshRenderer>();
		}

		transform.GetComponent<MeshFilter>().mesh = mesh;

		mesh.name = "MyOwnObject";

		mesh.vertices = _vertexList;
		mesh.triangles = _faceList;
//		mesh.uv = UV_MaterialDisplay;

		mesh.RecalculateNormals();
		GetComponent<Renderer>().material = material;
	}

	static int i = 0;

	private void Update()
	{
		if (i++ == 10)
		{
			LoadMesh();
		}
	}
}