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

		List<RACModifiableControl> controls = RACHumanFemaleDNAConverterBehaviour.customisation.ControlList;

		for (int iSliderIndex = 0; iSliderIndex < controls.Count; ++iSliderIndex)		
		{
			RACModifiableControl curControl = controls[iSliderIndex];

			for (int iBodyPartIndex = 0; iBodyPartIndex < curControl.modifiedBodyParts.Length; ++iBodyPartIndex)
			{
				int skeletonStringToHash = UMASkeleton.StringToHash(curControl.modifiedBodyParts[iBodyPartIndex]);

				//Get the starting information
				Vector3 startingInformation = Vector3.zero;
				if (curControl.sliderStyle == RACModifiableControl.SliderStyle.POSITION)
				{
					startingInformation = skeleton.GetPosition(skeletonStringToHash);

					Vector3 scale = skeleton.GetScale(skeletonStringToHash);
					

					//Modify it
					if (curControl.effectsX)
						startingInformation.x += curControl.sliderControl.actualValue*(1/scale.x);
					if (curControl.effectsY)
						startingInformation.y += curControl.sliderControl.actualValue*(1/scale.y);
					if (curControl.effectsZ)
						startingInformation.z += curControl.sliderControl.actualValue*(1/scale.z);
					
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
}
