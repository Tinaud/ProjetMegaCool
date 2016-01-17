using UnityEngine;
using System.Collections;

public class Paleontologist : BaseBooth {

    public Paleontologist() : base (1) {
        this.type = Booth.Paleontologist;
        this.nbVisitorsAdded = 0;
        this.CashPerTurn = 0;
        //special, ce kiosque est un counter-event

        Debug.Log("Nice ! You have a bright new Paleontologist working in your park!");
    }
    	public override void ShowDetails () {
		// Coute 2$ et 2 tuiles, +1 visitors, 0 victims
	}
}
