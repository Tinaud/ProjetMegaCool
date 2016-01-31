﻿using UnityEngine;
using System.Collections;

public class Casino : BaseBooth {

    bool isVisible = false;

    public Casino() : base (1) {
        this.type = Booth.Casino;
        this.nbVisitorsAdded = 0;
        this.CashPerTurn = 3;

        Debug.Log("Nyaahhh ! You have a super new Casino in your park!");
    }
    	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}

    public int officialPrice()
    {
        if (isVisible == false)
            return 5;
        else
            return 3;
    }

    public void turnOver()
    {
        isVisible = true;
    }
}
