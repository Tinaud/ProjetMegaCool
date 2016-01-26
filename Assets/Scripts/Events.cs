using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Events : MonoBehaviour 
{
    public List<int> allEvents = new List<int>();

    private GameManager gameManager;

	void Awake () 
    {
        gameManager = GetComponent<GameManager>();
        /*0allEvents.Add("Endangered species,Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur."); 
		1allEvents.Add( "Pay day!,Every player receive 10$!");
        1allEvents.Add( "Pay day!,Every player receive 10$!");
        1allEvents.Add( "Pay day!,Every player receive 10$!");
		2allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
        2allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
        2allEvents.Add( "Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only."); 
		3allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
        3allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
        3allEvents.Add( "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
		4allEvents.Add( "advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
        4allEvents.Add( "advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
		5allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
		5allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        5allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        5allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        5allEvents.Add( "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
        6allEvents.Add( "Spring Break!,5 new guests visit your park!");
        6allEvents.Add( "Spring Break!,5 new guests visit your park!");
        6allEvents.Add( "Spring Break!,5 new guests visit your park!");
		7allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");	
        7allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        7allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        7allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
        7allEvents.Add( "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");		
		8allEvents.Add( "King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
		8allEvents.Add( "King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
        9allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        9allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        9allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        9allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        9allEvents.Add( "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
        10allEvents.Add( "The mysterious men in white,A mysterious man in a white suit is interested by your growing business. Every players may choose a free booth for his park! Starting with the player which has the least visitors, every player build one of the face-up booth. If there is a tie, you proceed clock-wise from the active first player. The event ends when all the players have built a free booth or there is no more face-up booths available. Three new face-up booths are revealed.");
        11allEvents.Add( "Know-it-all Joe,A mad know-it-all Joe enters your park angry. He is upset because, he says, you don't treat your dinosaurs respectfully. He then proceed to sabotage one of your cage this turn. You suffer immediately the effect of a breach in your park (but you will skip the breach phase this turn). Ignore this event if you have a paleontologist booth in your park or if you have no dinosaurs in your park.");
        12allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        12allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        12allEvents.Add( "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
        13allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        13allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        13allEvents.Add( "Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        14allEvents.Add( "Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
        15allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        15allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        15allEvents.Add( "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
        16allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
        16allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
        16allEvents.Add( "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
	*/
        allEvents.Add(0);
        allEvents.Add(1); allEvents.Add(1); allEvents.Add(1);
        allEvents.Add(2); allEvents.Add(2); allEvents.Add(2);
        allEvents.Add(3); allEvents.Add(3); allEvents.Add(3);
        allEvents.Add(4); allEvents.Add(4);
        allEvents.Add(5); allEvents.Add(5); allEvents.Add(5); allEvents.Add(5); allEvents.Add(5);
        allEvents.Add(6); allEvents.Add(6); allEvents.Add(6);
        allEvents.Add(7); allEvents.Add(7); allEvents.Add(7); allEvents.Add(7); allEvents.Add(7);
        allEvents.Add(8); allEvents.Add(8);
        allEvents.Add(9); allEvents.Add(9); allEvents.Add(9); allEvents.Add(9); allEvents.Add(9);
        allEvents.Add(10);
        allEvents.Add(11);
        allEvents.Add(12); allEvents.Add(12); allEvents.Add(12);
        allEvents.Add(13); allEvents.Add(13); allEvents.Add(13);
        allEvents.Add(14); allEvents.Add(14); allEvents.Add(14); allEvents.Add(14); allEvents.Add(14); allEvents.Add(14);
        allEvents.Add(15); allEvents.Add(15); allEvents.Add(15);
        allEvents.Add(16); allEvents.Add(16); allEvents.Add(16);

    }

    public int getEvent()
    {
        int patate = Random.Range(0, allEvents.Count);
        int eventToSend = allEvents[patate];
        allEvents.RemoveAt(patate);

        return eventToSend;
    }

    public void applyEventEffect(int eventNumber, ref List<ParcManager> playerList)
    {
        switch(eventNumber)
        {
            case 0:
                Debug.Log("Endangered species,Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
                break;
            case 1:
                Debug.Log("Pay day!,Every player receive 10$!");
                foreach (ParcManager player in playerList)
                    player.cash += 10;
                break;
            case 2:
                Debug.Log("Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only.");
                foreach (ParcManager player in playerList)
                    player.danger++;
                break;
            case 3:
                Debug.Log("Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
                foreach (ParcManager player in playerList)
                    player.danger--;
                break;
            case 4:
                Debug.Log("advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
                break;
            case 5:
                Debug.Log("Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
                break;
            case 6:
                Debug.Log("Spring Break!,5 new guests visit your park!");
                foreach (ParcManager player in playerList)
                    player.visitors += 5;
                break;
            case 7:
                Debug.Log("Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");
                break;
            case 8:
                Debug.Log("King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
                foreach (ParcManager player in playerList)
                    if(!player.paleontologist || !player.noDinosaurs())
                        player.visitors -= 5;
                break;
            case 9:
                Debug.Log("Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
                break;
            case 10:
                Debug.Log("The mysterious men in white,A mysterious man in a white suit is interested by your growing business. Every players may choose a free booth for his park! Starting with the player which has the least visitors, every player build one of the face-up booth. If there is a tie, you proceed clock-wise from the active first player. The event ends when all the players have built a free booth or there is no more face-up booths available. Three new face-up booths are revealed.");
                break;
            case 11:
                Debug.Log("Know-it-all Joe,A mad know-it-all Joe enters your park angry. He is upset because, he says, you don't treat your dinosaurs respectfully. He then proceed to sabotage one of your cage this turn. You suffer immediately the effect of a breach in your park (but you will skip the breach phase this turn). Ignore this event if you have a paleontologist booth in your park or if you have no dinosaurs in your park.");
                foreach (ParcManager player in playerList)
                    if(!player.paleontologist)
                        player.Breach();
                break;
            case 12:
                Debug.Log("Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
                foreach (ParcManager player in playerList)
                {
                    player.visitors += 5;
                    player.cash += 5;
                }
                break;
            case 13:
                Debug.Log("Accumulation of defecation,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
                break;
            case 14:
                Debug.Log("Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
                break;
            case 15:
                Debug.Log("Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
                break;
            case 16:
                Debug.Log("Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
                break;
        }
    }
}
