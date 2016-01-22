using UnityEngine;
using System.Collections;

public class ParcManager : MonoBehaviour {
    public int cage;
    public int cash;
    public int visitors;
    public int cashPerTurn;
    public bool paleontologist;
    public bool spy;
    public int playerIdentity;
    private enum Danger { High, Medium_high, Medium, Medium_low, Low };
    private enum Booth { Restaurant, Security, Bathroom, Casino, Spy, Paleontologist };
    private enum Dino { Brontosaurus, Velociraptor, Triceratops, Tyrannosaurus };
    private Dino dinosaurs;
    private Booth booth;
    public Danger danger;
    private int[] dinos;
    private int[] booths;

    void Awake () {

        dinos = new int[] { 0, 0, 0, 0 };
        booths = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 1;
        cash = 15;
        visitors = 0;
        danger = Danger.Medium;
        cashPerTurn = 0;
        paleontologist = false;
        spy = false;
    }
	
    bool addDino(Dino dinosaurs) // trouver un moyen d'aller chercher le prix des dinosaures directement dans l'objet du dinosaure.
    { 
        switch (dinosaurs) 
        {
            case Dino.Brontosaurus:
                if (cash >= 2)
                {
                    visitors += 1;
                    cash -= 2;
                    dinos[0]++;
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }
            case Dino.Triceratops:
                if (cash >= 5)
                {
                    visitors += 5;
                    cash -= 5;
                    dinos[2]++;
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }
            case Dino.Tyrannosaurus:
                if (cash >= 25)
                {
                    cash -= 25;
                    visitors += 10;
                    dinos[3]++;
                    danger--;
                    return true;
                }
                else 
                {
                    Debug.Log("Not enough funds!");
                    return false;
                }
            case Dino.Velociraptor:
                if (cash >= 5)
                {
                    cash -= 5;
                    visitors += 2;
                    dinos[1]++;
                    return true;
                }
                else {
                    Debug.Log("Not enough funds!");
                    return false;
                }
            default: Debug.Log("Dinosaure type not recognized"); return false; 
        }
    }

    bool addBooth(Booth booth) 
    {
        switch (booth) 
        {
            case Booth.Restaurant:
                booths[0]++;
                visitors += 1;
                cashPerTurn += 2;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
            case Booth.Security:
                booths[1]++;
                danger++;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
            case Booth.Bathroom:
                booths[2]++;
                visitors += 3;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
            case Booth.Casino:
                booths[3]++;
                cashPerTurn += 3;
                cash -= 3; //aller chercher le officialPrice() au lieu du 3
                return true;
            case Booth.Spy:
                if (booths[4] == 0)
                {
                    booths[4] = 1;
                    spy = true;
                    cash -= 3; //aller chercher le officialPrice() au lieu du 3
                    return true;
                }
                else
                {
                    Debug.Log("il n'existe qu'un seul kiosque d'espionnage");
                    return false;
                }
            case Booth.Paleontologist:
                if (booths[5] == 0 && paleontologist == false)
                {
                    booths[5] = 1;
                    paleontologist = true;
                    cash -= 3; //aller chercher le officialPrice() au lieu du 3
                    return true;
                }
                else
                {
                    Debug.Log("déjà un kiosque de paléontologue");
                    return false;
                }
            default:
                Debug.Log("Booth type not recognized"); return false;
        }
    }

    public void Spying() 
    {
        //copier un dinosaure dans un parc adverse
        spy = false;
    }

    public void Breach()
    {
        Debug.Log("BREACH!!!");
    }
}
