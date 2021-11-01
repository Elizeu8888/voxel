using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnsmoothing = 0.1f;
    float turnsmoothvelocity = 0.5f;


    public float gravity = -9.81f;
    public float jumpheight = 5f;

    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;

    bool isgrounded;
    Vector3 velocity;
    public Animator anim;

    void start()
    {
        //anim = GetComponent<Animator>();
    }


    void Update()
    {


        anim.SetBool("grounded", false);

        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);

        if (!isgrounded)
        {
            anim.SetBool("grounded", false);
        }
        if (isgrounded)
        {
            anim.SetBool("grounded", true);
        }



        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -13f;
        }



        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;




        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        if (direction.magnitude >= 0.1f)
        {


            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvelocity, turnsmoothing);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            print("ooo");
            Vector3 movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized * speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }


        if (Input.GetKey("space") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }




        anim.SetBool("walking", false);




        if ((GetComponent<Rigidbody>().velocity.magnitude > 0.5) && isgrounded)
        {
            anim.SetBool("walking", true);

        }
        else
        {
            anim.SetBool("walking", false);
        }











    }

    void OnCollisionEnter()
    {

    }

    void FixedUpdate()
    {


    }
}
