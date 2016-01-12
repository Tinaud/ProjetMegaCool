using UnityEngine;
using System.Collections;

public class Events : MonoBehaviour 
{
    public string[,] allEvents = new string[17, 3] { 
        { "Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.", "Endangered species", "1"}, 
		{ "Every player receive 10$!" , "Pay day!", "3"},
		{ "There are power outage in the parks, every player raise his danger level by 1 for this turn only.", "Power outage", "3"}, 
		{ "New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.", "Prevention program", "3"},
		{ "Every player throw 1d6 and that number is the number of new guests they get in their park.", "advertisement on cereal boxes", "2"},
		{ "Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.", "Mating season", "5"},
		{ "5 new guests visit your park!", "Spring Break!", "3"},
		{ "The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.", "Tax return", "5"},	
		{ "Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.", "King of the jungle", "2"},
		{ "Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.", "Proliferation", "5"},
        { "", "The mysterious men in white", "1"},
        { "", "Know-it-all Joe", "1"},
        { "Some school buses are visiting your park! You gain 5 new guests and you receive 5$.", "Summer camp", "3"},
        { "", "Accumulation of defecation", "3"},
        { "You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.", "Metals abundance", "6"},
        { "Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.", "Archaeological research : Triceratops", "3"},
        { "Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 5$ only for this turn.", "Archaeological research : Tyrannosaurus", "3"}};

	void Start () 
    {
	
	}
	
	void Update () 
    {
	
	}
}
