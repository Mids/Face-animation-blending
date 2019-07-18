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
	public bool ReadyToPlay = false;
	private string _textToRead;
	private bool _isLoading = false;
	private bool _isLoaded = false;
	private bool _hasSomethingToPlay = false;
	private bool _isPlaying = false;

	private AudioSource _audio;
	WWW audioLoader;

	public void LoadVoice(string text)
	{
		if (LOADTTS_ENG() != 10)
		{
			print("TTS Load ERROR!");
		}
		else
		{
			print("TTS Load SUCCESS");
			_isLoaded = true;
			_hasSomethingToPlay = true;
			_textToRead = text;
		}
	}

	void Update()
	{
		if (!_isLoaded)
			return;

		if (_hasSomethingToPlay)
		{
			byte[] testByteArray = StringToByteArray(_textToRead);
			byte[] testFileName = StringToByteArray(Constants.WaveFileName);

			if (TextToWaveFile_ENG(testByteArray, testFileName) != 1)
			{
				print("TTS File Out ERROR!");
			}
			else
			{
				print("TTS File Out SUCCESS!");
				audioLoader = new WWW(Constants.WaveFilePath + Constants.WaveFileName);
				_hasSomethingToPlay = false;
				_isLoading = true;
			}
		}

		// Start to play audio if it is not playing
		if (audioLoader.isDone && _isLoading)
		{
			_isLoading = false;
			ReadyToPlay = true;
		}

		//TODO: Check if playing is ended
	}

	public void PlayVoice()
	{
		if (_isPlaying) return;

		_audio = GetComponent<AudioSource>();
		_audio.clip = audioLoader.GetAudioClip();
		_audio.Play();
		_isPlaying = true;
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