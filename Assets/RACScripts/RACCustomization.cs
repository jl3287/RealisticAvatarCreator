using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCustomization : UMACustomization 
{
	private List<RACModifiableControl> modifiableControlList = new List<RACModifiableControl>();
	private Dictionary<string, RACModifiableControl> modifiableControlDict = new Dictionary<string, RACModifiableControl>();

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
		this.modifiableControlDict = new Dictionary<string, RACModifiableControl>();
		
		//Use new sliders
		for (int iSliderIndex = 0; iSliderIndex < this.modifiableControlList.Count; ++iSliderIndex)		
		{
			RACModifiableControl curControl = this.modifiableControlList[iSliderIndex];
			curControl.sliderControl = InstantiateSlider(curControl.sliderName, curControl.sliderPosition.x, curControl.sliderPosition.y);
			curControl.sliderControl.actualValue = curControl.DefaultValue;
			curControl.sliderControl.minValue = curControl.minValue;
			curControl.sliderControl.maxValue = curControl.maxValue;
			curControl.StartingValue = curControl.DefaultValue;

			this.modifiableControlDict.Add(curControl.sliderName, curControl);
		}
	}
	
	public void SetAllSliderValues(List<RACModifiableControl> bodyTypeDefaultValueControlList)
	{
		//Use new sliders
		for (int iSliderIndex = 0; iSliderIndex < bodyTypeDefaultValueControlList.Count; ++iSliderIndex)		
		{
			RACModifiableControl newControlForValues = bodyTypeDefaultValueControlList[iSliderIndex];

			if (this.modifiableControlDict.ContainsKey(newControlForValues.sliderName))
			{
				RACModifiableControl curControl = this.modifiableControlDict[newControlForValues.sliderName];
				curControl.sliderControl.actualValue = newControlForValues.DefaultValue;
				curControl.sliderControl.minValue = newControlForValues.minValue;
				curControl.sliderControl.maxValue = newControlForValues.maxValue;
				curControl.StartingValue = newControlForValues.DefaultValue;
			}
			else
			{
				Debug.LogError("We're switching to a body with a slider named '" + newControlForValues.sliderName + "', but don't have that slider on our current body type.");
			}
		}

		UpdateUMAShape();
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
