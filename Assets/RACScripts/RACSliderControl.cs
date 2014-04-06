using UnityEngine;
using System.Collections;

public class RACSliderControl : SliderControl
{
	public float MousedOverTime {get {return this.totalMousedOverTime;} private set{}}

	private float lastMouseOverTime;

	private float totalMousedOverTime = 0.0f;

	private bool isMousedOver = false;

	protected override void Update ()
	{
		base.Update ();

		if (this.sliderBarCollision.HitTest(Input.mousePosition) && !this.isMousedOver)
		{
			this.isMousedOver = true;
			this.lastMouseOverTime = Time.time;
		}

		if (!this.sliderBarCollision.HitTest(Input.mousePosition) && this.isMousedOver)
		{
			this.isMousedOver = false;
			float mouseOverTimeThisHit = Time.time - this.lastMouseOverTime; 
			this.totalMousedOverTime += mouseOverTimeThisHit;

			//Debug.Log("You moused over " + this.name + " for " + mouseOverTimeThisHit + " seconds this hit and " + this.totalMousedOverTime + " seconds total.");

			this.lastMouseOverTime = 0.0f;
		}
	}
}
