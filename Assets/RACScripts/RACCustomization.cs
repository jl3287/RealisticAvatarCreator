using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCustomization : UMACustomization 
{
	public List<RACModifiableControl> modifiableControlList = new List<RACModifiableControl>();

	public bool useOldSlider = false;

	// Use this for initialization
	protected void Start () 
	{
		if (useOldSlider)
			base.Start();

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
