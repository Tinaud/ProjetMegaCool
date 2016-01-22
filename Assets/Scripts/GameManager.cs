using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    enum Phase { Event, Income, Building, Breach, End };

    public GameObject prefab;
    public GameObject park;

    private bool isFinish;
    private Component[] tempList;
    private Dice diceScript;
    private Events eventManager;
    private GameObject intanciatedObject;
    private int activePlayer,
                actualPhase,
                nbTurns,
                playerNumber;
    private List<ParcManager> playerList = new List<ParcManager>();
    private string currentEvent;
    private Transform cameraPos, parent;

	void Start () 
    {
        actualPhase = (int)Phase.Event;
        cameraPos = Camera.main.transform;
        eventManager = GetComponent<Events>();
        playerNumber = 4;//GetComponent<MenuPlayers>().NbPlayer;
        nbTurns = 10;// GetComponent<MenuPlayers>().NbTurns;
        parent = transform;
        isFinish = false;

        for (int i = 0; i < playerNumber; i++)
        {
            Debug.Log("Player created! :D");
            intanciatedObject = (GameObject)Instantiate(park, new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z + 10), Quaternion.identity);
            intanciatedObject.transform.parent = parent;
        }

        tempList = GetComponentsInChildren<ParcManager>();

        foreach (ParcManager players in tempList)
            playerList.Add(players);

        StartCoroutine(gameTurn());
	}

    IEnumerator gameTurn()
    {
        while (nbTurns > 0)
        {
            switch (actualPhase)
            {
                case (int)Phase.Event:
                    Debug.Log("Event phase");
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
                    int test = eventManager.getEvent();
                    eventManager.applyEventEffect(test, ref playerList);
                    Debug.Log(currentEvent);
                    
                    actualPhase++;

                    break;
                case (int)Phase.Income:
                    for(int i = 0; i < playerNumber; i++)
                        playerList[i].cash += playerList[i].cashPerTurn;
  
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
                            intanciatedObject = (GameObject)Instantiate(prefab, new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z + 10), Quaternion.identity);
                            intanciatedObject.transform.parent = parent;

                            diceScript = GetComponentInChildren<Dice>();

                            yield return new WaitWhile(() => diceScript.isSpinning);
                            Debug.Log(diceScript.diceResult);
                            if (diceScript.diceResult == 1)
                                playerList[i].Breach();
                        }
                    }
                    actualPhase++;
                    break;

                case (int)Phase.End:
                    actualPhase = 0;
                    nbTurns--;
                    break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
}