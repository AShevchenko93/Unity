using UnityEngine;
using System.Collections;

public class TimeDay : MonoBehaviour {
	Light time;
	// Update is called once per frame
	void Update () {
		time = GetComponent<Light> ();
		time.transform.RotateAround (transform.position, Vector3.right, 1.0f);
	
	}
}
