using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public bool isActive;
	bool isAvailable;

	//public enum ObjType {Cage, Dinosaur, Booth, Other};
	//ObjType type;

	/*----------------- GETTER & SETTER ------------------*/

	public bool IsAvailable {
		get { return isAvailable; }
	}

	public bool IsActive {
		get { return isActive; }
		set {isActive = value;}
	}

	public void SetAvailable() {
		isAvailable = true;
	}

	public void SetUnavailable() {
		isAvailable = false;
	}
		

	void Start () {
	}

	void Update () {

		/* Pour la selection des tuiles
		 * if (GetComponent<Renderer>().isVisible && Input.GetMouseButtonUp (0)) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = CameraOperator.InvertMouseY (camPos.y);
			IsSelected = CameraOperator.selection.Contains (camPos);
		}
		*/

		if (isActive)
			GetComponent<Renderer>().material.color = Color.blue;
		else
			GetComponent<Renderer>().material.color = Color.red;

	}
}

