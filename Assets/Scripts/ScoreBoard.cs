using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    private int visitors;
    private int cash;
    List<ParcManager> playerlist = new List<ParcManager>();
    public Text Cash;
    public Text Visitors;
    public int player;


	// Use this for initialization
	void Start () {
        Debug.Log("scoreboard");
        playerlist = Camera.main.GetComponent<GameManager>().getPlayers();
	
	}
	
	// Update is called once per frame
	void Update () {

        cash = playerlist[player].cash;
        visitors = playerlist[player].visitors;
        Cash.text = "Cash: " + cash + " $";
        Visitors.text = "Visitors: " + visitors;
	
	}
}
