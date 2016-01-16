using UnityEngine;
using System.Collections;

public class ParcManager : MonoBehaviour {
    public int cage;
    public int cash;
    public int visitors;
    private enum Danger {High, Medium_high, Medium, Medium_low, Low};
    private Danger danger;
    private int[] dinos;
    private int[] booth;
    private bool tyrannosaurusDanger = false;
    public bool paleontologist = false;

    // Use this for initialization
    void Start () {

        dinos = new int[] { 0, 0, 0, 0 };
        booth = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 1;
        cash = 15;
        visitors = 0;
        danger = Danger.Medium;

	
	}
	
	// Update is called once per frame
	void Update () {

        if (dinos[3] > 0 && tyrannosaurusDanger == false)
        {
            danger --;
            tyrannosaurusDanger = true;                       
        }

        if (booth[5] > 0 && paleontologist == false)
            paleontologist = true;

    }
}
