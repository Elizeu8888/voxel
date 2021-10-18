using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxSpeed = 20f;
    private Rigidbody rb;
    public Animator anim;
    Vector2 rotation = Vector2.zero;
    public float camspeed = 3;
    public float speed = 2;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    public Transform target;
    Vector3 v3Force;


    // Start is called before the first frame update
    void Start()
    {

        anim.SetBool("weapondrawn", false);
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Dojump();
        DoMove();
        

        transform.LookAt(target);
        anim.SetBool("attack", false);
        anim.SetBool("block", false);


        if (Input.GetKey("v"))
        {
            anim.SetBool("weapondrawn", true);
        }
        if (Input.GetKey("c"))
        {
            anim.SetBool("weapondrawn", false);
        }

        if (Input.GetKey("f"))
        {
            anim.SetBool("attack", true);

        }

        if (Input.GetKey("b"))
        {


            anim.SetBool("block", true);

        }



        




        




       // rotation.y += -target.position.x;
        //rotation.x += -Input.GetAxis("Mouse Y");
        //transform.eulerAngles = (Vector2)rotation * camspeed;

    }
    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }


    }

    void Dojump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }




    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void DoMove()
    {

        //Vector3 velocity = rb.velocity;

        if (GetComponent<Rigidbody>().velocity.magnitude > 0.01)
        {
            anim.SetFloat("speed", 1);
            print("ok");
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

        anim.SetFloat("moveX", 0);

        anim.SetFloat("moveZ", 0);

        if (Input.GetKey("w"))
        {

            Vector3 v3Force = speed * transform.forward;
            GetComponent<Rigidbody>().AddForce(v3Force, ForceMode.Impulse);
            anim.SetFloat("moveX", 1);
            anim.SetFloat("speed", 1);
        }



        if (Input.GetKey("s"))
        {

            Vector3 v3Force = speed * -transform.forward;
            GetComponent<Rigidbody>().AddForce(v3Force, ForceMode.Impulse);
            anim.SetFloat("moveX", -1);
            anim.SetFloat("speed", 2);
        }



        if (Input.GetKey("a"))
        {

            Vector3 v3Forceside = speed * -transform.right;
            GetComponent<Rigidbody>().AddForce(v3Forceside, ForceMode.Impulse);
            anim.SetFloat("moveZ", -1);
            anim.SetFloat("speed", 2);
        }


        if (Input.GetKey("d"))
        {

            Vector3 v3Forceside = speed * transform.right;
            GetComponent<Rigidbody>().AddForce(v3Forceside, ForceMode.Impulse);
            anim.SetFloat("moveZ", 1);
            anim.SetFloat("speed", 2);
        }







    }









}
