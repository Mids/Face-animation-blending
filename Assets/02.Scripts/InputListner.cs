using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputListner : MonoBehaviour
{
	private InputField _input;

	// Start is called before the first frame update
	void Start()
	{
		_input = gameObject.GetComponent<InputField>();
		_input.onEndEdit.AddListener(InputFieldListener);
	}

	private void InputFieldListener(string input)
	{
//		if (Add1(1) == 2)
//		{
//			_input.text = "DLL INJECTED!";
//		}
	}
}