using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Mesh_Script : MonoBehaviour
{
	public Vector3[] Vertex = new Vector3[]
	{
		new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, 1, 0), new Vector3(1, 1, 0)
	};

	public Vector2[] UV_MaterialDisplay = new Vector2[]
	{
		new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) // 4 UV with all directions! (Plane has 4 uvMaps)
	};

	public int[] Triangles = new int[6]; // 2 Triangle combinations (2*3=6 vertices/vertexes)

	public Material material;

	private Vector3[] _vertexList;
	private Vector2[] _uvMaterialDisplay;

	void SetVertex()
	{
	}

	void Start()
	{
		Triangles[0] = 0;
		Triangles[1] = 3;
		Triangles[2] = 1;

		Triangles[3] = 0;
		Triangles[4] = 2;
		Triangles[5] = 3;

		Mesh mesh = new Mesh();
		transform.GetComponent<MeshFilter>();

		if (!transform.GetComponent<MeshFilter>() || !transform.GetComponent<MeshRenderer>()) //If you havent got any meshrenderer or filter
		{
			transform.gameObject.AddComponent<MeshFilter>();
			transform.gameObject.AddComponent<MeshRenderer>();
		}

		transform.GetComponent<MeshFilter>().mesh = mesh;

		mesh.name = "MyOwnObject";

		mesh.vertices = Vertex;
		mesh.triangles = Triangles;
		mesh.uv = UV_MaterialDisplay;

		mesh.RecalculateNormals();
//		mesh.Optimize(); // This is doing nothing
//		transform.gameObject.renderer.material = material; //If you want a material.. you have it :)
		GetComponent<Renderer>().material = material;
	}
}