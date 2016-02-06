using UnityEngine;
using System.Collections;

public class Bathroom : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Bathroom;
		nbVisitorsAdded = 3;
		CashPerTurn = 0;

		Debug.Log("Finally ! You have a clean new Bathroom in your park!");
	}
		
    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}
		
}
