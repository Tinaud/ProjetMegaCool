using UnityEngine;
using System.Collections;

public class Velociraptor : BaseDinosaur
{
	void Start() {
		price = 5;

		type = Dino.Velociraptor;
		nbVisitorsAdded = 2;
		nbVisitorsEaten = 1;

		//Debug.Log("Woaaaw ! You have a velociraptor in your park!");
	}

    public override void ShowDetails()
    {
        // Coute 5$ et 1 tuile, +2 visitors, -2 victims
    }

}
