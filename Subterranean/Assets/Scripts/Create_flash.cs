using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_flash : MonoBehaviour {
    public GameObject flash;
    public int flash_number;
    bool player_enter;
    public Vector3 position;
	// Use this for initialization
	void Start () {
        player_enter = false;
	}

    void OnTriggerEnter(Collider Who)
    {
        if (Who.gameObject.tag == "Player")
        {
            for(int i = 0; i < flash_number; i++)
            {
                GameObject new_flash = Instantiate<GameObject>(flash);
                //new_flash.transform.position = position + transform.position.x Random.Range(-1.0f,1.0f);
                new_flash.transform.position = new Vector3(position.x + Random.Range(-1.0f, 1.0f),position.y+Random.Range(-0.5f,0.5f),position.z);
            }
        }
    }
}
