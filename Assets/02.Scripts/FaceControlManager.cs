using System.Collections;
using System.Collections.Generic;
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

	// Use this for initialization
	void Start()
	{
		_voiceTextWrapper = GetComponent<VoiceTextWrapper>();
		_faceMesh = GetComponent<FaceMesh>();
		_inputListner = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputListner>();
	}

	// Update is called once per frame
	void Update()
	{
		if (_inputListner.IsEditEnded)
		{
			_voiceTextWrapper.LoadVoice(_inputListner.GetText());
			_inputListner.IsEditEnded = false;
		}

		if (_voiceTextWrapper.ReadyToPlay && !_isPlaying)
		{
			_faceMesh.LoadMesh();
			_voiceTextWrapper.PlayVoice();
			_isPlaying = true;
		}

		if (_isPlaying)
		{
			_faceMesh.UpdateVertex();
		}
	}
}