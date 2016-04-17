using UnityEngine;
using System.Collections;

public class Spy : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Spy;
		nbVisitorsAdded = 0;
		CashPerTurn = 0;

        boothName = "Spy";
        boothDescription = "You have recruited ingenious spies to clone one of your enemy's dinosaur (single use effect).";

        Debug.Log("sshhhhh ! You have a sneaky new Spy in your park!");
	}
		
    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
