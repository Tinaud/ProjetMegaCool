using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Events : MonoBehaviour 
{
    public List<int> allEvents = new List<int>();

    private GameManager gameManager;
    string[] eventDescription;

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
        13allEvents.Add( "Big pile of poop,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        13allEvents.Add( "Big pile of poop,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
        13allEvents.Add( "Big pile of poop,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
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
        GameObject EventDisplay = GameObject.Find("GameInterface");
        Text eventInfo = (Text) EventDisplay.GetComponent("Text");
        
        string eventTitle;
        string eventText;
        switch(eventNumber)
        {
            case 0:
                //
                Debug.Log("Endangered species,Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
                eventDescription = "Endangered species,Scientists want to help endangered species! The player that pocess the most dinosaur loses his most expensive (only one). If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                break;
            case 1:
                Debug.Log("Pay day!,Every player receive 10$!");
                eventDescription = "Pay day!,Every player receive 10$!".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    player.cash += 10;
                break;
            case 2:
                Debug.Log("Power outage,There are power outage in the parks, every player raise his danger level by 1 for this turn only.");
                eventDescription = "Power outage,There are power outage in the parks; every player raise his danger level by 1 for this turn only.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                {
                    player.danger--;
                    player.eventDangerUp = true;
                }
                break;
            case 3:
                Debug.Log("Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.");
                eventDescription = "Prevention program,New tranquilizing weapons are in sale! Every player drop his danger level by 1 for this turn only.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                {
                    player.danger++;
                    player.eventDangerDown = true;
                }
                break;
            case 4:
                Debug.Log("Advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.");
                eventDescription = "Advertisement on cereal boxes,Every player throw 1d6 and that number is the number of new guests they get in their park.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                {
                    StartCoroutine(throwDice(player));
                }
                break;
            case 5:
                Debug.Log("Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die, you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.");
                eventDescription = "Mating season,Dinosaurs enter in their mating season! You must do two breaches this turn. If you get a 1 on both die; you suffer the effects of two breaches. Ignore this event if you have a paleontologist booth in your park.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    if (!player.paleontologist)
                        player.eventTwoBreach = true;
                break;
            case 6:
                Debug.Log("Spring Break!,5 new guests visit your park!");
                eventDescription = "Spring Break!,5 new guests visit your park!".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    player.visitors += 5;
                break;
            case 7:
                Debug.Log("Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.");
                eventDescription = "Tax return,The government loves you! You can have two actions this turn for the building phase. You only have to do the breach once.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    player.eventTwoBuild = true;
                break;
            case 8:
                Debug.Log("King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.");
                eventDescription = "King of the jungle,Your dinosaurs are making a roar contest and your guests are afraid! Everyone lose 5 guests in their park. Ignore this event if you have a paleontologist booth in your park.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    if(!player.paleontologist || !player.noDinosaurs())
                        player.visitors -= 5;
                break;
            case 9:
                //
                Debug.Log("Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.");
                eventDescription = "Proliferation,Your dinosaurs will have new born soon! You can buy a second dinosaur only for this turn if you already have that same dinosaur in your park.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                break;
            case 10:
                //
                Debug.Log("The mysterious men in white,A mysterious man in a white suit is interested by your growing business. Every players may choose a free booth for his park! Starting with the player which has the least visitors, every player build one of the face-up booth. If there is a tie, you proceed clock-wise from the active first player. The event ends when all the players have built a free booth or there is no more face-up booths available. Three new face-up booths are revealed.");
                eventDescription = "The mysterious men in white,A mysterious man in a white suit is interested by your growing business. Every players may choose a free booth for his park! Starting with the player which has the least visitors, every player build one of the face-up booth. If there is a tie; you proceed clock-wise from the active first player. The event ends when all the players have built a free booth or there is no more face-up booths available. Three new face-up booths are revealed.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                break;
            case 11:
                Debug.Log("Know-it-all Joe,A mad know-it-all Joe enters your park angry. He is upset because, he says, you don't treat your dinosaurs respectfully. He then proceed to sabotage one of your cage this turn. You suffer immediately the effect of a breach in your park (but you will skip the breach phase this turn). Ignore this event if you have a paleontologist booth in your park or if you have no dinosaurs in your park.");
                eventDescription = "Know-it-all Joe,A mad know-it-all Joe enters your park angry. He is upset because you don't treat your dinosaurs respectfully. He then proceed to sabotage one of your cage this turn. You suffer immediately the effect of a breach in your park (but you will skip the breach phase this turn). Ignore this event if you have a paleontologist booth in your park or if you have no dinosaurs in your park.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    if(!player.paleontologist)
                        player.Breach();
                break;
            case 12:
                Debug.Log("Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.");
                eventDescription = "Summer camp,Some school buses are visiting your park! You gain 5 new guests and you receive 5$.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                {
                    player.visitors += 5;
                    player.cash += 5;
                }
                break;
            case 13:
                //
                Debug.Log("Big pile of poop,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals, every of them must do this event. Ignore this event if no one have dinosaur.");
                eventDescription = "Big pile of poop,The player that have the most dinosaurs in his park is incapable to clean every enclosure. His guests are disgusted and 3 of them leave his park. If two or more players are equals; every of them must do this event. Ignore this event if no one have dinosaur.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                break;
            case 14:
                //
                Debug.Log("Metals abundance,You can build as many cages as you want during this turn, as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.");
                eventDescription = "Metals abundance,You can build as many cages as you want during this turn as long as you have the money and space in your park! You can then continue the normal building phase by buying something else.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                break;
            case 15:
                Debug.Log("Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.");
                eventDescription = "Archaeological research : Triceratops,Spectacular discoveries have happened in the archaeological world. Triceratops's price is reduced by 5$ only for this turn.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    player.eventTriceratopPriceDown = true;
                break;
            case 16:
                Debug.Log("Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.");
                eventDescription = "Archaeological research : Tyrannosaurus,Spectacular discoveries have happened in the archaeological world. Tyrannosaurus's price is reduced by 10$ only for this turn.".Split(',');
                eventTitle = eventDescription[0];
                eventText = eventDescription[1];
                eventInfo.text = "Event : " + eventTitle + "\n" + eventText;
                foreach (ParcManager player in playerList)
                    player.eventTyrannosaurusPriceDown = true;
                break;
        }
    }

    public void restoreEvents(ref List<ParcManager> playerList)
    {
        foreach(ParcManager player in playerList)
        {
            player.eventTwoBreach = false;
            player.eventTwoBuild = false;
            player.eventTriceratopPriceDown = false;
            player.eventTyrannosaurusPriceDown = false;

            if(player.eventDangerUp)
            {
                player.eventDangerUp = false;
                player.danger++;
            }

            if (player.eventDangerDown)
            {
                player.eventDangerDown = false;
                player.danger--;
            }
        }
    }

    public IEnumerator throwDice(ParcManager player)
    {
        GameObject dice = (GameObject)Resources.Load("Dé6");
        Transform cameraPos = Camera.main.transform;

        GameObject intanciatedObject = (GameObject)Instantiate(dice, new Vector3(cameraPos.position.x + 2, cameraPos.position.y - 6, cameraPos.position.z - 2), Quaternion.identity);
        intanciatedObject.transform.parent = transform;

        Dice diceScript = GetComponentInChildren<Dice>();

        yield return new WaitUntil(() => diceScript.isFinished);

        player.visitors += diceScript.diceResult;
    }
}
