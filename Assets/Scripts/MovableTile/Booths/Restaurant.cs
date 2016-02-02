using UnityEngine;
using System.Collections;

public class Restaurant : BaseBooth {

    //bool isVisible = false;

    public Restaurant() : base (1) {
        this.type = Booth.Restaurant;
        this.nbVisitorsAdded = 1;
        this.CashPerTurn = 2;

        Debug.Log("NomNomNom ! You have a shiny new Restaurant in your park!");
    }
    	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

    /*public int officialPrice()
    {
        if (isVisible == false)
            return 5;
        else
            return 3;
    }

    public void turnOver()
    {
        isVisible = true;
    }*/
}
