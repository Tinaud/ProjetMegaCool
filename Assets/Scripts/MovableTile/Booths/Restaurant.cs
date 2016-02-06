using UnityEngine;
using System.Collections;

public class Restaurant : BaseBooth {

	void Start() {
		isFaceDown = false;
		price = base.officialPrice ();

		type = Booth.Restaurant;
		nbVisitorsAdded = 1;
		CashPerTurn = 2;

		Debug.Log("NomNomNom ! You have a shiny new Restaurant in your park!");
	}

    public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

}
