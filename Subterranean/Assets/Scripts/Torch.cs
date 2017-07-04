using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torch : MonoBehaviour {
    Light light;
    bool light_add=true;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (light_add)
        {
            //light.intensity= light.intensity+1.0f*Time.deltaTime;
            light.intensity = light.intensity + Random.Range(0.5f, 1.0f)*Time.deltaTime;
        }
        else
            //light.intensity= light.intensity - 1.0f*Time.deltaTime;
            light.intensity = light.intensity - Random.Range(0.5f, 1.0f) * Time.deltaTime;
        if (light_add && light.intensity>2)
        {
            light_add = false;
        }
        if(!light_add && light.intensity<1)
        {
            light_add = true;
        }
        
    }
    void FixedUpdate()
    {
        
    }
}
