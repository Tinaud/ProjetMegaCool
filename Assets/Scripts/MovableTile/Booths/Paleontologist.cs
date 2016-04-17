using UnityEngine;
using System.Collections;

public class Paleontologist : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Paleontologist;
		nbVisitorsAdded = 0;
		CashPerTurn = 0;

        boothName = "Paleontologist";
        boothDescription = "You have recruited a wise paleontologist! He will help you counter some unfortunate events that could ruin your park.";

        Debug.Log("Nice ! You have a bright new Paleontologist working in your park!");
	}
    	
	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
