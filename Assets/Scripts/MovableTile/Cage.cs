﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cage : MovableTile {

	List<BaseDinosaur> dinosaurs;
	bool isEmpty = true;

	public Cage() : base(5,4) {
		Debug.Log ("A cage has been added in this parc.");
	}

	public void AddToCage(BaseDinosaur patate) {
	}

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat
	public override void ShowDetails () {}
}