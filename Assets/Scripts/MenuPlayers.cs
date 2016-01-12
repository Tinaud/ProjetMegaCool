using UnityEngine;
using System.Collections;

public class MenuPlayers : MonoBehaviour {

	public int NbPlayer;
	public int NbTurns;
	public GameObject play;

	// Use this for initialization
	void Start () {
		NbPlayer = 0;
		NbTurns = 0	;
	}
	
	// Update is called once per frame
	void Update () {
		if (NbPlayer != 0 && NbTurns != 0)
			play.SetActive(true);
			
	}

	public void player2 ()	{
		NbPlayer = 2;
		Debug.Log("2 players");
	}

	public void player3 ()	{
		NbPlayer = 3;
	}

	public void player4 ()	{
		NbPlayer = 4;
	}

	public void turns10 ()	{
		NbTurns = 10;
	}

	public void turns15 ()	{
		NbTurns = 15;
	}

	public void turns20 ()	{
		NbTurns = 20;
	}
}