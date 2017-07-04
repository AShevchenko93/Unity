using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    CharacterController controller;
    Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 10.0f;
    public float speed = 3.0f;
    float speedJump = 4.0f;
    public float run_speed = 0.0f;
    public GameObject stairs;
    bool this_stairs = false;
    bool start_stairs = false;
    bool first_step = true;
    bool exit_stairs = false;
    float timer = 0;
    bool exit2 = false;
    

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if(!start_stairs)
        {
            Control_controller();
        }
        else
        {
            stairs_controller();
        }
        
        //animator.SetBool("walk", true);
                
    }
    void OnTriggerStay(Collider cube)
    {
        if(stairs.GetComponent<Collider>() == cube)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("Stairs", true);
                start_stairs = true;
                GameObject ob;
                ob = GameObject.Find("stairs");
                controller.transform.SetParent(ob.transform);
                controller.transform.localRotation = Quaternion.Euler(new Vector3(-90, -180, 90));
                controller.transform.localScale = new Vector3(0.0244f, 0.326f, 0.326f);
                
                //controller.transform.rotation = Quaternion.Euler(new Vector3(-90, -180, 90));


            }
        }
    }
    void stairs_controller()
    {
        AnimatorStateInfo state_info = animator.GetCurrentAnimatorStateInfo(0);
        animator.SetBool("walk", false);
        if (state_info.nameHash == Animator.StringToHash("Base Layer.Embark_on_a_stairs"))
        {

        }
        else if(!this_stairs == !exit_stairs)
        {
            animator.SetBool("Stairs", false);
            controller.transform.localPosition = new Vector3(-4.757f, -0.126f, 0);
            this_stairs = true;
        }
        if (this_stairs)
        {
            animator.SetBool("Climb", true);
            controller.transform.position = transform.position + transform.TransformVector(new Vector3(0.0f, 0.8f, 0.0f)) * Time.deltaTime;
        }
        if(state_info.nameHash == Animator.StringToHash("Base Layer.Get_off_the_stairs"))
        {
            timer += Time.deltaTime;
            if(timer<0.5f)
            {
                controller.transform.position = transform.position + transform.TransformVector(new Vector3(0.0f, 0.8f, 0.0f))*Time.deltaTime;
            }else if(timer>0.5f)
            {
                controller.transform.position = transform.position + transform.TransformVector(new Vector3(-1.8f, 0.0f, 0.0f)) * Time.deltaTime;
            }
        }else if(exit_stairs && !exit2)
        {
            timer = 0;
            exit2 = true;
        }
        if(exit2)
        {
            timer += Time.deltaTime;
            if(timer>2.5f)
            {
                controller.transform.localPosition = new Vector3(-0.161f, -0.126f, -0.0216f);
                controller.transform.SetParent(null);
                start_stairs = false;
            }
        }
       
    }
    void Control_controller()
    {
        transform.Rotate(0f, Input.GetAxis("Mouse X"), 0f);
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y"), 0f, 0f);
        if (controller.isGrounded)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Vertical") != 0)
                {
                    animator.SetBool("walk", true);
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        if (run_speed < 1.0f)
                        {
                            run_speed += 0.5f * Time.deltaTime;
                        }
                        else
                        {
                            run_speed = 1.0f;
                        }
                        if (speed < 5.5f)
                        {
                            speed += 1.25f * Time.deltaTime;
                        }
                        else
                        {
                            speed = 5.5f;
                        }
                        animator.SetFloat("Run", run_speed);
                    }
                    else
                    {
                        if (run_speed > 0.0f)
                        {
                            run_speed -= 0.5f * Time.deltaTime;
                        }
                        else
                        {
                            run_speed = 0.0f;
                        }
                        if (speed > 3.0f)
                        {
                            speed -= 1.25f * Time.deltaTime;
                        }
                        else
                        {
                            speed = 3.0f;
                        }
                        animator.SetFloat("Run", run_speed);
                    }
                }
            }
            else
            {
                run_speed = 0.0f;
                speed = 3.0f;
                animator.SetBool("walk", false);
            }
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = speedJump;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
    void OnTriggerEnter(Collider who)
    {
        if(GameObject.Find("Exit_stairs").GetComponent<Collider>() == who)
        {
            
            animator.SetBool("Climb", false);
            this_stairs = false;
            exit_stairs = true;
        }
    }
}
