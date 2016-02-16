using UnityEngine;
using System.Collections;

public class Cage : MovableTile{

	public int cageNo;

	public enum CageType { 
		CageEmpty = 10, 
		CageBront = 0,
		CageVelo = 1, 
		CageTric = 2,
		CageTyra = 3
	}; 
	CageType type;

	public CageType Type {
		get { return type; }
		set { type = value; }
	}

	ArrayList dinosaurs;
	int capacity;

	bool isFull;

	public bool IsFull {
		get {return isFull;}
	}

	bool isSelected;

	public bool AddToCage(BaseDinosaur dinoPatate) {
		if (dinosaurs.Count == capacity) {
			if (type == CageType.CageEmpty) {
				type = (CageType)dinoPatate.Type;
				dinosaurs.Capacity = SetCapacity ();
			}
			dinosaurs.Add (dinoPatate);
			return true;
		}
		isFull = true;
		return false;
	}

	void Start() {
		type = CageType.CageEmpty;
		price = 5;
		capacity = 1;
		dinosaurs = new ArrayList ();
		isFull = false;
		gameObject.AddComponent<Renderer> ();
	}

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat

	void Update() {
		//Pour la selection des tuiles
		if (GetComponent<Renderer> ().isVisible) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = Player_options.InvertMouseY (camPos.y);
			isSelected = Player_options.selection.Contains (camPos);
		}

		if (isSelected) {
			if (!isFull)
				GetComponent<Renderer> ().material.color = Color.green;
			else
				GetComponent<Renderer> ().material.color = Color.red;
		}
		else
			GetComponent<Renderer> ().material.color = Color.white;
	}

	int SetCapacity() {
		switch (type) {
		case CageType.CageBront: 
			return 2;
		case CageType.CageVelo:
			return 4;
		default :
			return 1;
		}
	}
}
