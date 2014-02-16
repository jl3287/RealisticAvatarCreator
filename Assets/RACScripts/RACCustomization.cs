using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCustomization : UMACustomization 
{
	private List<RACModifiableControl> modifiableControlList = new List<RACModifiableControl>();

	public bool useOldSlider = false;

	public List<RACModifiableControl> ControlList {get{return this.modifiableControlList;} private set{}}

	// Use this for initialization
	protected void Start () 
	{
		if (useOldSlider)
			base.Start();

		InstanciateNewSliders(this.modifiableControlList);
	}

	public void InstanciateNewSliders(List<RACModifiableControl> newModifiableControlList)
	{
		//Destroy any old sliders
		for (int iSliderIndex = 0; iSliderIndex < this.modifiableControlList.Count; ++iSliderIndex)		
		{			
			RACModifiableControl curControl = this.modifiableControlList[iSliderIndex];
			Destroy(curControl.sliderControl.gameObject);
		}

		//Set our sliders to be new sliders
		this.modifiableControlList = newModifiableControlList;

		//Use new sliders
		for (int iSliderIndex = 0; iSliderIndex < this.modifiableControlList.Count; ++iSliderIndex)		
		{
			RACModifiableControl curControl = this.modifiableControlList[iSliderIndex];
			curControl.sliderControl = InstantiateSlider(curControl.sliderName, curControl.sliderPosition.x, curControl.sliderPosition.y);
			curControl.sliderControl.actualValue = curControl.defaultValue;
			curControl.sliderControl.minValue = curControl.minValue;
			curControl.sliderControl.maxValue = curControl.maxValue;
		}
	}

	public override void TransferValues ()
	{
		if (useOldSlider)
			base.TransferValues ();
	}

	public override void ReceiveValues ()
	{
		if (useOldSlider)
			base.ReceiveValues ();
	}

	protected override void Update ()
	{
		base.Update ();

		if (this.umaData)
		{
			for (int iSliderIndex = 0; iSliderIndex < this.modifiableControlList.Count; ++iSliderIndex)		
			{
				RACModifiableControl curControl = this.modifiableControlList[iSliderIndex];
				if (curControl.sliderControl.pressed)
				{
					this.editing = true;
					UpdateUMAShape();
				}
			}
		}
	}
}
