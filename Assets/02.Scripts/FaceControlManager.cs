using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/**
 * How To
 * 1. Load Voice
 * 2. Wait until the voice is ready
 * 3. Load Face Mesh and play at same time because timestamp starts when load face mesh.
 */
public class FaceControlManager : MonoBehaviour
{
	private VoiceTextWrapper _voiceTextWrapper;
	private FaceMesh _faceMesh;
	private InputListner _inputListner;

	private bool _isPlaying = false;
	private string _text;

	// Use this for initialization
	void Start()
	{
		RegisterDebugCallback(new DebugCallback(DebugMethod));

		_voiceTextWrapper = GetComponent<VoiceTextWrapper>();
		_faceMesh = GetComponent<FaceMesh>();
		_inputListner = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputListner>();
		_faceMesh.LoadMesh();
	}

	// Update is called once per frame
	void Update()
	{
		if (_inputListner.IsEditEnded)
		{
			_text = _inputListner.GetText();
			_inputListner.IsEditEnded = false;
			_text = _faceMesh.StartMesh(_text);
			_voiceTextWrapper.LoadVoice(_text);
		}

		if (_voiceTextWrapper.ReadyToPlay && !_isPlaying)
		{
			_voiceTextWrapper.PlayVoice();
			_isPlaying = true;
		}

		if (_isPlaying)
		{
			_faceMesh.UpdateVertex();
		}
	}


	private delegate void DebugCallback(string message);

	[DllImport("testdll")]
	private static extern void RegisterDebugCallback(DebugCallback callback);


	private static void DebugMethod(string message)
	{
		Debug.Log("testdll: " + message);
	}
}