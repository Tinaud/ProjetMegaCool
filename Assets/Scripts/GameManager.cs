using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    enum Phase { Event, Income, Building, Breach, End };

    public GameObject prefab;

    private Dice diceScript;
    private Events eventManager;

    private GameObject intanciatedObject;
    private int activePlayer,
                actualPhase,
                playerNumber,
                nbTurns;
    private string currentEvent,
                   eventName,
                   eventBody;
    private Transform cameraPos, parent;

	void Start () 
    {
        actualPhase = (int)Phase.Breach;
        cameraPos = Camera.main.transform;
        eventManager = GetComponent<Events>();
        playerNumber = GetComponent<MenuPlayers>().NbPlayer;
        nbTurns = GetComponent<MenuPlayers>().NbTurns;
        parent = transform;
	}

	void Update () 
    {
	    switch(actualPhase)
        {
            case (int)Phase.Event:
                if(Input.GetKeyDown(KeyCode.A))
                {
                    currentEvent = eventManager.getEvent();
                    Debug.Log(currentEvent);
                }
                    
                break;
            case (int)Phase.Income:
                break;
            case (int)Phase.Building:
                break;

            case (int)Phase.Breach:
                if (Input.GetKeyDown(KeyCode.A))
                {
                    intanciatedObject = (GameObject)Instantiate(prefab, new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z + 10), Quaternion.identity);
                    intanciatedObject.transform.parent = parent;

                    diceScript = GetComponentInChildren<Dice>();
                    diceScript.ThrowDice();
                }
  
                break;

            case (int)Phase.End:
                break;
        }
	}
}