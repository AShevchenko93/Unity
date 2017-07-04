using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimatorController : MonoBehaviour {

	public float speed = 3.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public bool fly=false;
	private Vector3 moveDirection = Vector3.zero;
	Animator animator;
	CharacterController controller;
	public float speedAnimetion=-1f;
	public float rotate = 0f;
	public float falltime=0f;
	public Transform rHand;
	private HandItem item;
	private CharacterStats stats;



	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
		stats = GetComponent<CharacterStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0f,Input.GetAxis ("Mouse X") * speed,0f);
		Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y"),0f,0f);

		if (controller.isGrounded) 
			{
			fly = false;
			if (falltime > 1) {
				stats.healthValue-=(int) (10*falltime);
			}
			falltime=0f;
			if(Input.GetAxis ("Vertical")!=0)
			{
				animator.SetBool ("walk", true);
				animator.SetFloat("speed",speedAnimetion);
				animator.SetFloat("rotate",rotate);
				if(Input.GetKey(KeyCode.LeftShift) && stats.enduranceValue >0)
				{
					speed+=1.5f*Time.deltaTime;
					speedAnimetion+=1f*Time.deltaTime;
					stats.enduranceValue-=10*Time.deltaTime;

					if(speed>6f)
					{
						speed=6f;
					}
					if(speedAnimetion>1f)
					{
						speedAnimetion=1f;
					}
					if(stats.enduranceValue<0)
					{
						stats.enduranceValue=0;
					}

				}else
				{
					speed-=1.5f*Time.deltaTime;
					speedAnimetion-=1f*Time.deltaTime;
					if(speed<3f)
					{
						speed=3f;
					}
					if(speedAnimetion<-1f)
					{
						speedAnimetion=-1;
					}
				}
			}else
			{
				animator.SetBool("walk",false);
			}


			
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump") && stats.enduranceValue>20) {
				moveDirection.y = jumpSpeed;
				stats.enduranceValue -= 20;
			}

			
		} else
			fly = true;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
		falltime += Time.deltaTime;

	}

	public void addHand(HandItem it){
		if (item != null) {
			item.transform.SetParent (null);
			item.gameObject.AddComponent<Rigidbody> ();
		}
		it.transform.SetParent (rHand);
		it.transform.localPosition = it.position;
		it.transform.localRotation = Quaternion.Euler (it.Rotation);
		Destroy (it.GetComponent<Rigidbody> ());
		item = it;
	}
}
