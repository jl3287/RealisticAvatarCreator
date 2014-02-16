using UnityEngine;
using System.Collections;
using UMA;
using System.Collections.Generic;

public class RACHumanFemaleDNAConverterBehaviour : HumanFemaleDNAConverterBehaviour
{    
	private static RACCustomization customisation = null;

	public RACHumanFemaleDNAConverterBehaviour()
	{
		this.ApplyDnaAction = UpdateRACFemaleDNABones;
		this.DNAType = typeof(UMADnaHumanoid);
	}

	public static void UpdateRACFemaleDNABones (UMAData umaData, UMASkeleton skeleton)
	{
		if (RACHumanFemaleDNAConverterBehaviour.customisation == null)
			RACHumanFemaleDNAConverterBehaviour.customisation = GameObject.FindObjectOfType(typeof(RACCustomization)) as RACCustomization;

		HumanFemaleDNAConverterBehaviour.UpdateUMAFemaleDNABones (umaData, skeleton);

		List<RACModifiableControl> controls = RACHumanFemaleDNAConverterBehaviour.customisation.modifiableControlList;

		for (int iSliderIndex = 0; iSliderIndex < controls.Count; ++iSliderIndex)		
		{
			RACModifiableControl curControl = controls[iSliderIndex];

			int skeletonStringToHash = UMASkeleton.StringToHash(curControl.modifiedBodyPart);

			//Get the starting information
			Vector3 startingInformation = Vector3.zero;
			if (curControl.sliderStyle == RACModifiableControl.SliderStyle.POSITION)
			{
				startingInformation = skeleton.GetPosition(skeletonStringToHash);

				//Modify it
				if (curControl.effectsX)
					startingInformation.x += curControl.sliderControl.actualValue;
				if (curControl.effectsY)
					startingInformation.y += curControl.sliderControl.actualValue;
				if (curControl.effectsZ)
					startingInformation.z += curControl.sliderControl.actualValue;
				
				skeleton.SetPosition(skeletonStringToHash, startingInformation);
			}
			else if (curControl.sliderStyle == RACModifiableControl.SliderStyle.SCALE)
			{
				startingInformation = skeleton.GetScale(skeletonStringToHash);
				
				//Modify it
				if (curControl.effectsX)
					startingInformation.x = curControl.sliderControl.actualValue;
				if (curControl.effectsY)
					startingInformation.y = curControl.sliderControl.actualValue;
				if (curControl.effectsZ)
					startingInformation.z = curControl.sliderControl.actualValue;

				skeleton.SetScale(skeletonStringToHash, startingInformation);
			}
		}
	}
}
