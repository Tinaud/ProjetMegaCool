using UnityEngine;
using System.Collections;

public class GameInterface : MonoBehaviour {

    public GameObject text;
    public GameObject booth;
    public GameObject dino;
    bool EspaceKiosk1;
    bool EspaceKiosk2;
    bool EspaceKiosk3;


	// Use this for initialization

    //everything to scrap
	void Start () {
		text.SetActive(false);
		booth.SetActive(false);
		dino.SetActive(false);
	}
	
	// Update is called once per frame
 	void Update () {
	
	}

	public void BoothPanel() {
		text.SetActive(false);
		booth.SetActive(true);
		dino.SetActive(false);		
	}

	public void DinoPanel() {
		text.SetActive(false);
		booth.SetActive(false);
		dino.SetActive(true);		
	}

	public void cageselect() {
		text.SetActive(true);
		booth.SetActive(false);
		dino.SetActive(false);	
	}

	public void cage() {
		text.SetActive(false);
		booth.SetActive(false);
		dino.SetActive(false);	
	}


    /*void KioskCard (GameObject button)
    {
        GameObject patateobject = (GameObject)Instantiate(kiosk);
        patateobject.transform.SetParent(Purchase.transform);
        patateobject.transform.rotation = (button.transform.rotation);
        patateobject.transform.localScale =new Vector3 (0.8F,0.8F,0.8F);
        patateobject.transform.position = button.transform.position;
    }*/
}
