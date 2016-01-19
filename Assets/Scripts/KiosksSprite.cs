using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KiosksSprite : MonoBehaviour {

    public Canvas spri;
    public Sprite pal;
    public float wi;
    public float height;

	// Use this for initialization
	void Start () {
        spri.GetComponentInChildren<Image>().sprite = pal;
        spri.GetComponentInChildren<Image>().rectTransform.localScale= new Vector3(wi,height,1F);
        Debug.Log("essai");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
