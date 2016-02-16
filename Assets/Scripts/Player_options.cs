using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player_options : MonoBehaviour {

	public GameObject kiosk;
	GameObject patateobject;
	public GameObject capacityText;
	public GameObject cageType;
    BaseDinosaur patateDinosaur;
	public Canvas spri;
	public Sprite pal;
	public Sprite cas;
	public Sprite spy;
	public Sprite res;
	public Sprite wash;
	public Sprite sec;
	public Sprite cage;
	public Sprite velo;
	public Sprite bron;
	public Sprite tri;
	public Sprite tyr;
	public Camera cam;
	float width;
	float height;

	/*-------CameraOperator++-------*/
	bool creating = false;
	bool checkingCage = false;
	bool once = true;
	int type;
	public Texture2D selectionHighLight = null;
	public static Rect selection = new Rect(0, 0, 0, 0);
	//Rect alert = new Rect (Screen.width / 2, Screen.height - 200f, 100f, 20f);
	Vector2 startPos; 
	Vector2 rectSize; int sizeX = 22, sizeY = 22;
	public int playerNo = 1;
	ParcManager parc;
	Cage cacage;

	//float displayTime = 3f;
	//bool displayMessage = false;

	// Use this for initialization
	void Start () {
		width = 1;
		height = 1;
	}

	// Update is called once per frame
	void Update () {
		if (creating) {
			if (once) {
				GameObject b = GameObject.Find ("Player_" + playerNo);
				parc = b.GetComponent<ParcManager> ();
				parc.SetAvailability (type);
				once = false;
			}
			InstantiateRect ();
			CreateObj (type);
		}
		if(checkingCage) {
			cageIsEmpty ();
		}
	}

	void InstantiateRect () {
		if (type == (int)SpaceRules.Type.CageEmpty) {
			rectSize = new Vector2 (sizeX*2, sizeY*2);
			startPos = new Vector2 (Input.mousePosition.x - rectSize.x /4, InvertMouseY (Input.mousePosition.y) - rectSize.y / 1.5f);
		} else {
			rectSize = new Vector2 (sizeX, sizeY);
			startPos = new Vector2 (Input.mousePosition.x - rectSize.x / 2, InvertMouseY (Input.mousePosition.y) - rectSize.y / 2);
		}
		selection = new Rect (startPos, rectSize);
	}

	public void checkCage() {
		checkingCage = true;
	}

    public void cageIsEmpty()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject b = GameObject.Find ("Player_" + playerNo);
            //parc = b.GetComponent<ParcManager> ();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
				cacage = hit.collider.gameObject.GetComponent<Cage>();
				//foreach (Tile p in cacage.Tiles)
					//Debug.Log ("("+p.Position.ToString()+"), ");
                if (cacage != null)
                {
                    if (!cacage.IsFull && cacage.Type == Cage.CageType.CageEmpty)
                    {
                        this.GetComponent<GameInterface>().DinoPanel();
                    }
                    else if (!cacage.IsFull)
                    {
                        //afficher le type de la cage et sa capacité.
						type = (int)cacage.Type;
						setImageDino ();
						Text countDino = capacityText.GetComponent<Text>();
						countDino.text = cacage.Dinosaurs.Count + "/" + cacage.Dinosaurs.Capacity;
						this.GetComponent<GameInterface>().DinoOneChoice();
                    }
					checkingCage = false;
                }
            }
        }
    }

	void setImageDino() 
	{
		Image img; 

		switch ((SpaceRules.Type)type) {
		case SpaceRules.Type.CageBront:
			img = cageType.GetComponentInChildren<Image> ();
			img.sprite = bron;
			break;
		case SpaceRules.Type.CageVelo:
			img = cageType.GetComponentInChildren<Image> ();
			img.sprite = velo;
			break;
		case SpaceRules.Type.CageTyra:
			img = cageType.GetComponentInChildren<Image> ();
			img.sprite = tyr;
			break;
		case SpaceRules.Type.CageTric:
			img = cageType.GetComponentInChildren<Image> ();
			img.sprite = tri;
			break;
		}
	}

	void CreateObj(int t) {
		if (Input.GetMouseButtonDown (0)) {
			//GameObject b = GameObject.Find ("Player_" + playerNo);
			//parc = b.GetComponent<ParcManager> ();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 tilePos = hit.collider.transform.position;
				int tileX, tileZ;
				Debug.Log (tilePos.ToString ());

                if (t == (int)SpaceRules.Type.CageEmpty) // Creer une cage vide  
                {
                    tileX = (int)hit.collider.GetComponent<Tile>().Position.x;
                    tileZ = (int)hit.collider.GetComponent<Tile>().Position.y;
					List<Tile> cageTiles = new List<Tile> (4);
					if (parc.PurchaseCage(tileX, tileZ, ref cageTiles))
                    {
                        tilePos.x += .125f;
                        tilePos.z += .125f;
                        patateobject = (GameObject)Instantiate(kiosk, tilePos, Quaternion.identity);
                        patateobject.transform.localScale = new Vector3(.5f, .2f, .5f);
                        addCompoType(t);
						patateobject.GetComponent<Cage> ().Tiles = new List<Tile> (cageTiles);
						if (cageTiles[0].Rule.TileType >= SpaceRules.Type.CageBront && cageTiles[0].Rule.TileType <= SpaceRules.Type.CageTyra) {
							int tamp = (int)cageTiles [0].Rule.TileType;
							patateobject.GetComponent<Cage> ().Type = (Cage.CageType)tamp;
						}
						Debug.Log ("Creation cage de type : " + patateobject.GetComponent<Cage> ().Type);
						//foreach (Tile p in patateobject.GetComponent<Cage> ().Tiles)
							//Debug.Log ("("+p.Position.ToString()+"), ");
                        creating = false;
                        once = true;
                    }
                }
                else if ((t >= (int)SpaceRules.Type.Restaurant) && (t <= (int)SpaceRules.Type.Paleontologist)) // Creer un kiosque
                {
                    tileX = (int)hit.collider.GetComponent<Tile>().Position.x;
                    tileZ = (int)hit.collider.GetComponent<Tile>().Position.y;
                    if (parc.PurchaseBooth(tileX, tileZ, t))
                    {
                        patateobject = (GameObject)Instantiate(kiosk, tilePos, Quaternion.identity);
                        addCompoType(t);
                        creating = false;
                        once = true;
                    }
                }
            }
		}
			
	}

	public static float InvertMouseY(float y)
	{
		return Screen.height - y;
	}

	void OnGUI()
	{
		GUI.color = new Color(1, 1, 1, 0.5f);
		//GUI.DrawTexture(selection, selectionHighLight);
		/*if (displayMessage) {
			GUI.Label (alert, " You can't place it there !");
			GUI.DrawTexture(alert, selectionHighLight);
		}*/
	}


	public void spykiosk ()
	{
		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.Spy;
		create(spy);
		//patateobject.AddComponent<Spy>();
	}
	public void casinokiosk()
	{
		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.Casino;
		create(cas);
		//patateobject.AddComponent<Casino>();

	}

	public void restaurantkiosk()
	{
		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.Restaurant;
		create(res);
		//patateobject.AddComponent<Restaurant>();
	}

	public void palekiosk()
	{
		width = .5F;
		height = .25F;
		type = (int)SpaceRules.Type.Paleontologist;
		create(pal);
		//patateobject.AddComponent<Paleontologist>();
	}

	public void washkiosk()
	{
		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.Bathroom;
		create(wash);
		//patateobject.AddComponent<Bathroom>();
	}

	public void secukiosk()
	{
		width = .5F;
		height = .3F;
		type = (int)SpaceRules.Type.Security;
		create(sec);
		//patateobject.AddComponent<Security>();
	}

	public void cagecreation()
	{
		width = .5F;
		height = .3F;
		type = (int)SpaceRules.Type.CageEmpty;
		create(cage);
		//patateobject.AddComponent<Cage>();
	}

	public void veloc()
	{
		width = .5F;
		height = .3F;
		type = (int)SpaceRules.Type.CageVelo;
		GameObject b = GameObject.Find ("Player_" + playerNo);
		parc = b.GetComponent<ParcManager> ();
		parc.PurchaseDino (cacage, new Velociraptor ());
		create(velo);
		this.GetComponent<GameInterface>().allInactive();
		//patateobject.AddComponent<Velociraptor>();
	}

	public void bront()
	{

		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.CageBront;
		GameObject b = GameObject.Find ("Player_" + playerNo);
		parc = b.GetComponent<ParcManager> ();
		parc.PurchaseDino (cacage, new Brontosaurus ());
		create(bron);
		this.GetComponent<GameInterface>().allInactive();
		//patateobject.AddComponent<Brontosaurus>();
	}

	public void trice()
	{

		width = .5F;
		height = .3F;
		type = (int)SpaceRules.Type.CageTric;
		GameObject b = GameObject.Find ("Player_" + playerNo);
		parc = b.GetComponent<ParcManager> ();
		parc.PurchaseDino (cacage, new Triceratop ());
		create(tri);
		this.GetComponent<GameInterface>().allInactive();
		//patateobject.AddComponent<Triceratop>();
	}

	public void tyran()
	{

		width = .5F;
		height = .25F;
		type = (int)SpaceRules.Type.CageTyra;
		GameObject b = GameObject.Find ("Player_" + playerNo);
		parc = b.GetComponent<ParcManager> ();
		parc.PurchaseDino (cacage, new Tyrannosaurus ());
		create(tyr);
		this.GetComponent<GameInterface>().allInactive();
		//patateobject.AddComponent<Tyrannosaurus>();
	}

	public void chooseDino()
	{
		switch ((SpaceRules.Type)type) {
		case SpaceRules.Type.CageBront:
			bront ();
			break;
		case SpaceRules.Type.CageVelo:
			veloc ();
			break;
		case SpaceRules.Type.CageTyra:
			tyran ();
			break;
		case SpaceRules.Type.CageTric:
			trice ();
			break;
		}
	}

	void create (Sprite spr)
	{
		creating = true;
		spri.GetComponentInChildren<Image> ().sprite = spr;
		spri.GetComponentInChildren<Image> ().rectTransform.localScale = new Vector3 (width, height, 1F);
	}

	void addCompoType(int type) {
		switch ((SpaceRules.Type)type) {
		 
			case SpaceRules.Type.CageEmpty:
				patateobject.AddComponent<Cage> ();
				break;
			case SpaceRules.Type.Restaurant : 
				patateobject.AddComponent<Restaurant> ();
				break;
			case SpaceRules.Type.Security :
				patateobject.AddComponent<Security> ();
				break;
			case SpaceRules.Type.Bathroom :
				patateobject.AddComponent<Bathroom> ();
				break;
			case SpaceRules.Type.Casino :
				patateobject.AddComponent<Casino> ();
				break;
			case SpaceRules.Type.Spy :
				patateobject.AddComponent<Spy> ();
				break;
			case SpaceRules.Type.Paleontologist :
				patateobject.AddComponent<Paleontologist> ();
				break;
		}
	}
}