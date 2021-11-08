using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Scorecounter : MonoBehaviour
{
    public Text MyText;
    
    public int score = Playercontroller.playerscore;

    // Start is called before the first frame update
    void Start()
    {
        MyText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        MyText.text = "" + score;
    }
}
