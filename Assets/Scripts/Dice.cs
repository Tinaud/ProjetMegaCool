using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
    public bool isSpinning;
    public int diceResult;

    private int patate;  //Random Number
    private Transform dice;
    
    void Awake()
    {
        dice = GetComponent<Transform>();
        isSpinning = true;
        StartCoroutine(MyCoroutine());
    }

    void Update()
    {
        if (isSpinning)
            dice.Rotate(20 * Random.value, 20 * Random.value, 20 * Random.value);
    }

    IEnumerator MyCoroutine()
    {
        ThrowDice();
        yield return new WaitForSeconds(2F);
        StopDice();

        patate = Random.Range(1, 7);
        diceResult = patate;

        switch (patate)
        {
            case 2:
                Debug.Log("2");
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(80, 100), Random.Range(170, 190));
                break;
            case 3:
                Debug.Log("3");
                dice.localEulerAngles = new Vector3(Random.Range(170, 190), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            case 4:
                Debug.Log("4");
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            case 5:
                Debug.Log("5");
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(265, 280), Random.Range(170, 190));
                break;
            case 6:
                Debug.Log("6");
                dice.localEulerAngles = new Vector3(Random.Range(80, 100), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            default:
                Debug.Log("1");
                dice.localEulerAngles = new Vector3(Random.Range(265, 280), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
        }

        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }

    void ThrowDice()
    {
        isSpinning = true;
    }

    void StopDice()
    {
        isSpinning = false;
    }
}