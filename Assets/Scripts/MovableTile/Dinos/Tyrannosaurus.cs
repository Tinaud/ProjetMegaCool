using UnityEngine;
using System.Collections;

public class Tyrannosaurus : BaseDinosaur {

	void Start() {
		price = 25;

		type = Dino.Tyrannosaurus;
		nbVisitorsAdded = 10;
		nbVisitorsEaten = 5;

		//Debug.Log ("OMFG ! This is G-O-R-G-E-O-U-S ! You have a tyrannosaurus in your park!");
	}

	public override void ShowDetails () {
		// Coute 25$ et 4 tuile, +10 visitors, -5 victims
	}

}
