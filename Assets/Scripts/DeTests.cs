using UnityEngine;
using System.Collections;

public class DeTests : MonoBehaviour 
{
    private Transform Dice;
    private bool isSpinning;
    private int Number;

	void Start ()
    {
        Dice = GetComponent<Transform>();
        isSpinning = false;
	}

	void Update () 
    {
        if(isSpinning)
            Dice.Rotate(20*Random.value, 20*Random.value, 20*Random.value);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isSpinning)
            {
                isSpinning = false;
                Number = Random.Range(1, 7);

                switch (Number)
                {
                    case 2:
                        Debug.Log("2");
                        Dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(80, 100), Random.Range(170, 190));
                        break;
                    case 3:
                        Debug.Log("3");
                        Dice.localEulerAngles = new Vector3(Random.Range(170, 190), Random.Range(-10, 10), Random.Range(-10, 10));
                        break;
                    case 4:
                        Debug.Log("4");
                        Dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
                        break;
                    case 5:
                        Debug.Log("5");
                        Dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(265, 280), Random.Range(170, 190));
                        break;
                    case 6:
                        Debug.Log("6");
                        Dice.localEulerAngles = new Vector3(Random.Range(80, 100), Random.Range(-10, 10), Random.Range(-10, 10));
                        break;
                    default:
                        Debug.Log("1");
                        Dice.localEulerAngles = new Vector3(Random.Range(265, 280), Random.Range(-10, 10), Random.Range(-10, 10));
                        break;
                }
            }
            
            else
                ThrowDice();
        }
	}

    public void ThrowDice()
    {
        isSpinning = true;
    }
}
