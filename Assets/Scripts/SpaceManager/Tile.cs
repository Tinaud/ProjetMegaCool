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

	SpaceRules rule;

	public SpaceRules Rule {
		get { return rule; }
		set { rule = value; }
	}

	/*----------------- GETTER & SETTER ------------------*/

	public bool IsAvailable {
		get { return isAvailable; }
		set {isAvailable = value;}
	}

	void Start () {
		isSelected = false;
		//SetUnavailable ();
		rule = new SpaceRules ();
	}

	void Update () {

		 //Pour la selection des tuiles
		if (GetComponent<Renderer> ().isVisible) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = Player_options.InvertMouseY (camPos.y);
			isSelected = Player_options.selection.Contains (camPos);
		}
			
		if (isSelected) {
			if (isAvailable)
				GetComponent<Renderer> ().material.color = Color.green;
			else
				GetComponent<Renderer> ().material.color = Color.red;
		}
		//else
			//GetComponent<Renderer> ().material.color = Color.white;
	}
}

