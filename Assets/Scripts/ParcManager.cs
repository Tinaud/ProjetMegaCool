using UnityEngine;
using System.Collections;

public class ParcManager : MonoBehaviour {
    public int cage;
    public int cash;
    public int visitors;
    public int cashPerTurn;
    public bool success;
    public bool paleontologist;
    public bool spy;
    public int playerIdentity;
    private enum Danger { High, Medium_high, Medium, Medium_low, Low };
    private enum Booth { Restaurant, Security, Bathroom, Casino, Spy, Paleontologist };
    private enum Dino { Brontosaurus, Velociraptor, Triceratops, Tyrannosaurus };
    private Dino dinosaurs;
    private Booth booth;
    private Danger danger;
    private int[] dinos;
    private int[] booths;
    private bool tyrannosaurusDanger;

    // Use this for initialization
    void Start () {

        dinos = new int[] { 0, 0, 0, 0 };
        booths = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 1;
        cash = 15;
        visitors = 0;
        danger = Danger.Medium;
        cashPerTurn = 0;
        paleontologist = false;
        tyrannosaurusDanger = false;
        spy = false;

    }
	
	// Update is called once per frame
	void Update () {
    }

    bool addDino(Dino dinosaurs) { // trouver un moyen d'aller chercher le prix des dinosaures directement dans l'objet du dinosaure.
        switch (dinosaurs) {
            case Dino.Brontosaurus:
                if (cash - 2 >= 0)
                {
                    visitors = +1;
                    cash = -2;
                    dinos[0]++;
                    return success = true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return success = false;
                }
            case Dino.Triceratops:
                if (cash - 5 >= 0)
                {
                    visitors = +5;
                    cash = -5;
                    dinos[2]++;
                    return success = true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return success = false;
                }
            case Dino.Tyrannosaurus:
                if (cash - 25 >= 0)
                {
                    cash = -25;
                    visitors = +10;
                    dinos[3]++;
                    if (tyrannosaurusDanger == false)
                    {
                        tyrannosaurusDanger = true;
                        danger--;
                    }
                    return success = true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return success = false;
                }
            case Dino.Velociraptor:
                if (cash - 5 <= 0)
                {
                    cash = -5;
                    visitors = +2;
                    dinos[1]++;
                    return success = true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return success = false;
                }
            default: Debug.Log("Dinosaure type not recognized"); return success = false; 
        }
    }

    bool addBooth(Booth booth) {
        switch (booth) {
            case Booth.Bathroom:
                booths[2]++;
                visitors = +3;
                cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                return success = true;
            case Booth.Casino:
                booths[3]++;
                cashPerTurn = +3;
                cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                return success = true;
            case Booth.Paleontologist:
                if (booths[5] == 0 && paleontologist == false)
                {
                    booths[5] = 1;
                    paleontologist = true;
                    cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                    return success = true;
                }
                else
                {
                    Debug.Log("déjà un kiosque de paléontologue");
                    return success = false;
                }
            case Booth.Restaurant:
                booths[0]++;
                visitors = +1;
                cashPerTurn = +2;
                cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                return success = true;
            case Booth.Security:
                booths[1]++;
                danger = danger++;
                cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                return success = true;
            case Booth.Spy:
                if (booths[4] == 0)
                {
                    booths[4] = 1;
                    spy = true;
                    cash = cash - 3; //aller chercher le officialPrice() au lieu du 3
                    return success = true;
                }
                else {
                    Debug.Log("il n'existe qu'un seul kiosque d'espionnage");
                    return success = false;
                }
            default:
                Debug.Log("Booth type not recognized"); return success = false;
        }
    }

    public void Spying() {
        //copier un dinosaure dans un parc adverse
        spy = false;
    }
}
