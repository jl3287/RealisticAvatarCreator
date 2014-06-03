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

	public string sliderName = "Slider Name";

	public Vector2 sliderPosition;

	[SerializeField]
	private float defaultValue = 0.5f;
	public float DefaultValue {get{return this.defaultValue;} private set{this.defaultValue = value;}}
	public float StartingValue {get; set;}

	public float minValue = 0.0f;

	public float maxValue = 1.0f;
	
	public string[] modifiedBodyParts = {"Global"};

	public float minimumWarningRange = 0.1f;
	public float maximumWarningRange = 0.9f;

	public float GetDeviation()
	{
		float startingValue = this.StartingValue;
		float leftValue = sliderControl.minValue;
		float rightValue = sliderControl.maxValue;
		float currentValue = sliderControl.actualValue;
		
		return Mathf.Abs(startingValue - currentValue)/Mathf.Abs(leftValue - rightValue);
	}
}
