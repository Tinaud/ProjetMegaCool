using UnityEngine;
using System.Collections;

public class BaseDinosaur {

    public BaseDinosaur(int price, int nbVisitors, int VisitorsEaten) {
        this.price = price;
        this.nbVisitorsAdded = nbVisitors;
        this.nbVisitorsEaten = VisitorsEaten;
    }

    public BaseDinosaur() { }

    protected int nbVisitorsEaten;	// nombre de visiteurs pouvant etre manges par le dino
    protected int nbVisitorsAdded;  // nombre de visiteurs generes 

    public enum Dino { Brontosaurus = 0, Velociraptor = 1, Triceratop = 2, Tyrannosaurus = 3 };
    protected Dino type;            // enum ou classes derivees pour les differents types de dino
                                    // penser aux specificites de chaque type
    protected int price;

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public virtual void ShowDetails() { } 	// Pour afficher les specificites propres a chaque dinosaure au moment de l'achat

    public Dino Type {
        get { return type; }
        set { type = value; }
    }

    protected int VisitorsAdded {
        get { return nbVisitorsAdded; }
        set { VisitorsAdded = value; }
    }

    protected int VisitorsEaten {
        get { return nbVisitorsEaten; }
        set { nbVisitorsEaten = value; }
    }


}
