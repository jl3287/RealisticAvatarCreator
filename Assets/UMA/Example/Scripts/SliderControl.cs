using UnityEngine;
using System.Collections;

public class SliderControl : MonoBehaviour 
{
	public bool pressed;

	public float percentOfBar;
	public Vector2 sliderOffset;

	public float actualValue;
	
	public bool stepSlider;
	public byte actualStepValue;
	public int stepSize;
	
	public GUIText descriptionText;
	public GUIText valueText;
	public GUITexture sliderBar;
	public GUITexture sliderBarCollision;
	public GUITexture sliderMark;
	
	public Vector2 descriptionTextOriginalPos;
	public Vector2 sliderBarOriginalPos;
	public Vector2 sliderBarCollisionOriginalPos;
	public Vector2 sliderMarkOriginalPos;
	
	public float minValue = 0;
	public float maxValue = 1;

	void Start () 
	{
		descriptionTextOriginalPos = descriptionText.pixelOffset;
		sliderBarOriginalPos.x = sliderBar.pixelInset.x;
		sliderBarOriginalPos.y = sliderBar.pixelInset.y;
		sliderBarCollisionOriginalPos.x = sliderBarCollision.pixelInset.x;
		sliderBarCollisionOriginalPos.y = sliderBarCollision.pixelInset.y;
		
		sliderMarkOriginalPos.x = sliderMark.pixelInset.x;
		sliderMarkOriginalPos.y = sliderMark.pixelInset.y;
		name = descriptionText.text;
	}
	
	void Update () 
	{
		float spread = this.maxValue - this.minValue;
		this.percentOfBar = (this.actualValue - this.minValue) / spread;

		descriptionText.pixelOffset = descriptionTextOriginalPos + sliderOffset;
		
		sliderBar.pixelInset = new Rect(sliderBarOriginalPos.x + sliderOffset.x, sliderBarOriginalPos.y + sliderOffset.y, sliderBar.pixelInset.width, sliderBar.pixelInset.height);
		
		sliderBarCollision.pixelInset = new Rect(sliderBarCollisionOriginalPos.x + sliderOffset.x, sliderBarCollisionOriginalPos.y + sliderOffset.y, sliderBarCollision.pixelInset.width,sliderBarCollision.pixelInset.height);
		
		sliderMark.pixelInset = new Rect((sliderBarCollision.pixelInset.width * percentOfBar) + sliderOffset.x - sliderMark.pixelInset.width/2, sliderMarkOriginalPos.y + sliderOffset.y, sliderMark.pixelInset.width, sliderMark.pixelInset.height);
		valueText.pixelOffset = new Vector2(sliderMark.pixelInset.x + 16,sliderMark.pixelInset.y + 18);
			
		if(Input.GetMouseButtonDown(0))
		{
			if(sliderBarCollision.HitTest(Input.mousePosition))
			{
				pressed = true;
			}
		}
		
		if(pressed)
		{
			percentOfBar = (Input.mousePosition.x - sliderBarCollision.pixelInset.x)/sliderBarCollision.pixelInset.width;
			
			if(percentOfBar > 1)
				percentOfBar = 1;
			else if(percentOfBar < 0)
				percentOfBar = 0;
			
			if(stepSlider)
			{
				actualStepValue = (byte)Mathf.RoundToInt(percentOfBar * stepSize);
			}
			
			if(Input.GetMouseButtonUp(0))
			{
				pressed = false;
			}
		}

		//Set the text and actual value based on the percent
		this.actualValue = this.percentOfBar*spread + this.minValue;
		valueText.text = this.actualValue.ToString("F2");
	}
	
	public void ForceUpdate(){
		//for stepSlider first update
		percentOfBar = (float)actualStepValue/stepSize;
	}
}