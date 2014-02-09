using UnityEngine;
using System.Collections;

public class RACModifiableControl : MonoBehaviour 
{
	private SliderControl sliderControl;

	public string sliderName;

	public Vector2 sliderPosition;

	[Range(0, 1)]
	public float defaultValue = 0.5f;
}
