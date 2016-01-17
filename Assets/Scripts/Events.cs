using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Events : MonoBehaviour 
{
    public List<string> allEvents = new List<string>();

	void Start () 
    {
        allEvents.Add("Endangered species,Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur."); 
		allEvents.Add( "Pay day!,Every player receive 10$!");
        allEvents.Add( "Pay day!,Every player receive 10$!");
        allEvents.Add( "Pay day!,Every player receive 10$!");
		allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
        allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
        allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
		allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
        allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
        allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
		allEvents.Add( "advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
        allEvents.Add( "advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
		allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
		allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        allEvents.Add( "Spring Break!,5 new guests visit your park!");
        allEvents.Add( "Spring Break!,5 new guests visit your park!");
        allEvents.Add( "Spring Break!,5 new guests visit your park!");
		allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");	
        allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
		allEvents.Add( "King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
		allEvents.Add( "King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
        allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        allEvents.Add( "The mysterious men in white,A mysterious man in a white suit is interested by your growing business. Every players may choose a free booth for his park! Starting with the player which has the least visitors, every player build one of the face-up booth. If there is a tie, you proceed clock-wise from the active first player. The event ends when all the players have built a free booth or there is no more face-up booths available. Three new face-up booths are revealed.");
        allEvents.Add( "Know-it-all Joe,A mad know-it-all Joe enters your park angry. He is upset because, he says, you don't treat your dinosaurs respectfully. He then proceed to sabotage one of your cage this turn. You suffer immediately the effect of a breach in your park (but you will skip the breach phase this turn). Ignore this event if you have a paleontologist booth in your park or if you have no dinosaurs in your park.");
        allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
        allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
        allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
	}
	
	void Update () 
    {
	
	}

    public string getEvent()
    {
        int patate = Random.Range(0, allEvents.Count);
        string eventToSend = allEvents[patate];
        allEvents.RemoveAt(patate);

        return eventToSend;
    }
}
