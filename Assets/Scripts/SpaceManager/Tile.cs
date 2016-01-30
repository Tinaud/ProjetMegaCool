using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	bool isAvailable;
	bool isSelected;
	Vector2 position;

	public Vector2 Position {
		get { return position; }
		set { position = value; }
	}

	public enum ObjType {
		Empty, 
		CageEmpty, 
		CageVelo, 
		CageTyra, 
		CageBront,
		CageTric,
		Restaurant, 
		Security,
		Bathroom, 
		Casino, 
		Spy, 
		Paleontologist
	};
	ObjType type;

	public ObjType Type {
		get { return type; }
		set { type = value; }
	}

	/*----------------- GETTER & SETTER ------------------*/

	public bool IsAvailable {
		get { return isAvailable; }
	}

	public void SetAvailable() {
		isAvailable = true;
	}

	public void SetUnavailable() {
		isAvailable = false;
	}
		

	void Start () {
		isSelected = false;
		SetAvailable ();
		type = ObjType.Empty;
	}

	void Update () {

		 //Pour la selection des tuiles
		if (GetComponent<Renderer> ().isVisible) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = CameraOperator.InvertMouseY (camPos.y);
			isSelected = CameraOperator.selection.Contains (camPos);
		}
			
		if (isSelected) {
			if (isAvailable)
				GetComponent<Renderer> ().material.color = Color.green;
			else
				GetComponent<Renderer> ().material.color = Color.red;
		}
		else
			GetComponent<Renderer> ().material.color = Color.white;
	}
}

