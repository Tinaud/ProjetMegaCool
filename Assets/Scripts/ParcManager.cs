using UnityEngine;
using System.Collections;

public class ParcManager : MonoBehaviour {
    public int cage;
    public int cash;
    public int visitors;
    private enum Danger {High, Medium_high, Medium, Medium_low, Low};
    private enum Booth {Restaurant, Security, Bathroom, Casino, Spy, Paleontologist};
    private enum Dino { Brontosaurus, Velociraptor, Triceratops, Tyrannosaurus };
    private Dino dinosaurs;
    private Booth booth;
    private Danger danger;
    public bool success;
    private int[] dinos;
    private int[] booths;
    private bool tyrannosaurusDanger = false;
    public bool paleontologist = false;

    // Use this for initialization
    void Start () {

        dinos = new int[] { 0, 0, 0, 0 };
        booths = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 1;
        cash = 15;
        visitors = 0;
        danger = Danger.Medium;

	
	}
	
	// Update is called once per frame
	void Update () {

        if (dinos[3] > 0 && tyrannosaurusDanger == false)
        {
            
            tyrannosaurusDanger = true;                       
        }
    }

    void addDino(Dino dinosaurs) {
        switch (dinosaurs) {
            case Dino.Brontosaurus:
                dinos[0]++;
                break;
            case Dino.Triceratops:
                dinos[2]++;
                break;
            case Dino.Tyrannosaurus:
                dinos[3]++;
                if (tyrannosaurusDanger == false)
                {
                    tyrannosaurusDanger = true;
                    danger--;
                }
                break;
            case Dino.Velociraptor:
                dinos[1]++;
                break;
        }
    }

    bool addBooth(Booth booth) {
        switch (booth) {
            case Booth.Bathroom:
                booths[2]++;
                return success = true;
            case Booth.Casino:
                booths[3]++;
                return success = true;
            case Booth.Paleontologist:
                if (booths[5] == 0 && paleontologist == false)
                {
                    booths[5] = 1;
                    paleontologist = true;
                    return success = true;
                }
                else
                {
                    Debug.Log("déjà un kiosque de paléontologue");
                    return success = false;
                }
            case Booth.Restaurant:
                booths[0]++;
                return success = true;
            case Booth.Security:
                booths[1]++;
                return success = true;
            case Booth.Spy:
                if (booths[4] == 0)
                {
                    booths[4] = 1;
                    return success = true;
                }
                else {
                    Debug.Log("il n'existe qu'un seul kiosque d'espionnage");
                    return success = false;
                }
            case default:
                return success = false;
        }
    }
}
