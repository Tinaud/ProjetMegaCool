using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour 
{
    private Transform dice;
    private bool isSpinning;
    private int patate;  //Random Number

    void Start()
    {
        dice = GetComponent<Transform>();
        isSpinning = false;
    }

    void Update()
    {
        if (isSpinning)
            dice.Rotate(20 * Random.value, 20 * Random.value, 20 * Random.value);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isSpinning)
                StopDice();
            else
                ThrowDice();
        }
    }

    IEnumerator MyCoroutine()
    {
        patate = Random.Range(1, 7);

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

    public void ThrowDice()
    {
        isSpinning = true;
    }

    public void StopDice()
    {
        isSpinning = false;
        StartCoroutine(MyCoroutine());
    }
}