﻿using UnityEngine;
using System.Collections;

public class Security : BaseBooth {

    public Security() : base (1) {
        this.type = Booth.Security;
        this.nbVisitorsAdded = 0;
        this.CashPerTurn = 0;

        Debug.Log("Watch out ! You have a safe new Security booth in your park!");
    }
    	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}
}