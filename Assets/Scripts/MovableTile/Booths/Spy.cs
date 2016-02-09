using UnityEngine;
using System.Collections;

public class Spy : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Spy;
		nbVisitorsAdded = 0;
		CashPerTurn = 0;

		Debug.Log("sshhhhh ! You have a sneaky new Spy in your park!");
	}
		
    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
