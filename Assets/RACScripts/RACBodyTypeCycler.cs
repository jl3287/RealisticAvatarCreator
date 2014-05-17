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

	[SerializeField]
	private RACLabel bodyTypeLabel;

	// Use this for initialization
	private void Start () 
	{
		RACBodyType[] bodyTypeArray = this.GetComponentsInChildren<RACBodyType>();
		bodyTypeList = bodyTypeArray.ToList();

		//Set the starting label
		RACBodyType selectedType = this.bodyTypeList[this.bodyTypeIndex];
		this.bodyTypeLabel.UpdateLabel(selectedType.name);
	}
	
	// Update is called once per frame
	private void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			this.bodyTypeIndex = (this.bodyTypeIndex + 1)%this.bodyTypeList.Count;
			RACBodyType selectedType = this.bodyTypeList[this.bodyTypeIndex];
			this.racCustomization.SetAllSliderValues(selectedType.ControlList);

			this.bodyTypeLabel.UpdateLabel(selectedType.name);
		}
	}

	public RACBodyType GetCurrentlySelectedBodyType()
	{
		return this.bodyTypeList[this.bodyTypeIndex];
	}


}
