using UnityEngine;
using System.Collections;

public class Triceratop : BaseDinosaur {

	public Triceratop() : base(10, 5, 2) {
		type = Dino.Triceratop;
		//Debug.Log ("Incredible! You have a triceratop in your park!");
	}

	public override void ShowDetails () {
		// Coute 10$ et 4 tuile, +5 visitors, -2 victims
	}
		
}
