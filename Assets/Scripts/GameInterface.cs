using UnityEngine;
using System.Collections;

public class GameInterface : MonoBehaviour {

    public GameObject Purchase;
    public GameObject Tyra;
    public GameObject Bron;
    public GameObject Velo;
    public GameObject Tric;
    public GameObject Cage;
    public GameObject Kisok1;
    public GameObject Kiosk2;
    public GameObject Kiosk3;
    public GameObject Kiosk4;

	// Use this for initialization

    //everything to scrap
	void Start () {
        Purchase.SetActive(true);
        Tyra.SetActive(true);
        Tric.SetActive(true);
        Bron.SetActive(true);
        Velo.SetActive(true);
        Cage.SetActive(true);
        Kisok1.SetActive(true);
        Kiosk2.SetActive(true);
        Kiosk3.SetActive(true);
        Kiosk4.SetActive(true);
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
        Cage.SetActive(false);
        Kisok1.SetActive(false);
        Kiosk2.SetActive(false);
        Kiosk3.SetActive(false);
        Kiosk4.SetActive(false);
    }

    public void kiosk()
    {
        Tyra.SetActive(false);
        Tric.SetActive(false);
        Bron.SetActive(false);
        Velo.SetActive(false);
        Cage.SetActive(true);
        Kisok1.SetActive(true);
        Kiosk2.SetActive(true);
        Kiosk3.SetActive(true);
        Kiosk4.SetActive(true);
    }
}
