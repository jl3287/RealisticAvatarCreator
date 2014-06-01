using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACAverageDeviation : MonoBehaviour 
{
	[SerializeField]
	private GUIText label;

	private RACCustomization racCustomization;

	// Use this for initialization
	void Start () 
	{
		this.racCustomization = GameObject.FindObjectOfType(typeof(RACCustomization)) as RACCustomization;
	}
	
	// Update is called once per frame
	void Update () 
	{
		List<RACModifiableControl> controlList = this.racCustomization.ControlList;
		float totalDeviation = 0;
		for (int iControlIndex = 0; iControlIndex < controlList.Count; ++iControlIndex)
		{
			totalDeviation += controlList[iControlIndex].GetDeviation();
		}
		totalDeviation /= controlList.Count;

		label.text = totalDeviation.ToString();
	}
}
