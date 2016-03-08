using UnityEngine;
using System.Collections;

public class testTrigger : MonoBehaviour 
{
    private int diceResult;

    void OnTriggerEnter(Collider collider)
    {
        diceResult = int.Parse(collider.name);
    }

    public int getDiceResult()
    {
        return diceResult;
    }
}
