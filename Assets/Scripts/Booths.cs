using UnityEngine;
using System.Collections;

public class Booths : MonoBehaviour {

    public List<string> allBooths = new List<string>();

    void Start()
    {
        allBooths.Add("Restaurant,This Burger Joint adds 1 visitor to your parc and generate 2 $ per turn.");
        allBooths.Add("Restaurant,This Sushi bar adds 1 visitor to your parc and generate 2 $ per turn.");
        allBooths.Add("Restaurant,This Pizza place adds 1 visitor to your parc and generate 2 $ per turn.");
        allBooths.Add("Restaurant,This Ice cream stand adds 1 visitor to your parc and generate 2 $ per turn.");
        allBooths.Add("Restaurant,This Cotton candy store adds 1 visitor to your parc and generate 2 $ per turn.");
        allBooths.Add("Security, Raoul the security guard is securing your park against dinosaur breaches.");
        allBooths.Add("Security, Gregory the security guard is securing your park against dinosaur breaches.");
        allBooths.Add("Security, Fred the security guard is securing your park against dinosaur breaches.");
        allBooths.Add("Security, Bob the security guard is securing your park against dinosaurs breach.");
        allBooths.Add("Security, Dwayne the security guard is securing your park against dinosaurs breach.");
        allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        allBooths.Add("Casino, This Pinball Machine helps you generate 3 $ per turn.");
        allBooths.Add("Casino, This Photo booth helps you generate 3 $ per turn.");
        allBooths.Add("Casino, This air Hockey table helps you generate 3 $ per turn.");
        allBooths.Add("Casino, This Driving arcade helps you generate 3 $ per turn.");
        allBooths.Add("Casino, This Shooting arcade helps you generate 3 $ per turn.");
        allBooths.Add("Spy, You have recruited ingenious spies to copy one of your enemy's dinosaur (single use effect).");
        allBooths.Add("Paleontologist, You have recruited Grant the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        allBooths.Add("Paleontologist, You have recruited Sattler the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        allBooths.Add("Paleontologist, You have recruited Hammond the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        allBooths.Add("Paleontologist, You have recruited Malcom the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
