using UnityEngine;
using System.Collections;

public class BaseKiosk : MovableTile {

	public enum Kiosk {Restaurant, Security, Toilets, Casino, Spying, Paleontologist}; 
	Kiosk type;				// enum ou classes derivees pour les differents types de kiosques
							// penser aux specificites de chaque type

	public Kiosk Type {
		get {return type;}
	}

				
							

	bool isVisible = false; // A implementer lorsque le kiosque est face ouverte ou pas 

	public BaseKiosk (Kiosk type) : base(3, 1) { // Par defaut un kiosque coute 3$ et 1 tuile 
		this.type = type;
		Debug.Log ("Kiosk " + KioskTypeToString(type) + " has been added in your park.");
	}
		
	// Pour afficher les specificites propres a chaque kiosque au moment de l'achat
	public override void ShowDetails () {

		// Restaurant (+1 visitors, +2$/turn)
		// Security (--Danger for the parc concerned)
		// Toilet (+3 visitors)
		// Casino (+3$/turn)
		// Spying (Copy a opponent's dino (1 time effect))
		// Paleontologist (Counter event)
		
	}

	// Convertit l'enum en string
	public string KioskTypeToString(Kiosk type) {
		switch (type) {
		case Kiosk.Restaurant:
			return "Restaurant";
		
		case Kiosk.Security:
			return "Security";

		case Kiosk.Toilets:
			return "Toilets";

		case Kiosk.Casino:
			return "Casino";

		case Kiosk.Spying:
			return "Spying";

		case Kiosk.Paleontologist:
			return "Paleontologist";

		default:
			return "UNKNOWN TYPE !"; 
		}
	}
}
