﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACCrowd : UMACrowd
{
	private RACCustomization customization;

	private RACBodyTypeCycler bodyTypeCycler;

	private void Awake()
	{		
		this.customization = GameObject.FindObjectOfType(typeof(RACCustomization)) as RACCustomization;
		this.bodyTypeCycler = GameObject.FindObjectOfType(typeof(RACBodyTypeCycler)) as RACBodyTypeCycler;
	}

	protected override UMACrowdRandomSet.CrowdRaceData SetGeneratedUMARace (UMA.UMAData.UMARecipe umaRecipe)
	{
		if (this.bodyTypeCycler != null)
		{
			RACBodyType bodyTypeOfCrowd = this.bodyTypeCycler.GetCurrentlySelectedBodyType();

			if (bodyTypeOfCrowd.isFemale)
				umaRecipe.SetRace(raceLibrary.GetRace("RACHumanFemale"));
			else
				umaRecipe.SetRace(raceLibrary.GetRace("HumanMale"));

			this.customization.InstanciateNewSliders(bodyTypeOfCrowd.ControlList);

			return null;
		}
		else
		{
			return base.SetGeneratedUMARace(umaRecipe);
		}
	}

}
