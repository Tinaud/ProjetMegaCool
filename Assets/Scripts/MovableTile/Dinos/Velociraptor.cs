using UnityEngine;
using System.Collections;

public class Velociraptor : BaseDinosaur
{
	public Velociraptor(): base(5, 2, 1) {
		type = Dino.Velociraptor;
		//Debug.Log("Woaaaw ! You have a velociraptor in your park!");
	}

    public override void ShowDetails()
    {
        // Coute 5$ et 1 tuile, +2 visitors, -2 victims
    }

}
