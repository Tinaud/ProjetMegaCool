using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
    public bool isFinished;
    public int diceResult;

    private bool isSpinning;
    private Transform dice;
    
    void Awake()
    {
        dice = GetComponent<Transform>();
        isSpinning = true;
        isFinished = false;
        StartCoroutine(MyCoroutine());
    }

    void Update()
    {
        if (isSpinning)
            dice.Rotate(20 * Random.value, 20 * Random.value, 20 * Random.value);
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2F);
        isSpinning = false;

        diceResult = Random.Range(1, 7);

        switch (diceResult)
        {
            case 2:
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(80, 100), Random.Range(170, 190));
                break;
            case 3:
                dice.localEulerAngles = new Vector3(Random.Range(170, 190), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            case 4:
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            case 5:
                dice.localEulerAngles = new Vector3(Random.Range(-10, 10), Random.Range(265, 280), Random.Range(170, 190));
                break;
            case 6:
                dice.localEulerAngles = new Vector3(Random.Range(80, 100), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
            default:
                dice.localEulerAngles = new Vector3(Random.Range(265, 280), Random.Range(-10, 10), Random.Range(-10, 10));
                break;
        }

        yield return new WaitForSeconds(1f);
        isFinished = true;
        Destroy(this.gameObject);
    }
}