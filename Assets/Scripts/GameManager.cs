using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    enum Phase { Event, Income, Building, Breach, End };

    private bool diceFinished,
                 firstTurn,
                 isFinish,
                 panelFound;
    private Component[] tempList;
    private Events eventManager;
    private GameObject board,
                       diceBox,
                       instanciatedObject,
                       panel,
                       park;
    private int activePlayer,
                actualPhase,
                diceResult,
                playerNumber,
                turnNumber;
    public List<ParcManager> playerList = new List<ParcManager>();
    private string currentEvent;
    private Transform cameraPos;
    private Booths BoothInfo;
    public List<BaseBooth> faceUpBooths = new List<BaseBooth>();

    void Start () 
    {
        actualPhase = (int)Phase.Event;
        cameraPos = Camera.main.transform;
        eventManager = GetComponent<Events>();
        BoothInfo = GetComponent<Booths>();
        Debug.Log(BoothInfo);
        diceFinished = true;
        firstTurn = true; 
        isFinish = false;
        park = (GameObject)Resources.Load("Joueur");
        panelFound = false;
        board = GameObject.Find("Board");
        tempList = board.GetComponentsInChildren<ParcManager>();
        faceUpBooths = BoothInfo.getFaceUpBooths(3);


        for (int i = 0; i < playerNumber; i++)
        {
            Debug.Log("Player created! :D");

            instanciatedObject = (GameObject)Instantiate(park, new Vector3(cameraPos.position.x + 2, cameraPos.position.y - 6, cameraPos.position.z - 2), Quaternion.identity);
            instanciatedObject.transform.parent = board.transform;
            instanciatedObject.name = "Player_" + i;

            playerList.Add(instanciatedObject.GetComponent<ParcManager>());
            playerList[i].setID(i + 1);
        }

        StartCoroutine(gameTurn());
	}

    IEnumerator gameTurn()
    {
        yield return new WaitWhile(() => this.GetComponent<MenuPlayers>().playable);

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

                    int boothsUp = faceUpBooths.Count;
                    Debug.Log("boothsUp : " + boothsUp);
                    if (boothsUp != 3)
                    {
                        int toTurn = 3 - boothsUp;
                        faceUpBooths =  BoothInfo.getFaceUpBooths(toTurn);
                    }

                    actualPhase += firstTurn ? 2 : 1;
                    firstTurn = false;
                    break;

                case (int)Phase.Income:
                    foreach(ParcManager player in playerList)
                    {
                        player.CashMoney += player.cashPerTurn;
                        player.CashMoney += player.visitors; //à vérifier?
                    }

                    actualPhase++;
                    break;

                case (int)Phase.Building:
                    foreach (ParcManager player in playerList)
                    {
                        int buildNumber = (player.eventTwoBuild) ? 2 : 1;
                        GetComponentInChildren<Player_options>().playerNo = player.ID - 1;
                        for (int i = 0; i < buildNumber; i++ )
                        {
                            Debug.Log("Build Phase " + player.ID);
                            panel.SetActive(true);
                            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                            panel.SetActive(false);
                            yield return new WaitForSeconds(2f);
                        } 
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
                            diceBox = (GameObject)Resources.Load("DiceBox");

                            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.A));
                            {
                                diceFinished = false;
                                StartCoroutine(throwDice(player));
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

    public IEnumerator throwDice(ParcManager player)
    {
        NewBehaviourScript diceScript = null;
        string name;
        GameObject thrownDice;

        instanciatedObject = (GameObject)Instantiate(diceBox, new Vector3(cameraPos.position.x, cameraPos.position.y - 6, cameraPos.position.z), Quaternion.identity);
        instanciatedObject.transform.parent = transform;

        switch (player.dangerLevel)
        {
            case ParcManager.Danger.Low:
                name = "dice_12";
                break;
            case ParcManager.Danger.Medium_low:
                name = "dice_10";
                break;
            case ParcManager.Danger.Medium:
                name = "dice_8";
                break;
            case ParcManager.Danger.Medium_high:
                name = "dice_6";
                break;
            default:
                name = "dice_4";
                break;
        }

        foreach (Transform child in instanciatedObject.transform)
            if (child.name == name)
            {
                thrownDice = child.gameObject;
                thrownDice.SetActive(true);
                diceScript = thrownDice.GetComponent<NewBehaviourScript>();
            }
            
        yield return new WaitWhile(() => diceScript.isMoving);
        diceResult = instanciatedObject.GetComponentInChildren<testTrigger>().getDiceResult();
       
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

    void Update()
    {
        if (!panelFound)
        {
            panel = GameObject.FindGameObjectWithTag("Panel");
            if (panel != null)
            {
                panelFound = true;
                panel.SetActive(false);
            }  
        }
    }

    /*public void faceUpBoothsUpdate(int nb)
    {
        List<int> getInfoFaceUpBooths;
        getInfoFaceUpBooths = BoothInfo.getFaceUpBooths(nb);
        for (int i=0; i < faceUpBooths.Count; i++)
        {
            faceUpBooths.Add(BoothInfo.boothsInfo(getInfoFaceUpBooths[i]));
        }
    }*/ 
}