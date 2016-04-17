using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Booths : MonoBehaviour {

    public List<int> allBooths = new List<int>();
    public List<int> faceUpBooths = new List<int>();

    private GameManager gameManager;

    void Start()
    {
        /*
        0allBooths.Add("Restaurant,This burger joint adds 1 visitor to your parc and generate 2 $ per turn.");
        0allBooths.Add("Restaurant,This sushi bar adds 1 visitor to your parc and generate 2 $ per turn.");
        0allBooths.Add("Restaurant,This pizza place adds 1 visitor to your parc and generate 2 $ per turn.");
        0allBooths.Add("Restaurant,This ice cream stand adds 1 visitor to your parc and generate 2 $ per turn.");
        0allBooths.Add("Restaurant,This cotton candy store adds 1 visitor to your parc and generate 2 $ per turn.");
        1allBooths.Add("Security, Raoul the security guard is securing your park against dinosaur breaches.");
        1allBooths.Add("Security, John the security guard is securing your park against dinosaur breaches.");
        1allBooths.Add("Security, Fred the security guard is securing your park against dinosaur breaches.");
        1allBooths.Add("Security, Bob the security guard is securing your park against dinosaurs breach.");
        1allBooths.Add("Security, Dwayne the security guard is securing your park against dinosaurs breach.");
        2allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        2allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        2allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        2allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        2allBooths.Add("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
        3allBooths.Add("Casino, This air hockey table helps you generate 3 $ per turn.");
        3allBooths.Add("Casino, This photo booth helps you generate 3 $ per turn.");
        3allBooths.Add("Casino, This dancing arcade table helps you generate 3 $ per turn.");
        3allBooths.Add("Casino, These bumping cars helps you generate 3 $ per turn.");
        3allBooths.Add("Casino, This shooting arcade helps you generate 3 $ per turn.");
        4allBooths.Add("Spy, You have recruited ingenious spies to clone one of your enemy's dinosaur (single use effect).");
        5allBooths.Add("Paleontologist, You have recruited Grant the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        5allBooths.Add("Paleontologist, You have recruited Sattler the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        5allBooths.Add("Paleontologist, You have recruited Hammond the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        5allBooths.Add("Paleontologist, You have recruited Malcom the wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
        */

        allBooths.Add(0); allBooths.Add(0); allBooths.Add(0); allBooths.Add(0); allBooths.Add(0);
        allBooths.Add(1); allBooths.Add(1); allBooths.Add(1); allBooths.Add(1); allBooths.Add(1);
        allBooths.Add(2); allBooths.Add(2); allBooths.Add(2); allBooths.Add(2); allBooths.Add(2);
        allBooths.Add(3); allBooths.Add(3); allBooths.Add(3); allBooths.Add(3); allBooths.Add(3);
        allBooths.Add(4);
        allBooths.Add(5); allBooths.Add(5); allBooths.Add(5); allBooths.Add(5); allBooths.Add(5);
    }

    // Update is called once per frame
    public int getBooth()
    {
        int patate = Random.Range(0, allBooths.Count);
        int boothToSend = allBooths[patate];
        allBooths.RemoveAt(patate);

        return boothToSend;
    }

    public List<int> getFaceUpBooths(int nb)
    {
        for (int i = 0; i < nb; i++)
        {
            int patate = Random.Range(0, allBooths.Count);
            int boothToSendFaceUp = allBooths[patate];
            allBooths.RemoveAt(patate);

            faceUpBooths.Add(boothToSendFaceUp);
        }

        return faceUpBooths;
    }

    public BaseBooth boothsInfo(int boothNumber)
    {
        switch (boothNumber)
        {
            case 0:
                Debug.Log("Restaurant,This restaurant adds 1 visitor to your parc and generate 2 $ per turn.");
                Restaurant restaurant = new Restaurant();
                restaurant.turnOver();
                return restaurant;
            case 1:
                Debug.Log("Security, This guard is securing your park against dinosaur breaches.");
                Security security = new Security();
                security.turnOver();
                return security;                
            case 2:
                Debug.Log("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
                Bathroom bathroom = new Bathroom();
                bathroom.turnOver();
                return bathroom;
            case 3:
                Debug.Log("Casino, This arcade helps you generate 3 $ per turn.");
                Casino casino = new Casino();
                casino.turnOver();
                return casino;
            case 4:
                Debug.Log("Spy, You have recruited ingenious spies to clone one of your enemy's dinosaur (single use effect).");
                Spy spy = new Spy();
                spy.turnOver();
                return spy;
            case 5:
                Debug.Log("Paleontologist, You have recruited a wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
                Paleontologist paleontologist = new Paleontologist();
                paleontologist.turnOver();
                return paleontologist;
            default:
                Debug.Log("invalid boothId");
                return null;
        }
    }

}
