using UnityEngine;
using System.Collections;

public class BaseDinosaur : MovableTile {

	protected int nbVisitorsAdded; 	// nombre de visiteurs generes 

	public enum Dino {Brontosaurus, Velociraptor, Triceratop, Tyrannosaurus}; 
	protected Dino type;			// enum ou classes derivees pour les differents types de dino
									// penser aux specificites de chaque type
	public Dino Type {
		get {return type;}
	}
		
	public int VisitorsAdded {
		get {return nbVisitorsAdded;}
		set {VisitorsAdded = value;}
	}

	protected int nbVisitorsEaten;	// nombre de visiteurs pouvant etre manges par le dino

	public BaseDinosaur(int price, int space) : base(price, space) {}

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat
	public override void ShowDetails () {}

	// Convertit l'enum en string
	public string DinoTypeToString(Dino type) {
		switch (type) {
		case Dino.Brontosaurus:
			return "Brontosaurus";

		case Dino.Velociraptor:
			return "Velociraptor";

		case Dino.Triceratop:
			return "Triceratop";

		case Dino.Tyrannosaurus:
			return "Tyrannosaurus";

		default:
			return "UNKNOWN TYPE !"; 
		}
	}
}
