﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Booths : MonoBehaviour {

    public List<int> allBooths = new List<int>();
    public List<int> faceUpBooths = new List<int>();

    private GameManager gameManager;

    string[] boothInfo;

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
        string boothName;
        string boothDescription;

        switch (boothNumber)
        {
            case 0:
                Debug.Log("Restaurant,This restaurant adds 1 visitor to your parc and generate 2 $ per turn.");
                boothInfo = "Restaurant,This restaurant adds 1 visitor to your parc and generate 2 $ per turn.".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Restaurant restaurant = new Restaurant();
                return restaurant;
            case 1:
                Debug.Log("Security, This guard is securing your park against dinosaur breaches.");
                boothInfo = "Security, This guard is securing your park against dinosaur breaches.".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Security security = new Security();
                return security;                
            case 2:
                Debug.Log("Bathroom, This clean new bathroom brings 3 new visitors around your park.");
                boothInfo = "Bathroom, This clean new bathroom brings 3 new visitors around your park.".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Bathroom bathroom = new Bathroom();
                return bathroom;
            case 3:
                Debug.Log("Casino, This arcade helps you generate 3 $ per turn.");
                boothInfo = "Casino, This arcade helps you generate 3 $ per turn.".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Casino casino = new Casino();
                return casino;
            case 4:
                Debug.Log("Spy, You have recruited ingenious spies to clone one of your enemy's dinosaur (single use effect).");
                boothInfo = "Spy, You have recruited ingenious spies to clone one of your enemy's dinosaur (single use effect).".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Spy spy = new Spy();
                return spy;
            case 5:
                Debug.Log("Paleontologist, You have recruited a wise paleontologist! He will help you counter some unfortunate events that could ruin your park.");
                boothInfo = "Paleontologist, You have recruited a wise paleontologist! He will help you counter some unfortunate events that could ruin your park.".Split(',');
                boothName = boothInfo[0];
                boothDescription = boothInfo[1];
                Paleontologist paleontologist = new Paleontologist();
                return paleontologist;
            default:
                Debug.Log("invalid boothId");
                return null;
        }
    }

}
