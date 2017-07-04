using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_create : MonoBehaviour {
    public GameObject arrows;
    float create_time = 0;
    bool first = true;
    GameObject arrow;
    GameObject player;
    Vector3 position;
    public int power;
    // Use this for initialization
    void Start () {
        arrow = Instantiate<GameObject>(arrows);
        arrow.transform.position = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        create_time += Time.deltaTime;
        if(create_time>1 && first)
        {
            first = false;
            arrow.AddComponent<Rigidbody>();
            //arrow.GetComponent<Rigidbody>().AddForceAtPosition(transform.right*power, new Vector3(position.x + Random.Range(-0.5f, 0.5f), position.y + Random.Range(-0.5f, 0.5f), position.z + Random.Range(-0.5f, 0.5f)), ForceMode.Impulse);
            arrow.transform.LookAt(new Vector3(position.x + Random.Range(-0.5f, 0.5f), position.y + Random.Range(-0.5f, 0.5f), position.z + Random.Range(-0.5f, 0.5f)));
            arrow.GetComponent<Rigidbody>().AddRelativeForce(-transform.right * power,ForceMode.Impulse);
        }
        if (create_time > 5)
        {
            Destroy(arrow);
            Destroy(gameObject);
        }
    }
}
