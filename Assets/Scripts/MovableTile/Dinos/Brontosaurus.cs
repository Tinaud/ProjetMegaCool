using UnityEngine;
using System.Collections;

public class Brontosaurus : BaseDinosaur {

	void Start() {
		price = 2;

		type = Dino.Brontosaurus;
		nbVisitorsAdded = 1;
		nbVisitorsEaten = 0;

		//Debug.Log ("Amazing ! You have a brontosaurus in your park!");
	}

	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}
		
}
