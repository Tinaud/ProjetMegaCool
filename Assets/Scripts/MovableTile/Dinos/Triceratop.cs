using UnityEngine;
using System.Collections;

public class Triceratop : BaseDinosaur {

	void Start() {
		price = 10;

		type = Dino.Triceratop;
		nbVisitorsAdded = 5;
		nbVisitorsEaten = 2;

		//Debug.Log ("Incredible! You have a triceratop in your park!");
	}

	public override void ShowDetails () {
		// Coute 10$ et 4 tuile, +5 visitors, -2 victims
	}
		
}
