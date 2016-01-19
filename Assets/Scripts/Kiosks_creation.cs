using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Kiosks_creation : MonoBehaviour {

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
    float wi;
    float height;

	// Use this for initialization
	void Start () {
        wi = 1;
        height = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spykiosk ()
    {
        wi = .5F;
        height = .5F;
        create(spy);
        patateobject.AddComponent<Spy>();
    }
    public void casinokiosk()
    {
        wi = .5F;
        height = .5F;
        create(cas);
        patateobject.AddComponent<Casino>();

    }

    public void restaurantkiosk()
    {
        wi = .5F;
        height = .5F;
        create(res);
        patateobject.AddComponent<Restaurant>();
    }

    public void palekiosk()
    {
        wi = .5F;
        height = .25F;
        create(pal);
        patateobject.AddComponent<Paleontologist>();
    }

    public void washkiosk()
    {
        wi = .5F;
        height = .5F;
        create(wash);
        patateobject.AddComponent<Bathroom>();
    }

    public void secukiosk()
    {
        wi = .5F;
        height = .3F;
        create(sec);
        patateobject.AddComponent<Security>();
    }

    public void cagecreation()
    {

        wi = .5F;
        height = .3F;
        create(cage);
        patateobject.AddComponent<Cage>();
    }

    public void veloc()
    {

        wi = .5F;
        height = .3F;
        create(velo);
        patateobject.AddComponent<Velociraptor>();
    }

    public void bront()
    {

        wi = .5F;
        height = .5F;
        create(bron);
        patateobject.AddComponent<Brontosaurus>();
    }

    public void trice()
    {

        wi = .5F;
        height = .3F;
        create(tri);
        patateobject.AddComponent<Triceratop>();
    }

    public void tyran()
    {

        wi = .5F;
        height = .25F;
        create(tyr);
        patateobject.AddComponent<Tyrannosaurus>();
    }

    void create (Sprite spr)
    {
        spri.GetComponentInChildren<Image>().sprite = spr;
        spri.GetComponentInChildren<Image>().rectTransform.localScale = new Vector3(wi, height, 1F);
        patateobject = (GameObject)Instantiate(kiosk, new Vector3(1, 1, 1), Quaternion.identity);
        Debug.Log("essai");
    }
}
