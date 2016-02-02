using UnityEngine;
using System.Collections;

public class Triceratop : BaseDinosaur {

	public Triceratop () : base (10, 4) {
		this.type = Dino.Triceratop;
		this.nbVisitorsAdded = 5;
		this.nbVisitorsEaten = 2;

		//Debug.Log ("Incredible! You have a triceratop in your park!");
	}

	public override void ShowDetails () {
		// Coute 10$ et 4 tuile, +5 visitors, -2 victims
	}
}
