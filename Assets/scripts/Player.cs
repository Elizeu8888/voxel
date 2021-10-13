using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public Animator anim;
    Vector2 rotation = Vector2.zero;
    public float speed = 3;

    Vector3 v3Force;


    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("weapondrawn", false);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", 0);


        anim.SetBool("attack", false);


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

        DoMove();




        rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }


    void DoMove()
    {
        //Vector3 velocity = rb.velocity;


        anim.SetFloat("moveX", 0);
        anim.SetFloat("speed", 0);
        anim.SetFloat("moveZ", 0);

        if (Input.GetKey("w"))
        {

            Vector3 v3Force = 5 * transform.forward;
            GetComponent<Rigidbody>().AddForce(v3Force);
            anim.SetFloat("moveX", 1);
            anim.SetFloat("speed", 1);
        }



        if (Input.GetKey("s"))
        {

            Vector3 v3Force = 5 * -transform.forward;
            GetComponent<Rigidbody>().AddForce(v3Force);
            anim.SetFloat("moveX", -1);
            anim.SetFloat("speed", 2);
        }



        if (Input.GetKey("a"))
        {

            Vector3 v3Forceside = 5 * -transform.right;
            GetComponent<Rigidbody>().AddForce(v3Forceside);
            anim.SetFloat("moveZ", -1);
            anim.SetFloat("speed", 2);
        }


        if (Input.GetKey("d"))
        {

            Vector3 v3Forceside = 5 * transform.right;
            GetComponent<Rigidbody>().AddForce(v3Forceside);
            anim.SetFloat("moveZ", 1);
            anim.SetFloat("speed", 2);
        }







    }









}
