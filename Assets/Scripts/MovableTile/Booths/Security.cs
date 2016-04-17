using UnityEngine;
using System.Collections;

public class Security : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Security;
		nbVisitorsAdded = 0;
		CashPerTurn = 0;

        boothName = "Security";
        boothDescription = "This guard is securing your park against dinosaur breaches.";
        
        Debug.Log("Watch out ! You have a safe new Security booth in your park!");
	}

    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
