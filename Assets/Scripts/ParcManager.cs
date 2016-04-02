using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ParcManager : MonoBehaviour {

    public bool eventTwoBreach,
                eventTwoBuild,
                eventTriceratopPriceDown,
                eventTyrannosaurusPriceDown,
                eventDangerDown,
                eventDangerUp;

    public int cage;
    public int cash;
    public int visitors;
    public int cashPerTurn;
    public int ID;
    public bool paleontologist;
    public bool spy;
    public enum Danger { High, Medium_high, Medium, Medium_low, Low };
    public Danger danger;
    private int[] dinos;
    private int[] booths;
    private GameObject Board;
    private Player_options menu;

    void Start()
    {
        eventTwoBreach = false;
        eventTwoBuild = false;
        eventTriceratopPriceDown = false;
        eventTyrannosaurusPriceDown = false;

        dinos = new int[] { 0, 0, 0, 0 };
        booths = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 0;
        cash = 15;
        visitors = 0;
        danger = Danger.Medium;
        cashPerTurn = 0;
        paleontologist = false;
        spy = false;
        Board = new GameObject("Board_P" + ID);
        Board.AddComponent<BoardManager>();
        Board.transform.parent = transform;
    }

    void Build() {
        menu = new Player_options();
        //construction
        Destroy(menu);
    }

	/*void Start() {
		Board = new GameObject("Board_P" + ID);
		Board.AddComponent<BoardManager>();
		Board.transform.parent = transform;
	}*/

    public Danger dangerLevel
    {
        get { return danger; }
        set { danger = value; }
    }

    public int CashFlow
    {
        get { return cashPerTurn; }
        set
        {
            int tampon = value - cashPerTurn;
            cashPerTurn = value;
            if (tampon != 0)
            {
                StartCoroutine(PopupCashFlow(tampon));
            }
        }
    }

    public int CashMoney
    {
        get { return cash; }
        set 
        {
            int tampon = value - cash;
            cash = value;
            if (tampon != 0)
            {
                StartCoroutine(PopupCashMoney(tampon));
            }
        }
    }

    public int nbVisitors
    {
        get { return visitors; }
        set 
        {
            int tampon = value - visitors;
            visitors = value;
            if (tampon != 0)
            {
                StartCoroutine(PopupNbVisitors(tampon));
            }
        }
    }

	public bool PurchaseBooth (int x, int z, int boothPatate) {
	 	if (Board.GetComponent<BoardManager> ().GetTileAt (x, z).IsAvailable) {
			Board.GetComponent<BoardManager> ().SetOccupiedTile (x, z, boothPatate);
			Board.GetComponent<BoardManager> ().SetNeighbors (x, z, boothPatate);
			addBooth ((BaseBooth.Booth)boothPatate);
			return true;
		} 
		return false;
	}

	public void SetAvailability(int type) {
		Board.GetComponent<BoardManager> ().SetAvailability (type);
	}

	public bool PurchaseDino (Cage cagePatate, BaseDinosaur dinoPatate) {
		int type = (int)dinoPatate.Type; 
		if (cagePatate.AddToCage (dinoPatate)) {
			foreach (Tile t in (List<Tile>)cagePatate.Tiles) {
				Board.GetComponent<BoardManager> ().SetTileType ((int)t.Position.x, (int)t.Position.y, type);
				Board.GetComponent<BoardManager> ().SetNeighbors ((int)t.Position.x, (int)t.Position.y, type);
			}
			addDino (dinoPatate.Type);
			return true;
		}
		return false;
	}

	public bool PurchaseCage (int x, int z, ref List<Tile> CageTiles) {
		int type = (int)SpaceRules.Type.CageEmpty;

		for (int i = x; i <= x + 1; i++) {
			for (int j = z; j <= z + 1; j++) {
				Tile cur = Board.GetComponent<BoardManager> ().GetTileAt (i, j);
				if (cur.IsAvailable) {
					if (cur.Rule.TileType >= SpaceRules.Type.CageBront && cur.Rule.TileType <= SpaceRules.Type.CageTyra)
						type = (int)cur.Rule.TileType;
					//Debug.Log (type);
					CageTiles.Add (cur);
				}
			}
		}
		if (CageTiles.Count == 4) {
			foreach (Tile tile in CageTiles) {
				//Board.GetComponent<BoardManager> ().SetTileType ((int)tile.Position.x, (int)tile.Position.y, type);
				Board.GetComponent<BoardManager> ().SetOccupiedTile((int)tile.Position.x, (int)tile.Position.y, type);
				Board.GetComponent<BoardManager> ().SetNeighbors ((int)tile.Position.x, (int)tile.Position.y, type);
				Debug.Log (tile.Rule.TileType.ToString ());
			}
			addCage ();	
			return true;
		}
		return false;
	}

	bool addCage() {
		if (cash >= 5) {
			cage++;
			cash -= 5;
			Debug.Log ("A cage has been added in this parc.");
			return true;
		}
		Debug.Log("Not enough funds!");
		return false;
	}

	bool addDino(BaseDinosaur.Dino dinosaurs) // trouver un moyen d'aller chercher le prix des dinosaures directement dans l'objet du dinosaure.
    { 
		switch (dinosaurs) 
        {
		case BaseDinosaur.Dino.Brontosaurus:
                if (cash >= 2)
                {
                    visitors += 1;
                    cash -= 2;
                    dinos[0]++;
					Debug.Log ("Amazing ! You have a brontosaurus in your park!");
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }

		case BaseDinosaur.Dino.Triceratop:
                int TriceratopsPrice = eventTriceratopPriceDown ? 5 : 15;
                if (cash >= TriceratopsPrice)
                {
                    visitors += 5;
                    cash -= TriceratopsPrice;
                    dinos[2]++;
					Debug.Log ("Incredible! You have a triceratop in your park!");
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }

		case BaseDinosaur.Dino.Tyrannosaurus:
			int TyrannosaurusPrice = eventTyrannosaurusPriceDown ? 15 : 25;
			if (cash >= TyrannosaurusPrice)
                {
					cash -= TyrannosaurusPrice;
                    visitors += 10;
                    dinos[3]++;
                    danger--;
					Debug.Log ("OMFG ! This is G-O-R-G-E-O-U-S ! You have a tyrannosaurus in your park!");
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }

		case BaseDinosaur.Dino.Velociraptor:
                if (cash >= 5)
                {
					Debug.Log ("Cash : " + cash + "$.");
                    cash -= 5;
					Debug.Log ("Cash : " + cash + "$.");
                    visitors += 2;
                    dinos[1]++;
					Debug.Log("Woaaaw ! You have a velociraptor in your park!");
                    return true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return false;
                }

        default: Debug.Log("Dinosaure type not recognized"); return false; 
        }
    }

	bool addBooth(BaseBooth.Booth booth) 
    {
		switch (booth) 
        {
		case BaseBooth.Booth.Restaurant:
                booths[0]++;
                visitors += 1;
                cashPerTurn += 2;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
		case BaseBooth.Booth.Security:
                booths[1]++;
                danger++;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
		case BaseBooth.Booth.Bathroom:
                booths[2]++;
                visitors += 3;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
		case BaseBooth.Booth.Casino:
                booths[3]++;
                cashPerTurn += 3;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
		case BaseBooth.Booth.Spy:
                if (booths[4] == 0)
                {
                    booths[4] = 1;
                    spy = true;
                    cash -= 3; //aller chercher le officialPrice() au lieu du 3
                    return true;
                }
                else
                {
                    Debug.Log("il n'existe qu'un seul kiosque d'espionnage");
                    return false;
                }
		case BaseBooth.Booth.Paleontologist:
                if (booths[5] == 0 && paleontologist == false)
                {
                    booths[5] = 1;
                    paleontologist = true;
                    cash -= 3; //aller chercher le officialPrice() au lieu du 3
                    return true;
                }
                else
                {
                    Debug.Log("déjà un kiosque de paléontologue");
                    return false;
                }
            default:
                Debug.Log("Booth type not recognized"); return false;
        }
    }

    public void Spying() 
    {
        //copier un dinosaure dans un parc adverse
        spy = false;
    }

    public void setID(int id)
    {
        ID = id;
    }

    public void Breach()
    {
        int mostDangerousDinosaur = mostDangerous();
        /*for (int i = 1; i < 4; i++)
            if (dinos[i] > 0)
                temp = i;*/

        Debug.Log("BREACH!!!");
        switch (mostDangerousDinosaur)
        {
            case 0:
                Debug.Log("Un brontosaure s'est échappé de sa cage! OK.");
                visitors -= 0;
                break;
            case 1:
                Debug.Log("Yikes! un vélociraptor s'est échappé de sa cage!");
                visitors -= 1;
                break;
            case 2:
                Debug.Log("Ouch! Un tricératops s'est échappé de sa cage!");
                visitors -= 2;
                break;
            case 3:
                Debug.Log("OMFG! Un tyranosaure s'est échappé de sa cage!");
                visitors -= 5;
                break;
            default:
                Debug.Log("il n'y a aucun dinosaure dans votre parc...");
                break;
        }
    }

    public bool noDinosaurs()
    {
        int dinosaurNumber = 0;

        for (int i = 1; i < 4; i++)
            if (dinos[i] != 0)
                dinosaurNumber += dinos[i];
        
        if (dinosaurNumber == 0)
            return true; //aucun dinosaures dans le parc
        else
            return false; // des dinosaures dans le parc.
    }

    public int mostDangerous()
    {
        int mostDangerousDinosaur = -1;

        for (int i = 1; i < 4; i++)
            if (dinos[i] > 0)
                mostDangerousDinosaur = i;

        return mostDangerousDinosaur; // 0 = bronto, 1 = velo, 2 = trice, 3 = Tyra
    }

    IEnumerator PopupCashMoney(int tampon)
    {
        GameObject PlayerCanvas = GameObject.Find("player" + ID);
        GameObject popup = (GameObject)Instantiate(Resources.Load("Popup"), new Vector3(PlayerCanvas.transform.position.x, PlayerCanvas.transform.position.y-0.8f, PlayerCanvas.transform.position.z), PlayerCanvas.transform.rotation);
        popup.transform.parent = PlayerCanvas.transform;
        Text TextPopup = popup.GetComponentInChildren<Text>();
        if (tampon > 0)
        {
            TextPopup.color = Color.yellow;
            TextPopup.text = "+ " + tampon + " $";
        }
        else
        {
            TextPopup.color = Color.red;
            TextPopup.text = "- " + Mathf.Abs(tampon) + " $";
        }
        yield return new WaitForSeconds(5);
        DestroyObject(popup);
    }

    IEnumerator PopupCashFlow(int tampon)
    {
        GameObject PlayerCanvas = GameObject.Find("player" + ID);
        GameObject popup = (GameObject)Instantiate(Resources.Load("Popup"), new Vector3(PlayerCanvas.transform.position.x, PlayerCanvas.transform.position.y-1, PlayerCanvas.transform.position.z), PlayerCanvas.transform.rotation);
        popup.transform.parent = PlayerCanvas.transform;
        Text TextPopup = popup.GetComponentInChildren<Text>();
        if (tampon > 0)
        {
            TextPopup.color = Color.green;
            TextPopup.text = "+ " + tampon + " $ per turn";
        }
        else
        {
            TextPopup.color = Color.red;
            TextPopup.text = "- " + Mathf.Abs(tampon) + " $ per turn";
        }
        yield return new WaitForSeconds(5);
        DestroyObject(popup);
    }

    IEnumerator PopupNbVisitors(int tampon)
    {
        GameObject PlayerCanvas = GameObject.Find("player" + ID);
        GameObject popup = (GameObject)Instantiate(Resources.Load("Popup"), new Vector3(PlayerCanvas.transform.position.x, PlayerCanvas.transform.position.y-1, PlayerCanvas.transform.position.z), PlayerCanvas.transform.rotation);
        popup.transform.parent = PlayerCanvas.transform;
        Text TextPopup = popup.GetComponentInChildren<Text>();
        if (tampon > 0)
        {
            TextPopup.color = Color.blue;
            TextPopup.text = "+ " + tampon + " visitors";
        }
        else
        {
            TextPopup.color = Color.red;
            TextPopup.text = "- " + Mathf.Abs(tampon) + " visitors";
        }
        yield return new WaitForSeconds(5);
        DestroyObject(popup);
    }
}