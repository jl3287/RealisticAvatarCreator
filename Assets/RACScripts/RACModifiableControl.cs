using UnityEngine;
using System.Collections;

public class RACModifiableControl : MonoBehaviour 
{
	[HideInInspector]
	public SliderControl sliderControl;
	
	public enum SliderStyle {SCALE, POSITION};
	public SliderStyle sliderStyle = SliderStyle.POSITION;
	
	public bool effectsX = false;
	public bool effectsY = false;
	public bool effectsZ = false;

	public string sliderName;

	public Vector2 sliderPosition;

	public float defaultValue = 0.5f;

	public string modifiedBodyPart = "Global";
}
