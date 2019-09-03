using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
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

	public unsafe string ParseEmotionScript(string script)
	{
		byte[] byteString = Encoding.ASCII.GetBytes(script);

		ParseEmotion(byteString);
		// The script is changed after parsing emotion.
		script = System.Text.Encoding.ASCII.GetString(byteString);
		print(script);

		return script;
	}

	public void StartFace()
	{
		StartFaceAni();
	}

	public void SetEmotion()
	{
		SetEmotionalWord();
	}

    public void UpdateFace()
	{
		UpdateLipSync();
	}

	[DllImport("testdll")]
	private static extern unsafe int ParseEmotion(byte[] script);

	[DllImport("testdll")]
	private static extern int LoadFaceAni();

	[DllImport("testdll")]
	private static extern int StartFaceAni();

	[DllImport("testdll")]
	private static extern int SetEmotionalWord();

    [DllImport("testdll")]
	private static extern int UpdateLipSync();

	[DllImport("testdll", CallingConvention = CallingConvention.Cdecl)]
	private static extern SHxFaceObj GetFace();
}