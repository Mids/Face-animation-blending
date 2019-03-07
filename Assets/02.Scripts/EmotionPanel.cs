using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionPanel : MonoBehaviour
{
	public bool MouseIsOn = false;

	private void OnMouseEnter()
	{
		MouseIsOn = true;
	}

	private void OnMouseExit()
	{
		MouseIsOn = false;
	}

	private void OnMouseOver()
	{
		MouseIsOn = true;
	}
}