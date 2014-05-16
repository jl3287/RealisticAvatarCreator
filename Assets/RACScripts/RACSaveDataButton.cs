using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACSaveDataButton : MonoBehaviour 
{
	//Numbers in percent of screen space
	[Range(0, 1)]
	public float buttonXPos = 0;
	[Range(0, 1)]
	public float buttonYPos = 0;
	
	[Range(0, 1)]
	public float buttonWidth = 0.1f;
	[Range(0, 1)]
	public float buttonHeight = 0.01f;

	public RACCustomization racCustomization;

	public string fileSaveName = "Sliders";

	public GUIStyle guiStyle;

	// Use this for initialization
	private void OnGUI () 
	{
		if(GUI.Button(new Rect(buttonXPos*Screen.width, buttonYPos*Screen.height, buttonWidth*Screen.width, buttonHeight*Screen.height), "Save Sliders", this.guiStyle)) 
		{
			SaveSliders();
		}
	}

	private void SaveSliders()
	{
		List<RACModifiableControl> allControls = racCustomization.ControlList;

		string fileOutputString = "Slider Name\t" + "SliderValue\t" + "HoverTime\n";
		for (int iSliderIndex = 0; iSliderIndex < allControls.Count; ++iSliderIndex)		
		{
			RACModifiableControl control = allControls[iSliderIndex];

			RACSliderControl sliderControlAsRAC = control.sliderControl as RACSliderControl;

			string sliderName = control.sliderName;
			string sliderValue = sliderControlAsRAC.actualValue.ToString();
			string sliderMouseOverTime = sliderControlAsRAC.MousedOverTime.ToString();

			fileOutputString += sliderName + "\t" + sliderValue + "\t" + sliderMouseOverTime + "\n";
		}

		string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");

		System.IO.File.WriteAllText(Application.dataPath + @"\RACSliderOutputs\" + this.fileSaveName + "-" + date + ".txt", fileOutputString);
	}

}
