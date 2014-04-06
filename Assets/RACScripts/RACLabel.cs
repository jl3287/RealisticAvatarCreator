using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACLabel : MonoBehaviour 
{
	public int buttonXPos = 0;
	public int buttonYPos = 0;

	public int width = 20;
	public int height = 20;

	public string text = "text";

	// Use this for initialization
	private void OnGUI () 
	{
		GUI.Label(new Rect(buttonXPos, buttonYPos, 100, 20), this.text);
	}
}
