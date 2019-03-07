using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private bool _isSelected = false;
	private const float Radius = 3.0f;
	private const float ShortRadius = 0.866025f;
	private const float Slope = 1.73205f;

	private void OnMouseDown()
	{
		_isSelected = true;
	}

	private void OnMouseDrag()
	{
		if (!_isSelected) return;

		var lastPosition = transform.localPosition;

		// Let it follow cursor.
		var positionOfScreen = Camera.main.WorldToScreenPoint(transform.position);
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));

		// If it's out of hexagon
		var x = transform.localPosition.x;
		var y = transform.localPosition.y;
		var distance = Mathf.Sqrt(x * x + y * y);
		if (y > ShortRadius || y < -ShortRadius ||
		    y > -Slope * x + Slope ||
		    y < +Slope * x - Slope ||
		    y < -Slope * x - Slope ||
		    y > +Slope * x + Slope)
		{
			// Back to last position
			transform.localPosition = lastPosition;
		}
	}

	private void OnMouseUp()
	{
		_isSelected = false;
	}
}