using UnityEngine;
using System.Collections;

public class Casino : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Casino;
		nbVisitorsAdded = 0;
		CashPerTurn = 2;

        boothName = "Casino";
        boothDescription = "This arcade helps you generate 3 $ per turn.";

        Debug.Log("Nyaahhh ! You have a super new Casino in your park!");
	}

    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
