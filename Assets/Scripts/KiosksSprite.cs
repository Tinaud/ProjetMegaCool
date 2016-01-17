using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KiosksSprite : MonoBehaviour {

    public Canvas spri;
    public Sprite pal;

	// Use this for initialization
	void Start () {
        spri.GetComponentInChildren<Image>().sprite = pal;
        Debug.Log("essai");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
