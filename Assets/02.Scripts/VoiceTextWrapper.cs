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
	// Start is called before the first frame update
	void Start()
	{
		if (LOADTTS_ENG() != 10)
		{
			print("TTS Load ERROR!");
		}
		else
		{
			print("TTS Load SUCCESS");
		}

		// TODO: This code is running even if load is failed.
		
		byte[] testByteArray = StringToByteArray(texttest());
		byte[] testFileName = StringToByteArray("byte.pcm");

		if (TextToPcmFile_ENG(testByteArray, testFileName) != 1)
		{
			print("TTS File Out ERROR!");
		}
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

	string texttest()
	{
		var inputListener = GameObject.Find("InputField").GetComponent<InputListner>();
		var text = inputListener.GetText();
		return text;
	}

	[DllImport("voicetext_eng")]
	static extern short LOADTTS_ENG();

	[DllImport("voicetext_eng")]
	static extern short TextToPcmFile_ENG([In, Out] byte[] tts_text, byte[] filename);
}