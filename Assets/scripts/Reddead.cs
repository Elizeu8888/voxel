using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagment;

public class Reddead : MonoBehaviour
{
    public GameObject player;
    public Transform playerpos;
    public Collider other;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel(Application.loadedLevel);
            print("ggg");
            //Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        
    }



}
