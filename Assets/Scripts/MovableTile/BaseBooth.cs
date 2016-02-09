using UnityEngine;
using System.Collections;

public class BaseBooth : MovableTile {

    protected int nbVisitorsAdded;  // nombre de visiteurs generes 
    protected int CashPerTurn;  // nombre de visiteurs pouvant etre manges par le dino

    public enum Booth {Restaurant = 4, Security = 5, Bathroom = 6, Casino = 7, Spy = 8, Paleontologist = 9}; 
	protected Booth type;				// enum ou classes derivees pour les differents types de kiosques
							// penser aux specificites de chaque type

	public Booth Type {
		get { return type; }
		set { type = value; }
	}
		
	protected bool isFaceDown;

	void Start() {
		isFaceDown = false;
		price = officialPrice ();
	}
		
	// Pour afficher les specificites propres a chaque kiosque au moment de l'achat
	public override void ShowDetails () {

		// Restaurant (+1 visitors, +2$/turn)
		// Security (--Danger for the parc concerned)
		// Bathroom (+3 visitors)
		// Casino (+3$/turn)
		// Spy (Copy a opponent's dino (1 time effect))
		// Paleontologist (Counter event)
		
	}

   protected int officialPrice() {
		if (isFaceDown)
            return 3;
        else
            return 5;
    }

    public void turnOver() {
		isFaceDown = true;
    }  

}
