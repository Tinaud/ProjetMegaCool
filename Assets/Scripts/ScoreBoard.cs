using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    private int visitors;
    private int cash;
    public Text Cash;
    public Text Visitors;

	// Use this for initialization
	void Start () {

        visitors = 0;
        cash = 15;
	
	}
	
	// Update is called once per frame
	void Update () {

        Cash.text = "Cash: " + cash + " $";
        Visitors.text = "Visitors: " + visitors;
	
	}
}
