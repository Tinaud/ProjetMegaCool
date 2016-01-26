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
    public Camera cam;
    float width;
    float height;

	// Use this for initialization
	void Start () {
        width = 1;
        height = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void spykiosk ()
    {
        width = .5F;
        height = .5F;
        create(spy);
        patateobject.AddComponent<Spy>();
    }
    public void casinokiosk()
    {
        width = .5F;
        height = .5F;
        create(cas);
        patateobject.AddComponent<Casino>();

    }

    public void restaurantkiosk()
    {
        width = .5F;
        height = .5F;
        create(res);
        patateobject.AddComponent<Restaurant>();
    }

    public void palekiosk()
    {
        width = .5F;
        height = .25F;
        create(pal);
        patateobject.AddComponent<Paleontologist>();
    }

    public void washkiosk()
    {
        width = .5F;
        height = .5F;
        create(wash);
        patateobject.AddComponent<Bathroom>();
    }

    public void secukiosk()
    {
        width = .5F;
        height = .3F;
        create(sec);
        patateobject.AddComponent<Security>();
    }

    public void cagecreation()
    {

        width = .5F;
        height = .3F;
        create(cage);
        patateobject.AddComponent<Cage>();
    }

    public void veloc()
    {

        width = .5F;
        height = .3F;
        create(velo);
        patateobject.AddComponent<Velociraptor>();
    }

    public void bront()
    {

        width = .5F;
        height = .5F;
        create(bron);
        patateobject.AddComponent<Brontosaurus>();
    }

    public void trice()
    {

        width = .5F;
        height = .3F;
        create(tri);
        patateobject.AddComponent<Triceratop>();
    }

    public void tyran()
    {

        width = .5F;
        height = .25F;
        create(tyr);
        patateobject.AddComponent<Tyrannosaurus>();
    }

    void create (Sprite spr)
    {
        spri.GetComponentInChildren<Image>().sprite = spr;
        spri.GetComponentInChildren<Image>().rectTransform.localScale = new Vector3(width, height, 1F);
        patateobject = (GameObject)Instantiate(kiosk, (cam.transform.position - new Vector3(0,7,0)), Quaternion.identity);
    }
}
