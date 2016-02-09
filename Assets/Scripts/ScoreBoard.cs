using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public bool playersSet = false;
    private int visitors;
    private int cash;
    public List<ParcManager> playerlist = new List<ParcManager>();
    public Text Cash;
    public Text Visitors;
    public int player;

    void OnEnable()
    {
        setPlayerList();
    }

	void Update () 
    {
        if (playersSet)
        {
            cash = playerlist[player].cash;
            visitors = playerlist[player].visitors;

            Cash.text = "Cash: " + cash + " $";
            Visitors.text = "Visitors: " + visitors;
        }
	}

    void setPlayerList()
    {
        playerlist = Camera.main.GetComponent<GameManager>().getPlayers();
        playersSet = true;
    }
}