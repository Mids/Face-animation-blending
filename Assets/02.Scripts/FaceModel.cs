using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Runtime.InteropServices;


public class FaceModel : MonoBehaviour
{
	public const string FaceModelName = "GRML_Upper_B_Tim";
	public const string DownTeethName = "GRH_DownTeeth_Tim";
	public const string UpperTeethName = "GRH_UpperTeeth_Tim";
	public const string EyeLashesName = "GRH_EyeLashes_Tim";
	public const string LEyeName = "GRH_LEye_Tim";
	public const string REyeName = "GRH_REye_Tim";
	public const string TongueName = "GRH_Tongue_Tim";

	private Mesh _downTeethMesh;
	private Mesh _upperTeethMesh;
	private Mesh _eyeLashesMesh;
	private Mesh _lEyeMesh;
	private Mesh _rEyeMesh;
	private Mesh _tongueMesh;
	private Mesh _faceMesh;

	void Start()
	{
		GetModelMeshes();
	}


	// Update is called once per frame
	void Update()
	{
		UpdateMeshes(_downTeethMesh);
		UpdateMeshes(_upperTeethMesh);
		UpdateMeshes(_eyeLashesMesh);
		UpdateMeshes(_lEyeMesh);
		UpdateMeshes(_rEyeMesh);
		UpdateMeshes(_tongueMesh);
		UpdateMeshes(_faceMesh);
	}

	private void GetModelMeshes()
	{
		var face = transform.Find(FaceModelName);
		_downTeethMesh = face.Find(DownTeethName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_upperTeethMesh = face.Find(UpperTeethName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_eyeLashesMesh = face.Find(EyeLashesName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_lEyeMesh = face.Find(LEyeName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_rEyeMesh = face.Find(REyeName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_tongueMesh = face.Find(TongueName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
		_faceMesh = face.Find(FaceModelName).GetComponent<SkinnedMeshRenderer>().sharedMesh;
	}

	private void UpdateMeshes(Mesh mesh)
	{
		var vertices = mesh.vertices;
		var normals = mesh.normals;

		VertexManipulate(vertices, normals, vertices.Length, Time.time);

		mesh.vertices = vertices;
	}

	[DllImport("testdll")]
	static extern void VertexManipulate([In, Out] Vector3[] vertices, Vector3[] normals, int length, float time);
}