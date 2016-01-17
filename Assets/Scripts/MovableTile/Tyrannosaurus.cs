using UnityEngine;
using System.Collections;

public class Tyrannosaurus : BaseDinosaur {

	public Tyrannosaurus () : base (25, 4) {
		this.type = Dino.Tyrannosaurus;
		this.nbVisitorsAdded = 10;
		this.nbVisitorsEaten = 5;

		Debug.Log ("OMFG ! This is G-O-R-G-E-O-U-S ! You have a tyrannosaurus in your park!");
	}

	public override void ShowDetails () {
		// Coute 25$ et 4 tuile, +10 visitors, -5 victims
	}
}
