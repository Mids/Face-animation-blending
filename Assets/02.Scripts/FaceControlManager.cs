using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceControlManager : MonoBehaviour
{
	private VoiceTextWrapper _voiceTextWrapper;
	private FaceMesh _faceMesh;

	private bool _isPlaying = false;

	// Use this for initialization
	void Start () {
		_voiceTextWrapper = GetComponent<VoiceTextWrapper>();
		_faceMesh = GetComponent<FaceMesh>();
		_voiceTextWrapper.LoadVoice();
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (_voiceTextWrapper.ReadyToPlay)
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
