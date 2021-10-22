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
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerinrange = Physics.CheckSphere(playercheck.position, chaserange, layertarget);



        transform.LookAt(target);



    }
}
