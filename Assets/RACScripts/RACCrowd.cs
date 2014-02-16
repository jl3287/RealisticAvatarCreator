using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCrowd : UMACrowd
{
	public RACBodyType bodyTypeOfCrowd;

	private RACCustomization customization;

	private void Awake()
	{		
		this.customization = GameObject.FindObjectOfType(typeof(RACCustomization)) as RACCustomization;
	}

	protected override UMACrowdRandomSet.CrowdRaceData SetGeneratedUMARace (UMA.UMAData.UMARecipe umaRecipe)
	{
		if (bodyTypeOfCrowd.isFemale)
			umaRecipe.SetRace(raceLibrary.GetRace("RACHumanFemale"));
		else
			umaRecipe.SetRace(raceLibrary.GetRace("HumanMale"));

		this.customization.InstanciateNewSliders(bodyTypeOfCrowd.modifiableControls);

		return null;
	}

}
