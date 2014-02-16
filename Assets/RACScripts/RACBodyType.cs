using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RACBodyType : MonoBehaviour 
{
	[HideInInspector]
	public List<RACModifiableControl> modifiableControls;

	public bool isFemale = true;

	private void Awake()
	{
		RACModifiableControl[] controlsArray = this.GetComponentsInChildren<RACModifiableControl>() as RACModifiableControl[];
		this.modifiableControls = controlsArray.ToList();
	}
}
