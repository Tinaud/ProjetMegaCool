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
	Vector2 startPos;
	Vector2 rectSize = new Vector2(22, 22);
	public int playerNo = 1;
	ParcManager parc;

	// Use this for initialization
	void Start () {
		width = 1;
		height = 1;
	}

	// Update is called once per frame
	void Update () {
		if (creating) {
			InstantiateRect ();
			CreateObj (type);
		}
	}

	void InstantiateRect () {
		startPos = new Vector2 (Input.mousePosition.x - rectSize.x / 2, InvertMouseY (Input.mousePosition.y) - rectSize.y / 2);
		selection = new Rect (startPos, rectSize);
	}

	void CreateObj(int t) {
		if (Input.GetMouseButtonDown (0)) {
			GameObject b = GameObject.Find ("Player_" + playerNo);
			parc = b.GetComponent<ParcManager> ();

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 tilePos = hit.collider.transform.position;
				//Debug.Log (tilePos.ToString ());

				if (parc.PurchaseAt ((int)Mathf.Round (tilePos.x * 2), (int)Mathf.Round (tilePos.z * 2), t)) {
					patateobject = (GameObject)Instantiate (kiosk, tilePos, Quaternion.identity);
					addCompoType (type);
					creating = false;
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
		GUI.DrawTexture(selection, selectionHighLight);
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