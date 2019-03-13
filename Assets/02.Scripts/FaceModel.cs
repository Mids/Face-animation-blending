using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceModel : MonoBehaviour
{
	private Mesh _faceMesh;

	void Start()
	{
		_faceMesh = transform.Find("TestCube").GetComponent<MeshFilter>().mesh;
	}



    // Update is called once per frame
    void Update()
    {
	    var vertices = _faceMesh.vertices;
	    var normals = _faceMesh.normals;
	    int j=0;
	    for (int i = 0; i < vertices.Length; i++)
	    {
            			print("time" +  " : "+Time.time);
            vertices[i] -= normals[i] * Mathf.Sin(Time.time*10)/10;
	    }
        
        _faceMesh.vertices = vertices;
    }
}
