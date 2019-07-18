using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputListner : MonoBehaviour
{
	private InputField _input;
	public bool IsEditEnded = false;

	// Start is called before the first frame update
	void Start()
	{
		_input = gameObject.GetComponent<InputField>();
		_input.onEndEdit.AddListener(InputFieldListener);
	}

	private void InputFieldListener(string input)
	{
		IsEditEnded = true;
	}

	public string GetText()
	{
		return _input.text;
	}
}