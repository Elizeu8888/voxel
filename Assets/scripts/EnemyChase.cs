using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform playercheck;
    public float chaserange = 0.4f;
    public LayerMask layertarget;

    public Transform target;

    bool playerinrange;
    public Transform gunslot;
    public Rigidbody rocketprefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerinrange = Physics.CheckSphere(playercheck.position, chaserange, layertarget);



        transform.LookAt(target);

        if (playerinrange)
        {
            Rigidbody rocketinstance;
            rocketinstance = Instantiate(rocketprefab, gunslot.position, gunslot.rotation) as Rigidbody;
            rocketinstance.AddForce(gunslot.forward * 1000);
        }

    }
}
