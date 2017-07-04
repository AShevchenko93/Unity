using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	public List<Item> list;
	public GameObject inventory;
	public GameObject container;
	public AnimatorController controller;
	bool visible;
	public string []names=new string[5];
	public Item []inv=new Item[16];
	// Use this for initialization
	void Start () {
		list=new List<Item>();
		controller = GetComponent<AnimatorController> ();
		Screen.lockCursor = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (1)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			//Ray ray = Camera.main.ScreenPointToRay (Vector3.forward*3f);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Item item = hit.collider.GetComponent<Item> ();
				if (item != null) {
					list.Add (item);
					names [list.Count-1] = item.name;
					Destroy (hit.collider.gameObject);
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.I)) {
			if (inventory.activeSelf) {
				Screen.lockCursor = true;
				inventory.SetActive (false);
				for (int i = 0; i < inventory.transform.childCount; i++) {
					if (inventory.transform.GetChild (i).transform.childCount>0) {
						Destroy (inventory.transform.GetChild (i).transform.GetChild(0).gameObject);
					}
				}
			} else {
				Screen.lockCursor = false;
				inventory.SetActive (true);
				int count = list.Count;
				for (int i = 0; i < count; i++) {
					
					Item it = list [i];
					if (inventory.transform.childCount >= i) {
						GameObject img = Instantiate (container);
						img.transform.SetParent (inventory.transform.GetChild (i).transform);
						img.GetComponent<Image> ().sprite = Resources.Load<Sprite>(it.sprite);
						img.GetComponent<Drag> ().item = it;
					}
					else break;
				}
			}
		}
	}
	void remove(Drag drag){
		Item it = drag.item;
		//it.name = "заработало";
		GameObject newo = Instantiate<GameObject> (Resources.Load<GameObject> (it.prefabs));
		newo.transform.position = transform.position + transform.forward + transform.up;

		//newo.name = "заработало";
		Destroy (drag.gameObject);
		list.Remove (it);
	}
	void use(Drag drag){
		if (drag.item.type == "hand") {
			HandItem myitem = Instantiate<GameObject> (Resources.Load<GameObject> (drag.item.prefabs)).GetComponent<HandItem>();
			controller.addHand (myitem);
			list.Remove (drag.item);
			Destroy (drag.gameObject);
		}
	}

}
