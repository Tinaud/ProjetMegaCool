using UnityEngine;
using System.Collections;

public class BaseDinosaur : MovableTile {

	protected int nbVisitorsAdded; 	// nombre de visiteurs generes 

	public enum Dino {Brontosaurus = 0, Velociraptor = 1 , Triceratop = 2, Tyrannosaurus = 3}; 
	protected Dino type;			// enum ou classes derivees pour les differents types de dino
									// penser aux specificites de chaque type
	public Dino Type {
		get { return type; }
		set {type = value;}
	}
		
	protected int VisitorsAdded {
		get {return nbVisitorsAdded;}
		set {VisitorsAdded = value;}
	}

	protected int nbVisitorsEaten;	// nombre de visiteurs pouvant etre manges par le dino

	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat
	public override void ShowDetails () {}

}
