using UnityEngine;
using System.Collections;

public class ParcManager : MonoBehaviour {
    public int cage;
    public int cash;
    public int visitors;
    
    // Use this for initialization
    void Start () {

        int[] dinos = new int[] { 0, 0, 0, 0 };
        int[] booth = new int[] { 0, 0, 0, 0, 0, 0 };
        cage = 1;
        cash = 15;
        visitors = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
