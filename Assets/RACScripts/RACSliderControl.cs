using UnityEngine;
using System.Collections;

public class RACSliderControl : SliderControl
{
	//The total amount of time that the user spent hovering over this slider
	public float MousedOverTime {get {return this.totalMousedOverTime;} private set{}}

	private float lastMouseOverTime;

	private float totalMousedOverTime = 0.0f;

	private bool isMousedOver = false;

	/// <summary>
	/// The minimum amount of time that the user needs to hover over a slider to record
	/// any data for a hover that "hit"
	/// </summary>
	[SerializeField]
	private float minmumRecordedTime = 0.1f;

	private RACWarningEffect warningEffect;
	
	[SerializeField]
	private float minimumWarningRange = 0.1f;
	[SerializeField]
	private float maximumWarningRange = 0.9f;

	protected override void Start ()
	{
		base.Start ();

		this.warningEffect = GameObject.FindObjectOfType(typeof(RACWarningEffect)) as RACWarningEffect;
	}

	protected override void Update ()
	{
		base.Update ();

		//When the user hovers over this slider for the first time, capture that moment
		if (this.sliderBarCollision.HitTest(Input.mousePosition) && !this.isMousedOver)
		{
			this.isMousedOver = true;
			this.lastMouseOverTime = Time.time;
		}

		//If we just moused off a slider, make sure to record that
		if (!this.sliderBarCollision.HitTest(Input.mousePosition) && this.isMousedOver)
		{
			this.isMousedOver = false;
			float mouseOverTimeThisHit = Time.time - this.lastMouseOverTime; 

			if (mouseOverTimeThisHit > this.minmumRecordedTime)
			{
				this.totalMousedOverTime += mouseOverTimeThisHit;

				//Debug.Log("You moused over " + this.name + " for " + mouseOverTimeThisHit + " seconds this hit and " + this.totalMousedOverTime + " seconds total.");
			}

			this.lastMouseOverTime = 0.0f;
		}

		if (this.pressed && this.warningEffect != null && (this.percentOfBar < this.minimumWarningRange || this.percentOfBar > this.maximumWarningRange))
		{
			this.warningEffect.PlayWarningEffect();
		}
	}
}
