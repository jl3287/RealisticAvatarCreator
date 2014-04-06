using UnityEngine;
using System.Collections;

public class RACPopupList : MonoBehaviour {

	public int xPos = 0;
	public int yPos = 0;

	// Use this for initialization
	void OnGUI () 
	{

		bool showList = true;
		int entities = 3;

		GUIContent newContent = new GUIContent("Top Thing");
		GUIContent[] contentList = new GUIContent[3];
		contentList[0] = new GUIContent("Thing 1");
		contentList[1] = new GUIContent("Thing 2");
		contentList[2] = new GUIContent("Thing 3");
		contentList[2] = new GUIContent("Thing 4");
		GUIStyle newStyle = new GUIStyle();

		PopupList.List(
			new Rect(xPos, yPos, 200, 20),
			ref showList,
			ref entities,
			newContent,
			contentList,
			newStyle);
	}

	private void ListCallback()
	{
		Debug.Log("List callback executed");
	}
}
