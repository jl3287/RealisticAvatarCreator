using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCustomization : UMACustomization 
{
	public List<RACModifiableControl> modifiableControlList = new List<RACModifiableControl>();

	// Use this for initialization
	protected void Start () 
	{
		//base.Start();

		for (int iSliderIndex = 0; iSliderIndex < this.modifiableControlList.Count; ++iSliderIndex)		
		{
			RACModifiableControl curControl = this.modifiableControlList[iSliderIndex];
			curControl.sliderControl = InstantiateSlider(curControl.sliderName, curControl.sliderPosition.x, curControl.sliderPosition.y);
			curControl.sliderControl.actualValue = curControl.defaultValue;
		}
	}

	public override void ReceiveValues ()
	{
		//base.ReceiveValues ();
	}

	public override void TransferValues ()
	{
		//base.TransferValues ();
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
