using UnityEngine;
using System.Collections;

public class Cage : MovableTile{

	Renderer rend;
	public int cageNo;

	public enum CageType { 
		CageEmpty = 10, 
		CageBront = 0,
		CageVelo = 1, 
		CageTric = 2,
		CageTyra = 3
	}; 
	CageType type;

	ArrayList dinosaurs;
	int capacity;

	bool isFull;

	public bool IsFull {
		get {return isFull;}
	}

	bool isSelected;

	public bool AddToCage(BaseDinosaur dinoPatate) {
		if (!isFull) {
			if (type == (CageType)dinoPatate.Type || type == CageType.CageEmpty) {
				if (type == CageType.CageEmpty) {
					type = (CageType)dinoPatate.Type;
					capacity = officialCapacity ();
					dinosaurs.Capacity = capacity;

				}
				dinosaurs.Add (dinoPatate);
				return true;
			}
		}
		return false;
	}

	void Start() {
		price = 5;
		capacity = 4;
		dinosaurs = new ArrayList ();
		isFull = false;
		type = CageType.CageEmpty;
		rend = GetComponent<Renderer> ();
	}

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat

	void Update() {
		if (dinosaurs.Count == capacity)
			isFull = true;

		//Pour la selection des tuiles
		if (rend.isVisible) {
			Vector3 camPos = Camera.main.WorldToScreenPoint (transform.position);
			camPos.y = Player_options.InvertMouseY (camPos.y);
			isSelected = Player_options.selection.Contains (camPos);
		}

		if (isSelected) {
			if (!isFull)
				rend.material.color = Color.green;
			else
				rend.material.color = Color.red;
		}
		else
			rend.material.color = Color.white;
	}

	int officialCapacity() {
		switch (type) {
		case CageType.CageBront: 
			return 2;
		case CageType.CageTric:
			return 1;
		case CageType.CageTyra:
			return 1;
		default :
			return 4;
		}
	}
}
