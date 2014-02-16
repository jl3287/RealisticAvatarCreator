using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RACBodyType : MonoBehaviour 
{
	private List<RACModifiableControl> modifiableControlsList = new List<RACModifiableControl>();
	
	public bool isFemale = true;

	public List<RACModifiableControl> ControlList 
	{
		get
		{
			if (this.modifiableControlsList.Count == 0)
			{
				RACModifiableControl[] controlsArray = this.GetComponentsInChildren<RACModifiableControl>() as RACModifiableControl[];
				this.modifiableControlsList = controlsArray.ToList();
			}

			return this.modifiableControlsList;
		}

		set{}
	}
}
