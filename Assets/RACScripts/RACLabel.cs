using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACLabel : MonoBehaviour 
{
	[Range(0, 1)]
	public float buttonXPos = 0;
	
	[Range(0, 1)]
	public float buttonYPos = 0;

	public int width = 200;
	public int height = 200;

	public string text = "text";

	public GUIStyle guiStyle;

	// Use this for initialization
	private void OnGUI () 
	{
		GUIStyle newStyle = guiStyle;
		GUI.Label(new Rect(this.buttonXPos*Screen.width, this.buttonYPos*Screen.height, this.width, this.height), this.text, newStyle);
	}
}
