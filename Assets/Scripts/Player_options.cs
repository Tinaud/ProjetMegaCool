using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_options : MonoBehaviour {

	public GameObject kiosk;
	GameObject patateobject;
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
	bool once = true;
	int type;
	public GameObject gInter;
	public Texture2D selectionHighLight = null;
	public static Rect selection = new Rect(0, 0, 0, 0);
	//Rect alert = new Rect (Screen.width / 2, Screen.height - 200f, 100f, 20f);
	Vector2 startPos; 
	Vector2 rectSize; int sizeX = 22, sizeY = 22;
	public int playerNo = 1;
	int cageNo = 0;
	ParcManager parc;

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
		/*if(displayMessage) {
			displayTime -= Time.deltaTime;
			if (displayTime <= 0)
				displayMessage = false;
		}*/
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
					tileX = (int)hit.collider.GetComponent<Tile> ().Position.x;
					tileZ = (int)hit.collider.GetComponent<Tile> ().Position.y;
					if (parc.PurchaseCage (tileX, tileZ)) {
						tilePos.x += .25f;
						tilePos.z += .25f;
						patateobject = (GameObject)Instantiate (kiosk, tilePos, Quaternion.identity);
						patateobject.transform.localScale = new Vector3 (.5f, .2f, .5f);
						addCompoType (t);
						patateobject.GetComponent<Cage> ().cageNo = cageNo;
						creating = false;
						once = true;
						cageNo++;
					}
				} 
				else if ((t>= (int)SpaceRules.Type.Restaurant) && (t <= (int)SpaceRules.Type.Paleontologist)) // Creer un kiosque
				{
					tileX = (int)hit.collider.GetComponent<Tile> ().Position.x;
					tileZ = (int)hit.collider.GetComponent<Tile> ().Position.y;
					if (parc.PurchaseBooth (tileX, tileZ, t)) {
						patateobject = (GameObject)Instantiate (kiosk, tilePos, Quaternion.identity);
						addCompoType (t);
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
		create(velo);
		//patateobject.AddComponent<Velociraptor>();
	}

	public void bront()
	{

		width = .5F;
		height = .5F;
		type = (int)SpaceRules.Type.CageBront;
		create(bron);
		//patateobject.AddComponent<Brontosaurus>();
	}

	public void trice()
	{

		width = .5F;
		height = .3F;
		type = (int)SpaceRules.Type.CageTric;
		create(tri);
		//patateobject.AddComponent<Triceratop>();
	}

	public void tyran()
	{

		width = .5F;
		height = .25F;
		type = (int)SpaceRules.Type.CageTyra;
		create(tyr);
		//patateobject.AddComponent<Tyrannosaurus>();
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
			case SpaceRules.Type.CageBront:
				patateobject.AddComponent<Brontosaurus> ();
				break;
			case SpaceRules.Type.CageVelo: 
				patateobject.AddComponent<Velociraptor> ();
				break;
			case SpaceRules.Type.CageTric:
				patateobject.AddComponent<Triceratop> ();
				break;
			case SpaceRules.Type.CageTyra:
				patateobject.AddComponent<Tyrannosaurus> ();
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