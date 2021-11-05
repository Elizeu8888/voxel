using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform playercheck;
    public float chaserange = 20f;
    public LayerMask layertarget;

    public Transform target;
    
    bool playerinrange;
    public Transform gunslot;
    public Rigidbody rocketprefab;
    public float timer = 10f;
    GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        




        transform.LookAt(target);

        if (playerinrange)
        {
            if (timer <= 1f)
            {
                Rigidbody rocketinstance;
                rocketinstance = Instantiate(rocketprefab, gunslot.position, gunslot.rotation) as Rigidbody;
                rocketinstance.AddForce(gunslot.forward * 3000);
                timer = 10f;
            }

        }timer--;



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerinrange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerinrange = false;
        }
    }




}
