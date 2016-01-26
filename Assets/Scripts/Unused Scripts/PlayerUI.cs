using UnityEngine;
using System.Collections;

public class PlayerUI : MonoBehaviour {
    public PlayBouton InfoMenu;
    public GameObject Box;
    public GameObject Jeton;
    public int nbPlayers;
    private PlayerInfo Red, Green, Blue, Yellow;

    // Use this for initialization
    void Start () {
        //Info = GetComponent<GUIText>();
        InfoMenu.GetComponent<PlayBouton>();
        switch (InfoMenu.nbJoueur)
        {
            case 2:
                GameObject Player1 = Instantiate(Jeton);
                Red = Player1.GetComponent<PlayerInfo>();
                GameObject Player2 = Instantiate(Jeton);
                Green = Player2.GetComponent<PlayerInfo>();
                nbPlayers = 2;
                break;
            case 3:
                GameObject Player3 = Instantiate(Jeton);
                Blue = Player3.GetComponent<PlayerInfo>();
                nbPlayers = 3;
                goto case 2;
            case 4:
                GameObject Player4 = Instantiate(Jeton);
                Yellow = Player4.GetComponent<PlayerInfo>();
                nbPlayers = 4;
                goto case 3;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
