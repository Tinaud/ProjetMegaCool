using UnityEngine;
using System.Collections;

public class Brontosaurus : BaseDinosaur {

	public Brontosaurus () : base (2, 2) {
		this.type = Dino.Brontosaurus;
		this.nbVisitorsAdded = 1;
		this.nbVisitorsEaten = 0;

		//Debug.Log ("Amazing ! You have a brontosaurus in your park!");
	}

	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
