using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;

    Vector2 rotation = Vector2.zero;
    public float speed = 3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown("w"))
        {
            DoMove();
        }
        rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }


    void DoMove()
    {
        Vector3 velocity = rb.velocity;

        Vector3 v3Force = 10 * transform.forward;
        GetComponent<Rigidbody>().AddForce(v3Force);



    }









}
