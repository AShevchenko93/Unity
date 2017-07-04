using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public string name;
	public string type;
	public string sprite;
	public string prefabs;
	bool visible;


	void OnMouseOver(){
		visible = true;
	}
	void OnMouseExit(){
		visible = false;
	}
	void OnGUI(){
		if (visible) {
			GUI.color = Color.blue;
			GUI.Label (new Rect (Input.mousePosition.x+20, Screen.height - Input.mousePosition.y, 200, 80), name);
		}
	}
}
