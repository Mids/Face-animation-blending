using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMesh : MonoBehaviour
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
	private Mesh _mesh;

	private bool _isFirst = true;

	public void SetMeshFromFaceObj(SHxFaceObj obj)
	{
		// Get Vertices
		UpdateVertex(obj);
		unsafe
		{
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
		_mesh = new Mesh();
		transform.GetComponent<MeshFilter>();

		if (!transform.GetComponent<MeshFilter>() || !transform.GetComponent<MeshRenderer>()) //If you havent got any meshrenderer or filter
		{
			transform.gameObject.AddComponent<MeshFilter>();
			transform.gameObject.AddComponent<MeshRenderer>();
		}

		transform.GetComponent<MeshFilter>().mesh = _mesh;

		_mesh.name = "MyOwnObject";

		_mesh.vertices = _vertexList;
		_mesh.triangles = _faceList;
//		mesh.uv = UV_MaterialDisplay;

		_mesh.RecalculateNormals();
		GetComponent<Renderer>().material = material;
	}

	void Update()
	{
		// LoadMesh should be called after start() finished.
		if (_isFirst)
		{
			LoadMesh();
			_isFirst = false;
		}
		else
		{
			UpdateVertex(DllWrapper.GetFaceObj());
			_mesh.vertices = _vertexList;
			_mesh.triangles = _faceList;
			_mesh.RecalculateNormals();
		}
	}

	private void UpdateVertex(SHxFaceObj obj)
	{
		unsafe
		{
			// Get Vertices
			_vertexList = new Vector3[obj.m_numVtx];
			for (int i = 0; i < obj.m_numVtx; i++)
			{
				_vertexList[i] = new Vector3(obj.m_pAniVtxList[i].x, obj.m_pAniVtxList[i].y, obj.m_pAniVtxList[i].z);
			}
		}
	}
}