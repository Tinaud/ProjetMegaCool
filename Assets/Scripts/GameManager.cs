using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    enum Phase { Event, Income, Building, Breach, End };

    private bool diceFinished,
                 firstTurn,
                 isFinish;
    private Component[] tempList;
    private Dice diceScript;
    private Events eventManager;
    private GameObject dice,
                       intanciatedObject,
                       park;
    private int activePlayer,
                actualPhase,
                diceResult,
                playerNumber,
                turnNumber;
    private List<ParcManager> playerList = new List<ParcManager>();
    private string currentEvent;
    private Transform cameraPos;

	void Start () 
    {
        actualPhase = (int)Phase.Event;
        cameraPos = Camera.main.transform;
        eventManager = GetComponent<Events>();
        diceFinished = true;
        firstTurn = true; 
        isFinish = false;
        park = (GameObject)Resources.Load("Joueur");

        TestMultiBoard test = GetComponent<TestMultiBoard>();
        GameObject[] test2 = test.getBoard();
        Debug.Log(test2[1].GetComponent<ParcManager>().cash);
        for (int i = 0; i < playerNumber; i++)
        {
            Debug.Log("Player created! :D");
            //intanciatedObject = (GameObject)Instantiate(park, new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z + 10), Quaternion.identity);
            //intanciatedObject.transform.parent = transform;


        }

        tempList = GetComponentsInChildren<ParcManager>();

        foreach (ParcManager player in tempList)
            playerList.Add(player);

        for (int i = 0; i < playerList.Count; i++)
            playerList[i].setID(i + 1);

        StartCoroutine(gameTurn());
	}

    IEnumerator gameTurn()
    {
        while (turnNumber > 0)
        {
            switch (actualPhase)
            {
                case (int)Phase.Event:
                    Debug.Log("Event phase");
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
                    int eventNumber = eventManager.getEvent();

                    eventManager.restoreEvents(ref playerList);
                    eventManager.applyEventEffect(eventNumber, ref playerList);

                    actualPhase += firstTurn ? 2 : 1;
                    firstTurn = false;
                    break;

                case (int)Phase.Income:
                    foreach(ParcManager player in playerList)
                    {
                        player.cash += player.cashPerTurn;
                        player.cash += player.visitors; //à vérifier?
                    }

                    actualPhase++;
                    break;

                case (int)Phase.Building:
                    foreach (ParcManager player in playerList)
                    {
                        int buildNumber = (player.eventTwoBuild) ? 2 : 1;
                        for (int i = 0; i < buildNumber; i++ )
                            Debug.Log("Build Phase " + player.ID);
                    }

                    actualPhase++;
                    break;

                case (int)Phase.Breach:
                    foreach (ParcManager player in playerList)
                    {
                        int breachNumber = (player.eventTwoBreach) ? 2 : 1;
                        for (int i = 0; i < breachNumber; i++ )
                        {
                            Debug.Log("Dice part! " + player.ID);

                            switch(player.dangerLevel)
                            {
                                case ParcManager.Danger.Low:
                                    dice = (GameObject)Resources.Load("dice_12");
                                    break;
                                case ParcManager.Danger.Medium_low:
                                    dice = (GameObject)Resources.Load("dice_10");
                                    break;
                                case ParcManager.Danger.Medium:
                                    dice = (GameObject)Resources.Load("DiceBox");
                                    break;
                                case ParcManager.Danger.Medium_high:
                                    dice = (GameObject)Resources.Load("Dé6");
                                    break;
                                case ParcManager.Danger.High:
                                    dice = (GameObject)Resources.Load("dice_4");
                                    break;
                            }

                            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
                            {
                                diceFinished = false;
                                StartCoroutine(throwDice());
                                yield return new WaitUntil(() => diceFinished);

                                Debug.Log(diceResult);
                                if (diceResult == 1)
                                    player.Breach();
                            }
                        }                       
                    }

                    actualPhase++;
                    break;

                case (int)Phase.End:
                    actualPhase = 0;
                    turnNumber--;
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public IEnumerator throwDice()
    {
        intanciatedObject = (GameObject)Instantiate(dice, new Vector3(cameraPos.position.x + 2, cameraPos.position.y - 6, cameraPos.position.z - 2), Quaternion.identity);
        intanciatedObject.transform.parent = transform;

        diceScript = GetComponentInChildren<Dice>();

        yield return new WaitUntil(() => diceScript.isFinished);
        
        diceResult = diceScript.diceResult;
        diceFinished = true;
    }

    public void setInfos(int nbP, int nbT)
    {
        playerNumber = nbP;
        turnNumber = nbT;
    }

    public List<ParcManager> getPlayers()
    {
        return playerList;
    }
}