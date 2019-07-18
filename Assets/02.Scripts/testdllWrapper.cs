using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class testdllWrapper : MonoBehaviour
{
	// Use this for initialization
	public void LoadFace()
	{
		LoadFaceAni();
	}

	public SHxFaceObj GetFaceObj()
	{
		return GetFace();
	}

	public void UpdateFace()
	{
		UpdateLipSync();
	}

	[DllImport("testdll")]
	private static extern int LoadFaceAni();

	[DllImport("testdll")]
	private static extern int UpdateLipSync();

	[DllImport("testdll", CallingConvention = CallingConvention.Cdecl)]
	private static extern SHxFaceObj GetFace();
}