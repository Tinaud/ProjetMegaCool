using UnityEngine;
using System.Collections;

public class MenuPlayers : MonoBehaviour {

    public int NbPlayer, NbTurns;
    float X, Y, Z;
    public bool playable;
    public float patate;
    public GameObject play;
    public GameObject menu;
    public GameObject option;
    public GameObject score1;
    public GameObject score2;
    public GameObject score3;
    public GameObject score4;
    public GameObject players2;
    public GameObject players3;
    public GameObject players4;
    public GameObject turns10;
    public GameObject turns15;
    public GameObject turns20;
    public GameObject topTable;
    public GameObject gameInterface;
    public Camera mainCamera;
    public BoardManager boardManager; 

	// Use this for initialization
	void Start () {
		NbPlayer = 0;
		NbTurns = 0	;
        playable = false;
        patate = 40F;
        X = 0F;
        Y = 0F;
        Z = 0F;
        topTable.SetActive(true);
        menu.SetActive(true);
        score1.SetActive(false);
        score2.SetActive(false);
        score3.SetActive(false);
        score4.SetActive(false);
        gameInterface.SetActive(false);
        play.SetActive(false);
        option.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (NbPlayer != 0 && NbTurns != 0)
			play.SetActive(true);
        if (playable)
        {
            mainCamera.transform.Rotate(Vector3.right * patate * Time.deltaTime);
            if (mainCamera.transform.rotation.x >= .7)
            {
                playable = false;
                gameInterface.SetActive(true);
            }
            if (X > -1F){
                X += -1F;
                Y += 28F;
                Z += -1.67F;
                mainCamera.transform.position = new Vector3(X, Y, Z);
            }
            switch (NbPlayer)
            {
                case 4: score4.SetActive(true); goto case 3;
                case 3: score3.SetActive(true); goto case 2;
                case 2: score2.SetActive(true); goto case 1;
                case 1: score1.SetActive(true);
                break;
            }
        }
			
	}

	public void player2 ()	{
		NbPlayer = 2;
        players2.SetActive(true);
        players3.SetActive(false);
        players4.SetActive(false);
		Debug.Log("2 players");
        //boardManager.nbPlayers = 2;
	}

	public void player3 ()	{
        NbPlayer = 3;
        players2.SetActive(false);
        players3.SetActive(true);
        players4.SetActive(false);
        Debug.Log("3 players");
        //boardManager.nbPlayers = 3;
    }

	public void player4 ()	{
        NbPlayer = 4;
        players2.SetActive(false);
        players3.SetActive(false);
        players4.SetActive(true);
        Debug.Log("4 players");
        //boardManager.nbPlayers =4 ;
    }

	public void turn10 ()	{
        NbTurns = 10;
        turns10.SetActive(true);
        turns15.SetActive(false);
        turns20.SetActive(false);
        Debug.Log("10 turns");
	}

	public void turn15 ()	{
        NbTurns = 15;
        turns10.SetActive(false);
        turns15.SetActive(true);
        turns20.SetActive(false);
        Debug.Log("15 turns");
	}

	public void turn20 ()	{
        NbTurns = 20;
        turns10.SetActive(false);
        turns15.SetActive(false);
        turns20.SetActive(true);
        Debug.Log("20 turns");
	}

    public void PlayButton ()    {
        topTable.SetActive(false);
        playable = true;
        Debug.Log("rotation863");
    }

    public void optionsmenu()
    {
        menu.SetActive(false);
        option.SetActive(true);
    }

    public void backbutton()
    {
        menu.SetActive(true);
        option.SetActive(false);
    }
}