using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RACLabel : MonoBehaviour 
{
	[Range(0, 1)]
	public float buttonXPos = 0;

	[HideInInspector]
	[Range(0, 1)]
	public float buttonYPos = 0;

	public int width = 200;
	public int height = 200;

	private string text = "text";

	public GUIStyle guiStyle;

	[Range(0, 1)]
	public float textAlphaColor = 1.0f;

	// Use this for initialization
	private void OnGUI () 
	{
		GUIStyle newStyle = guiStyle;
		Color newColor = newStyle.normal.textColor;
		newColor.a = this.textAlphaColor;
		newStyle.normal.textColor = newColor;
		GUI.Label(new Rect(this.buttonXPos*Screen.width, this.buttonYPos*Screen.height, this.width, this.height), this.text, newStyle);
	}

	public void UpdateLabel(string newText)
	{
		this.text = newText;
		this.animation.Play();
	}
}
