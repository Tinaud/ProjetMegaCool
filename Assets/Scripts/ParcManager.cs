using UnityEngine;
using System.Collections;

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
        set { cashPerTurn = value; }
    }

    public int CashMoney
    {
        get { return cash; }
        set { cash = value; }
    }

    public int nbVisitors
    {
        get { return visitors; }
        set { visitors = value; }
    }

	public bool PurchaseAt (int x, int z, int type) {
		Board.GetComponent<BoardManager> ().SetAvailability (type);
		if (Board.GetComponent<BoardManager> ().GetTileAt (x, z).IsAvailable) {
			Board.GetComponent<BoardManager> ().SetTileType (x, z, type);
			Board.GetComponent<BoardManager> ().SetNeighbors (x, z);
			addType (type);
			return true;
		} 

		return false;
	}

	void addType (int type) {
		if (type == (int)SpaceRules.Type.CageEmpty)
			addCage ();
		else if ((type >= (int)SpaceRules.Type.CageBront) && (type <= (int)SpaceRules.Type.CageTyra))
			addDino (type);
		else if ((type >= (int)SpaceRules.Type.Restaurant) && (type <= (int)SpaceRules.Type.Paleontologist))
			addBooth (type);
		
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

    bool addDino(int dinosaurs) // trouver un moyen d'aller chercher le prix des dinosaures directement dans l'objet du dinosaure.
    { 
		switch ((BaseDinosaur.Dino)dinosaurs) 
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

    bool addBooth(int booth) 
    {
		switch ((BaseBooth.Booth)booth) 
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
}