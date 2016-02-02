using UnityEngine;
using System.Collections;

public class BaseBooth : MovableTile {

    protected int nbVisitorsAdded;  // nombre de visiteurs generes 
    protected int CashPerTurn;  // nombre de visiteurs pouvant etre manges par le dino

    public enum Booth {Restaurant = 4, Security = 5, Bathroom = 6, Casino = 7, Spy = 8, Paleontologist = 9}; 
	protected Booth type;				// enum ou classes derivees pour les differents types de kiosques
							// penser aux specificites de chaque type

	public Booth Type {
		get {return type;}
	}

			
							

	//bool isVisible = false;  place dans les instances enfants 

    public BaseBooth(int space) : base(space)
    {
        //this.price = officialPrice();

    }

    /*public BaseBooth (Booth type) : base(Price, Space) { // Par defaut un kiosque coute 3$ et 1 tuile 
		this.type = type;
		Debug.Log ("Booth " + BoothTypeToString(type) + " has been added in your park.");
	}*/
		
	// Pour afficher les specificites propres a chaque kiosque au moment de l'achat
	public override void ShowDetails () {

		// Restaurant (+1 visitors, +2$/turn)
		// Security (--Danger for the parc concerned)
		// Bathroom (+3 visitors)
		// Casino (+3$/turn)
		// Spy (Copy a opponent's dino (1 time effect))
		// Paleontologist (Counter event)
		
	}
    /*public int officialPrice() {
        if (isVisible == false)
            return 5;
        else
            return 3;
    }

    public void turnOver() {
        isVisible = true;
    }*/   //LES DEUX DERNIERES FONCTIONS SONT IMPLEMENTEES DANS LES INSTANCES ENFANTS

	// Convertit l'enum en string
	public string BoothTypeToString(Booth type) {
		switch (type) {
		case Booth.Restaurant:
			return "Restaurant";
		
		case Booth.Security:
			return "Security";

		case Booth.Bathroom:
			return "Bathroom";

		case Booth.Casino:
			return "Casino";

		case Booth.Spy:
			return "Spy";

		case Booth.Paleontologist:
			return "Paleontologist";

		default:
			return "UNKNOWN TYPE !"; 
		}
	}
}
