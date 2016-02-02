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
    public GameObject kiosk;
    bool EspaceKiosk1;
    bool EspaceKiosk2;
    bool EspaceKiosk3;


	// Use this for initialization

    //everything to scrap
	void Start () {
		ActivePanel ();
	}
	
	// Update is called once per frame
 	void Update () {
	
	}

	public void ActivePanel() {
		Purchase.SetActive (true);
		Tyra.SetActive (true);
		Tric.SetActive (true);
		Bron.SetActive (true);
		Velo.SetActive (true);
		Cage.SetActive (true);
		Kisok1.SetActive (true);
		Kiosk2.SetActive (true);
		Kiosk3.SetActive (true);
		Kiosk4.SetActive (true);
		KioskCard (Kisok1);
		KioskCard (Kiosk2);
		KioskCard (Kiosk3);
	}

	public void DesactivePanel() {
		Purchase.SetActive (false);
		Tyra.SetActive (false);
		Tric.SetActive (false);
		Bron.SetActive (false);
		Velo.SetActive (false);
		Cage.SetActive (false);
		Kisok1.SetActive (false);
		Kiosk2.SetActive (false);
		Kiosk3.SetActive (false);
		Kiosk4.SetActive (false);
		KioskCard (Kisok1);
		KioskCard (Kiosk2);
		KioskCard (Kiosk3);
	}


    void KioskCard (GameObject button)
    {
        GameObject patateobject = (GameObject)Instantiate(kiosk);
        patateobject.transform.SetParent(Purchase.transform);
        patateobject.transform.rotation = (button.transform.rotation);
        patateobject.transform.localScale =new Vector3 (0.8F,0.8F,0.8F);
        patateobject.transform.position = button.transform.position;
    }
}
