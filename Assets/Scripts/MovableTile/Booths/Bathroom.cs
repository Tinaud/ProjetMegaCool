﻿using UnityEngine;
using System.Collections;

public class Bathroom : BaseBooth {

    public Bathroom() : base (1) {
        this.type = Booth.Bathroom;
        this.nbVisitorsAdded = 3;
        this.CashPerTurn = 0;

        Debug.Log("Finally ! You have a clean new Bathroom in your park!");
    }
    	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}
}