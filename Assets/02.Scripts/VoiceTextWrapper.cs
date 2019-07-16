using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class VoiceTextWrapper : MonoBehaviour
{
	public TextAsset textFile;

    void Start()
	{
//		if (LOADTTS_ENG() != 10)
//		{
//			print("TTS Load ERROR!");
//		}
//		else
//		{
//			print("TTS Load SUCCESS");
//		}
//
//		// TODO: This code is running even if load is failed.
//		
//		byte[] testByteArray = StringToByteArray(textFile.text);
//		byte[] testFileName = StringToByteArray("byte.wav");
//
//		if (TextToWaveFile_ENG(testByteArray, testFileName) != 1)
//		{
//			print("TTS File Out ERROR!");
//		}
//
//		playWav("file:///C:/Users/jiny1/Documents/Unity3D/Face anim 32bit/byte.wav");
	}

	private byte[] StringToByteArray(string s)
	{
		var result = new byte[s.Length + 1];

		for (int i = 0; i < s.Length; i++)
		{
			result[i] = (byte) s[i];
		}

		result[s.Length] = 0;

		return result;
	}

	private AudioSource audio;
	void playWav(string url)
	{
		WWW audioLoader = new WWW(url);
		while (!audioLoader.isDone)
		{
//			print("Loading Wav File");
		}

		print("Success!");

		audio = GetComponent<AudioSource>();
		audio.clip = audioLoader.GetAudioClip();
		audio.Play();
    }

	[DllImport("kernel32", SetLastError = true)]
    private static extern bool FreeLibrary(IntPtr hModule);
    private void OnApplicationQuit()
    {
	    UNLOADTTS_ENG();

	    foreach (System.Diagnostics.ProcessModule mod in System.Diagnostics.Process.GetCurrentProcess().Modules)
	    {
		    if (mod.FileName.Contains("voicetext") ||
		        mod.FileName.Contains("testdll"))
		    {
				Debug.Log("Free Library : " + mod.FileName);
			    FreeLibrary(mod.BaseAddress);
		    }
        }
    }

    [DllImport("voicetext_eng")]
    static extern short LOADTTS_ENG();

    [DllImport("voicetext_eng")]
    static extern short UNLOADTTS_ENG();

    [DllImport("voicetext_eng")]
	static extern short TextToWaveFile_ENG([In, Out] byte[] tts_text, byte[] filename);
}