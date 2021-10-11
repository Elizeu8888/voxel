using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public Animator anim;
    Vector2 rotation = Vector2.zero;
    public float speed = 3;


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



       

        if (Input.GetKey("v"))
        {
            anim.SetBool("weapondrawn", true);
        }
        if (Input.GetKey("c"))
        {
            anim.SetBool("weapondrawn", false);
        }

        if (anim.GetBool("weapondrawn") == true && Input.GetKey("f"))
        {
            anim.SetBool("attack", true);
        }
      





        if (Input.GetKey("w"))
        {
            anim.SetFloat("speed", 1);
            DoMove();
        }
        else
        {

            anim.SetFloat("speed", 0);
        }
        rotation.y += Input.GetAxis("Horizontal");
        //rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }


    void DoMove()
    {
        //Vector3 velocity = rb.velocity;
        
        Vector3 v3Force = 7 * transform.forward;
        GetComponent<Rigidbody>().AddForce(v3Force);



    }









}
