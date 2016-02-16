using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cage : MovableTile{

	List<Tile> tiles;

	public List<Tile> Tiles {
		get {return tiles;}
		set {tiles = value;}
	}

	public enum CageType { 
		CageEmpty = 10, 
		CageBront = 0,
		CageVelo = 1, 
		CageTric = 2,
		CageTyra = 3
	}; 
	CageType type = CageType.CageEmpty;

	public CageType Type {
		get { return type; }
		set { type = value; }
	}

	List<BaseDinosaur> dinosaurs;

	public List<BaseDinosaur> Dinosaurs {
		get {return dinosaurs;}
		set {dinosaurs = value;}
	}

	bool isFull;

	public bool IsFull {
		get {return isFull;}
	}

	bool isSelected;

	public bool AddToCage(BaseDinosaur dinoPatate) {
		if (!isFull) {
			if (type == CageType.CageEmpty) {
				type = (CageType)dinoPatate.Type;
				dinosaurs.Capacity = SetCapacity ();
			}
			dinosaurs.Add (dinoPatate);
			return true;
		}
		return false;
	}

	void Start() {
		price = 5;
		dinosaurs = new List<BaseDinosaur> (SetCapacity());
		isFull = false;
		//gameObject.AddComponent<Renderer> ();
	}

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat

	void Update() {
		if (dinosaurs.Count == dinosaurs.Capacity)
			isFull = true;

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
