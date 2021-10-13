using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralook : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float speed = 2;
    //public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);
        rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;

    }








}
