using UnityEngine;
using System.Collections;

public class GameInterface : MonoBehaviour {

    public GameObject Purchase;
    public GameObject Tyra;
    public GameObject Bron;
    public GameObject Velo;
    public GameObject Tric;
    public GameObject Secu;
    public GameObject Wash;
    public GameObject Casi;
    public GameObject Spys;
    public GameObject Pale;
    public GameObject Rest;

	// Use this for initialization

    //everything to scrap
	void Start () {
        Purchase.SetActive(false);
        Tyra.SetActive(false);
        Tric.SetActive(false);
        Bron.SetActive(false);
        Velo.SetActive(false);
        Secu.SetActive(false);
        Wash.SetActive(false);
        Casi.SetActive(false);
        Spys.SetActive(false);
        Pale.SetActive(false);
        Rest.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void purchase()
    {
        Purchase.SetActive(true);
    }

    public void dino()
    {
        Tyra.SetActive(true);
        Tric.SetActive(true);
        Bron.SetActive(true);
        Velo.SetActive(true);
        Secu.SetActive(false);
        Wash.SetActive(false);
        Casi.SetActive(false);
        Spys.SetActive(false);
        Pale.SetActive(false);
        Rest.SetActive(false);
    }

    public void kiosk()
    {
        Tyra.SetActive(false);
        Tric.SetActive(false);
        Bron.SetActive(false);
        Velo.SetActive(false);
        Secu.SetActive(true);
        Wash.SetActive(true);
        Casi.SetActive(true);
        Spys.SetActive(true);
        Pale.SetActive(true);
        Rest.SetActive(true);
    }
}
