using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_off : MonoBehaviour {
    int room=0;
    bool changed = false;
    public int zone_id;
    public GameObject torches;
    public Transform[] child;

	// Use this for initialization
	void Start () {
        child = new Transform[torches.transform.childCount];
        int i = 0;
        foreach(Transform t in torches.transform)
        {
            child[i++] = t;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		if(changed)
        {
            changed = false;
            if(room == 1)
            {
                for(int i=0;i<child.Length;i++)
                {
                    if(child[i].GetComponent<Torch_id>().room == "room1")
                    {
                        child[i].gameObject.SetActive(!child[i].gameObject.activeSelf);
                    }                   
                    if(child[i].GetComponent<Torch_id>().room == "room2")
                    {
                        child[i].gameObject.SetActive(!child[i].gameObject.activeSelf);
                    }
                }
            }
            if(room == 2)
            {
                for(int i=0;i<child.Length;i++)
                {
                    if(child[i].GetComponent<Torch_id>().room == "room3")
                    {
                        child[i].gameObject.SetActive(!child[i].gameObject.activeSelf);
                    }
                }
            }
            if(room == 3)
            {
                for(int i = 0; i < child.Length; i++)
                {
                     if(child[i].GetComponent<Torch_id>().room == "room1")
                    {
                        child[i].gameObject.SetActive(false);
                    }
                }
            }
        }
        
	}
    void OnTriggerEnter(Collider Who)
    {
        if(Who.gameObject.tag=="Player")
        {
            room = zone_id;
            changed = true;
        }
    }
}
