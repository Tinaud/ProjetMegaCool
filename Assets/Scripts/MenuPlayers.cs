using UnityEngine;
using System.Collections;

public class MenuPlayers : MonoBehaviour {

	public int NbPlayer = 0;
	public int NbTurns = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void player2 ()	{
		NbPlayer = 2;
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