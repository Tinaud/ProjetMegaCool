using UnityEngine;
using System.Collections;

public class Restaurant : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Restaurant;
		nbVisitorsAdded = 1;
		CashPerTurn = 2;

        boothName = "Restaurant";
        boothDescription = "This restaurant adds 1 visitor to your parc and generate 2 $ per turn.";

        Debug.Log("NomNomNom ! You have a shiny new Restaurant in your park!");
	}

    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
