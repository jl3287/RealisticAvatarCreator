using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACSaveDataButton : MonoBehaviour 
{
	public int buttonXPos = 0;
	public int buttonYPos = 0;

	public RACCustomization racCustomization;

	public string fileSaveName = "Sliders";

	// Use this for initialization
	private void OnGUI () 
	{
		if(GUI.Button(new Rect(buttonXPos, buttonYPos, 100, 20), "Save Sliders")) 
		{
			SaveSliders();
		}
	}

	private void SaveSliders()
	{
		List<RACModifiableControl> allControls = racCustomization.ControlList;

		string fileOutputString = "Slider Name\tSliderValue\n";
		for (int iSliderIndex = 0; iSliderIndex < allControls.Count; ++iSliderIndex)		
		{
			RACModifiableControl control = allControls[iSliderIndex];

			string sliderName = control.sliderName;
			string sliderValue = control.sliderControl.actualValue.ToString();

			fileOutputString += sliderName + "\t" + sliderValue + "\n";
		}

		string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");

		System.IO.File.WriteAllText(Application.dataPath + @"\RACSliderOutputs\" + this.fileSaveName + "-" + date + ".txt", fileOutputString);
	}

}
