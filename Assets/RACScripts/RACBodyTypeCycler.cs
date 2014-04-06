using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RACBodyTypeCycler : MonoBehaviour 
{
	private List<RACBodyType> bodyTypeList = new List<RACBodyType>();

	private int bodyTypeIndex = 0;

	[SerializeField]
	private RACCustomization racCustomization;

	// Use this for initialization
	private void Start () 
	{
		RACBodyType[] bodyTypeArray = this.GetComponentsInChildren<RACBodyType>();
		bodyTypeList = bodyTypeArray.ToList();
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			this.bodyTypeIndex = (this.bodyTypeIndex + 1)%this.bodyTypeList.Count;
			this.racCustomization.SetAllSliderValues(this.bodyTypeList[this.bodyTypeIndex].ControlList);
		}
	}


}
