using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    enum Phase { Event, Income, Building, Breach, End };

    public GameObject prefab;
    public GameObject park;

    private bool isFinish,
                 diceFinished;
    private Component[] tempList;
    private Dice diceScript;
    private Events eventManager;
    private GameObject intanciatedObject;
    private int activePlayer,
                actualPhase,
                diceResult,
                turnNumber,
                playerNumber;
    private List<ParcManager> playerList = new List<ParcManager>();
    private string currentEvent;
    private Transform cameraPos, parent;

	void Start () 
    {
        actualPhase = (int)Phase.Event;
        cameraPos = Camera.main.transform;
        eventManager = GetComponent<Events>();
        parent = transform;
        isFinish = false;
        diceFinished = true;
        prefab = (GameObject)Resources.Load("Dé Prefab");
        park = (GameObject)Resources.Load("Joueur");

        for (int i = 0; i < playerNumber; i++)
        {
            Debug.Log("Player created! :D");
            intanciatedObject = (GameObject)Instantiate(park, new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z + 10), Quaternion.identity);
            intanciatedObject.transform.parent = parent;
        }

        tempList = GetComponentsInChildren<ParcManager>();

        foreach (ParcManager players in tempList)
            playerList.Add(players);

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
                    int test = eventManager.getEvent();
                    eventManager.applyEventEffect(test, ref playerList);
                    
                    actualPhase++;

                    break;
                case (int)Phase.Income:
                    for(int i = 0; i < playerNumber; i++)
                    {
                        playerList[i].cash += playerList[i].cashPerTurn;
                        playerList[i].cash += playerList[i].visitors; //à vérifier?
                    }

                    actualPhase++;
                    break;
                case (int)Phase.Building:
                    Debug.Log("Build Phase");
                    actualPhase++;
                    break;

                case (int)Phase.Breach:
                    for (int i = 0; i < playerNumber; i++)
                    {
                        Debug.Log("Dice part!");
                        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
                        {
                            diceFinished = false;
                            StartCoroutine(throwDice());
                            yield return new WaitUntil(() => diceFinished);

                            Debug.Log(diceResult);
                            if (diceResult == 1)
                                playerList[i].Breach();
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
        intanciatedObject = (GameObject)Instantiate(prefab, new Vector3(cameraPos.position.x + 2, cameraPos.position.y - 6, cameraPos.position.z - 2), Quaternion.identity);
        intanciatedObject.transform.parent = parent;

        diceScript = GetComponentInChildren<Dice>();

        yield return new WaitWhile(() => diceScript.isSpinning);

        diceFinished = true;
        diceResult = diceScript.diceResult;
    }

    public void setInfos(int nbP, int nbT)
    {
        playerNumber = nbP;
        turnNumber = nbT;
    }
}