using UnityEngine;
using System.Collections;

public class Velociraptor : BaseDinosaur
{

    public Velociraptor() : base(5, 1)
    {
        this.type = Dino.Velociraptor;
        this.nbVisitorsAdded = 2;
        this.nbVisitorsEaten = 1;

        //Debug.Log("Woaaaw ! You have a velociraptor in your park!");
    }

    public override void ShowDetails()
    {
        // Coute 5$ et 1 tuile, +2 visitors, -2 victims
    }

}
